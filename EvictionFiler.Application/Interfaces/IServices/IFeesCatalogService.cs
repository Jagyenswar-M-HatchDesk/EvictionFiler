using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogService
    {
        Task<List<FeesCatalog>> GetAllAsync();
        Task<FeesCatalog?> GetByIdAsync(int id);
        Task AddAsync(FeesCatalog entity);
        Task UpdateAsync(FeesCatalog entity);
        Task DeleteAsync(int id);
    }
}