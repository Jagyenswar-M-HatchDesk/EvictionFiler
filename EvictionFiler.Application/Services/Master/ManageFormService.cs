using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services.Master
{
    public class ManageFormService : IManageFormService
    {
        private readonly IManageFormRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ManageFormService(IManageFormRepository repository  , IUnitOfWork unitOfWork) 
        { 
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FormAddEditViewModelDto>> GetAllFormAsync()
        {
            var forms = await _repository.GetAllForm();
            var result = forms.Select(x => new FormAddEditViewModelDto
            {
                Name = x.Name,
                CaseType = x.CaseType,
                CaseTypeId = x.CaseTypeId,
                HTML = x.HTML,
                Id = x.Id,
                
            }).ToList();
            return result;
        }

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllFormAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                x => x.IsDeleted != true,
                    x => x.CaseType,
                    x => x.Category
               );

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearch = searchTerm.ToLower();
                query = query.Where(form =>
                       (form.CaseType.Name ?? "").ToLower().Contains(lowerSearch) ||
                      (form.Name ?? "").ToLower().Contains(lowerSearch)

                 );

            }


            var totalCount = query.Count();

            var forms = query
        .OrderBy(c => c.Id)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(x => new FormAddEditViewModelDto
        {
            Name = x.Name,
            CaseType = x.CaseType,
            CaseTypeId = x.CaseTypeId,
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "Common",
            CategoryName = x.Category != null ? x.Category.Name : "-",
            HTML = x.HTML,
            CreatedOn = x.CreatedOn,
            Id = x.Id,
        })
        .ToList();

            return new PaginationDto<FormAddEditViewModelDto>
            {
                Items = forms,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }

        public async Task<bool> CreateForm(FormAddEditViewModelDto dto)
        {
        
            var forms = new FormTypes
            {
                
                HTML= dto.HTML,
                CaseTypeId = dto.CaseTypeId,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                CreatedOn = DateTime.Now,

            };
            await _repository.AddAsync(forms);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<FormAddEditViewModelDto?> GetFormByIdAsync(Guid? id)
        {
            var form = await _repository.GetAsync(id);

            if (form == null) return null;
            return new FormAddEditViewModelDto
            {
                Id = form.Id,
                HTML = form.HTML,
                CaseTypeId = form.CaseTypeId,
                CategoryId = form.CategoryId,
                Name = form.Name,
                CreatedOn = form.CreatedOn,

            };
        }


        public async Task<bool> DeleteFormAsync(Guid id)
        {
            var form = await _repository.DeleteAsync(id);
            var deleterecordes = await _unitOfWork.SaveChangesAsync();
            if (deleterecordes > 0)
                return true;
            return false;
        }

        public async Task<bool> UpdateFormAsync(FormAddEditViewModelDto form)
        {
            var existing = await _repository.GetAsync(form.Id);
            if (existing == null) return false;

            // Pehle existing legal case fields update karo (already hai)
            existing.HTML = form.HTML;
            existing.CaseTypeId = form.CaseTypeId;
            existing.Name = form.Name;
            existing.CategoryId = form.CategoryId;
            existing.CreatedOn = DateTime.Now;

            // Save changes
            _repository.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }


    }
}
