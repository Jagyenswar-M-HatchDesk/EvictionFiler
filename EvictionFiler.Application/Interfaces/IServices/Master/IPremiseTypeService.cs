using EvictionFiler.Application.DTOs.MasterDtos.PremiseTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IPremiseTypeService
    {
        Task<bool> Create(EditToPremiseTypeDto dto);
        Task<PaginationDto<EditToPremiseTypeDto>> GetAllPremiseTypeAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdatePremiseTypeAsync(EditToPremiseTypeDto dto);

        Task<EditToPremiseTypeDto?> GetPremiseTypeByIdAsync(Guid? id);
        Task<bool> DeletePremiseTypeAsync(Guid id);
        
    }
}
