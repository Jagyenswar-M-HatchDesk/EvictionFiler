using EvictionFiler.Application.DTOs.CalanderDto;
using EvictionFiler.Application.DTOs.CaseHearing;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
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
        private readonly IAppearanceModeRepository _modeRepository;
        private readonly IVirtualPlatformRepository _virtualRepository;
        private readonly IAppearanceTypeForHearingRepository _appearanceTypeForHearingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;

        public CaseHearingService(ICaseHearingRepository caseHearingRepository, IAppearanceTypeForHearingRepository appearanceTypeForHearingRepository, IAppearanceModeRepository modeRepository, IVirtualPlatformRepository virtualRepository, IUnitOfWork unitOfWork, IUserRepository userRepo)
        {
            _caseHearingRepository = caseHearingRepository;
            _modeRepository = modeRepository;
            _virtualRepository = virtualRepository;
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
            _appearanceTypeForHearingRepository = appearanceTypeForHearingRepository;
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
                AppearanceModeId = dto.AppearanceModeId,
                AppearanceTypeForHearingId = dto.AppearanceTypeForHearingId,
                VirtualPlatformId = dto.VirtualPlatformId,
                LastAction = dto.LastAction,



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
        //    public async Task<PaginationDto<CaseHearingDto>> GetAllCaseHeariingAsync(int pageNumber, int pageSize, string userId, bool isAdmin)
        //    {
        //        var calanders = await _caseHearingRepository
        //              .GetAllQuerable(x => x.IsDeleted != true, x => x.LegalCase,x=>x.CaseTypes, x=>x.AppearanceTypeforHearing, x=>x.Courts.County, x=>x.CourtParts ,  x => x.Courts, x => x.LegalCase.CaseType , x=>x.LegalCase.LandLords , x=>x.LegalCase.Tenants)
        //              .ToListAsync();

        //        var result = calanders.Select(dto => new CaseHearingDto
        //        {
        //            Id = dto.Id,

        //            HearingDate = dto.HearingDate ?? DateTime.Today,

        //            HearingTime = (dto.HearingTime == default || dto.HearingTime == TimeOnly.MinValue)
        //? TimeOnly.FromTimeSpan(TimeSpan.FromHours(9.5))
        //: dto.HearingTime.Value,


        //            CourtId = dto.CourtId,
        //            LegalCaseId = dto.LegalCaseId,
        //            IndexNo = dto.LegalCase != null ? dto.LegalCase.Index : "",
        //            CaseTypeId = dto.LegalCase.CaseTypeId,


        //            // CaseType name — safe whether CaseTypeId or LegalCaseId is null
        //            CaseTypeName =
        //           dto.CaseTypeId != null
        //        ? dto.CaseTypes?.Name
        //        : dto.LegalCase?.CaseType?.Name ?? string.Empty,

        //            // Judge — prefer Hearing Judge, fallback to Court Judge
        //            Judge = dto.CourtParts != null
        //            ? dto.CourtParts?.Judge
        //            : string.Empty,

        //            // Court part — from CourtPart or fallback to Court.Part
        //            CourtPart =
        //            dto.CourtPartId != null
        //                ? dto.CourtParts?.Part
        //                : string.Empty,
        //            CourtPartId = dto.CourtPartId,

        //            // Case status name — only if present
        //            CaseStatusName =
        //            dto.CaseStatusId != null
        //                ? dto.CaseStatus?.Name
        //                : string.Empty,

        //            AppearanceTypeForHearinname =
        //            dto.AppearanceTypeForHearingId != null
        //                ? dto.AppearanceTypeforHearing?.Name
        //                : string.Empty,

        //            // Room number — prefer explicit RoomNo, fallback to Court’s RoomNo
        //            RoomNo = dto.CourtParts != null
        //            ? dto.CourtParts?.RoomNo
        //            : string.Empty,

        //            // County name — safe for null CountyId
        //            CountyName =
        //    dto.Courts.County.Name != null
        //        ? dto.Courts.County.Name
        //        : string.Empty,

        //            LandlordName = dto.LegalCase?.LandLords != null
        //    ? $"{dto.LegalCase.LandLords.FirstName} {dto.LegalCase.LandLords.LastName}"
        //    : string.Empty,

        //            TenantName = dto.LegalCase?.Tenants != null
        //    ? $"{dto.LegalCase.Tenants.FirstName} {dto.LegalCase.Tenants.LastName}"
        //    : string.Empty,
        //            LastAction = dto.LastAction,
        //            CountyId = dto.Courts.CountyId,


        //            CreatedOn = dto.CreatedOn,

        //        }).ToList();


        //        return result;
        //    }

        public async Task<PaginationDto<CaseHearingDto>> GetAllCaseHeariingAsync(
    int pageNumber,
    int pageSize,
    string userId,
    bool isAdmin)
        {
            // 🔹 SAME SOURCE – bas Queryable rakha
            var query = _caseHearingRepository
                .GetAllQuerable(
                    x => x.IsDeleted != true,
                    x => x.LegalCase,
                    x => x.CaseTypes,
                    x => x.AppearanceTypeforHearing,
                    x => x.Courts.County,
                    x => x.CourtParts,
                    x => x.Courts,
                    x => x.LegalCase.CaseType,
                    x => x.LegalCase.LandLords,
                    x => x.LegalCase.Tenants
                )
                .AsQueryable();



            // 🔹 Total count (pagination)
            var totalCount = await query.CountAsync();

            // 🔹 SAME DTO mapping (unchanged)
            var items = await query
                .OrderByDescending(x => x.CreatedOn)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(dto => new CaseHearingDto
                {
                    Id = dto.Id,
                    HearingDate = dto.HearingDate ?? DateTime.Today,

                    HearingTime =
                        (dto.HearingTime == default || dto.HearingTime == TimeOnly.MinValue)
                            ? TimeOnly.FromTimeSpan(TimeSpan.FromHours(9.5))
                            : dto.HearingTime!.Value,

                    CourtId = dto.CourtId,
                    CourtLocationId = dto.CourtId,

                    LegalCaseId = dto.LegalCaseId,
                    IndexNo = dto.LegalCase != null ? dto.LegalCase.Index : "",
                    CaseTypeId = dto.LegalCase!.CaseTypeId,

                    CaseTypeName =
                        dto.CaseTypeId != null
                            ? dto.CaseTypes!.Name
                            : dto.LegalCase!.CaseType!.Name ?? string.Empty,

                    Judge = dto.CourtParts != null ? dto.CourtParts.Judge : string.Empty,

                    CourtPart = dto.CourtPartId != null
                        ? dto.CourtParts!.Part
                        : string.Empty,

                    CourtPartId = dto.CourtPartId,

                    CaseStatusName =
                        dto.CaseStatusId != null
                            ? dto.CaseStatus!.Name
                            : string.Empty,

                    AppearanceTypeForHearinname =
                        dto.AppearanceTypeForHearingId != null
                            ? dto.AppearanceTypeforHearing!.Name
                            : string.Empty,

                    RoomNo = dto.CourtParts != null
                        ? dto.CourtParts!.RoomNo
                        : string.Empty,

                    CountyName = dto.Courts.County.Name ?? string.Empty,

                    LandlordName = dto.LegalCase!.LandLords != null
                        ? $"{dto.LegalCase.LandLords.FirstName} {dto.LegalCase.LandLords.LastName}"
                        : string.Empty,

                    TenantName = dto.LegalCase!.Tenants != null
                        ? $"{dto.LegalCase.Tenants.FirstName} {dto.LegalCase.Tenants.LastName}"
                        : string.Empty,

                    LastAction = dto.LastAction,
                    CountyId = dto.Courts.CountyId,
                    CreatedOn = dto.CreatedOn,
                    OpposingAttorney =
                                dto.LegalCase.OppAttorneyname != null
                                    ? dto.LegalCase.OppAttorneyFirm != null
                                        ? $"{dto.LegalCase.OppAttorneyname}, {dto.LegalCase.OppAttorneyFirm}"
                                        : dto.LegalCase.OppAttorneyname
                                    : string.Empty,
                })
                .ToListAsync();


            return new PaginationDto<CaseHearingDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }



        public async Task<List<CaseHearingDto>> GetAllCaseHeariingByCaseIdAsync(Guid id)
        {
            var calanders = await _caseHearingRepository
                  .GetAllQuerable(x => x.IsDeleted != true && x.LegalCaseId == id, x => x.LegalCase, x => x.Courts)
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
                LastAction = dto.LastAction,

            }).OrderBy(e => e.HearingDate).ToList();



            return result;
        }

        public async Task<IEnumerable<AppearanceMode>> GetAllModes()
        {
            var modes = await _modeRepository.GetAllAsync1();
            return modes;
        }

        public async Task<IEnumerable<AppearanceTypeforHearing>> GetAllAppearanceTypeForHearing()
        {
            var modes = await _appearanceTypeForHearingRepository.GetAllAsync1();
            return modes;
        }
        public async Task<IEnumerable<VirtualPlatform>> GetAllPlatform()
        {
            var modes = await _virtualRepository.GetAllAsync1();
            return modes;
        }
    }
}
