using EvictionFiler.Application.DTOs.CaseHearing;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseHearingService
    {
        Task<bool> AddHearing(CaseHearingDto dto);
        Task<List<CaseHearingDto>> GetAllCaseHeariingAsync();
        Task<List<CaseHearingDto>> GetAllCaseHeariingByCaseIdAsync(Guid id);
        Task<int> GetAllTodayCaseHearingAsync();

        Task<IEnumerable<AppearanceMode>> GetAllModes();
        Task<IEnumerable<VirtualPlatform>> GetAllPlatform();
    }
}
