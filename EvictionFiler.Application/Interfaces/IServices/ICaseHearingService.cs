using EvictionFiler.Application.DTOs.CaseHearing;
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
    }
}
