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

        public async Task<List<AddApartment>> SearchBuildingByCode(string code)
        {
            var newtenant = await _repository.SearchBuildingByCode(code);
            return newtenant;
        }
    }
}
