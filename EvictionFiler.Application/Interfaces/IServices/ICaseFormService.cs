using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.DTOs.LandLordDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface ICaseFormService
	{
		Task<List<GenrateNoticeModel>> GetCaseFormsByCaseId(Guid caseId);
		Task<GenrateNoticeModel?> GetCaseFormByIdAsync(Guid id);
		Task<bool> DeleteDetailAsync(Guid id);

    }
}
