using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.BuildingDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
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

		public async Task<string?> GetLastBuildingCodeAsync()
		{
			return await _context.Buildings
				.OrderByDescending(l => l.CreatedOn)
				.Select(l => l.BuildingCode)
				.FirstOrDefaultAsync();
		}

		public async Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id)
		{
			var appartment = await _context.Buildings
				.Include(x => x.LandlordType) // ✅ Include LandlordType
				.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

			if (appartment == null) return null;

			var tenant = await _context.Tenants
				.Include(t => t.Language) // ✅ Include Language
				.Include(t => t.State)    // ✅ Include State
				.Where(a => a.BuildinId == id && a.IsDeleted != true)
				.Select(dto => new EditToTenantDto
				{
					Id = dto.Id,
					TenantCode = dto.TenantCode,
					FirstName = dto.FirstName,
					LastName = dto.LastName,
					DOB = dto.DOB,
					SSN = dto.SSN,
					Phone = dto.Phone,
					Email = dto.Email,
					LanguageId = dto.LanguageId,
					StateId = dto.StateId,
					LanguageName = dto.Language != null ? dto.Language.Name : null, // ✅ new field
					StateName = dto.State != null ? dto.State.Name : null,         // ✅ new field
					Address1 = dto.Address1,
					Address2 = dto.Address2,
					City = dto.City,
					Zipcode = dto.Zipcode,
					Apt = dto.Apt,
					Borough = dto.Borough,
					Rent = dto.Rent,
					HasPossession = dto.HasPossession,
					HasRegulatedTenancy = dto.HasRegulatedTenancy,
					Name_Relation = dto.Name_Relation,
					OtherOccupants = dto.OtherOccupants,
					Registration_No = dto.Registration_No,
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
					City = appartment.City,
					StateId = appartment.StateId,
					PremiseTypeId = appartment.PremiseTypeId,
					Address1 = appartment.Address1,
					Address2 = appartment.Address2,
					Zipcode = appartment.Zipcode,
					MDRNumber = appartment.MDRNumber,
					PetitionerInterest = appartment.PetitionerInterest,
					RegulationStatusId = appartment.RegulationStatusId,
					BuildingUnits = appartment.BuildingUnits,
					DateOfRefreeDeed = appartment.DateOfRefreeDeed,
					LandlordTypeId = appartment.LandlordTypeId,
					LandlordTypeName = appartment.LandlordType?.Name,
					LandlordId = appartment.LandlordId,
				},
				Tenants = tenant
			};
		}


		public async Task<List<EditToBuildingDto>> SearchBuildingByCode(string code, Guid landlordId)
		{
			return await _context.Buildings
				.Where(appartment =>
					appartment.LandlordId == landlordId && 
					appartment.BuildingCode.StartsWith(code)
				)
				.Select(appartment=> new EditToBuildingDto
				{
					Id = appartment.Id,
					BuildingCode = appartment.BuildingCode,
					ApartmentCode = appartment.ApartmentCode,
					City = appartment.City,
					StateId = appartment.StateId,
					PremiseTypeId = appartment.PremiseTypeId,
					Address1 = appartment.Address1,
					Address2 = appartment.Address2,
					Zipcode = appartment.Zipcode,
					MDRNumber = appartment.MDRNumber,
					PetitionerInterest = appartment.PetitionerInterest,
					RegulationStatusId = appartment.RegulationStatusId,
					BuildingUnits = appartment.BuildingUnits,
					DateOfRefreeDeed = appartment.DateOfRefreeDeed,
					LandlordTypeId = appartment.LandlordTypeId,
					LandlordTypeName = appartment.LandlordType.Name,
					LandlordId = appartment.LandlordId,

				})
				.ToListAsync();
		}

		public async Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId)
		{
			var building = await _context.Buildings
		.Include(a => a.State)
		.Include(a => a.PremiseType)
		.Include(a => a.RegulationStatus)
		.Where(x => x.LandlordId == landlordId && x.IsDeleted != true)
		.ToListAsync();

			return building.Select(appartment  => new EditToBuildingDto
			{
				Id = appartment.Id,
				BuildingCode = appartment.BuildingCode,
				ApartmentCode = appartment.ApartmentCode,
				City = appartment.City,
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
				DateOfRefreeDeed = appartment.DateOfRefreeDeed,
				LandlordTypeId = appartment.LandlordTypeId,
				LandlordTypeName = appartment.LandlordType?.Name,
				LandlordId = appartment.LandlordId,
			

			}).ToList();
		}


	


	}
}