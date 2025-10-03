using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface ILandlordSevice
	{
		Task<bool> AddLandLordAsync(List<CreateToLandLordDto> dto);
		Task<List<EditToLandlordDto>> GetAllLandLordsAsync();
		Task<CreateToLandLordDto?> GetLandLordByIdAsync(Guid id);
		Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query, Guid clientId);
		Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId);
		Task<List<EditToLandlordDto>> GetLandlordsByClientIdAsync(Guid? clientId);
		Task<bool> UpdateLandLordsAsync(List<EditToLandlordDto> landlords);
        Task<string> GetLastLandLordCode();
    }
}
