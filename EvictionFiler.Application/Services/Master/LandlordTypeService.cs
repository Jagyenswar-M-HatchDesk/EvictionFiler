using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IServices.Master;
using EvictionFiler.Domain.Entities.Master;

using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.DTOs.MasterDtos.LandlordTypeDto;

namespace EvictionFiler.Application.Services.Master
{
    public class LandlordTypeService : ILandlordTypeService
    {
        private readonly ILandlordTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public LandlordTypeService(ILandlordTypeRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<bool> Create(EditToLandlordTypeDto dto)
        {
            var forms = new LandlordType
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

   

        public async Task<bool> DeleteLandlordTypeAsync(Guid id)
        {
            var form = await _repository.DeleteAsync(id);
            var deleterecordes = await _unitOfWork.SaveChangesAsync();
            if (deleterecordes > 0)
                return true;
            return false;
        }

      

        public async Task<PaginationDto<EditToLandlordTypeDto>> GetAllLandlordTypeAsync(int pageNumber, int pageSize, string searchTerm)
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
        .Select(x => new EditToLandlordTypeDto
        { 
            Id = x.Id,
            Name = x.Name,
            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
           
        })
        .ToList();

            return new PaginationDto<EditToLandlordTypeDto>
            {
                Items = forms,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }

      

        public async Task<EditToLandlordTypeDto?> GetLandlordTypeByIdAsync(Guid? id)
        {
            var form = await _repository.GetAsync(id);

            if (form == null) return null;
            return new EditToLandlordTypeDto
            {
                Id = form.Id,
                Name = form.Name,
                CreatedOn = form.CreatedOn,
                CreatedBy = form.CreatedBy,
                IsActive = form.IsActive,
                IsDeleted = form.IsDeleted,

            };
        }

  

        public async  Task<bool> UpdateLandlordTypeAsync(EditToLandlordTypeDto dto)
        {
            var existing = await _repository.GetAsync(dto.Id);
            if (existing == null) return false;

            // Pehle existing legal LandlordType fields update karo (already hai)
            existing.Name = dto.Name;
            existing.CreatedOn = DateTime.Now;

            // Save changes
            _repository.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
