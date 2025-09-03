using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
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

        public CasesRepository(MainDbContext context) : base(context)
		{
            _context = context;
        }

        public async Task<int> GetTotalCasesCountAsync()
        {
            return await _context.LegalCases.CountAsync();
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

        public async Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize, CaseFilterDto filters)
        {
            var query = _context.LegalCases
                .AsNoTracking();

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
                    ReasonHoldover = c.ReasonHoldover,
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
