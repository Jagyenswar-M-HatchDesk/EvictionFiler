using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IUserservices
    {
        Task<string?> LoginAsync(string email, string password);
        Task<bool> RegisterTenantAsync(RegisterDto model);
        Task<IEnumerable<User>> GetAllUserAsync();
    }
}
