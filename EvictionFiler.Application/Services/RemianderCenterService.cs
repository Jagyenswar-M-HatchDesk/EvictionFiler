using EvictionFiler.Application.DTOs.RemainderCenterDto;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace EvictionFiler.Application.Services
{
    public class RemianderCenterService : IRemianderCenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRemainderCenterRepository _remainderCenterRepo;
        private readonly IUserRepository _userRepo;

        public RemianderCenterService(IRemainderCenterRepository RemainderCenterRepo, IUnitOfWork unitOfWork, IUserRepository userRepo)
        {
            _unitOfWork = unitOfWork;
            _remainderCenterRepo = RemainderCenterRepo;
            _userRepo = userRepo;
        }

        public async Task<bool> Create(EditToRemainderCenterDto dto)
        {
            var rc = new RemainderCenter()
            {
                Id = dto.Id,
                When = dto.When,
                CaseId = dto.CaseId,
                CountyId = dto.CountyId,
                TenantId = dto.TenantId,
                RemainderTypeId = dto.RemainderTypeId,
                Index = dto.Index,
                Notes = dto.Notes,
                ReminderName = dto.ReminderName,
                ReminderCategoryId = dto.ReminderCategoryId,
                ReminderEscalateId = dto.ReminderEscalateId,


            };
            await _remainderCenterRepo.AddAsync(rc);

            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
        public async Task<bool> CompleteRemainder(EditToRemainderCenterDto dto)
        {
            var data = await _remainderCenterRepo.GetAsync(dto.Id);
            if (data != null)
            {
                data.IsComplete = dto.IsComplete;
                
            }
            
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteRemainderCenterAsync(Guid id)
        {
            var rc = await _remainderCenterRepo.DeleteAsync(id);
            var deleterecordes = await _unitOfWork.SaveChangesAsync();
            if (deleterecordes > 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteAllRemainderAsync()
        {
            var result = await _remainderCenterRepo.DeleteAllAsync();
            if (!result)
                return false;

            var saved = await _unitOfWork.SaveChangesAsync();
            return saved > 0;
        }


        public async Task<List<EditToRemainderCenterDto>> GetAllRemainderCenterAsync()
        {
            var calanders = await _remainderCenterRepo
                .GetAllQuerable(x => x.IsDeleted != true, x => x.RemainderType, x => x.County, x => x.Tenant, x => x.Case, x=>x.ReminderEscalates, x=>x.ReminderCategory)
                .ToListAsync();

            var result = calanders.Select(dto => new EditToRemainderCenterDto
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


        public async Task<EditToRemainderCenterDto?> GetRemainderCenterByIdAsync(Guid? id)
        {
            var dto = await _remainderCenterRepo.GetAsync(id);


            if (dto == null)
                return null;

            return new EditToRemainderCenterDto
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
                CreatedOn = dto.CreatedOn,
            };
        }

        //public Task<List<EditToClientDto>> SearchRemainderCenter(string searchTerm)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> UpdateRemainderCenterAsync(EditToRemainderCenterDto dto)
        {
            var existing = await _remainderCenterRepo.GetAsync(dto.Id);

            if (existing == null) return false;


            existing.When = dto.When;
            existing.CaseId = dto.CaseId;
            existing.CountyId = dto.CountyId;
            existing.TenantId = dto.TenantId;
            existing.RemainderTypeId = dto.RemainderTypeId;
            existing.Index = dto.Index;
            existing.Notes = dto.Notes;

            existing.CreatedOn = DateTime.Now;

            // Save changes
            _remainderCenterRepo.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
