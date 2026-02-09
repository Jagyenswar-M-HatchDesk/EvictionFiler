using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.BuildingDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IBuildingRepository : IRepository<Building>
    {
		Task<string?> GetLastBuildingCodeAsync();
        Task<List<EditToBuildingDto>> SearchBuilding(string searchText, Guid landlordId);

        Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id);
        Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId);
		Task<EditToBuildingDto> GetBuildingByIdAsync(Guid buildingId);
        Task<string> GenerateBuildingCodeAsync();

        Task<List<EditToBuildingDto>> GetBuildingsByClientIdAsync(Guid CLientid);
    }
}
