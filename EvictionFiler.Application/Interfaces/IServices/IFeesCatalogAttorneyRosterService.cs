using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogAttorneyRosterService
    {
        Task<List<FeesCatalogAttorneyRoster>> GetAllAsync();
        Task<FeesCatalogAttorneyRoster?> GetByIdAsync(int id);
        Task AddAsync(FeesCatalogAttorneyRoster entity);
        Task UpdateAsync(FeesCatalogAttorneyRoster entity);
        Task DeleteAsync(int id);
    }
}