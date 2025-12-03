using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ITenantRepository : IRepository<Tenant>
    {

        Task<string?> GetLasttenantCodeAsync();
        Task<List<EditToTenantDto>> SearchTenantByname(string name);
        Task<List<EditToTenantDto>> SearchTenantAsync(string query, Guid BuildingId);
        Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId);
        Task<List<Language>> GetAllLanguage();
        Task<string> GenerateTenantCodeAsync();
        Task<(EditToLandlordDto landlord, EditToBuildingDto building)>
 GetLandlordBuildingByTenantAsync(Guid tenantId);
        Task<List<EditToTenantDto>> GetTenantsByLandlordIdAsync(Guid landlordId);
        Task<List<EditToTenantDto>> GetTenantsByBuildingIdAsync(Guid buildingId);



    }
}
