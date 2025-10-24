

using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IServices.Master;
using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services.Master
{
    public class FeesCatalogCourtAppearanceService : IFeesCatalogCourtAppearanceService
    {
        private readonly IFeesCatalogCourtAppearanceRepository _repository;

        public FeesCatalogCourtAppearanceService(IFeesCatalogCourtAppearanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FeesCatalogCourtAppearance>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<FeesCatalogCourtAppearance?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<int?> AddAsync(FeesCatalogCourtAppearance entity)
        {
            return await _repository.AddAsync(entity);
        }
        public async Task<bool> UpdateAsync(FeesCatalogCourtAppearance entity)
        { 
            return await _repository.UpdateAsync(entity);
        }
        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
