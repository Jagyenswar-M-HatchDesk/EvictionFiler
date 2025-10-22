using EvictionFiler.Application.DTOs.CourtDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
   public  class CourtRepository:ICourtRepository
    {
        private readonly MainDbContext _mainDbContext;

        public CourtRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<Courts>> GetAllCourtDataAsync()
        {
            return await _mainDbContext.Courts.ToListAsync();
        }
        public async Task<PaginationDto<Courts>> GetPagedCourtsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _mainDbContext.Courts.AsQueryable();

            // Optional search
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    c.Court.Contains(searchTerm) ||
                    c.Address.Contains(searchTerm) ||
                    c.Phone.Contains(searchTerm) ||
                    c.Notes.Contains(searchTerm));
            }

            var totalCount = await query.CountAsync();

            var courts = await query
                .OrderBy(c => c.Court)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationDto<Courts>
            {
                Items = courts,
                TotalCount = totalCount
            };
        }

        public async Task AddCourtAsync(CourtDto courtInfosDto)
        {
            var entity = new Courts
            {
                Id = courtInfosDto.Id,
                Court = courtInfosDto.Court,
                Address = courtInfosDto.Address,
                Phone = courtInfosDto.Phone,
                Notes = courtInfosDto.Notes,
                RoomNo = courtInfosDto.RoomNo,
                ConferenceId = courtInfosDto.ConferenceId,
                CallIn = courtInfosDto.CallIn,
                VirtualLink = courtInfosDto.VirtualLink,
                Judge = courtInfosDto.Judge,
                Part = courtInfosDto.Part,
            };

            await _mainDbContext.Courts.AddAsync(entity);
            await _mainDbContext.SaveChangesAsync();
        }
        public async Task<Courts> GetCourtByIdAsync(Guid id)
        {

            return await _mainDbContext.Courts.FindAsync(id);


        }
        public async Task UpdateCourtAsync(CourtDto dto)
        {
            var entity = await _mainDbContext.Courts.FindAsync(dto.Id);
            if (entity == null) return;

            entity.Court = dto.Court;
            entity.Address = dto.Address;
            entity.Phone = dto.Phone;
            entity.Notes = dto.Notes;

            _mainDbContext.Courts.Update(entity);
            await _mainDbContext.SaveChangesAsync();
        }
        public async Task DeleteCourtAsync(Guid id)
        {
            var entity = await _mainDbContext.Courts.FindAsync(id);
            if (entity == null) return;

            _mainDbContext.Courts.Remove(entity);
            await _mainDbContext.SaveChangesAsync();
        }

    }
}
