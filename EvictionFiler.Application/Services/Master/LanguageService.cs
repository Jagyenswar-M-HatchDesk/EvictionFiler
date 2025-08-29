
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IServices.Master;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.DTOs.MasterDtos.LanguageDto;

namespace EvictionFiler.Application.Services.Master
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public LanguageService(ILanguageRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<bool> Create(EditToLanguageDto dto)
        {
            var forms = new Language
            {

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

        public async Task<bool> DeleteLanguageAsync(Guid id)
        {
            var form = await _repository.DeleteAsync(id);
            var deleterecordes = await _unitOfWork.SaveChangesAsync();
            if (deleterecordes > 0)
                return true;
            return false;
        }

        public async Task<PaginationDto<EditToLanguageDto>> GetAllLanguageAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = await _repository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearch = searchTerm.ToLower();
                query = query.Where(form =>                  
                      (form.Name ?? "").ToLower().Contains(lowerSearch)

                 );

            }


            var totalCount = query.Count();

            var forms = query
        .OrderBy(c => c.Id)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(x => new EditToLanguageDto
        {
            Id = x.Id,
            Name = x.Name,
            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
           
        })
        .ToList();

            return new PaginationDto<EditToLanguageDto>
            {
                Items = forms,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }

        public async Task<EditToLanguageDto?> GetLanguageByIdAsync(Guid? id)
        {
            var form = await _repository.GetAsync(id);

            if (form == null) return null;
            return new EditToLanguageDto
            {
                Id = form.Id,
                Name = form.Name,
                CreatedOn = form.CreatedOn,
                CreatedBy = form.CreatedBy,
                IsActive = form.IsActive,
                IsDeleted = form.IsDeleted,

            };
        }

     

        public async  Task<bool> UpdateLanguageAsync(EditToLanguageDto dto)
        {
            var existing = await _repository.GetAsync(dto.Id);
            if (existing == null) return false;

            // Pehle existing legal case fields update karo (already hai)
            existing.Name = dto.Name;
            existing.CreatedOn = DateTime.Now;

            // Save changes
            _repository.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
