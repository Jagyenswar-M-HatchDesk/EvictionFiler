using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Services
{
	public class LandlordService : ILandlordSevice
	{
		private readonly ILandLordRepository _landLordRepository;

		public LandlordService(ILandLordRepository landLordRepository)
		{
			_landLordRepository = landLordRepository;
		}

		public async Task<bool> AddLandLordAsync(List<CreateLandLordDto> dto)
		{
			var newlandlord = await _landLordRepository.AddLandLord(dto);
			return newlandlord;
		}
		public async Task<List<CreateLandLordDto>> SearchLandlordByCode(string code)
		{
			var newtenant = await _landLordRepository.SearchLandlordByCode(code);
			return newtenant;
		}

		public async Task<List<CreateLandLordDto>> GetAllLandLordsAsync()
		{
			var landlords = await _landLordRepository.GetAllLandLordsAsync();
			return landlords;
		}

		public async Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query, Guid clientId)
		{
			return await _landLordRepository.SearchLandlordsAsync(query, clientId);
		}

		public async Task<CreateLandLordDto?> GetLandLordByIdAsync(Guid id)
		{
			return await _landLordRepository.GetLandLordByIdAsync(id);
		}

		public async Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId)
		{
			return await _landLordRepository.GetLandlordWithBuildingsAsync(landlordId);
		}

		public async Task<List<EditLandlordDto>> GetLandlordsByClientIdAsync(Guid clientId)
		{
			var landlords = await _landLordRepository.GetByClientIdAsync(clientId);
			return landlords;


		}

		public async Task<bool> UpdateLandLordsAsync(List<EditLandlordDto> landlords)

		{
			var landlord = await _landLordRepository.UpdateLandLordsAsync(landlords);
			return landlord;


		}


		public async Task<List<TypeOfOwner>> GetAllOwner()
		{

			var states = await _landLordRepository.GetAllOwner();
			return states;
		}
	}
}
