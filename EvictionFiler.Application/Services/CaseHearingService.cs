using EvictionFiler.Application.DTOs.CalanderDto;
using EvictionFiler.Application.DTOs.CaseHearing;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class CaseHearingService : ICaseHearingService
    {

        private readonly ICaseHearingRepository _caseHearingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;

        public CaseHearingService(ICaseHearingRepository caseHearingRepository, IUnitOfWork unitOfWork, IUserRepository userRepo)
        {
            _caseHearingRepository = caseHearingRepository;
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
        }
        public async Task<bool> AddHearing(CaseHearingDto dto)
        {
            var calander = new CaseHearing()
            {
                Id = dto.Id,
                HearingDate = dto.HearingDate,
                HearingTime = dto.HearingTime,
                CourtId = dto.CourtId,
                LegalCaseId = dto.LegalCaseId,
                IndexNo = dto.IndexNo,
                Caption = dto.Caption,
                CaseStatusId = dto.CaseStatusId,
                CountyId = dto.CountyId,
                CourtPartId = dto.CourtPartId,
                Judge = dto.Judge,
                RoomNo = dto.RoomNo,
                CaseTypeId = dto.CaseTypeId,
                CreatedOn = DateTime.Now,
                CreatedBy = dto.CreatedBy,


            };
            await _caseHearingRepository.AddAsync(calander);

            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;

        }
        public async Task<int> GetAllTodayCaseHearingAsync()
        {
            var calanders = await _caseHearingRepository
                  .GetAllQuerable(x => x.HearingDate.HasValue && x.HearingDate.Value.Date == DateTime.Today)
                  .CountAsync();
            return calanders;
        }
        public async Task<List<CaseHearingDto>> GetAllCaseHeariingAsync()
        {
            var calanders = await _caseHearingRepository
                  .GetAllQuerable(x => x.IsDeleted != true, x => x.LegalCase, x => x.Courts, x => x.LegalCase.CaseType)
                  .ToListAsync();

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
            ? dto.CaseTypes?.Name
            : dto.LegalCase?.CaseType?.Name ?? string.Empty,

        //        // Judge — prefer Hearing Judge, fallback to Court Judge
        //        Judge = dto.Judge
        //?? dto.Courts?.Judge
        //?? string.Empty,

        //        // Court part — from CourtPart or fallback to Court.Part
        //        CourtPart =
        //dto.CourtPartId != null
        //    ? dto.CourtParts?.Part
        //    : dto.Courts?.Part ?? string.Empty,

        //        // Case status name — only if present
        //        CaseStatusName =
        //dto.CaseStatusId != null
        //    ? dto.CaseStatus?.Name
        //    : string.Empty,

        //        // Room number — prefer explicit RoomNo, fallback to Court’s RoomNo
        //        RoomNo = dto.RoomNo
        //?? dto.Courts?.RoomNo
        //?? string.Empty,

                // County name — safe for null CountyId
                CountyName =
        dto.CountyId != null
            ? dto.Counties?.Name
            : string.Empty
            }).ToList();


            return result;
        }

        public async Task<List<CaseHearingDto>> GetAllCaseHeariingByCaseIdAsync(Guid id)
        {
            var calanders = await _caseHearingRepository
                  .GetAllQuerable(x => x.IsDeleted != true && x.LegalCaseId == id, x => x.LegalCase , x =>x.Courts )
                  .ToListAsync();

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
            ? dto.CaseTypes?.Name
            : dto.LegalCase?.CaseType?.Name ?? string.Empty,

        //        // Judge — prefer Hearing Judge, fallback to Court Judge
        //        Judge = dto.Judge
        //?? dto.Courts?.Judge
        //?? string.Empty,

        //        // Court part — from CourtPart or fallback to Court.Part
        //        CourtPart =
        //dto.CourtPartId != null
        //    ? dto.CourtParts?.Part
        //    : dto.Courts?.Part ?? string.Empty,

                // Case status name — only if present
                CaseStatusName =
        dto.CaseStatusId != null
            ? dto.CaseStatus?.Name
            : string.Empty,

        //        // Room number — prefer explicit RoomNo, fallback to Court’s RoomNo
        //        RoomNo = dto.RoomNo
        //?? dto.Courts?.RoomNo
        //?? string.Empty,

                // County name — safe for null CountyId
                CountyName =
        dto.CountyId != null
            ? dto.Counties?.Name
            : string.Empty,

                CreatedOn = dto.CreatedOn,

            }).ToList();



            return result;
        }
    }
}
