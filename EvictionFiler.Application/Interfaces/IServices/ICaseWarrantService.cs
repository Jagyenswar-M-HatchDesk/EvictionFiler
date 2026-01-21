using EvictionFiler.Application.DTOs.CaseWarrantDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseWarrantService
    {
        Task<bool> AddCaseWarrant(CaseWarrantDto dto);
        Task<CaseWarrantDto> GetWarrantDetails(Guid caseId);
    }
}
