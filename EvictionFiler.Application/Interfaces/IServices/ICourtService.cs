using EvictionFiler.Application.DTOs.CourtDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICourtService
    {
        Task<List<CourtDto>> GetAllCourtDataAsync();

        public Task<Guid?> AddCourtAsync(CourtDto courtInfosDto);
        public Task<CourtDto> GetCourtByIdAsync(Guid id);
        public Task<bool> UpdateCourtAsync(CourtDto dto);
        public Task DeleteCourtAsync(Guid id);
       public Task<List<CourtDto>> SearchCourt(string searchTerm);

        Task<PaginationDto<CourtDto>> GetAllCourtsAsync(
         int pageNumber,
    int pageSize,
    string searchTerm,
    string userId,
    bool isAdmin);
    }
}
