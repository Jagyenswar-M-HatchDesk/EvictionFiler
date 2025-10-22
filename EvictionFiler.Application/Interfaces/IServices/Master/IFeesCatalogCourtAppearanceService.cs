
using EvictionFiler.Domain.Entities.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices.Master
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