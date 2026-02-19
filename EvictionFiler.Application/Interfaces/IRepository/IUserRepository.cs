using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task SaveChangesAsync();
        Task<bool> RegisterTenant(RegisterDto model, Guid? FirmId);
        Task<IEnumerable<User>> GetAllUser();
        Task<User?> GetByIdAsync(Guid id);
        Task<bool> UpdateUserAsync(RegisterDto updatedUser);
        Task<bool> DeleteUserAsync(Guid id);
        Task<IEnumerable<User>> GetAllStaffMember(Guid Firmid);
        Task<UserDto?> GetUserByIdAsync(Guid id);

        Task<User?> GetFirmOwnerAsync(Guid firmId);

        Task<List<User>> GetUsersByFirmIdAsync(Guid firmId);


    }
}
