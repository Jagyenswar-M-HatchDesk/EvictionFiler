using EvictionFiler.Application.DTOs.CourtDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICourtRepository
    {
        Task<List<Courts>> GetAllCourtDataAsync();
        public Task<Guid?> AddCourtAsync(CourtDto courtInfosDto);
        public Task<Courts> GetCourtByIdAsync(Guid id);
        public Task<bool> UpdateCourtAsync(CourtDto dto);
        public Task DeleteCourtAsync(Guid id);
        Task<PaginationDto<Courts>> GetPagedCourtsAsync(int pageNumber, int pageSize, string searchTerm);
    }
}
