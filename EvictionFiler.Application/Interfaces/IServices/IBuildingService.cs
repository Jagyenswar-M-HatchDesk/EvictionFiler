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
		Task<List<EditToBuildingDto>> SearchBuildingByCode(string code, Guid landlordId);
		Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id);
		Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid clientId);
		Task<bool> UpdateBuildingAsync(List<EditToBuildingDto> buildings);
		
	}
}
