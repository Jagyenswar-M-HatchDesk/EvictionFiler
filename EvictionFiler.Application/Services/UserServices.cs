using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EvictionFiler.Application.Services
{
    public class UserService : IUserservices
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, IConfiguration config, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _config = config;
            _userManager = userManager;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                return null;

            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName +" " + user.LastName ?? ""),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
        };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> RegisterTenantAsync(RegisterDto model, Guid? Id = null)
        {
            var registerResult = await _userRepository.RegisterTenant(model, Id);
            if (!registerResult) return false;
            return true;
        }
        public async Task<bool> UpdateUserAsync(RegisterDto model)
        {
            var registerResult = await _userRepository.UpdateUserAsync(model);
            if (!registerResult) return false;
            return true;
        }
        public async Task<bool> DeleteUser(Guid Id)
        {
            var registerResult = await _userRepository.DeleteUserAsync(Id);
            if (!registerResult) return false;
            return true;
        }
        public async Task<bool> RegisterStaffMemberAsync(RegisterDto model, Guid? Id = null)
        {
            var registerResult = await _userRepository.RegisterTenant(model, Id);
            if (!registerResult) return false;
            return true;
        }


        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllUser();
            return users;
        }
        public async Task<IEnumerable<User>> GetAllStaffMembers(Guid FirmId)
        {
            var staff = await _userRepository.GetAllStaffMember(FirmId);
            return staff;
        }
        public async Task<User> GetUserById(Guid UserId)
        {
            var staff = await _userRepository.GetByIdAsync(UserId);
            return staff;
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid UserId)
        {
            return await _userRepository.GetUserByIdAsync(UserId);
        }

        public async Task<UserDto?> GetFirmOwnerAsync(Guid firmId)
        {
            var user = await _userRepository.GetFirmOwnerAsync(firmId);
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role != null ? new UserRoleDto
                {
                    RoleId = user.Role.Id,
                    RoleName = user.Role.Name ?? string.Empty
                } : null,
                Firm = user.Firms != null ? new UserFirmDto
                {
                    FirmId = user.Firms.Id,
                    FirmName = user.Firms.Name ?? string.Empty,
                    UserSubscription = user.Firms.SubscriptionTypes != null ? new UserSubscriptionDto
                    {
                        SubscriptionId = user.Firms.SubscriptionTypes.Id,
                        SubscriptionName = user.Firms.SubscriptionTypes.Name ?? string.Empty
                    } : null
                } : null
            };
        }

        public async Task<List<UserDto>> GetUsersByFirmIdAsync(Guid firmId)
        {
            var users = await _userRepository.GetUsersByFirmIdAsync(firmId);

            return users.Select(user => new UserDto
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role != null ? new UserRoleDto
                {
                    RoleId = user.Role.Id,
                    RoleName = user.Role.Name ?? string.Empty
                } : null
            }).ToList();
        }

    }
}
