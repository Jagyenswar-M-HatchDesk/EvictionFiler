using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogService
    {
        Task<List<FeesCatalogDto>> GetAllByCategoryAsync(string Category) ;
        Task<List<FeesCatalogDto>> GetAllAsync();
        Task<FeesCatalog?> GetByIdAsync(Guid id);
        Task<Guid?> AddAsync(FeesCatalogDto entity);
        Task<bool> UpdateAsync(FeesCatalogDto entity);
        Task DeleteAsync(Guid id);
    }
}