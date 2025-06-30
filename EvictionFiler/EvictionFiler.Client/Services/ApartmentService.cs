using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Client.Services
{
    public class ApartmentService
    {
        private readonly IApartmentRepository _repository;

        public ApartmentService(IApartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddApartmentAsync(AddApartment dto)
        {
            var newapartment = await _repository.AddAsync(dto);
            return newapartment;
        }
    }
}
