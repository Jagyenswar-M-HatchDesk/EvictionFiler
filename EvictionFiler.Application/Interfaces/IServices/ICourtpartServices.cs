using EvictionFiler.Application.DTOs.CourtPart;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICourtpartServices
    {
        Task<List<CourtPartDto>> GetAllCourtDataAsync();
        Task<PaginationDto<CourtPartDto>> GetAllCourtsAsync(
    int pageNumber,
    int pageSize,
    string searchTerm,
    string userId,
    bool isAdmin);

        Task<Guid?> AddCourtAsync(CourtPartDto courtInfosDto);
        Task<CourtPartDto> GetCourtByIdAsync(Guid id);
        Task UpdateCourtAsync(CourtPartDto dto);
        Task DeleteCourtAsync(Guid id);
        Task<List<Guid>?> AddCourtPartListAsync(List<CourtPartDto> courtInfosDto);
        Task<bool> SaveCourtPartList(List<CourtPartDto> dto, Guid id);
    }
}
