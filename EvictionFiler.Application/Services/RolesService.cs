using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class RolesService:IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            var roles = await _rolesRepository.GetAllRoles();
            return roles;
        }
        // Get role by Id
        public async Task<Role?> GetRoleByIdAsync(Guid id)
        {
            return await _rolesRepository.GetByIdAsync(id);
        }

        // Update role
        public async Task<bool> UpdateRoleAsync(Role role)
        {
            return await _rolesRepository.UpdateRoleAsync(role);
        }
    }
}
