using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.MasterDtos.HarassmentTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CasesRepository : Repository<LegalCase>, ICasesRepository
	{
        private readonly MainDbContext _context;
        private readonly IUserRepository _userRepo;

        public CasesRepository(MainDbContext context , IUserRepository userRepo) : base(context)
		{
            _context = context;
            _userRepo = userRepo;
        }


        public async Task<List<IntakeModel>> SearchCasebyCode(string code)
        {
            var cases = await _context.LegalCases.Where(e => e.Casecode.Contains(code)).Select(dto => new IntakeModel
            {

                Casecode = dto.Casecode,
              

            }).ToListAsync();
            if (cases == null)
                return new List<IntakeModel>();
            return cases;
        }

        public async Task<int> GetTotalCasesCountAsync(string userId , bool isAdmin)
        {
            if (isAdmin)
            {
                var today = DateTime.Today;
                var startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1); // Monday
                var endOfWeek = startOfWeek.AddDays(7);

                var count = await _context.LegalCases
                    .Where(e => e.CreatedOn >= startOfWeek && e.CreatedOn < endOfWeek)
                    .CountAsync();

                return count;
            }
            else
            {
              
                var userGuid = Guid.Parse(userId);
                
                var today = DateTime.Today;
                var startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1); // Monday
                var endOfWeek = startOfWeek.AddDays(7);

                var count = await _context.LegalCases.Include(e=>e.User)
                    .Where(e => e.CreatedOn >= startOfWeek && e.CreatedOn < endOfWeek && e.User.FirmId == userGuid)
                    .CountAsync();
                return count;

            }
        }
        public async Task<int> GetActiveCasesCountAsync(string userId, bool isAdmin)
        {
            if (isAdmin)
            {
               
                return await _context.LegalCases
                                     .Where(c => c.IsActive)
                                     .CountAsync();
            }
            else
            {
                var userGuid = Guid.Parse(userId);
                return await _context.LegalCases
                                     .Where(c => c.IsActive && c.CreatedBy == userGuid) 
                                     .CountAsync();
            }
        }
        //public async Task<List<PipeLineChartItem>> GetPipelineChartDataAsync(string userId, bool isAdmin)
        //{
        //    var query = _context.LegalCases.Include(e=>e.CaseType)
        //        .Where(c => c.IsActive);

        //    if (!isAdmin)
        //    {
        //        var userGuid = Guid.Parse(userId);
        //        query = query.Where(c => c.CreatedBy == userGuid);
        //    }

        //    return await query
        //        .GroupBy(c => new { c.CreatedOn.Year, c.CreatedOn.Month })
        //        .Select(g => new PipeLineChartItem
        //        {
        //            Month = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMM"),
        //            NonPayment = g.Count(x => x.CaseType.Name.ToLower() == "nonpayment"),
        //            Holdover = g.Count(x => x.CaseType.Name.ToLower() == "holdover"),
        //            Other = g.Count(x => x.CaseType.Name.ToLower() != "nonpayment" && x.CaseType.Name.ToLower() != "holdover")
        //        })
        //        .OrderBy(x => DateTime.ParseExact(x.Month, "MMM", null).Month)
        //        .ToListAsync();
        //}

        public async Task<List<PipeLineChartItem>> GetPipelineChartDataAsync(string userId, bool isAdmin)
        {
            var query = _context.LegalCases
                .Include(e => e.CaseType).Include(e=>e.User)
                .Where(c => c.IsActive);

            if (!isAdmin)
            {
                var userGuid = Guid.Parse(userId);
                query = query.Where(c => c.User.FirmId == userGuid);
            }

            // 1️⃣ RAW SQL-safe query
            var raw = await query
                .GroupBy(c => new { c.CreatedOn.Year, c.CreatedOn.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    NonPayment = g.Count(x => x.CaseType.Name == "NonPayment"),
                    Holdover = g.Count(x => x.CaseType.Name == "Holdover"),
                    Other = g.Count(x => x.CaseType.Name != "NonPayment" &&
                                         x.CaseType.Name != "Holdover")
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            // 2️⃣ Project to your DTO in C#
            return raw
                .Select(x => new PipeLineChartItem
                {
                    Month = new DateTime(x.Year, x.Month, 1).ToString("MMM"),
                    NonPayment = x.NonPayment,
                    Holdover = x.Holdover,
                    Other = x.Other
                })
                .ToList();
        }


        public async Task<List<LegalCase>> GetTodayCasesAsync()
        {

            var today = DateTime.Today;
            var query = _context.LegalCases
        .AsNoTracking()
        .Where(c => c.CreatedOn.Date == today);


            var items = await query
                .OrderByDescending(c => c.CreatedOn)

                .Select(c => new LegalCase
                {
                    Id = c.Id,
                    Casecode = c.Casecode,
                    CreatedOn = c.CreatedOn,
                    CreatedBy = c.CreatedBy,
                    ReasonHoldover = c.ReasonHoldover,
                    CaseType = c.CaseType != null ? new CaseType
                    {
                        Name = c.CaseType.Name
                    } : new CaseType(),
                    Clients = c.Clients != null ? new Client
                    {
                        FirstName = c.Clients.FirstName,
                        LastName = c.Clients.LastName,
                        ClientCode = c.Clients.ClientCode
                    } : new Client(),
                    LandLords = c.LandLords != null ? new LandLord
                    {
                        FirstName = c.LandLords.FirstName,
                        LastName = c.LandLords.LastName,
                        LandLordCode = c.LandLords.LandLordCode
                    } : new LandLord(),
                    Buildings = c.Buildings != null ? new Building
                    {
                        BuildingCode = c.Buildings.BuildingCode
                    } : new Building(),
                    RegulationStatus = c.RegulationStatus != null ? new RegulationStatus
                    {
                        Name = c.RegulationStatus.Name,

                    } : new RegulationStatus(),

                    LandlordType = c.LandlordType != null ? new LandlordType
                    {
                        Name = c.LandlordType.Name,

                    } : new LandlordType(),
                    Tenants = c.Tenants != null ? new Tenant
                    {
                        TenantCode = c.Tenants.TenantCode,
                        FirstName = c.Tenants.FirstName,
                        LastName = c.Tenants.LastName
                    } : new Tenant()
                })
                .ToListAsync();
            return items;

        }

        public async Task<List<LegalCase>> GetAllCasesAsync()
        {
            var query = _context.LegalCases
                .AsNoTracking();


            var items = await query
                .OrderByDescending(c => c.CreatedOn)
              
                .Select(c => new LegalCase
                {
                    Id = c.Id,
                    Casecode = c.Casecode,
                    CreatedOn = c.CreatedOn,
                    CreatedBy = c.CreatedBy,
                    ReasonHoldover = c.ReasonHoldover,
                    TenantName = c.TenantName,
                    CaseType = c.CaseType != null ? new CaseType
                    {
                        Name = c.CaseType.Name
                    } : new CaseType(),
                    Clients = c.Clients != null ? new Client
                    {
                        FirstName = c.Clients.FirstName,
                        LastName = c.Clients.LastName,
                        ClientCode = c.Clients.ClientCode
                    } : new Client(),
                    LandLords = c.LandLords != null ? new LandLord
                    {
                        FirstName = c.LandLords.FirstName,
                        LastName = c.LandLords.LastName,
                        LandLordCode = c.LandLords.LandLordCode
                    } : new LandLord(),
                    Buildings = c.Buildings != null ? new Building
                    {
                        BuildingCode = c.Buildings.BuildingCode
                    } : new Building(),
                    RegulationStatus = c.RegulationStatus != null ? new RegulationStatus
                    {
                        Name = c.RegulationStatus.Name,
                       
                    } : new RegulationStatus(),

                    LandlordType = c.LandlordType != null ? new LandlordType
                    {
                        Name = c.LandlordType.Name,

                    } : new LandlordType(),
                    Tenants = c.Tenants != null ? new Tenant
                       {
                           TenantCode = c.Tenants.TenantCode,
                           FirstName = c.Tenants.FirstName,
                           LastName = c.Tenants.LastName
                       } : new Tenant()
                })
                .ToListAsync();
            return items;
           
        }

        //public async Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize, CaseFilterDto filters, string userId,bool isAdmin)
        //{
        //    var query = _context.LegalCases
        //        .AsNoTracking();
        //    var users = await _userRepo.GetAllUser();
        //    var userDict = users.ToDictionary(u => u.Id, u => $"{u.FirstName} {u.MiddleName} {u.LastName}");

        //    if (!isAdmin)
        //    {
        //        query = query.Where(c => c.IsActive == true && c.IsDeleted == false);

        //        // ✅ Non-admin → Sirf apne hi clients dekhe
        //        if (!string.IsNullOrWhiteSpace(userId))
        //        {
        //            var userGuid = Guid.Parse(userId);
        //            query = query.Where(c => c.CreatedBy == userGuid);
        //        }
        //    }
        //    else
        //    {
        //        // ✅ Admin → Saare clients dikhenge, deleted + inactive bhi
        //        query = query.OrderByDescending(c => c.CreatedOn);
        //    }

        //    // ✅ CaseCode filter
        //    if (!string.IsNullOrWhiteSpace(filters.CaseCode))
        //    {
        //        var caseCode = filters.CaseCode.ToLower();
        //        query = query.Where(c => (c.Casecode ?? "").ToLower().StartsWith(caseCode));
        //    }

        //    if (!string.IsNullOrWhiteSpace(filters.Client))
        //    {
        //        var clientFilter = filters.Client.ToLower();
        //        query = query.Where(c =>
        //            c.Clients != null &&
        //            (
        //                (c.Clients.ClientCode ?? "").ToLower().StartsWith(clientFilter) ||
        //                (((c.Clients.FirstName ?? "") + " " + (c.Clients.LastName ?? "")).ToLower().StartsWith(clientFilter))
        //            )
        //        );
        //    }


        //    // ✅ Tenant filter
        //    if (!string.IsNullOrWhiteSpace(filters.Tenant))
        //    {
        //        var tenantFilter = filters.Tenant.ToLower();
        //        query = query.Where(c =>
        //            (c.Tenants != null &&
        //                (
        //                    (c.Tenants.TenantCode ?? "").ToLower().StartsWith(tenantFilter) ||
        //                    ((c.Tenants.FirstName ?? "") + " " + (c.Tenants.LastName ?? ""))
        //                        .ToLower()
        //                        .StartsWith(tenantFilter)
        //                )
        //            )
        //        );
        //    }

        //    if (!string.IsNullOrWhiteSpace(filters.LandLord))
        //    {
        //        var landlordFilter = filters.LandLord.ToLower();
        //        query = query.Where(c =>
        //            (c.Tenants != null &&
        //                (
        //                    (c.LandLords.LandLordCode ?? "").ToLower().StartsWith(landlordFilter) ||
        //                    ((c.LandLords.FirstName ?? "") + " " + (c.LandLords.LastName ?? ""))
        //                        .ToLower()
        //                        .StartsWith(landlordFilter)
        //                )
        //            )
        //        );
        //    }
        //    //if (!string.IsNullOrWhiteSpace(filters.CaseType))
        //    //    query = query.Where(x => (x.CaseType.Name ?? "").ToLower().StartsWith(filters.CaseType.ToLower()));
        //    if (filters.CaseTypeId.HasValue && filters.CaseTypeId != Guid.Empty)
        //    {
        //        query = query.Where(x => x.CaseTypeId == filters.CaseTypeId);
        //    }


        //    if (!string.IsNullOrWhiteSpace(filters.ReasonHoldover))
        //        query = query.Where(x => (x.ReasonHoldover.Name ?? "").ToLower().StartsWith(filters.ReasonHoldover.ToLower()));

        //    if (!string.IsNullOrWhiteSpace(filters.ActionDate) && DateTime.TryParse(filters.ActionDate, out var parsedDate))
        //        query = query.Where(x => x.CreatedOn.Date == parsedDate.Date);

        //    if (!string.IsNullOrWhiteSpace(filters.Status))
        //    {
        //        query = query.Where(x =>
        //            (x.IsActive ? "active" : "inactive").ToLower().StartsWith(filters.Status.ToLower())
        //        );
        //    }



        //    var totalCount = await query.CountAsync();


        //    var items = await query
        //        .OrderByDescending(c => c.CreatedOn)
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .Select(c => new LegalCase
        //        {
        //            Id = c.Id,
        //            Casecode = c.Casecode,
        //            CreatedOn = c.CreatedOn,
        //            IsActive = c.IsActive,  
        //            IsDeleted = c.IsDeleted,
        //            CaseType = c.CaseType,
        //            ReasonHoldover = c.ReasonHoldover,
        //            CreatedBy = c.CreatedBy,
        //            TenantName = c.TenantName,
        //            CreatedByName = userDict.ContainsKey(c.CreatedBy)
        //                    ? userDict[c.CreatedBy]
        //                    : "Admin",
        //            Clients = c.Clients != null ? new Client
        //            {
        //                FirstName = c.Clients.FirstName,
        //                LastName = c.Clients.LastName,
        //                ClientCode = c.Clients.ClientCode
        //            } : new Client(),
        //            LandLords = c.LandLords != null ? new LandLord
        //            {
        //                FirstName = c.LandLords.FirstName,
        //                LastName = c.LandLords.LastName,
        //                LandLordCode = c.LandLords.LandLordCode
        //            } : new LandLord(),
        //            Buildings = c.Buildings != null ? new Building
        //            {
        //                BuildingCode = c.Buildings.BuildingCode
        //            } : new Building(),
        //            Tenants = c.Tenants != null ? new Tenant
        //            {
        //                TenantCode = c.Tenants.TenantCode,
        //                FirstName = c.Tenants.FirstName,
        //                LastName = c.Tenants.LastName
        //            } : new Tenant()
        //        })
        //        .ToListAsync();

        //    return new PaginationDto<LegalCase>
        //    {
        //        Items = items,
        //        TotalCount = totalCount,
        //        PageSize = pageSize,
        //        CurrentPage = pageNumber
        //    };
        //}
        public async Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize, CaseFilterDto filters, string userId, bool isAdmin)
        {
            IQueryable<LegalCase> query = _context.LegalCases
                .AsNoTracking();

            // Preload users ONCE
            var users = await _userRepo.GetAllUser();
            var userDict = users.ToDictionary(
                u => u.Id,
                u => $"{u.FirstName} {u.MiddleName} {u.LastName}".Trim());

            /* ---------------------------------------------------
               ADMIN + USER FILTERING
            --------------------------------------------------- */
            if (!isAdmin)
            {
                query = query.Where(c => c.IsActive == true && c.IsDeleted != true);

                if (!string.IsNullOrWhiteSpace(userId) &&
                    Guid.TryParse(userId, out Guid gid))
                {
                    query = query.Where(c => c.User.FirmId == gid);
                }
            }

            /* ---------------------------------------------------
               FILTERS — SQL Server Optimized
            --------------------------------------------------- */

            // CASE CODE
            if (!string.IsNullOrWhiteSpace(filters.CaseCode))
            {
                string f = filters.CaseCode;
                query = query.Where(c =>
                    c.Casecode != null &&
                    c.Casecode.ToLower().StartsWith(f));
            }

            // CLIENT
            if (!string.IsNullOrWhiteSpace(filters.Client))
            {
                string f = filters.Client;
                query = query.Where(c =>
                    c.Clients != null &&
                    (
                        (c.Clients.ClientCode != null &&
                            c.Clients.ClientCode.ToLower().StartsWith(f))
                        ||
                        ((c.Clients.FirstName + " " + c.Clients.LastName)
                        .ToLower()
                         .StartsWith(f))
                    ));
            }

            // TENANT
            if (!string.IsNullOrWhiteSpace(filters.Tenant))
            {
                string f = filters.Tenant;
                query = query.Where(c =>
                    c.Tenants != null &&
                    (
                        (c.Tenants.TenantCode != null &&
                            c.Tenants.TenantCode.ToLower().StartsWith(f))
                        ||
                        ((c.Tenants.FirstName + " " + c.Tenants.LastName)
                        .ToLower()
                            .StartsWith(f))
                    ));
            }

            // LANDLORD  (FIXED BUG)
            if (!string.IsNullOrWhiteSpace(filters.LandLord))
            {
                string f = filters.LandLord;
                query = query.Where(c =>
                    c.LandLords != null &&
                    (
                        (c.LandLords.LandLordCode != null &&
                            c.LandLords.LandLordCode.ToLower().StartsWith(f))
                        ||
                        ((c.LandLords.FirstName + " " + c.LandLords.LastName)
                        .ToLower()
                            .StartsWith(f))
                    ));
            }

            // CASE TYPE
            if (filters.CaseTypeId.HasValue && filters.CaseTypeId != Guid.Empty)
            {
                query = query.Where(x => x.CaseTypeId == filters.CaseTypeId);
            }

            // REASON HOLDOVER
            if (!string.IsNullOrWhiteSpace(filters.ReasonHoldover))
            {
                string f = filters.ReasonHoldover;
                query = query.Where(x =>
                    x.ReasonHoldover != null &&
                    x.ReasonHoldover.Name.ToLower().StartsWith(f));
            }

            // ACTION DATE
            if (!string.IsNullOrWhiteSpace(filters.ActionDate) &&
                DateTime.TryParse(filters.ActionDate, out DateTime parsedDate))
            {
                query = query.Where(x => x.CreatedOn.Date == parsedDate.Date);
            }

            // STATUS
            if (!string.IsNullOrWhiteSpace(filters.Status))
            {
                var status = filters.Status.ToLower();

                if (status.StartsWith("active"))
                {
                    query = query.Where(x => x.IsActive == true && x.IsDeleted != true);
                }
                else if (status.StartsWith("inactive"))
                {
                    query = query.Where(x => x.IsActive == false && x.IsDeleted == true);
                }
            }
            // Firms
            if (filters.FirmId != null && filters.FirmId != Guid.Empty)
            {
               
                 query = query.Where(x => x.CreatedBy == filters.FirmId);
                
            }

            /* ---------------------------------------------------
               PAGING
            --------------------------------------------------- */
            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CreatedOn)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new LegalCase
                {
                    Id = c.Id,
                    Casecode = c.Casecode,
                    CreatedOn = c.CreatedOn,
                    IsActive = c.IsActive,
                    IsDeleted = c.IsDeleted,
                    CaseType = c.CaseType,
                    ReasonHoldover = c.ReasonHoldover,
                    CreatedBy = c.CreatedBy,
                    TenantName = c.TenantName,

                    CreatedByName = userDict.ContainsKey(c.CreatedBy)
                            ? userDict[c.CreatedBy]
                            : "Admin",

                    Clients = c.Clients,
                    LandLords = c.LandLords,
                    Buildings = c.Buildings,
                    Tenants = c.Tenants
                })
                .ToListAsync();

            return new PaginationDto<LegalCase>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }


        public async Task<string> GenerateCaseCodeAsync()
		{
			var lastCase = await _context.LegalCases
				.OrderByDescending(c => c.Casecode)
				.Select(c => c.Casecode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("EF"))
			{
				string numberPart = lastCase.Substring(2);
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			string newCode = "EF" + nextNumber.ToString("D10");
			return newCode;
		}

        public async Task<List<CaseTypeHPD>> GetHPDByIdsAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<CaseTypeHPD>();

            return await _context.MstCaseTypesHPD
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<CaseTypePerdiem>> GetCaseTypePerDiemByIdsAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<CaseTypePerdiem>();

            return await _context.MstCaseTypePerdiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        

        public async Task<List<HarassmentType>> GetHarassmentTypeIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<HarassmentType>();

            return await _context.MstHarassmentTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<DefenseType>> GetDefenseTypeIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<DefenseType>();

            return await _context.MstDefenseTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }
        public async Task<List<AppearanceType>> GetApperenceTypeIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<AppearanceType>();

            return await _context.MstAppearanceTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<AppearanceTypePerDiem>> GetApperenceTypePerDiemIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<AppearanceTypePerDiem>();

            return await _context.MstAppearanceTypesPerDiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<DocumentTypePerDiem>> GetDocumentIntructionsTypsIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<DocumentTypePerDiem>();

            return await _context.MstDocumentTypePerDiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<ReportingTypePerDiem>> GetReportingTypePerDiemsIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<ReportingTypePerDiem>();

            return await _context.MstReportingTypePerDiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<ReliefPetitionerType>> GetReliefPetitionerTypesListTypeIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<ReliefPetitionerType>();

            return await _context.MstReliefPetitionerTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<ReliefRespondentType>> GetReliefRespondentTypesListTypeIdAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<ReliefRespondentType>();

            return await _context.MstReliefRespondentTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }



    }
}
