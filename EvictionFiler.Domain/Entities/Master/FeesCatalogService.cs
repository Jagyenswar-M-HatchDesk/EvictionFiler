
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices.Master;
using EvictionFiler.Domain.Entities.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services.Master
{
    public class FeesCatalogService : IFeesCatalogService
    {
        private readonly IFeesCatalogRepository _repository;
        public FeesCatalogService(IFeesCatalogRepository repository) => _repository = repository;

        public Task<List<FeesCatalog>> GetAllAsync() => _repository.GetAllAsync();
        // Fixed: Ensure it calls the repository's GetByIdAsync
        public Task<FeesCatalog?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(FeesCatalog entity) => _repository.AddAsync(entity);
        public Task UpdateAsync(FeesCatalog entity) => _repository.UpdateAsync(entity);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
