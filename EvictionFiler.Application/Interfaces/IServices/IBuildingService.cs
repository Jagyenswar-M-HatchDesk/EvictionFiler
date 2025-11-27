using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.BuildingDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface IBuildingService
	{
		Task<List<CreateToBuildingDto>> GetAll();
		Task<bool> AddApartmentAsync(List<CreateToBuildingDto> dto);
		Task<CreateToBuildingDto> GetByIdAsync(Guid id);
		Task<List<EditToBuildingDto>> SearchBuilding(string query, Guid landlordId);

        Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id);
		Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId);

        Task<bool> UpdateBuildingAsync(List<EditToBuildingDto> buildings);
		Task<string> GetLastBuilding();
		Task<EditToBuildingDto> GetBuildingByIdAsync(Guid buildingId);


		Task<Guid?> AddOnlyApartmentfromCase(CreateToBuildingDto appartment);
		Task<bool> UpdateonlyBuildingfromCase(EditToBuildingDto appartment);





    }
}
