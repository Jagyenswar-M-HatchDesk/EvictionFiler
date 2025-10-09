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
		Task<bool> AddTenantAsync(List<CreateToTenantDto> dto);
		Task<List<CreateToTenantDto>> SearchTenantbyCode(string code);
		Task<List<EditToTenantDto>> SearchTenantsAsync(string query, Guid buildingId);
		Task<EditToTenantDto> GetByIdAsync(Guid id);
		Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId);
		Task<bool> UpdateTenantAsync(List<EditToTenantDto> dto);
		Task<List<CreateToTenantDto>> GetAll();
		Task<string> GetLastTenantCode();

		Task<Guid?> AddTenantfromCase(CreateToTenantDto t);
    }
}
