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
        Task<bool> RegisterTenantAsync(RegisterDto model);
        Task<IEnumerable<User>> GetAllUserAsync();
    }
}
