using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IAdditionalTenantsRepository : IRepository<AdditioanlTenants>
    {
        Task AddAdditionalTenant(List<AddtionalTenantDto> tenant);
        Task<List<AdditioanlTenants>> GetAdditionalTenants(Guid? Id);
        Task<AdditioanlTenants> GetAdditionalTenantsById(Guid? Id);
        Task<bool> UpdateAdditionalTenant(List<AddtionalTenantDto> tenant);
    }
}
