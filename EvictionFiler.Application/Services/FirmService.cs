using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class FirmService : IFirmService
    {
        private readonly IUserRepository _userRepo;
        private readonly IFirmRepository _firmRepo;
        private readonly IEmailService _emailService;
        public FirmService(IUserRepository userRepo, IFirmRepository firmRepo, IEmailService emailService)
        {
            _firmRepo = firmRepo;
            _userRepo = userRepo;
            _emailService = emailService;

        }

        public async Task<bool> RegisterFirm(RegisterDto model, FirmDto dto)
        {
            var firmId = await _firmRepo.RegisterFirm(dto);
            var result = await _userRepo.RegisterTenant(model, firmId);
            if (result)
            {
                await _emailService.SendFirmEnrollEmailAsync(model.Email, $"{model.FirstName} {model.LastName}", dto.Name, model.Password);
            }
            return result;
        }

        public async Task<bool> AddNewFirm(FirmDto dto)
        {
            var firmId = await _firmRepo.RegisterFirm(dto);
            return firmId != null;
        }


        public async Task<IEnumerable<FirmDto>> GetAllFirms()
        {
            var firms = await _firmRepo.GetAllAsync(includes: e => e.SubscriptionTypes!);
            return firms.Select(e => new FirmDto
            {
                Name = e.Name,
                Phone = e.Phone,
                FAX = e.FAX,
                Email = e.Email,
                Address = e.Address,
                Id = e.Id,
                SubscriptionName = e.SubscriptionTypes?.Name
            });
        }

        // New: UpdateFirm method
        public async Task<bool> UpdateFirm(RegisterDto model, FirmDto dto)
        {
            if (dto.Id == Guid.Empty) return false;

            // Update firm
            var firmUpdated = await _firmRepo.UpdateFirm(dto);
            if (!firmUpdated) return false;

            // Update user
            var userUpdated = await _userRepo.UpdateUserAsync(model);
            return userUpdated;
        }




        public async Task<List<FirmDto>> GetTopFirms()
        {
            return await _firmRepo.GetTopFirms();
        }
        public async Task<List<FirmDto>> GetFirmSuggestions(string term)
        {
            return await _firmRepo.GetFirmSuggestions(term);
        }
    }
}
