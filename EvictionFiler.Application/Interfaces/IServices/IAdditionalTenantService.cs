using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IAdditionalTenantService
    {
        Task AddAdditionalTenantAsync(List<AddtionalTenantDto> tenant);
        Task<List<AdditioanlTenants>> GetAllAdditionalTenantsAsync(Guid? Id);
        Task<bool> UpdateAdditionalTenantAsync(List<AddtionalTenantDto> tenant);

    }
}
