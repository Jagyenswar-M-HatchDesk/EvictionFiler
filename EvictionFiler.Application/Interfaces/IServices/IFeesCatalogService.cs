using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogService
    {
        Task<List<FeesCatalog>> GetAllByCategoryAsync(string Category) ;
        Task<List<FeesCatalogDto>> GetAllAsync();
        Task<FeesCatalog?> GetByIdAsync(int id);
        Task<int?> AddAsync(FeesCatalog entity);
        Task<bool> UpdateAsync(FeesCatalog entity);
        Task DeleteAsync(int id);
    }
}