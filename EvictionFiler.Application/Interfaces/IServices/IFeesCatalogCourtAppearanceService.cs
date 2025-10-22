using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogCourtAppearanceService
    {
        Task<List<FeesCatalogCourtAppearance>> GetAllAsync();
        Task<FeesCatalogCourtAppearance?> GetByIdAsync(int id);
        Task AddAsync(FeesCatalogCourtAppearance entity);
        Task UpdateAsync(FeesCatalogCourtAppearance entity);
        Task DeleteAsync(int id);
    }
}