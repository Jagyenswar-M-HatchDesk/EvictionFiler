using EvictionFiler.Application.DTOs.CourtDto;
using EvictionFiler.Application.DTOs.CourtPart;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CourtpartRepository : ICourtpartRepository
    {
        private readonly MainDbContext _mainDbContext;

        public CourtpartRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<CourtPart>> GetAllCourtDataAsync()
        {
            return await _mainDbContext.CourtPart.ToListAsync();
        }
        public async Task<PaginationDto<CourtPart>> GetPagedCourtsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _mainDbContext.CourtPart.Include(e => e.CourtId).AsQueryable();

            // Optional search
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    c.Part.Contains(searchTerm) ||
                    c.RoomNo.Contains(searchTerm) ||
                    c.ConferenceId.Contains(searchTerm) ||
                    c.Judge.Contains(searchTerm));
            }

            var totalCount = await query.CountAsync();

            var courts = await query
                .OrderBy(c => c.Part)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationDto<CourtPart>
            {
                Items = courts,
                TotalCount = totalCount
            };
        }

        public async Task<Guid?> AddCourtAsync(CourtPartDto courtInfosDto)
        {
            var entity = new CourtPart
            {
                Id = courtInfosDto.Id,

                RoomNo = courtInfosDto.RoomNo,
                ConferenceId = courtInfosDto.ConferenceId,
                CallIn = courtInfosDto.CallIn,
                VirtualLink = courtInfosDto.VirtualLink,
                Judge = courtInfosDto.Judge,
                Part = courtInfosDto.Part,
                CourtId = courtInfosDto.CourtId,
            };

            var court = _mainDbContext.CourtPart.Add(entity);
            var result = await _mainDbContext.SaveChangesAsync();
            if (result > 0) return entity.Id;

            return null;
        }

        public async Task<bool> AddCourtPartListAsync(List<CourtPartDto> courtInfosDto)
        {
            var courtdata = courtInfosDto.Select(e=> new CourtPart
            {
                Id = e.Id,

                RoomNo = e.RoomNo,
                ConferenceId = e.ConferenceId,
                CallIn = e.CallIn,
                VirtualLink = e.VirtualLink,
                Judge = e.Judge,
                Part = e.Part,
                CourtId = e.CourtId,
            });

            _mainDbContext.CourtPart.AddRange(courtdata);
            var result = await _mainDbContext.SaveChangesAsync();
            if (result > 0) return true;

            return false;
        }
        public async Task<CourtPart> GetCourtByIdAsync(Guid id)
        {

            return await _mainDbContext.CourtPart.FindAsync(id);


        }
        public async Task UpdateCourtAsync(CourtPartDto courtInfosDto)
        {
            var entity = await _mainDbContext.CourtPart.FindAsync(courtInfosDto.Id);
            if (entity == null) return;

            entity.RoomNo = courtInfosDto.RoomNo;
            entity.ConferenceId = courtInfosDto.ConferenceId;
            entity.CallIn = courtInfosDto.CallIn;
            entity.VirtualLink = courtInfosDto.VirtualLink;
            entity.Judge = courtInfosDto.Judge;
            entity.Part = courtInfosDto.Part;

            _mainDbContext.CourtPart.Update(entity);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveCourtPartListAsync(List<CourtPartDto> parts, Guid courtId)
        {
            // Load existing court parts for comparison
            var existingParts = await _mainDbContext.CourtPart
                .Where(x => x.CourtId == courtId)
                .ToListAsync();

            foreach (var dto in parts)
            {
                if (dto.Id == Guid.Empty)
                {
                    // NEW
                    var newPart = new CourtPart
                    {
                        Id = Guid.NewGuid(),               // Now assign ID
                        CourtId = courtId,
                        Part = dto.Part,
                        RoomNo = dto.RoomNo,
                        ConferenceId = dto.ConferenceId,
                        CallIn = dto.CallIn,
                        Tollfree = dto.Tollfree,
                        VirtualLink = dto.VirtualLink,
                        Judge = dto.Judge
                    };

                    await _mainDbContext.CourtPart.AddAsync(newPart);
                }
                else
                {
                    // UPDATE
                    var entity = existingParts.First(x => x.Id == dto.Id);

                    entity.Part = dto.Part;
                    entity.RoomNo = dto.RoomNo;
                    entity.ConferenceId = dto.ConferenceId;
                    entity.CallIn = dto.CallIn;
                    entity.Tollfree = dto.Tollfree;
                    entity.VirtualLink = dto.VirtualLink;
                    entity.Judge = dto.Judge;
                }
            }

            await _mainDbContext.SaveChangesAsync();
            return true;
        }


        public async Task DeleteCourtAsync(Guid id)
        {
            var entity = await _mainDbContext.CourtPart.FindAsync(id);
            if (entity == null) return;

            _mainDbContext.CourtPart.Remove(entity);
            await _mainDbContext.SaveChangesAsync();
        }
    }
}
