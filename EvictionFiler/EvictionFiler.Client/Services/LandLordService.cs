using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Client.Services
{
    public class LandLordService
    {
        private readonly ILandLordRepository _landLordRepository;

        public LandLordService(ILandLordRepository landLordRepository)
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

		public async Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query)
		{
			return await _landLordRepository.SearchLandlordsAsync(query);
		}

		public async Task<CreateLandLordDto?> GetLandLordByIdAsync(Guid id)
		{
			return await _landLordRepository.GetLandLordByIdAsync(id);
		}


	}
}
