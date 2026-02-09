
using EvictionFiler.Application.DTOs;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IFeesCatalogRepository
    {
        Task<List<FeesCatalog>> GetAllAsync();
        Task<List<FeesCatalogDto>> GetAllByCategoryAsync(string Category);
        Task<FeesCatalog?> GetByIdAsync(Guid id);
        Task<Guid?> AddAsync(FeesCatalogDto entity);
        Task<bool> UpdateAsync(FeesCatalogDto entity);
        Task DeleteAsync(Guid id);
    }
}