using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task SaveChangesAsync();
        Task<bool> RegisterTenant(RegisterDto model);
        Task<IEnumerable<User>> GetAllUser();
        Task<User?> GetByIdAsync(Guid id);
        Task<bool> UpdateUserAsync(User updatedUser);
        Task<bool> DeleteUserAsync(Guid id);
     

	}
}
