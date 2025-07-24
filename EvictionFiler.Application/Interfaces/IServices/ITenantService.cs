using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ITenantService
    {
		Task<bool> AddTenantAsync(List<CreateTenantDto> dto);
		Task<List<CreateTenantDto>> SearchTenantbyCode(string code);
		Task<List<CreateTenantDto>> SearchTenantsAsync(string query, Guid buildingId);
		Task<EditTenantDto> GetByIdAsync(Guid id);
		Task<List<EditTenantDto>> GetTenantsByClientIdAsync(Guid clientId);
		Task<bool> UpdateTenantAsync(List<EditTenantDto> dto);
		Task<List<Language>> GetAllLanguage();
		Task<List<CreateTenantDto>> GetAll();

	}
}
