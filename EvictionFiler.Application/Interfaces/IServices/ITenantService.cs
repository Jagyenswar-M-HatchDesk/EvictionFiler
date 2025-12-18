using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ITenantService
    {
        Task<bool> AddTenantAsync(List<CreateToTenantDto> dto);
        Task<List<EditToTenantDto>> SearchTenantbyname(string name);
        Task<List<EditToTenantDto>> SearchTenantsAsync(string query, Guid buildingId);

        Task<EditToTenantDto> GetByIdAsync(Guid id);
        Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId);
        Task<bool> UpdateTenantAsync(EditToTenantDto t);

        Task<List<CreateToTenantDto>> GetAll();
        Task<string> GetLastTenantCode();
        Task<List<EditToTenantDto>> GetAlltenant();
        Task<Guid?> AddOnlyTenantfromCase(CreateToTenantDto dto);
        Task<bool> UpdateTenantfromCase(EditToTenantDto tenants);
        Task<(EditToLandlordDto landlord, EditToBuildingDto building)>
    GetLandlordBuildingByTenantAsync(Guid tenantId);

        Task<Guid?> AddTenantfromCase(CreateToTenantDto t);
        Task<List<EditToTenantDto>> GetTenantsByLandlordIdAsync(Guid landlordId);
        Task<List<EditToTenantDto>> GetTenantsByBuildingIdAsync(Guid buildingId);

        Task<EditToLandlordDto> GetLandlordByBuildingAsync(Guid buildingId);
    }
}
