
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IFeesCatalogAttorneyRosterService
    {
        Task<List<FeesCatalogAttorneyRoster>> GetAllAsync();
        Task<FeesCatalogAttorneyRoster?> GetByIdAsync(int id);
        Task<int?> AddAsync(FeesCatalogAttorneyRoster entity);
        //  Task<int> AddAsync(FeesCatalogAttorneyRoster entity);

        Task<bool> UpdateAsync(FeesCatalogAttorneyRoster entity);
        Task DeleteAsync(int id);
    }
}