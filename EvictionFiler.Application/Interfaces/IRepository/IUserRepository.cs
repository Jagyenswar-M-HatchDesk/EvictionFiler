using EvictionFiler.Application.DTOs;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
