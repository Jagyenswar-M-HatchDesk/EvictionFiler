using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;


namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ICaseTypeService
    {
        Task<bool> Create(EditToCaseTypeDto dto);
        Task<PaginationDto<EditToCaseTypeDto>> GetAllCaseTypeAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateCaseTypeAsync(EditToCaseTypeDto dto);

        Task<EditToCaseTypeDto?> GetCaseTypeByIdAsync(Guid? id);
        Task<bool> DeleteCaseTypeAsync(Guid id);
        
    }
}
