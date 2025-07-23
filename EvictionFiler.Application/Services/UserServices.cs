using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EvictionFiler.Application.DTOs;
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
            new Claim(ClaimTypes.Email, user.Email ?? "")
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

        public async Task<bool> RegisterTenantAsync(RegisterDto model)
        {
            var registerResult = _userRepository.RegisterTenant(model);
            if (registerResult == null) return false;
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllUser();
            return users;
        }
    }
}
