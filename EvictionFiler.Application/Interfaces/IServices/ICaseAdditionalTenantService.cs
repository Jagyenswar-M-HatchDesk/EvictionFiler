using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
