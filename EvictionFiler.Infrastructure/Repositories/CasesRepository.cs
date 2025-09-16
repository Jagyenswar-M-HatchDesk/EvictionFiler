using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
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

        public async Task<int> GetTotalCasesCountAsync(string userId , bool isAdmin)
        {
            if (isAdmin)
            {
                
                return await _context.LegalCases.CountAsync();
            }
            else
            {
              
                var userGuid = Guid.Parse(userId);
                return await _context.LegalCases
                                     .Where(c => c.CreatedBy == userGuid) 
                                     .CountAsync();
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

        public async Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize, CaseFilterDto filters, string userId,bool isAdmin)
        {
            var query = _context.LegalCases
                .AsNoTracking();
            var users = await _userRepo.GetAllUser();
            var userDict = users.ToDictionary(u => u.Id, u => $"{u.FirstName} {u.MiddleName} {u.LastName}");

            if (!isAdmin)
            {
                query = query.Where(c => c.IsActive == true && c.IsDeleted == false);

                // ✅ Non-admin → Sirf apne hi clients dekhe
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var userGuid = Guid.Parse(userId);
                    query = query.Where(c => c.CreatedBy == userGuid);
                }
            }
            else
            {
                // ✅ Admin → Saare clients dikhenge, deleted + inactive bhi
                query = query.OrderByDescending(c => c.CreatedOn);
            }

            // ✅ CaseCode filter
            if (!string.IsNullOrWhiteSpace(filters.CaseCode))
            {
                var caseCode = filters.CaseCode.ToLower();
                query = query.Where(c => (c.Casecode ?? "").ToLower().StartsWith(caseCode));
            }

            if (!string.IsNullOrWhiteSpace(filters.Client))
            {
                var clientFilter = filters.Client.ToLower();
                query = query.Where(c =>
                    c.Clients != null &&
                    (
                        (c.Clients.ClientCode ?? "").ToLower().StartsWith(clientFilter) ||
                        (((c.Clients.FirstName ?? "") + " " + (c.Clients.LastName ?? "")).ToLower().StartsWith(clientFilter))
                    )
                );
            }


            // ✅ Tenant filter
            if (!string.IsNullOrWhiteSpace(filters.Tenant))
            {
                var tenantFilter = filters.Tenant.ToLower();
                query = query.Where(c =>
                    (c.Tenants != null &&
                        (
                            (c.Tenants.TenantCode ?? "").ToLower().StartsWith(tenantFilter) ||
                            ((c.Tenants.FirstName ?? "") + " " + (c.Tenants.LastName ?? ""))
                                .ToLower()
                                .StartsWith(tenantFilter)
                        )
                    )
                );
            }

            if (!string.IsNullOrWhiteSpace(filters.LandLord))
            {
                var landlordFilter = filters.LandLord.ToLower();
                query = query.Where(c =>
                    (c.Tenants != null &&
                        (
                            (c.LandLords.LandLordCode ?? "").ToLower().StartsWith(landlordFilter) ||
                            ((c.LandLords.FirstName ?? "") + " " + (c.LandLords.LastName ?? ""))
                                .ToLower()
                                .StartsWith(landlordFilter)
                        )
                    )
                );
            }
            if (!string.IsNullOrWhiteSpace(filters.CaseType))
                query = query.Where(x => (x.CaseType.Name ?? "").ToLower().StartsWith(filters.CaseType.ToLower()));

            if (!string.IsNullOrWhiteSpace(filters.ReasonHoldover))
                query = query.Where(x => (x.ReasonHoldover.Name ?? "").ToLower().StartsWith(filters.ReasonHoldover.ToLower()));

            if (!string.IsNullOrWhiteSpace(filters.ActionDate) && DateTime.TryParse(filters.ActionDate, out var parsedDate))
                query = query.Where(x => x.CreatedOn.Date == parsedDate.Date);

            if (!string.IsNullOrWhiteSpace(filters.Status))
            {
                query = query.Where(x =>
                    (x.IsActive ? "active" : "inactive").ToLower().StartsWith(filters.Status.ToLower())
                );
            }



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
                    CreatedByName = userDict.ContainsKey(c.CreatedBy)
                            ? userDict[c.CreatedBy]
                            : "Admin",
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
                    Tenants = c.Tenants != null ? new Tenant
                    {
                        TenantCode = c.Tenants.TenantCode,
                        FirstName = c.Tenants.FirstName,
                        LastName = c.Tenants.LastName
                    } : new Tenant()
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

	}
}
