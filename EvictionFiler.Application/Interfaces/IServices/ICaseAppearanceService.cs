using EvictionFiler.Application.DTOs.CaseAppearanceDtos;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseAppearanceService
    {
        Task<bool> AddCaseAppearance(CaseAppearanceDto data);
        Task<List<CaseAppearanceDto>> GetAllCaseAppreance(Guid caseId);

        Task<bool> UpdateCaseAppreance(CaseAppearanceDto appearance);
    }
}
