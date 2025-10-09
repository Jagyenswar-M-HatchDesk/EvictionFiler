

using EvictionFiler.Application.DTOs.MasterDtos.CourtPartDto;
using EvictionFiler.Application.DTOs.MasterDtos.CourtPartDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ICourtPartService
    {
        Task<bool> Create(EditToCourtPartDto dto);
        Task<PaginationDto<EditToCourtPartDto>> GetAllCourtPartAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateCourtPartAsync(EditToCourtPartDto dto);

        Task<EditToCourtPartDto?> GetCourtPartByIdAsync(Guid? id);
        Task<bool> DeleteCourtPartAsync(Guid id);
        
    }
}
