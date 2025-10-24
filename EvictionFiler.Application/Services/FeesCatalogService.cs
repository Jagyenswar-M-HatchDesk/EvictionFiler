using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Services.Master
{
    public class FeesCatalogService : IFeesCatalogService
    {
        private readonly IFeesCatalogRepository _repository;
        public FeesCatalogService(IFeesCatalogRepository repository) => _repository = repository;

        public Task<List<FeesCatalog>> GetAllAsync(string Category) => _repository.GetAllAsync(Category);
        // Fixed: Ensure it calls the repository's GetByIdAsync
        public Task<FeesCatalog?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<int?> AddAsync(FeesCatalog entity) { return _repository.AddAsync(entity); }
        public Task<bool> UpdateAsync(FeesCatalog entity) { return _repository.UpdateAsync(entity); }
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
