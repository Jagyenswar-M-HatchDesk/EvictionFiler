using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ITenantRepository
    {
        Task<bool> AddTenant(List<CreateTenantDto> dtolist);

		Task<List<CreateTenantDto>> SearchTenantByCode(string code);
        Task<Tenant> GetTenantById(Guid id);
        Task<List<Tenant>> GetAllTenantsAsync();
        Task<bool> DeleteTenantAsync(Guid id);
        Task<bool> UpdateTenantAsync(List<EditTenantDto> dto);

		Task<List<CreateTenantDto>> SearchTenantAsync(string query, Guid BuildingId);

        Task<EditTenantDto?> GetByIdAsync(Guid id);

		Task<List<EditTenantDto>> GetTenantsByClientIdAsync(Guid clientId);
        Task<List<Language>> GetAllLanguage();
		//Task<string> GenerateTenantCodeAsync();

	}
}
