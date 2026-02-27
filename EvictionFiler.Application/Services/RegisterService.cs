using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class RegisterService:IRegisterService
    {

        private readonly IRegisterRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IFirmRepository _firmRepository;
        private readonly IEmailService _emailService;
        private readonly CaptchaService _captchaService;

        public RegisterService(
            IRegisterRepository repo,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IFirmRepository firmRepository,
            IEmailService emailService,
            CaptchaService captchaService
            )
        {
            _repo = repo;
            _userManager = userManager;
            _roleManager = roleManager;
            _firmRepository = firmRepository;
            _emailService = emailService;
            _captchaService = captchaService;
        }

       
        public async Task<(bool Success, string Message)> RegisterAsync(RegisterDto dto,FirmDto? Dto, string SubscriptionName,string captchaToken)
        {
            

            try
            {
                if (string.IsNullOrWhiteSpace(captchaToken))
                    return (false, "Captcha is required");

                var isCaptchaValid = await _captchaService.ValidateRecaptcha(captchaToken);

                if (!isCaptchaValid)
                    return (false, "Captcha validation failed");

                string roleName = string.IsNullOrWhiteSpace(dto.Role) ? "Admin" : dto.Role;

                var role = await _roleManager.FindByNameAsync(roleName);

                if (role == null)
                    return (false, $"Role '{roleName}' not found");

                var subscriptionId = await _repo.GetSubscriptionIdByNameAsync(SubscriptionName);

                if (subscriptionId == null || subscriptionId == Guid.Empty)
                    return (false, "Default subscription not configured");
                //Guid? firmId = null;
                Guid firmId;
                if (Dto != null && !string.IsNullOrWhiteSpace(Dto.Name))
                {


                    Dto.SubscriptionTypeId = subscriptionId;

                    Guid?  createdFirmId= await _firmRepository.RegisterFirm(Dto);
                    if (!createdFirmId.HasValue || createdFirmId == Guid.Empty)
                        return (false, "Firm creation failed");

                    firmId = createdFirmId.Value;
                }
                else
                {
                    firmId = Guid.NewGuid();
                    var firm = new Firms
                    {
                        Id = firmId,
                        Name = dto.FirstName,
                        SubscriptionTypeId = subscriptionId,

                        CreatedOn = DateTime.UtcNow
                    };

                    await _repo.AddFirmAsync(firm);
                    await _repo.SaveChangesAsync();
                }
                var user = new User
                {
                    Id = Guid.NewGuid(),
                   
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    UserName=dto.Email,
                    NormalizedUserName=dto.Email.ToUpper(),
                    NormalizedEmail = dto.Email.ToUpper(),
                    CreatedBy = Guid.Empty,              
                    CreatedOn = DateTime.UtcNow,
                    RoleId=role.Id,
                    FirmId=firmId,
                    IsActive = true,
                    TwoFactorEnabled = true, 

                };

                var result = await _userManager.CreateAsync(user, dto.Password);

                //if (result.Succeeded && firmId.HasValue && Dto != null)
                //{
                //    await _emailService.SendFirmEnrollEmailAsync(user.Email, $"{user.FirstName} {user.LastName}", Dto.Name, password);
                //}

                //if (!result.Succeeded)
                //    return (false, string.Join(", ", result.Errors.Select(x => x.Description)));


                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(x => x.Description));
                    return (false, errors);
                }



                await _userManager.AddToRoleAsync(user, roleName);
               

        

                return (true, "User registered successfully");
            }
            catch (Exception ex)
            {
                
                return (false, ex.Message);
            }
        }

    }
}
