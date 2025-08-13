using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.Services
{
	public class CaseFormService : ICaseFormService
	{
		private readonly ICaseFormRepository _caseFormRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CaseFormService(ICaseFormRepository caseFormRepository, IUnitOfWork unitOfWork)
		{
			_caseFormRepository = caseFormRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<List<GenrateNoticeModel>> GetCaseFormsByCaseId(Guid caseId)
		{
			var caseForms = await _caseFormRepository
				.GetAllQuerable(
					x => x.IsDeleted != true && x.LegalCaseId == caseId, 
					x => x.FormType!
				)
				.ToListAsync();

			var result = caseForms.Select(dto => new GenrateNoticeModel
			{
				Id = dto.Id,
				FormTypeName = dto.FormType?.Name ?? "",
				FormTypeId = dto.FormTypeId,
				File = dto.File,
				HTML = dto.HTML,
				CreatedOn = dto.CreatedOn,
			}).ToList();

			return result;
		}


		public async  Task<GenrateNoticeModel?> GetCaseFormByIdAsync(Guid id)
		{
			var dto = await _caseFormRepository.GetAsync(id);


			if (dto == null)
				return null;

			return new GenrateNoticeModel
			{

				FormTypeName = dto.FormType?.Name ?? "",
				FormTypeId = dto.FormTypeId,
				File = dto.File,
				HTML = dto.HTML,
				CreatedOn = dto.CreatedOn,
			};
		}
	}
}
