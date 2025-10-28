using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Services.Master
{
    public class FeesCatalogService : IFeesCatalogService
    {
        private readonly IFeesCatalogRepository _repository;
        public FeesCatalogService(IFeesCatalogRepository repository) => _repository = repository;

        public Task<List<FeesCatalog>> GetAllByCategoryAsync(string Category) => _repository.GetAllByCategoryAsync(Category);
        public async Task<List<FeesCatalogDto>> GetAllAsync()
        {
            var feecatalog =  await _repository.GetAllAsync();
            return feecatalog.Select(e => new FeesCatalogDto
            {
                Id = e.Id,
                Code = e.Code,
                Label = e.Label,
                Rate = e.Rate,
                Unit = e.Unit
            }).ToList();
        }
        // Fixed: Ensure it calls the repository's GetByIdAsync
        public Task<FeesCatalog?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<int?> AddAsync(FeesCatalog entity) { return _repository.AddAsync(entity); }
        public Task<bool> UpdateAsync(FeesCatalog entity) { return _repository.UpdateAsync(entity); }
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
