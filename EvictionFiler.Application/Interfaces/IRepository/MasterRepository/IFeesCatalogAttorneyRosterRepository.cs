

using EvictionFiler.Application.DTOs;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IFeesCatalogAttorneyRosterRepository
    {
        Task<List<FeesCatalogAttorneyRosterDto>> GetAllAsync();
        Task<FeesCatalogAttorneyRoster?> GetByIdAsync(Guid id);
        // Task AddAsync(FeesCatalogAttorneyRoster entity);
        Task<Guid> AddAsync(FeesCatalogAttorneyRoster entity);

        Task<bool> UpdateAsync(FeesCatalogAttorneyRosterDto entity);
        Task DeleteAsync(Guid id);
    }
}