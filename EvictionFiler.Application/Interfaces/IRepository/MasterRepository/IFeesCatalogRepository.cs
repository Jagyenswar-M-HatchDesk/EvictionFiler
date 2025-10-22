
using EvictionFiler.Domain.Entities.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IFeesCatalogRepository
    {
        Task<List<FeesCatalog>> GetAllAsync();
        Task<FeesCatalog?> GetByIdAsync(int id);
        Task AddAsync(FeesCatalog entity);
        Task UpdateAsync(FeesCatalog entity);
        Task DeleteAsync(int id);
    }
}