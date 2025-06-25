//using EvictionFiler.Application.DTOs;
//using EvictionFiler.Application.Interfaces.IServices;
//using EvictionFiler.Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace EvictionFiler.Application.Services
//{
//    public class UserService : IUserservices
//    {
//        private readonly IUserRepository _userRepository;
//        private readonly IConfiguration _config;

//        public UserService(IUserRepository userRepository, IConfiguration config)
//        {
//            _userRepository = userRepository;
//            _config = config;
//        }

//        public async Task<string?> LoginAsync(string email, string password)
//        {
//            var user = await _userRepository.GetByEmailAsync(email);
//            var passwordmatch = new PasswordHasher<object>().VerifyHashedPassword(null, user.PasswordHash, password);
//            if (user == null || passwordmatch == PasswordVerificationResult.Failed)
//                return null;

//            var claims = new List<Claim>
//            {
//            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//            new Claim(ClaimTypes.Name, user.Name),
//            new Claim(ClaimTypes.Email, user.Email ?? ""),
//            new Claim("tenantConn", user.ConnectionString),
//            new Claim(ClaimTypes.Role, user.Role.Name) // or user.Role.Name if available
//        };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var token = new JwtSecurityToken(
//                _config["Jwt:Issuer"],
//                _config["Jwt:Issuer"],
//                claims,
//                expires: DateTime.UtcNow.AddHours(2),
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        public async Task<bool> RegisterTenantAsync(RegisterDto model)
//        {
//            var registerResult = _userRepository.RegisterTenant(model);
//            if (registerResult == null) return false;
//            return true;
//        }

//        public async Task<IEnumerable<User>> GetAllUserAsync()
//        {
//            var users = await _userRepository.GetAllUser();
//            return users;
//        }
//    }
//}
