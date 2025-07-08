using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Client.Services
{
    public class TenantService
    {
        private readonly ITenantRepository _repo;

        public TenantService(ITenantRepository services)
        {
			_repo = services;
        }

        public async Task<bool> AddTenantAsync(List<CreateTenantDto> dto)
        {
            var newtenant =  await _repo.AddTenant(dto);
            return newtenant;
        }

        public async Task<List<CreateTenantDto>> SearchTenantbyCode(string code)
        {
            var newtenant = await _repo.SearchTenantByCode(code);
            return newtenant;
        }
    }
}
