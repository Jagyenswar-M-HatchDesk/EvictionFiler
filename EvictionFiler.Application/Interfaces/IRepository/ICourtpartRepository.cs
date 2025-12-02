using EvictionFiler.Application.DTOs.CourtPart;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICourtpartRepository
    {
        Task<List<CourtPart>> GetAllCourtDataAsync();
        Task<PaginationDto<CourtPart>> GetPagedCourtsAsync(int pageNumber, int pageSize, string searchTerm);
        Task<Guid?> AddCourtAsync(CourtPartDto courtInfosDto);
        Task<CourtPart> GetCourtByIdAsync(Guid id);
        Task UpdateCourtAsync(CourtPartDto courtInfosDto);
        Task DeleteCourtAsync(Guid id);
        Task<List<Guid>?> AddCourtPartListAsync(List<CourtPartDto> courtInfosDto);
        Task<bool> SaveCourtPartListAsync(List<CourtPartDto> parts, Guid courtId);
    }
}
