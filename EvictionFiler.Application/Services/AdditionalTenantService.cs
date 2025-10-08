using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class AdditionalTenantService : IAdditionalTenantService
    {
        private readonly IAdditionalTenantsRepository _additionalTenantsRepository;
        public AdditionalTenantService(IAdditionalTenantsRepository additionalTenantsRepository)
        {
            _additionalTenantsRepository = additionalTenantsRepository;
        }

        public async Task AddAdditionalTenantAsync(List<AddtionalTenantDto> tenant)
        {
            await _additionalTenantsRepository.AddAdditionalTenant(tenant);
        }

        public async Task<List<AdditioanlTenants>> GetAllAdditionalTenantsAsync(Guid? Id)
        {
            var additional = await _additionalTenantsRepository.GetAdditionalTenants(Id);
            return additional;
        }
    }
}
