using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;

namespace EvictionFiler.Client.Services
{
    public class LandLordService
    {
        private readonly ILandLordRepository _landLordRepository;

        public LandLordService(ILandLordRepository landLordRepository)
        {
            _landLordRepository = landLordRepository;
        }

        public async Task<bool> AddLandLordAsync(CreateLandLordDto dto)
        {
            var newlandlord = await _landLordRepository.AddLandLord(dto);
            return newlandlord;
        }
        public async Task<List<CreateLandLordDto>> SearchLandlordByCode(string code)
        {
            var newtenant = await _landLordRepository.SearchLandlordByCode(code);
            return newtenant;
        }
    }
}
