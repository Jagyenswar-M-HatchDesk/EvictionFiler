using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.BuildingDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Services
{
	public class BuildingService : IBuildingService
	{
		private readonly IBuildingRepository _repository;
		private readonly IUnitOfWork _unitOfWork;

		public BuildingService(IBuildingRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}


		public async Task<List<CreateToBuildingDto>> GetAll()
		{
			var query = await _repository.GetAllAsync();
			return query.Select(appartment => new CreateToBuildingDto
			{
			
				BuildingCode = appartment.BuildingCode,
				ApartmentCode = appartment.ApartmentCode,
				City = appartment.City,
				StateId = appartment.StateId,
				RegulationStatusId = appartment.RegulationStatusId,
				PremiseTypeId = appartment.PremiseTypeId,
				Address1 = appartment.Address1,
				Address2 = appartment.Address2,
				Zipcode = appartment.Zipcode,
				MDRNumber = appartment.MDRNumber,
				PetitionerInterest = appartment.PetitionerInterest,
				BuildingUnits = appartment.BuildingUnits,
				LandlordId = appartment.LandlordId,
				
			}).ToList();

		}
		public async Task<bool> AddApartmentAsync(List<CreateToBuildingDto> dtoList)
		{
			var newapartment = new List<Building>();

			var lastCode = await _repository.GetLastBuildingCodeAsync();

			int nextNumber = 1;
			if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
			{
				var numericPart = lastCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
				{
					nextNumber = lastNumber + 1;
				}
			}

			foreach (var appartment in dtoList)
			{
				var code = $"BB{nextNumber.ToString().PadLeft(10, '0')}";
				nextNumber++; 

				var apartment = new Building
				{
					BuildingCode = appartment.BuildingCode,
					ApartmentCode = appartment.ApartmentCode,
					City = appartment.City,
					StateId = appartment.StateId,
					RegulationStatusId = appartment.RegulationStatusId,
					PremiseTypeId = appartment.PremiseTypeId,
					Address1 = appartment.Address1,
					Address2 = appartment.Address2,
					Zipcode = appartment.Zipcode,
					MDRNumber = appartment.MDRNumber,
					PetitionerInterest = appartment.PetitionerInterest,
					BuildingUnits = appartment.BuildingUnits,
				
					LandlordId = appartment.LandlordId,
				};

				newapartment.Add(apartment);
			}

			await _repository.AddRangeAsync(newapartment);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}

		public async Task<CreateToBuildingDto> GetByIdAsync(Guid id)
		{
			var appartment = await _repository.GetAsync(id);

			if (appartment == null)
				return null;

			return new CreateToBuildingDto
			{
				BuildingCode = appartment.BuildingCode,
				ApartmentCode = appartment.ApartmentCode,
				City = appartment.City,
				StateId = appartment.StateId,
				RegulationStatusId = appartment.RegulationStatusId,
				PremiseTypeId = appartment.PremiseTypeId,
				Address1 = appartment.Address1,
				Address2 = appartment.Address2,
				Zipcode = appartment.Zipcode,
				MDRNumber = appartment.MDRNumber,
				PetitionerInterest = appartment.PetitionerInterest,
				BuildingUnits = appartment.BuildingUnits,
			
				LandlordId = appartment.LandlordId,
			};
	}

		public async Task<List<EditToBuildingDto>> SearchBuildingByCode(string code, Guid landlordId)
		{
			return await _repository.SearchBuildingByCode(code, landlordId);
		}

		public async Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id)
		{
			return await _repository.GetBuildingsWithTenantAsync(id);
		}
		public async Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid clientId)
		{
			var landlords = await _repository.GetBuildingsByLandlordIdAsync(clientId);
			return landlords;


		}

		public async Task<bool> UpdateBuildingAsync(List<EditToBuildingDto> buildings)

		{
			foreach (var appartment in buildings)
			{
				var entity = await _repository.GetAsync(appartment.Id);
				if (entity != null)
				{
				
					entity.ApartmentCode = appartment.ApartmentCode;
					entity.BuildingCode = appartment.BuildingCode;
					entity.City = appartment.City;
					entity.StateId = appartment.StateId;
					entity.PremiseTypeId = appartment.PremiseTypeId;
					entity.Address1 = appartment.Address1;
					entity.Address2 = appartment.Address2;
					entity.Zipcode = appartment.Zipcode;
					entity.MDRNumber = appartment.MDRNumber;
					entity.PetitionerInterest = appartment.PetitionerInterest;
					entity.RegulationStatusId = appartment.RegulationStatusId;
					entity.BuildingUnits = appartment.BuildingUnits;
					entity.LandlordId = appartment.LandlordId;
					
				}

				_repository.UpdateAsync(entity);
				await _unitOfWork.SaveChangesAsync();
			}
			return true;
		}

		public async Task<string> GetLastBuilding()
		{
            var lastBuildingCode = await _repository.GetLastBuildingCodeAsync();
			return lastBuildingCode!;
        }
		
	}
}
