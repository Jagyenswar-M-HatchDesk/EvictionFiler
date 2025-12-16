using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IAdditionalTenantService
    {
        Task AddAdditionalTenantAsync(List<AddtionalTenantDto> tenant);
        Task<List<AdditioanlTenants>> GetAllAdditionalTenantsAsync(Guid? Id);
        Task<bool> UpdateAdditionalTenantAsync(List<AddtionalTenantDto> tenant);

    }
}
