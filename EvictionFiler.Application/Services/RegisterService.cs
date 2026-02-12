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
       

        public RegisterService(
            IRegisterRepository repo,
            UserManager<User> userManager,
            RoleManager<Role> roleManager
            )
        {
            _repo = repo;
            _userManager = userManager;
            _roleManager = roleManager;
            
        }

        public async Task<(bool Success, string Message)> RegisterAsync(RegisterDto dto, string SubscriptionName)
        {
            

            try
            {
                string roleName = string.IsNullOrWhiteSpace(dto.Role) ? "Admin" : dto.Role;

                var role = await _roleManager.FindByNameAsync(roleName);

                if (role == null)
                    return (false, $"Role '{roleName}' not found");
                var subscriptionId = await _repo.GetSubscriptionIdByNameAsync(SubscriptionName);

                if (subscriptionId == null || subscriptionId == Guid.Empty)
                    return (false, "Default subscription not configured");
                var firmId = Guid.NewGuid();
                var firm = new Firms
                {
                    Id = firmId,
                    Name = dto.FirstName,
                    SubscriptionTypeId = subscriptionId,
                    
                    CreatedOn = DateTime.UtcNow
                };

                await _repo.AddFirmAsync(firm);
                await _repo.SaveChangesAsync();
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
                 





                };

                var result = await _userManager.CreateAsync(user, dto.Password);

                if (!result.Succeeded)
                    return (false, string.Join(", ", result.Errors.Select(x => x.Description)));

                



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
