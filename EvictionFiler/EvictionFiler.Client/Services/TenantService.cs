using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;

namespace EvictionFiler.Client.Services
{
    public class TenantService
    {
        private readonly ITenantRepository _services;

        public TenantService(ITenantRepository services)
        {
            _services = services;
        }

        public async Task<bool> AddTenantAsync(CreateTenantDto dto)
        {
            var newtenant =  await _services.AddTenant(dto);
            return newtenant;
        }
    }
}
