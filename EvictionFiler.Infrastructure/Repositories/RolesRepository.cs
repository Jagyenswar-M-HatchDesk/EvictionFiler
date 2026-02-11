using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public  class RolesRepository: IRolesRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly RoleManager<Role> _roleManager;

        public RolesRepository(MainDbContext mainDbContext, RoleManager<Role> roleManager)
        {
            _mainDbContext = mainDbContext;
            _roleManager = roleManager;
        }

        public RoleManager<Role> RoleManager { get; }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var allRoles = await _mainDbContext.Roles
                .Where(r => r.IsDeleted != true).ToListAsync();
            return allRoles;
        }
        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _mainDbContext.Roles.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateRoleAsync(Role updatedRole)
        {
            var role = await _mainDbContext.Roles.FirstOrDefaultAsync(u => u.Id == updatedRole.Id);
            if (role == null) return false;

            role.Name =   updatedRole.Name;
            role.Description =   updatedRole.Description;
            
            role.UpdatedOn = DateTime.UtcNow;
            role.IsActive = updatedRole.IsActive;

            _mainDbContext.Roles.Update(role);
            await _mainDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _mainDbContext.Roles.FirstOrDefaultAsync(u => u.Id == id);
            if (role == null) return false;
            role.IsDeleted = true;
            role.IsActive = false;
            role.UpdatedOn = DateTime.UtcNow;
            _mainDbContext.Roles.Update(role);
            await _mainDbContext.SaveChangesAsync();
            return true;
        }

    }
}


