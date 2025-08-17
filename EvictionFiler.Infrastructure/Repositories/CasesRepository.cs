using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
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


		public async Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize)
		{
			var query = _context.LegalCases.AsNoTracking()
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
				});

			var totalCount = await query.CountAsync();
			var items = await query
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
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
