using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.BuildingDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IBuildingRepository : IRepository<Building>
    {
		Task<string?> GetLastBuildingCodeAsync();
        Task<List<EditToBuildingDto>> SearchBuildingByCode(string code, Guid landlordId, Guid excludeBuildingId);
		Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id);
        Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId);
		Task<EditToBuildingDto> GetBuildingByIdAsync(Guid buildingId);

	}
}
