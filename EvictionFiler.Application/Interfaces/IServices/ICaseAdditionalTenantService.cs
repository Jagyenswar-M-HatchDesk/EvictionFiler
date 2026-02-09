using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseAdditionalTenantService
    {
        Task AddAdditionalCaseTenantAsync(List<AddtionalTenantDto> tenat);
        Task<List<CaseAdditionalTenants>> GetAllAdditionalCaseTenantsAsync(Guid? Id);
        Task<bool> UpdateAdditionalCaseTenantAsync(List<AddtionalTenantDto> occupant);
        Task<bool> DeleteAdditionalCaseTenants(List<AddtionalTenantDto> tenants);
    }
}
