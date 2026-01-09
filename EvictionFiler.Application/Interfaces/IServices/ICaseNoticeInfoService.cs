using EvictionFiler.Application.DTOs.CaseNoticeInfoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseNoticeInfoService
    {
        Task<Guid?> AddCaseNoticeInfo(CaseNoticeInfoDto dto);
        Task<Guid?> AddOrUpdateCaseNoticeInfo(CaseNoticeInfoDto dto);
        Task<List<CaseNoticeInfoDto>> GetAllCasenoticeInfo(Guid caseId);
    }
}
