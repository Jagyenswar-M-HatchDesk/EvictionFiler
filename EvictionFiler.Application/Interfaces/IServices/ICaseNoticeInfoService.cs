using EvictionFiler.Application.DTOs.CaseNoticeInfoDtos;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseNoticeInfoService
    {
        Task<Guid?> AddCaseNoticeInfo(CaseNoticeInfoDto dto);
        Task<Guid?> AddOrUpdateCaseNoticeInfo(CaseNoticeInfoDto dto);
        Task<List<CaseNoticeInfoDto>> GetAllCasenoticeInfo(Guid caseId);
    }
}
