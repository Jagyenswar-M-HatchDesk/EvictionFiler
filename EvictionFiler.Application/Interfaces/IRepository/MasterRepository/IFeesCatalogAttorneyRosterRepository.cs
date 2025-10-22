

using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IFeesCatalogAttorneyRosterRepository
    {
        Task<List<FeesCatalogAttorneyRoster>> GetAllAsync();
        Task<FeesCatalogAttorneyRoster?> GetByIdAsync(int id);
        // Task AddAsync(FeesCatalogAttorneyRoster entity);
        Task<int> AddAsync(FeesCatalogAttorneyRoster entity);

        Task UpdateAsync(FeesCatalogAttorneyRoster entity);
        Task DeleteAsync(int id);
    }
}