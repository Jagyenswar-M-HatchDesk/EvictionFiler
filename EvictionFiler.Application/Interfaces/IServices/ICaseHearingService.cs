using EvictionFiler.Application.DTOs.CaseHearing;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseHearingService
    {
        Task<bool> AddHearing(CaseHearingDto dto);
        Task<PaginationDto<CaseHearingDto>> GetAllCaseHeariingAsync(int pageNumber, int pageSize, string userId, bool isAdmin);
        Task<List<CaseHearingDto>> GetAllCaseHeariingByCaseIdAsync(Guid id);
        Task<int> GetAllTodayCaseHearingAsync();

        Task<IEnumerable<AppearanceMode>> GetAllModes();
        Task<IEnumerable<VirtualPlatform>> GetAllPlatform();
        Task<IEnumerable<AppearanceTypeforHearing>> GetAllAppearanceTypeForHearing();
    }
}
