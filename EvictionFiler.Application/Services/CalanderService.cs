using EvictionFiler.Application.DTOs.CalanderDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.Services
{
    public class CalanderService : ICalanderService
    {
        private readonly ICalanderRepository _calanderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;

        public CalanderService(ICalanderRepository calanderRepository, IUnitOfWork unitOfWork, IUserRepository userRepo)
        {
            _calanderRepository = calanderRepository;
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
        }
        public async Task<bool> GenrateCalander(CalanderDto dto)
        {
            var calander = new Calander()
            {
                Id = dto.Id,
                CountyId= dto.CountyId,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                CourtPartId = dto.CourtPartId,
                Room = dto.Room,
                CaseTypeId = dto.CaseTypeId,
                Judge = dto.Judge,
                CaseStatusId = dto.CaseStatusId,
                Caption = dto.Caption,
                
            };
             await _calanderRepository.AddAsync(calander);
           
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;

        }

        public async  Task<List<CalanderDto>> GetAllCalanderAsync()
        {
            var calanders = await _calanderRepository
                  .GetAllQuerable(x => x.IsDeleted != true, x => x.CaseStatus, x => x.CourtPart, x => x.County , x => x.CaseType)
                  .ToListAsync();

            var result = calanders.Select(dto => new CalanderDto
            {
                Id = dto.Id,
                CountyId = dto.CountyId,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                CourtPartId = dto.CourtPartId,
                Room = dto.Room,
                CaseTypeId = dto.CaseTypeId,
                Judge = dto.Judge,
                CaseStatusId = dto.CaseStatusId,
                Caption = dto.Caption,
                CourtPartName = dto.CourtPart?.Part ?? "Unknown",
                CountyName = dto.County?.Name ?? "Unknown",
                CaseTypeName = dto.CaseType?.Name ?? "Unknown",
                CaseStatusName = dto.CaseStatus?.Name ?? "Unknown",

            }).ToList();

            return result;
        }
    }
}
