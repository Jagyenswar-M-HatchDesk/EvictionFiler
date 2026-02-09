using EvictionFiler.Application.DTOs.FormTypeDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface ICaseFormService
	{
		Task<List<GenrateNoticeModel>> GetCaseFormsByCaseId(Guid caseId, string userId, bool isAdmin);
		Task<GenrateNoticeModel?> GetCaseFormByIdAsync(Guid id);
		Task<bool> DeleteDetailAsync(Guid id);
		Task<bool> UpdateCaseFormAsync(GenrateNoticeModel dto);

		Task<List<GenrateNoticeModel>> GetCaseFormsPathByCaseId(Guid caseId);


    }
}
