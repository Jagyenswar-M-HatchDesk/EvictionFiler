using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.Repositories;

namespace EvictionFiler.Client.Services
{
    public class ApartmentService
    {
        private readonly IApartmentRepository _repository;

        public ApartmentService(IApartmentRepository repository)
        {
            _repository = repository;
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
	}
}
