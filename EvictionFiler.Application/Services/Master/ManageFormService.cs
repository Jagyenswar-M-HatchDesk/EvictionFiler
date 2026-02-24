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


        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllFormAsync(int pageNumber, int pageSize, string searchTerm, Guid? FirmId)
        {
            var query = _repository.GetAllQuerable
                (
                x => x.IsDeleted != true ,
                    x => x.CaseType,
                    x => x.Category,
                    x=>x.Firms
               );

            if(FirmId != null  && FirmId != Guid.Empty)
            {
                query = query.Where(x => x.FirmId == FirmId || x.FirmId == null);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearch = searchTerm.ToLower();
                query = query.Where(form =>
                       (form.CaseType.Name ?? "").ToLower().Contains(lowerSearch) ||
                      (form.Category.Name ?? "").ToLower().Contains(lowerSearch) ||
                      (form.Firms.Name ?? "").ToLower().Contains(lowerSearch) ||
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
            CategoryName = x.Category != null ? x.Category.Name : "-",
            HTML = x.HTML,
            CreatedOn = x.CreatedOn,
            Id = x.Id,
            FirmId = x.FirmId,
            FirmName = x.Firms != null ? x.Firms.Name : "Generic",
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

        public async Task<List<FormAddEditViewModelDto>> GetAllFormByCategoryAsync()
        {
            var query = _repository.GetAllQuerable
                (
                x => x.IsDeleted != true,
                    x => x.CaseType,
                    x => x.Category
               );

            


            var forms = query
        .Select(x => new FormAddEditViewModelDto
        {
            Name = x.Name.Trim(),
            CaseType = x.CaseType,
            CaseTypeId = x.CaseTypeId,
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
            CategoryName = x.Category != null ? x.Category.Name : "-",
            HTML = x.HTML,
            CreatedOn = x.CreatedOn,
            Id = x.Id,
            CategoryId = x.FormCategoryId,
            UnitId = x.UnitId,
            Code = x.Code ?? "-",
            Rate = x.Rate ?? "-" ,
            FirmId = x.FirmId,
            UnitName = x.Units != null ? x.Units.Name : "-",
            
        })
        .ToList();

            return forms;
        }

        public async Task<bool> CreateForm(FormAddEditViewModelDto dto)
        {
        
            var forms = new FormTypes
            {
                
                HTML= dto.HTML,
                CaseTypeId = dto.CaseTypeId,
                FormCategoryId = dto.CategoryId,
                Name = dto.Name,
                FirmId = dto.FirmId,
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
            var form = await _repository.FindAsync(e=>e.Id ==id, a=>a.Firms!);

            if (form == null) return null;
            return new FormAddEditViewModelDto
            {
                Id = form.Id,
                HTML = form.HTML,
                CaseTypeId = form.CaseTypeId,
                CategoryId = form.FormCategoryId,
                Name = form.Name,
                CreatedOn = form.CreatedOn,
                FirmId = form.FirmId,
                FirmName = form.Firms?.Name
            };
        }


        public async Task<bool> DeleteFormAsync(Guid id)
        {
            var form = await _repository.SoftDeleteAsync(id);
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
            existing.FormCategoryId = form.CategoryId;
            existing.UpdatedOn = DateTime.Now;
            if(form.FirmId != null && form.FirmId != Guid.Empty) existing.FirmId = form.FirmId;

            // Save changes
            _repository.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateFormFeeAsync(FormAddEditViewModelDto form)
        {
            var existing = await _repository.GetAsync(form.Id);
            if (existing == null) return false;

            // Pehle existing legal case fields update karo (already hai)
            existing.Code = form.Code;
            existing.UnitId = form.UnitId;
            existing.Rate = form.Rate;
            existing.UpdatedOn = DateTime.Now;

            // Save changes
             _repository.UpdateAsync(existing);
            var result = await _unitOfWork.SaveChangesAsync();
            if(result > 0) return true;

            return false;
        }
        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllAffidavaitAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "affidavits of service",
                    x => x.CaseType,
                    x => x.Category
               );

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearch = searchTerm.ToLower();
                query = query.Where(form =>
                (form.Name ?? "").ToLower().StartsWith(lowerSearch) ||
                       (form.CaseType.Name ?? "").ToLower().StartsWith(lowerSearch) 
                      

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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllAppealsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "appeals",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllHoldoverAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "hold over",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllMotionAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "motions and orders to show cause ",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllNonMilitaryAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "non-Military affidavit of investigation",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllNonPaymentAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "non-payment",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllNoticeOfEntryAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "notice of entry",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllStipulationsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "stipulations",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllTenantAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "tenants",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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

        public async Task<PaginationDto<FormAddEditViewModelDto>> GetAllWarrantsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _repository.GetAllQuerable
                (
                    x => x.IsDeleted != true && x.Category != null && x.Category.Name.ToLower() == "warrants",
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
            CaseTypeName = x.CaseType != null ? x.CaseType.Name : "-",
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


    }
}
