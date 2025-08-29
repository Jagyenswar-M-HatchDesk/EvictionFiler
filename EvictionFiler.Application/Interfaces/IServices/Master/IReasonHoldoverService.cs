using EvictionFiler.Application.DTOs.MasterDtos.ReasonHoldoverDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IReasonHoldoverService
    {
        Task<bool> Create(EditToReasonHoldoverDto dto);
        Task<PaginationDto<EditToReasonHoldoverDto>> GetAllReasonHoldoverAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateReasonHoldoverAsync(EditToReasonHoldoverDto dto);
        Task<EditToReasonHoldoverDto?> GetReasonHoldoverByIdAsync(Guid? id);
        Task<bool> DeleteReasonHoldoverAsync(Guid id);
        
    }
}
