using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base;
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
                .Include(a => a.CourtLocation)
                  .ThenInclude(b => b.County)
                .Include(a=> a.CourtPart)
                .Include(a=>a.CourtTypes)
                .FirstOrDefaultAsync();

            if (l == null) return null;

            return new CourtDetailDto
            {
                Id = l.CourtLocation?.Id ?? Guid.Empty,
                Court = l.CourtLocation != null ? $"{l.CourtLocation?.Court}" : "",
                CourtTypeId = l.CourtTypeId != null ? l.CourtTypeId : null,
                CourtPartId = l.CourtPartId != null ? l.CourtPartId : null,
                CountryId = l.CourtLocation?.County?.Id,
                Country = l.CourtLocation?.County?.Name,

                CourtLocationId = l.CourtLocationId,
                CourtLocation = l.CourtLocation?.Address,
                CourtPart = l.CourtPart != null ? l.CourtPart?.Part : new string(l.CourtRoom?.Where(char.IsLetter).ToArray()),
                CourtRoomNo = l.CourtPart != null ? l.CourtPart?.RoomNo : new string(l.CourtRoom?.Where(char.IsDigit).ToArray()),
                Judge = l.CourtPart != null ? l.CourtPart?.Judge : l.ManagingAgent,

                Index = l.Index




                //Court = caseEntity.CourtLocation != null ? caseEntity.CourtLocation.Court! : "",
                //CourtAddress = caseEntity.CourtLocation != null ? caseEntity.CourtLocation.Address! : "",
                //CourtPartId = caseEntity.CourtPartId != null ? caseEntity.CourtPartId : null,
                //CourtPart = caseEntity.CourtPart != null ? caseEntity.CourtPart.Part : new string(caseEntity.CourtRoom.Where(char.IsLetter).ToArray()),
                //CourtRoom = caseEntity.CourtPart != null ? caseEntity.CourtPart.RoomNo : caseEntity.CourtRoom,
                //CourtRoomNo = caseEntity.CourtPart != null ? caseEntity.CourtPart.RoomNo : new string(caseEntity.CourtRoom.Where(char.IsDigit).ToArray()),
                //CourtLocationId = caseEntity.CourtLocationId,
                //CourtName = caseEntity.CourtLocation != null ? $"{caseEntity.CourtLocation.Court}" : "",
                //Judge = caseEntity.CourtPart != null ? caseEntity.CourtPart.Judge : caseEntity.ManagingAgent,
            };
        }
    }
}
