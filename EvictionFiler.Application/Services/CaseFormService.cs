using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
	public class CaseFormService : ICaseFormService
	{
		private readonly ICaseFormRepository _caseFormRepository;
		private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;

        public CaseFormService(ICaseFormRepository caseFormRepository, IUnitOfWork unitOfWork , IUserRepository userRepo)
		{
			_caseFormRepository = caseFormRepository;
			_unitOfWork = unitOfWork;
            _userRepo = userRepo;
		}
        public async Task<List<GenrateNoticeModel>> GetCaseFormsByCaseId(Guid caseId, string userId, bool isAdmin)
        {
            var query = _caseFormRepository
                .GetAllQuerable(
                    x => x.IsDeleted != true && x.LegalCaseId == caseId,
                    x => x.FormType!
                );

            var users = await _userRepo.GetAllUser();
            var userDict = users.ToDictionary(u => u.Id, u => $"{u.FirstName} {u.MiddleName} {u.LastName}");

            if (!isAdmin)
            {
                query = query.Where(c => c.IsActive == true && c.IsDeleted == false);

                // ✅ Non-admin → Sirf apne hi clients dekhe
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var userGuid = Guid.Parse(userId);
                    query = query.Where(c => c.CreatedBy == userGuid);
                }
            }
            else
            {
                // ✅ Admin → Saare clients dikhenge, deleted + inactive bhi
                query = query.OrderByDescending(c => c.CreatedOn);
            }

            var result = query.Select(dto => new GenrateNoticeModel
            {
                Id = dto.Id,
                FormTypeName = dto.FormType.Name ?? "",
                FormTypeId = dto.FormTypeId,
                File = dto.File,
                HTML = dto.HTML,
                CreatedOn = dto.CreatedOn,
                CreatedByName = userDict.ContainsKey(dto.CreatedBy)
                            ? userDict[dto.CreatedBy]
                            : "Admin",
            }).OrderBy(e=>e.CreatedOn).ToList();

            return result;
        }



        public async  Task<bool> UpdateCaseFormAsync(GenrateNoticeModel dto)
		{
			var existing = await _caseFormRepository.GetAsync(dto.Id);
        
            if (existing == null) return false;

          
            existing.FormTypeId = dto.FormTypeId ;
            existing.File = dto.File;
            existing.HTML = dto.HTML;
        
            existing.CreatedOn = DateTime.Now;

            // Save changes
            _caseFormRepository.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;





        }

        public async Task<GenrateNoticeModel?> GetCaseFormByIdAsync(Guid id)
        {
            var dto = await _caseFormRepository.GetAsync(id);


            if (dto == null)
                return null;

            return new GenrateNoticeModel
            {
                Id = dto.Id,
                FormTypeName = dto.FormType?.Name ?? "",
                FormTypeId = dto.FormTypeId,
                File = dto.File,
                HTML = dto.HTML,
                CreatedOn = dto.CreatedOn,
            };
        }

        public async Task<bool> DeleteDetailAsync(Guid id)
        {
            var client = await _caseFormRepository.DeleteAsync(id);
            return client;
        }
    }
}
