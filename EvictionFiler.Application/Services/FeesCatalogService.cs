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

        public Task<List<FeesCatalogDto>> GetAllByCategoryAsync(string Category) => _repository.GetAllByCategoryAsync(Category);
        public async Task<List<FeesCatalogDto>> GetAllAsync()
        {
            var feecatalog =  await _repository.GetAllAsync();
            return feecatalog.Select(e => new FeesCatalogDto
            {
               // Id = e.Id,
                Code = e.Code,
                Label = e.Label,
                Rate = e.Rate,
                Unit = e.Unit
            }).ToList();
        }
        // Fixed: Ensure it calls the repository's GetByIdAsync
        public Task<FeesCatalog?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);
        public Task<Guid?> AddAsync(FeesCatalogDto entity) { return _repository.AddAsync(entity); }
        public Task<bool> UpdateAsync(FeesCatalogDto entity) { return _repository.UpdateAsync(entity); }
        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
