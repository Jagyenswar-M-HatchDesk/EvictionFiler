using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogService
    {
        Task<List<FeesCatalog>> GetAllAsync(string Category);
        Task<FeesCatalog?> GetByIdAsync(int id);
        Task<int?> AddAsync(FeesCatalog entity);
        Task<bool> UpdateAsync(FeesCatalog entity);
        Task DeleteAsync(int id);
    }
}