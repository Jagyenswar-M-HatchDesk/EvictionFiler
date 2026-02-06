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
using Microsoft.EntityFrameworkCore.Internal;
using Polly;
using System.Linq;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class TenantRepository : Repository<Tenant>, ITenantRepository
    {
        private readonly MainDbContext _dbContext;
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public TenantRepository(MainDbContext dbContext, IDbContextFactory<MainDbContext> contextFactory) : base(dbContext, contextFactory)
        {
            _dbContext = dbContext;
            _contextFactory = contextFactory;

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

		public async Task<List<EditToTenantDto>> SearchTenantByname(string name)
		{
			var tenant = await _dbContext.Tenants.Where(e => e.TenantCode.Contains(name)).Select(dto => new EditToTenantDto
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
				return new List<EditToTenantDto>();
			return tenant;
		}

        public async Task<List<EditToTenantDto>> SearchTenantAsync(string query, Guid buildingId)
        {
            query = query?.Trim().ToLower() ?? "";

            var tenants = await _dbContext.Tenants
                .Where(t =>
                    t.BuildinId == buildingId &&      
                    t.IsDeleted != true &&             
                    (
                        t.TenantCode.ToLower().Contains(query) ||
                        (t.FirstName + " " + t.LastName).ToLower().Contains(query) ||
                        t.UnitOrApartmentNumber.ToLower().Contains(query)
                    )
                )
                .Select(t => new EditToTenantDto
                {
                    Id = t.Id,
                    TenantCode = t.TenantCode,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    UnitOrApartmentNumber = t.UnitOrApartmentNumber
                })
                .ToListAsync();

            return tenants;
        }






        public async Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId)
        {
            // 1️⃣ Get BuildingIds for the selected Client
            var buildingIds = await _dbContext.Buildings
                .Where(b => b.Id == clientId)
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
                    LastName = t.LastName,
                    SSN = t.SSN,
                    Email = t.Email,
                    Phone = t.Phone,
                    ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
                    LanguageId = t.LanguageId,
                    LanguageName= t.Language.Name,
                    UnitOrApartmentNumber = t.UnitOrApartmentNumber,
                    MonthlyRent = t.MonthlyRent,
                    TenantShare = t.TenantShare,
                    TenancyTypeId=t.TenancyTypeId,
                    TenancyTypeName = t.TenancyType.Name,
                    RentDueEachMonthOrWeekId = t.RentDueEachMonthOrWeekId,
                    IsUnitIllegalId = t.IsUnitIllegalId,
                    PrimaryResidence = t.PrimaryResidence,
                    
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
        public async Task<EditToLandlordDto>GetLandlordByBuildingAsync(Guid buildingId)
        {
            var data = await _dbContext.Buildings
                .Where(t => t.Id == buildingId)
                .Select(t => new
                {
                    Landlord = new EditToLandlordDto
                    {
                        Id = t.Landlord.Id,
                        FirstName = t.Landlord.FirstName,
                        LastName = t.Landlord.LastName,
                        LandLordCode = t.Landlord.LandLordCode
                    },
                    
                })
                .FirstOrDefaultAsync();

            return data.Landlord;
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

        public async Task<List<EditToTenantDto>> GetTenantsByBuildingIdAsync(Guid buildingId)
        {
           
            return await _dbContext.Tenants
                 .Where(b => b.BuildinId == buildingId && b.IsDeleted != true)
                 .Select(t => new EditToTenantDto
                 {
                     Id = t.Id,
                     FirstName = t.FirstName,
                     LastName = t.LastName,
                     TenantCode = t.TenantCode,
                     BuildingId = t.BuildinId,
                     UnitOrApartmentNumber = t.UnitOrApartmentNumber,
                     TenancyTypeId = t.TenancyTypeId,
                     TenantShare = t.TenantShare,
                     MonthlyRent = t.MonthlyRent,
                     RentDueEachMonthOrWeekId = t.RentDueEachMonthOrWeekId,
                     PrimaryResidence = t.PrimaryResidence,
                     
                 })
                 .ToListAsync();
        }
    }
}
