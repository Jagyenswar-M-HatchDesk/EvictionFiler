using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Services
{
	public class ApartmentService : IApartmentService
	{
		private readonly IApartmentRepository _repository;

		public ApartmentService(IApartmentRepository repository)
		{
			_repository = repository;
		}


		public async Task<List<AddApartment>> GetAll()
		{
			var newapartment = await _repository.GetAllAsync();
			return newapartment;
		}

		public async Task<bool> AddApartmentAsync(List<AddApartment> dto)
		{
			var newapartment = await _repository.AddApartmentAsync(dto);
			return newapartment;
		}

		public async Task<AddApartment> GetByIdAsync(Guid id)
		{
			var newapartment = await _repository.GetByIdAsync(id);
			return newapartment;
		}

		public async Task<List<AddApartment>> SearchBuildingByCode(string code, Guid landlordId)
		{
			return await _repository.SearchBuildingByCode(code, landlordId);
		}


		public async Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id)
		{
			return await _repository.GetBuildingsWithTenantAsync(id);
		}
		public async Task<List<EditApartmentDto>> GetBuildingsByLandlordIdAsync(Guid clientId)
		{
			var landlords = await _repository.GetBuildingsByLandlordIdAsync(clientId);
			return landlords;


		}

		public async Task<bool> UpdateBuildingAsync(List<EditApartmentDto> buildings)

		{
			var building = await _repository.UpdateBuildingAsync(buildings);
			return building;


		}

		public async Task<List<RegulationStatus>> GetAllRentRegulation()
		{
			var regulations = await _repository.GetAllRentRegulation();
			return regulations;
		}

		public async Task<List<PremiseType>> GetAllPremiseTypes()
		{

			var PremiseTypes = await _repository.GetAllPremiseType();
			return PremiseTypes;
		}
	}
}
