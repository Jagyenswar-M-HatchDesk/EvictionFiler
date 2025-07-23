using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
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

		public async Task<List<CreateTenantDto>> SearchTenantsAsync(string query , Guid buildingId)
		{
			return await _repo.SearchTenantAsync(query , buildingId);
		}

		public async Task<EditTenantDto> GetByIdAsync(Guid id)
		{
			var newtenant = await _repo.GetByIdAsync(id);
			return newtenant;
		}

		public async Task<List<EditTenantDto>> GetTenantsByClientIdAsync(Guid clientId)
		{
			var tenants = await _repo.GetTenantsByClientIdAsync(clientId);
			return tenants;


		}
		public async Task<bool> UpdateTenantAsync(List<EditTenantDto> dto)

		{
			var tenant = await _repo.UpdateTenantAsync(dto);
			return tenant;


		}
		public async Task<List<Language>> GetAllLanguage()
		{
			await Task.Delay(4000);
			var lang = await _repo.GetAllLanguage();
			return lang;
		}

	}
}
