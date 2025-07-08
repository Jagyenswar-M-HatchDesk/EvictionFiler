using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.Repositories;

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

		public async Task<List<CreateTenantDto>> SearchTenantsAsync(string query)
		{
			return await _repo.SearchTenantAsync(query);
		}

		public async Task<CreateTenantDto> GetByIdAsync(Guid id)
		{
			var newtenant = await _repo.GetByIdAsync(id);
			return newtenant;
		}
	}
}
