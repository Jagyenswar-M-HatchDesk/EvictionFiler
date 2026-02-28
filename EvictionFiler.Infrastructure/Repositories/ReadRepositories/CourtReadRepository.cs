using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public class CourtReadRepository : ReadRepository<Courts>, ICourtReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public CourtReadRepository(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<CourtDetailDto> GetCourtDetailsAsync(Guid caseId)
        {
            using var context = _contextFactory.CreateDbContext();
            var l= await context.LegalCases
                
                .Where(c => c.Id == caseId && c.IsDeleted != true)
                .Include(a => a.Courts)
                  .ThenInclude(b => b.County)
                .Include(a=> a.CourtPart)
                .Include(a=>a.CourtTypes)
                .FirstOrDefaultAsync();

            if (l == null) return null;

            return new CourtDetailDto
            {
                Id = l.Courts?.Id ?? Guid.Empty,
                Court = l.Courts?.Court,
                CourtTypeId = l.CourtTypeId,
                CourtPartId = l.CourtPart?.Id,
                CountryId = l.Courts?.County?.Id,
                 Country = l.Courts?.County?.Name,
                
                 CourtLocationId = l.CourtLocationId,
                 CourtLocation = l.Courts?.Address,
                CourtPart = l.CourtPart?.Part,
                CourtRoomNo = l.CourtPart?.RoomNo,
                Judge = l.CourtPart?.Judge,
                
                Index = l.Index
            };
        }
    }
}
