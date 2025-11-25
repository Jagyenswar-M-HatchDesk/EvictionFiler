using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Linq;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class TenantRepository : Repository<Tenant>, ITenantRepository
	{
		private readonly MainDbContext _dbContext;
		public TenantRepository(MainDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<string> GenerateTenantCodeAsync()
		{
			var lastCase = await _dbContext.Tenants
				.OrderByDescending(c => c.TenantCode)
				.Select(c => c.TenantCode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("TT"))
			{
				string numberPart = lastCase.Substring(2);
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			string newCode = "TT" + nextNumber.ToString("D10");
			return newCode;
		}

		public async Task<string?> GetLasttenantCodeAsync()
		{
			return await _dbContext.Tenants
				.OrderByDescending(l => l.TenantCode)
				.Select(l => l.TenantCode)
				.FirstOrDefaultAsync();
		}

		public async Task<List<CreateToTenantDto>> SearchTenantByCode(string code)
		{
			var tenant = await _dbContext.Tenants.Where(e => e.TenantCode.Contains(code)).Select(dto => new CreateToTenantDto
			{

				TenantCode = dto.TenantCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,

				SSN = dto.SSN,
				Phone = dto.Phone,
				Email = dto.Email,
				LanguageId = dto.LanguageId,



				HasPossession = dto.HasPossession,
				HasRegulatedTenancy = dto.HasRegulatedTenancy,
				//Name_Relation = dto.Name_Relation,
				OtherOccupants = dto.OtherOccupants,

				TenantRecord = dto.TenantRecord,
				HasPriorCase = dto.HasPriorCase,
				BuildingId = dto.BuildinId

			}).ToListAsync();
			if (tenant == null)
				return new List<CreateToTenantDto>();
			return tenant;
		}

        public async Task<List<EditToTenantDto>> SearchTenantAsync(string query, Guid clientId)
        {
            query = query?.Trim().ToLower() ?? "";

            // 1️⃣ Get all BuildingIds for the selected Client
            var buildingIds = await _dbContext.Buildings
                .Where(b => b.Landlord.ClientId == clientId)
                .Select(b => b.Id)
                .ToListAsync();

            // 2️⃣ Now search tenant under those buildings
            var tenants = await _dbContext.Tenants
                .Where(t =>
                    buildingIds.Contains(t.BuildinId.Value) &&
                    t.IsDeleted != true &&
                    (
                        t.TenantCode.ToLower().Contains(query) ||
                        (t.FirstName + " " + t.LastName).ToLower().StartsWith(query) ||
                        t.UnitOrApartmentNumber.ToLower().StartsWith(query)
                    )
                )
                .Select(dto => new EditToTenantDto
                {
                    Id = dto.Id,
                    TenantCode = dto.TenantCode,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                })
                .ToListAsync();

            return tenants;
        }



       

        public async Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId)
        {
            // 1️⃣ Get BuildingIds for the selected Client
            var buildingIds = await _dbContext.Buildings
                .Where(b => b.Landlord.ClientId == clientId)
                .Select(b => b.Id)
                .ToListAsync();

            // 2️⃣ Get Tenants under those buildings
            var tenants = await _dbContext.Tenants
                .Where(t =>
                    t.IsDeleted != true &&
                    t.BuildinId != null &&
                    buildingIds.Contains(t.BuildinId.Value)
                )
                .Select(t => new EditToTenantDto
                {
                    Id = t.Id,
                    TenantCode = t.TenantCode,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                })
                .ToListAsync();

            return tenants;
        }



        public async Task<List<Language>> GetAllLanguage()
		{
			return await _dbContext.MstLanguages.ToListAsync();
		}

        public async Task<(EditToLandlordDto landlord, EditToBuildingDto building)>
GetLandlordBuildingByTenantAsync(Guid tenantId)
        {
            var data = await _dbContext.Tenants
                .Where(t => t.Id == tenantId)
                .Select(t => new
                {
                    Landlord = new EditToLandlordDto
                    {
                        Id = t.Building.Landlord.Id,
                        FirstName = t.Building.Landlord.FirstName,
                        LastName = t.Building.Landlord.LastName,
                        LandLordCode = t.Building.Landlord.LandLordCode
                    },
                    Building = new EditToBuildingDto
                    {
                        Id = t.Building.Id,
                        BuildingCode = t.Building.BuildingCode,
                        BuildingUnits = t.Building.BuildingUnits,
                        Address1 = t.Building.Address1,
                        PremiseTypeId = t.Building.PremiseTypeId,
                        RegistrationStatusId = t.Building.RegistrationStatusId,
                    }
                })
                .FirstOrDefaultAsync();

            return (data.Landlord, data.Building);
        }

        public async Task<List<EditToTenantDto>> GetTenantsByLandlordIdAsync(Guid landlordId)
        {
            // Step 1: Get Building Ids for the selected landlord
            var buildingIds = await _dbContext.Buildings
                .Where(b => b.LandlordId == landlordId && b.IsDeleted != true)
                .Select(b => b.Id)
                .ToListAsync();

            // Step 2: Get tenants that belong to those buildings
            return await _dbContext.Tenants
                .Where(t => buildingIds.Contains(t.BuildinId.Value) && t.IsDeleted != true)
                .Select(t => new EditToTenantDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    TenantCode = t.TenantCode,
                    BuildingId = t.BuildinId
                })
                .ToListAsync();
        }


    }
}
