using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.BuildingDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Guid?> AddOnlyApartmentfromCase(CreateToBuildingDto appartment)
        {

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


            var code = $"BB{nextNumber.ToString().PadLeft(10, '0')}";
            nextNumber++;

            var newapartment = new Building
            {
                BuildingCode = code,
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
                BuildingTypeId = appartment.BuildingTypeId,
                RegistrationStatusId = appartment.RegistrationStatusId,


                LandlordId = appartment.LandlordId,
            };



            await _repository.AddAsync(newapartment);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0) return newapartment.Id;

            return null;
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

        public async Task<List<EditToBuildingDto>> SearchBuilding(string code, Guid landlordId)
        {
            return await _repository.SearchBuilding(code, landlordId);
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

        public async Task<bool> UpdateonlyBuildingfromCase(EditToBuildingDto appartment)

        {

            var entity = await _repository.GetAsync(appartment.Id);
            if (entity != null)
            {

                if(entity.ApartmentCode != appartment.ApartmentCode) entity.ApartmentCode = appartment.ApartmentCode;
                if(entity.City != appartment.City) entity.City = appartment.City;
                if (entity.Address1 != appartment.Address1)  entity.Address1 = appartment.Address1;
                if (entity.Address2 != appartment.Address2) entity.Address2 = appartment.Address2;
                if (entity.StateId != appartment.StateId) entity.StateId = appartment.StateId;
                if (entity.MDRNumber != appartment.MDRNumber) entity.MDRNumber = appartment.MDRNumber;
                if (entity.RegulationStatusId != appartment.RegulationStatusId)  entity.RegulationStatusId = appartment.RegulationStatusId;
                if (entity.BuildingUnits != appartment.BuildingUnits) entity.BuildingUnits = appartment.BuildingUnits;
                if (entity.BuildingTypeId != appartment.BuildingTypeId) entity.BuildingTypeId = appartment.BuildingTypeId;
                if (entity.PremiseTypeId != appartment.PremiseTypeId) entity.PremiseTypeId = appartment.PremiseTypeId;
                if (entity.RegistrationStatusId != appartment.RegistrationStatusId) entity.RegistrationStatusId = appartment.RegistrationStatusId;

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

        public async Task<EditToBuildingDto> GetBuildingByIdAsync(Guid buildingId)
        {
            var building = await _repository.GetBuildingByIdAsync(buildingId);
            return building!;
        }

    }
}
