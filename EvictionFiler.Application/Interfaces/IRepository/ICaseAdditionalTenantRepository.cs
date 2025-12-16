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
    public interface ICaseAdditionalTenantRepository : IRepository<CaseAdditionalTenants>
    {
        Task AddAdditionalCaseTenant(List<AddtionalTenantDto> tenant);
        Task<List<CaseAdditionalTenants>> GetAdditionalCaseTenants(Guid? Id);
        Task<bool> UpdateAdditionalCaseTenant(List<AddtionalTenantDto> occupant);
        Task<CaseAdditionalTenants> GetCaseTenantById(Guid Id);
        Task<bool> DeleteAdditionalTenants(List<AddtionalTenantDto> Tenant);
    }
}
