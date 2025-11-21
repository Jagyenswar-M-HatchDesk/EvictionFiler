using EvictionFiler.Application.DTOs;
using EvictionFiler.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFeesCatalogCourtAppearanceService
    {
        Task<List<FeesCatalogCourtAppearanceDto>> GetAllAsync();
        Task<FeesCatalogCourtAppearance?> GetByIdAsync(Guid id);
        Task<Guid?> AddAsync(FeesCatalogCourtAppearance entity);
        Task<bool> UpdateAsync(FeesCatalogCourtAppearanceDto entity);
        Task DeleteAsync(Guid id);
    }
}