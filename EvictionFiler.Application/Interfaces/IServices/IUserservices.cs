using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IUserservices
    {
        Task<string?> LoginAsync(string email, string password);
        Task<bool> RegisterTenantAsync(RegisterDto model, Guid? Id = null);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<bool> DeleteUser(Guid Id);
        Task<bool> UpdateUserAsync(RegisterDto model);
        Task<IEnumerable<User>> GetAllStaffMembers(Guid FirmId);
        Task<User> GetUserById(Guid UserId);
        Task<UserDto?> GetUserByIdAsync(Guid UserId);
    }
}
