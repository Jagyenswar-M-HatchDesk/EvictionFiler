using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.CourtDto;
using EvictionFiler.Application.DTOs.CourtPart;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Polly;
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
            return await _mainDbContext.Courts.Include(e => e.CourtParts).OrderBy(e=>e.Court).Take(10).ToListAsync();
        }
        public async Task<PaginationDto<Courts>> GetPagedCourtsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _mainDbContext.Courts.Include(e=>e.County).Include(e=>e.CourtParts).AsQueryable();

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

        public async Task<Guid?> AddCourtAsync(CourtDto courtInfosDto)
        {
            var entity = new Courts
            {
                Id = courtInfosDto.Id,
                Court = courtInfosDto.Court,
                Address = courtInfosDto.Address,
                Phone = courtInfosDto.Phone,
                Notes = courtInfosDto.Notes,
                //RoomNo = courtInfosDto.RoomNo,
                //ConferenceId = courtInfosDto.ConferenceId,
                //CallIn = courtInfosDto.CallIn,
                //VirtualLink = courtInfosDto.VirtualLink,
                //Judge = courtInfosDto.Judge,
                //Part = courtInfosDto.Part,
                CountyId = courtInfosDto.CountyId,
            };

           var court = _mainDbContext.Courts.Add(entity);
            var result = await _mainDbContext.SaveChangesAsync();
            if (result > 0) return entity.Id;

            return null;
        }
        public async Task<Courts> GetCourtByIdAsync(Guid id)
        {

            return await _mainDbContext.Courts.Include(e=>e.CourtParts).Where(e=>e.Id == id).FirstOrDefaultAsync();


        }

        public async Task<List<CourtDto>> SearchCourt(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<CourtDto>();

            searchTerm = searchTerm.Trim().ToLower();

           

            var court = await _mainDbContext.Courts
                .Where(a =>
                    (a.Court != null && a.Court.ToLower().Contains(searchTerm))
                   
                )
                .Select(c => new CourtDto
                {
                    Id = c.Id,
                    Court = c.Court,
                    Address = c.Address,
                    Phone = c.Phone,
                    Notes = c.Notes,
                    //CallIn = c.CallIn,
                    //ConferenceId = c.ConferenceId,
                    //RoomNo = c.RoomNo,
                    //Judge = c.Judge,
                    //Part = c.Part,
                    //VirtualLink = c.VirtualLink,
                    CountyId = c.CountyId,
                    CourtPart = c.CourtParts.Select(e => new CourtPartDto
                    {
                        Id = e.Id,
                        CallIn = e.CallIn,
                        ConferenceId = e.ConferenceId,
                        RoomNo = e.RoomNo,
                        Part = e.Part,
                        Judge = e.Judge,
                        Tollfree = e.Tollfree,
                        VirtualLink = e.VirtualLink,
                        CourtId = e.CourtId,
                    }).ToList(),
                }).ToListAsync();

            return court ?? new List<CourtDto>();
        }
        public async Task<bool> UpdateCourtAsync(CourtDto dto)
        {
            var entity = await _mainDbContext.Courts.FindAsync(dto.Id);
            if (entity == null) return false;

            entity.Court = dto.Court;
            entity.Address = dto.Address;
            entity.Phone = dto.Phone;
            entity.Notes = dto.Notes;

            _mainDbContext.Courts.Update(entity);
            var result =await _mainDbContext.SaveChangesAsync();
            if(result > 0) return true;

            return false;
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
