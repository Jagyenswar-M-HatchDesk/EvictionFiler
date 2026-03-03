using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.CaseHearing;
using EvictionFiler.Application.DTOs.RemainderCenterDto;
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
            var l = await context.LegalCases

                .Where(c => c.Id == caseId && c.IsDeleted != true)
                .Include(a => a.CourtLocation)
                  .ThenInclude(b => b.County)
                .Include(a => a.CourtPart)
                .Include(a => a.CourtTypes)
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
                CourtRoom = l.CourtRoom ?? string.Empty,
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
        public async Task<List<CaseHearingDto>> GetCourtHearingDetailsAsync(Guid caseId)
        {
            using var context = _contextFactory.CreateDbContext();
            var calanders = await context.CaseHearings.Include(e => e.LegalCase).Include(e => e.Courts)
                 .Where(x => x.IsDeleted != true && x.LegalCaseId == caseId).ToListAsync();

            var result = calanders.Select(dto => new CaseHearingDto
            {
                Id = dto.Id,

                HearingDate = dto.HearingDate ?? DateTime.Today,

                HearingTime = (dto.HearingTime == default || dto.HearingTime == TimeOnly.MinValue)
    ? TimeOnly.FromTimeSpan(TimeSpan.FromHours(9.5))
    : dto.HearingTime.Value,


                CourtId = dto.CourtId,
                LegalCaseId = dto.LegalCaseId,
                IndexNo = dto.IndexNo,
                Caption = dto.Caption,

                // CaseType name — safe whether CaseTypeId or LegalCaseId is null
                CaseTypeName =
        dto.CaseTypeId != null
            ? dto.CaseTypes.Name
            : dto.LegalCase.CaseType.Name ?? string.Empty,

                //        //        // Judge — prefer Hearing Judge, fallback to Court Judge
                //        //        Judge = dto.Judge
                //        //?? dto.Courts?.Judge
                //        //?? string.Empty,

                //        //        // Court part — from CourtPart or fallback to Court.Part
                //        //        CourtPart =
                //        //dto.CourtPartId != null
                //        //    ? dto.CourtParts?.Part
                //        //    : dto.Courts?.Part ?? string.Empty,

                //        // Case status name — only if present
                //        CaseStatusName =
                //dto.CaseStatusId != null
                //    ? dto.CaseStatus.Name
                //    : string.Empty,

                //        //        // Room number — prefer explicit RoomNo, fallback to Court’s RoomNo
                //        //        RoomNo = dto.RoomNo
                //        //?? dto.Courts?.RoomNo
                //        //?? string.Empty,

                //        // County name — safe for null CountyId
                //        CountyName =
                //dto.CountyId != null
                //    ? dto.Counties.Name
                //    : string.Empty,

                //        CreatedOn = dto.CreatedOn,
                //        LastAction = dto.LastAction,

            }).OrderBy(e => e.HearingDate).ToList();



            return result;
        }
        public async Task<List<EditToRemainderCenterDto>> GetRemainderDetailsAsync(Guid caseId)
        {
            using var context = _contextFactory.CreateDbContext();
            var list = await context.TblRemainderCenter.Include(b => b.RemainderType!).Where(e => e.CaseId == caseId).ToListAsync();


            //if (dto == null)
            //    return null;

            var result = list.Select(dto => new EditToRemainderCenterDto
            {
                Id = dto.Id,
                When = dto.When,
                CaseId = dto.CaseId,
                CountyId = dto.CountyId,
                TenantId = dto.TenantId,
                RemainderTypeId = dto.RemainderTypeId,
                Index = dto.Index,
                Notes = dto.Notes,
                RemainderTypeName = dto.RemainderType?.Name ?? "Unknown",
                CountyName = dto.County?.Name ?? "Unknown",
                TenantName = dto.Tenant?.FirstName ?? "Unknown",
                CaseCode = dto.Case?.Casecode ?? "Unknown",
                ReminderName = dto.ReminderName,
                ReminderCategoryId = dto.ReminderCategoryId,
                ReminderEscalateId = dto.ReminderEscalateId,
                ReminderCategoryName = dto.ReminderCategory != null ? dto.ReminderCategory.Name : string.Empty,
                ReminderEscalateName = dto.ReminderEscalates != null ? dto.ReminderEscalates.Name : string.Empty,
                IsComplete = dto.IsComplete,
            }).ToList();

            return result;



        }
    }
}
