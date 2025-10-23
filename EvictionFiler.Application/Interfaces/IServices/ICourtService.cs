using EvictionFiler.Application.DTOs.CourtDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICourtService
    {
        Task<List<CourtDto>> GetAllCourtDataAsync();

        public Task<Guid?> AddCourtAsync(CourtDto courtInfosDto);
        public Task<CourtDto> GetCourtByIdAsync(Guid id);
        public Task UpdateCourtAsync(CourtDto dto);
        public Task DeleteCourtAsync(Guid id);

        Task<PaginationDto<CourtDto>> GetAllCourtsAsync(
         int pageNumber,
    int pageSize,
    string searchTerm,
    string userId,
    bool isAdmin);
    }
}
