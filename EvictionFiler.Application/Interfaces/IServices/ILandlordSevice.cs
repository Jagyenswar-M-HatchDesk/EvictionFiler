using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface ILandlordSevice
	{
		Task<bool> AddLandLordAsync(List<CreateLandLordDto> dto);
		Task<List<CreateLandLordDto>> GetAllLandLordsAsync();
		Task<List<TypeOfOwner>> GetAllOwner();
		Task<List<CreateLandLordDto>> SearchLandlordByCode(string code);
		Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query, Guid clientId);
		Task<CreateLandLordDto?> GetLandLordByIdAsync(Guid id);
		Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId);
		Task<List<EditLandlordDto>> GetLandlordsByClientIdAsync(Guid clientId);
		Task<bool> UpdateLandLordsAsync(List<EditLandlordDto> landlords);
	}
}
