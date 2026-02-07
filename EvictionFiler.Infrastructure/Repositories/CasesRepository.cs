using EvictionFiler.Application;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.MasterDtos.HarassmentTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CasesRepository : Repository<LegalCase>, ICasesRepository
	{
        private readonly MainDbContext _context;
        private readonly IUserRepository _userRepo;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CasesRepository(MainDbContext context , IUserRepository userRepo,IDbContextFactory<MainDbContext>contextFactory) : base(context, contextFactory)
		{
            _context = context;
            _userRepo = userRepo;
            this.contextFactory = contextFactory;
        }


        public async Task<List<IntakeModel>> SearchCasebyCode(string code)
        {
            await using var db = await contextFactory.CreateDbContextAsync();
            var cases = await db.LegalCases.Where(e => e.Casecode.Contains(code)).Select(dto => new IntakeModel
            {

                Casecode = dto.Casecode,
              

            }).ToListAsync();
            if (cases == null)
                return new List<IntakeModel>();
            return cases;
        }

        public async Task<Guid?> UpdateCaseLandlord(IntakeModel casedetails)
        {
            await using var db = await contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.BuildingId = casedetails.BuildingId;

            

            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;

            
        }
        public async Task<Guid?> UpdateCaseTenant(IntakeModel casedetails)
        {

            await using var db = await contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.TenantId = casedetails.TenantId;

            
            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;

        }
        public async Task<Guid?> UpdateCaseCourt(IntakeModel casedetails)
        {
            await using var db = await contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.CourtLocationId = casedetails.CourtLocationId;

            existingCase.CourtPartId = casedetails.CourtPartId;
            existingCase.CourtTypeId = casedetails.CourtTypeId;
            existingCase.CourtId = casedetails.CourtId;

            db.LegalCases.Update(existingCase);

            var result =await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;
        }
        public async Task<Guid?> UpdateCaseBuilding(IntakeModel casedetails)
        {
            await using var db = await contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.BuildingId = casedetails.BuildingId;


            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;
        }
        public async Task<Guid?> UpdateClient(IntakeModel casedetails)
        {
            await using var db = await contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.ClientId = casedetails.ClientId;

            
            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;
        }
        public async Task<int> GetTotalCasesCountAsync(string userId , bool isAdmin)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (isAdmin)
            {
                var today = DateTime.Today;
                var startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1); // Monday
                var endOfWeek = startOfWeek.AddDays(7);

                var count = await db.LegalCases
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

                var count = await db.LegalCases
                    .Where(e => e.CreatedOn >= startOfWeek && e.CreatedOn < endOfWeek && e.CreatedBy == userGuid)
                    .CountAsync();
                return count;

            }
        }
        public async Task<int> GetActiveCasesCountAsync(string userId, bool isAdmin)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (isAdmin)
            {
               
                return await db.LegalCases
                                     .Where(c => c.IsActive)
                                     .CountAsync();
            }
            else
            {
                var userGuid = Guid.Parse(userId);
                return await db.LegalCases
                                     .Where(c => c.IsActive && c.CreatedBy == userGuid) 
                                     .CountAsync();
            }
        }


        public async Task<List<LegalCase>> GetTodayCasesAsync()
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            var today = DateTime.Today;
            var query = db.LegalCases
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

        public async Task<bool> UpdateMarshal(IntakeModel legalCase)
        {
            await using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                var existingCase = await db.LegalCases.FindAsync(legalCase.Id);
                if (existingCase == null) return false;

                existingCase.MarshalId = legalCase.MarshalId!;

                var result = await db.SaveChangesAsync();

                if (result > 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public async Task<List<LegalCase>> GetAllCasesAsync()
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            var query = db.LegalCases
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
            await using var db = await contextFactory.CreateDbContextAsync();

            IQueryable<LegalCase> query = db.LegalCases
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
                    query = query.Where(c => c.CreatedBy == gid);
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
                    c.Casecode.StartsWith(f, StringComparison.OrdinalIgnoreCase));
            }

            // CLIENT
            if (!string.IsNullOrWhiteSpace(filters.Client))
            {
                string f = filters.Client;
                query = query.Where(c =>
                    c.Clients != null &&
                    (
                        (c.Clients.ClientCode != null &&
                            c.Clients.ClientCode.StartsWith(f, StringComparison.OrdinalIgnoreCase))
                        ||
                        ((c.Clients.FirstName + " " + c.Clients.LastName)
                            .StartsWith(f, StringComparison.OrdinalIgnoreCase))
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
                            c.Tenants.TenantCode.StartsWith(f, StringComparison.OrdinalIgnoreCase))
                        ||
                        ((c.Tenants.FirstName + " " + c.Tenants.LastName)
                            .StartsWith(f, StringComparison.OrdinalIgnoreCase))
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
                            c.LandLords.LandLordCode.StartsWith(f, StringComparison.OrdinalIgnoreCase))
                        ||
                        ((c.LandLords.FirstName + " " + c.LandLords.LastName)
                            .StartsWith(f, StringComparison.OrdinalIgnoreCase))
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
                    x.ReasonHoldover.Name.StartsWith(f, StringComparison.OrdinalIgnoreCase));
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
            await using var db = await contextFactory.CreateDbContextAsync();

            var lastCase = await db.LegalCases
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
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<CaseTypeHPD>();

            return await db.MstCaseTypesHPD
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<CaseTypePerdiem>> GetCaseTypePerDiemByIdsAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<CaseTypePerdiem>();

            return await db.MstCaseTypePerdiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        

        public async Task<List<HarassmentType>> GetHarassmentTypeIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<HarassmentType>();

            return await db.MstHarassmentTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<DefenseType>> GetDefenseTypeIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<DefenseType>();

            return await db.MstDefenseTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }
        public async Task<List<AppearanceType>> GetApperenceTypeIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<AppearanceType>();

            return await db.MstAppearanceTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<AppearanceTypePerDiem>> GetApperenceTypePerDiemIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<AppearanceTypePerDiem>();

            return await db.MstAppearanceTypesPerDiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<DocumentTypePerDiem>> GetDocumentIntructionsTypsIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<DocumentTypePerDiem>();

            return await db.MstDocumentTypePerDiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<ReportingTypePerDiem>> GetReportingTypePerDiemsIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<ReportingTypePerDiem>();

            return await db.MstReportingTypePerDiems
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<ReliefPetitionerType>> GetReliefPetitionerTypesListTypeIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<ReliefPetitionerType>();

            return await db.MstReliefPetitionerTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<ReliefRespondentType>> GetReliefRespondentTypesListTypeIdAsync(List<Guid> ids)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            if (ids == null || !ids.Any())
                return new List<ReliefRespondentType>();

            return await db.MstReliefRespondentTypes
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task<List<LegalCase>> GetAlllAsync(Expression<Func<LegalCase, bool>>? predicate = null, params Expression<Func<LegalCase, object>>[]? includes)
        {
            await using var db =await  contextFactory.CreateDbContextAsync();

            IQueryable<LegalCase> query = db.Set<LegalCase>();
            //var query = _dbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }
            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.AsNoTracking().ToListAsync();
        }

    }
}
