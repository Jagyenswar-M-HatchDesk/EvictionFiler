using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.CaseHearing;
using EvictionFiler.Application.DTOs.RemainderCenterDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public interface ICourtReadRepository:IReadRepository<Courts>
    {
        Task<CourtDetailDto> GetCourtDetailsAsync(Guid caseId);
        Task<List<CaseHearingDto>> GetCourtHearingDetailsAsync(Guid caseId);
        Task<List<EditToRemainderCenterDto>> GetRemainderDetailsAsync(Guid caseId);
    }
}
