using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogCourtAppearanceService
    {
        Task<List<FeesCatalogCourtAppearance>> GetAllAsync();
        Task<FeesCatalogCourtAppearance?> GetByIdAsync(int id);
        Task<int?> AddAsync(FeesCatalogCourtAppearance entity);
        Task<bool> UpdateAsync(FeesCatalogCourtAppearance entity);
        Task DeleteAsync(int id);
    }
}