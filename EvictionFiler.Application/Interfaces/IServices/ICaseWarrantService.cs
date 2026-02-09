using EvictionFiler.Application.DTOs.CaseWarrantDtos;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseWarrantService
    {
        Task<bool> AddCaseWarrant(CaseWarrantDto dto);
        Task<CaseWarrantDto> GetWarrantDetails(Guid caseId);
    }
}
