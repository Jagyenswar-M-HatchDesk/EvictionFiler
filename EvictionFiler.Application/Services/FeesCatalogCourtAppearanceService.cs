

using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Services.Master
{
    public class FeesCatalogCourtAppearanceService : IFeesCatalogCourtAppearanceService
    {
        private readonly IFeesCatalogCourtAppearanceRepository _repository;

        public FeesCatalogCourtAppearanceService(IFeesCatalogCourtAppearanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FeesCatalogCourtAppearanceDto>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<FeesCatalogCourtAppearance?> GetByIdAsync(Guid id) =>
            await _repository.GetByIdAsync(id);

        public async Task<Guid?> AddAsync(FeesCatalogCourtAppearance entity)
        {
            return await _repository.AddAsync(entity);
        }
        public async Task<bool> UpdateAsync(FeesCatalogCourtAppearanceDto entity)
        { 
            return await _repository.UpdateAsync(entity);
        }
        public async Task DeleteAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }
}
