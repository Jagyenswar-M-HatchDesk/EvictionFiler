
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.BuildingDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        private readonly MainDbContext _context;

        public BuildingRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GenerateBuildingCodeAsync()
        {
            var lastCase = await _context.Buildings
                .OrderByDescending(c => c.BuildingCode)
                .Select(c => c.BuildingCode)
                .FirstOrDefaultAsync();

            int nextNumber = 1;

            if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("BB"))
            {
                string numberPart = lastCase.Substring(2);
                if (int.TryParse(numberPart, out int parsedNumber))
                {
                    nextNumber = parsedNumber + 1;
                }
            }

            string newCode = "BB" + nextNumber.ToString("D10");
            return newCode;
        }

        public async Task<string?> GetLastBuildingCodeAsync()
		{
			return await _context.Buildings
				.OrderByDescending(l => l.BuildingCode)
				.Select(l => l.BuildingCode)
				.FirstOrDefaultAsync();
		}

		public async Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id)
		{
			var appartment = await _context.Buildings
				
				.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

			if (appartment == null) return null;

			var tenant = await _context.Tenants
				.Include(t => t.Language) // ✅ Include Language
			
				.Where(a => a.BuildinId == id && a.IsDeleted != true)
				.Select(dto => new EditToTenantDto
				{
					Id = dto.Id,
					TenantCode = dto.TenantCode,
					FirstName = dto.FirstName,
					LastName = dto.LastName,
				
					SSN = dto.SSN,
					Phone = dto.Phone,
					Email = dto.Email,
					LanguageId = dto.LanguageId,
					
					LanguageName = dto.Language != null ? dto.Language.Name : null, // ✅ new field
				
			
					HasPossession = dto.HasPossession,
					HasRegulatedTenancy = dto.HasRegulatedTenancy,
					//Name_Relation = dto.Name_Relation,
					OtherOccupants = dto.OtherOccupants,
		
					TenantRecord = dto.TenantRecord,
					HasPriorCase = dto.HasPriorCase,
					BuildingId = dto.BuildinId,
				})
				.ToListAsync();

			return new BuildingWithTenant
			{
				Building = new EditToBuildingDto
				{
					Id = appartment.Id,
					BuildingCode = appartment.BuildingCode,
					ApartmentCode = appartment.ApartmentCode,
					CityId = appartment.CityId,
					StateId = appartment.StateId,
					PremiseTypeId = appartment.PremiseTypeId,
					Address1 = appartment.Address1,
					Address2 = appartment.Address2,
					Zipcode = appartment.Zipcode,
					MDRNumber = appartment.MDRNumber,
					PetitionerInterest = appartment.PetitionerInterest,
					RegulationStatusId = appartment.RegulationStatusId,
					BuildingUnits = appartment.BuildingUnits,
					LandlordId = appartment.LandlordId,
				},
				Tenants = tenant
			};
		}


        public async Task<List<EditToBuildingDto>> SearchBuilding(string searchText, Guid landlordId)
        {
            searchText = searchText?.Trim() ?? "";

            return await _context.Buildings
                .Where(b =>
                    b.LandlordId == landlordId &&
                    b.IsDeleted != true &&
                    (
                        // Search by BuildingCode (StartsWith = indexed & fast)
                        b.BuildingCode.StartsWith(searchText) ||
                        b.Address1.Contains(searchText) ||
                        b.Address2.Contains(searchText) ||
                        b.Cities.Name.Contains(searchText)
                    )
                )
                .Select(b => new EditToBuildingDto
                {
                    Id = b.Id,
                    BuildingCode = b.BuildingCode,
                    ApartmentCode = b.ApartmentCode,
                    CityId = b.CityId,
                    StateId = b.StateId,
                    PremiseTypeId = b.PremiseTypeId,
                    Address1 = b.Address1,
                    Address2 = b.Address2,
                    Zipcode = b.Zipcode,
                    MDRNumber = b.MDRNumber,
                    PetitionerInterest = b.PetitionerInterest,
                    RegulationStatusId = b.RegulationStatusId,
                    BuildingUnits = b.BuildingUnits,
                    LandlordId = b.LandlordId,
					BuildingTypeId = b.BuildingTypeId,
					RegistrationStatusId = b.RegistrationStatusId,
                    ExemptionBasisId = b.ExemptionBasisId,
                    ExemptionreasonId = b.ExemptionReasonId,
                    PrimaryResidence = b.PrimaryResidence,
                    GoodCause = b.GoodCause,
                    OwnerOccupied = b.OwnerOccupied,
                    TenancyTypeForBuildingId = b.TenancyTypeForBuildingId,

                })
                .ToListAsync();
        }


        public async Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId)
		{
			var building = await _context.Buildings
		.Include(a => a.State)
		.Include(a => a.PremiseType)
		.Include(a => a.RegulationStatus)
        .Include(a => a.RegistrationStatus)
        .Include(a => a.ExemptionReason)
        .Include(a => a.ExemptionBasis)
        .Include(a => a.TenancyTypeForBuilding)
        .Where(x => x.LandlordId == landlordId && x.IsDeleted != true)
		.ToListAsync();

			return building.Select(appartment  => new EditToBuildingDto
			{
				Id = appartment.Id,
				BuildingCode = appartment.BuildingCode,
				ApartmentCode = appartment.ApartmentCode,
				CityId = appartment.CityId,
				StateId = appartment.StateId,
				StateName = appartment.State?.Name,
				PremiseTypeId = appartment.PremiseTypeId,
				PremiseTypeName = appartment.PremiseType?.Name,
				RegulationStatusId = appartment.RegulationStatusId,
				RegulationStatusName = appartment.RegulationStatus?.Name,
                RegistrationStatusName = appartment.RegistrationStatus?.Name,
                RegistrationStatusId = appartment.RegistrationStatusId,
                ExemptionBasisName = appartment.ExemptionBasis?.Name,
                ExemptionBasisId = appartment.ExemptionBasisId,
                ExemptionReasonName = appartment.ExemptionReason?.Name,
                ExemptionreasonId = appartment.ExemptionReasonId,
                TenancyTypeForBuildingName = appartment.TenancyTypeForBuilding?.Name,
                TenancyTypeForBuildingId = appartment.TenancyTypeForBuildingId,
				PrimaryResidence = appartment.PrimaryResidence,
                GoodCause = appartment.GoodCause,
                OwnerOccupied = appartment.OwnerOccupied,
				RentRegulationDescription = appartment.RentRegulationDescription,
                Address1 = appartment.Address1,
				ManagingAgent = appartment.ManagingAgent,
				Address2 = appartment.Address2,
				Zipcode = appartment.Zipcode,
				MDRNumber = appartment.MDRNumber,
				PetitionerInterest = appartment.PetitionerInterest,
				BuildingUnits = appartment.BuildingUnits,
				LandlordId = appartment.LandlordId,
				IsActive = appartment.IsActive,
				IsDeleted = appartment.IsDeleted,
			

			}).ToList();
		}
        public async Task<List<EditToBuildingDto>> GetBuildingsByClientIdAsync(Guid CLientid)
        {
            var building = await _context.Buildings
        .Include(a => a.State)
        .Include(a => a.PremiseType)
        .Include(a => a.RegulationStatus)
        .Where(x => x.Landlord.ClientId == CLientid && x.IsDeleted != true)
        .ToListAsync();

            return building.Select(appartment => new EditToBuildingDto
            {
                Id = appartment.Id,
                BuildingCode = appartment.BuildingCode,
                ApartmentCode = appartment.ApartmentCode,
                CityId = appartment.CityId,
                StateId = appartment.StateId,
                StateName = appartment.State?.Name,
                PremiseTypeId = appartment.PremiseTypeId,
                PremiseTypeName = appartment.PremiseType?.Name,
                RegulationStatusId = appartment.RegulationStatusId,
                RegulationStatusName = appartment.RegulationStatus?.Name,
                RegistrationStatusId = appartment.RegistrationStatusId,
                Address1 = appartment.Address1,
                ManagingAgent = appartment.ManagingAgent,
                Address2 = appartment.Address2,
                Zipcode = appartment.Zipcode,
                MDRNumber = appartment.MDRNumber,
                PetitionerInterest = appartment.PetitionerInterest,
                BuildingUnits = appartment.BuildingUnits,
                LandlordId = appartment.LandlordId,
                IsActive = appartment.IsActive,
                IsDeleted = appartment.IsDeleted,


            }).ToList();
        }

        public async Task<EditToBuildingDto> GetBuildingByIdAsync(Guid buildingId)
		{
			var appartment = await _context.Buildings
				.Include(a => a.State)
				.Include(a => a.PremiseType)
				.Include(a => a.RegulationStatus)
				.FirstOrDefaultAsync(x => x.Id == buildingId && x.IsDeleted != true);

			if (appartment == null) return null;

			return new EditToBuildingDto
			{
				Id = appartment.Id,
				BuildingCode = appartment.BuildingCode,
				ApartmentCode = appartment.ApartmentCode,
				CityId = appartment.CityId,
				StateId = appartment.StateId,
				StateName = appartment.State?.Name,
				PremiseTypeId = appartment.PremiseTypeId,
				PremiseTypeName = appartment.PremiseType?.Name,
				RegulationStatusId = appartment.RegulationStatusId,
				RegulationStatusName = appartment.RegulationStatus?.Name,
				Address1 = appartment.Address1,
				Address2 = appartment.Address2,
				Zipcode = appartment.Zipcode,
				MDRNumber = appartment.MDRNumber,
				PetitionerInterest = appartment.PetitionerInterest,
				BuildingUnits = appartment.BuildingUnits,
				LandlordId = appartment.LandlordId,
				IsActive = appartment.IsActive,
				IsDeleted = appartment.IsDeleted
			};
		}



	}
}