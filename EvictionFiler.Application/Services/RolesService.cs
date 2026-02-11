using EvictionFiler.Application.DTOs.RolesDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<IEnumerable<RolesDto>> GetAllRolesAsync()
        {
            var roles = await _rolesRepository.GetAllRoles();
            return roles.Select(role => new RolesDto
            {
                Id = role.Id,
                Name = role.Name!,
                Description = role.Description,
                IsActive = role.IsActive,
                IsDeleted = role.IsDeleted

            }).ToList();
        }
        // Get role by Id
        public async Task<RolesDto?> GetRoleByIdAsync(Guid id)
        {
            var result = await _rolesRepository.GetByIdAsync(id);
            return new RolesDto
            {
                Id = result.Id,
                Name = result.Name!,
                Description = result.Description,
                IsActive = result.IsActive,
            };
        }

        // Update role
        public async Task<bool> UpdateRoleAsync(RolesDto role)
        {
            var roless = new Role
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive,
                IsDeleted = role.IsDeleted,
                UpdatedOn = DateTime.UtcNow
            };
            return await _rolesRepository.UpdateRoleAsync(roless);
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            return await _rolesRepository.DeleteRoleAsync(id);
        }
    }
}
