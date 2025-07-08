using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ITenantRepository
    {
        Task<bool> AddTenant(List<CreateTenantDto> dtolist);

		Task<List<CreateTenantDto>> SearchTenantByCode(string code);
        Task<Tenant> GetTenantById(Guid id);
        Task<List<Tenant>> GetAllTenantsAsync();
        Task<bool> DeleteTenantAsync(Guid id);
        Task<bool> UpdateTenantAsync(CreateTenantDto dto);
    }
}
