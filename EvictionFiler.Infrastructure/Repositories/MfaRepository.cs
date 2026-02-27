using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class MfaRepository :IMfaRepository
    {
        private readonly MainDbContext _mainDbContext;

        public MfaRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<bool> SetGlobalMfaAsync(bool enable, Guid currentUserId, bool isSuperAdmin)
        {
            var superAdminRoleId = await _mainDbContext.Roles
                .Where(r => r.Name == "Super Admin")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            var superAdminUserIds = _mainDbContext.UserRoles
                .Where(ur => ur.RoleId == superAdminRoleId)
                .Select(ur => ur.UserId);
            IQueryable<User> query = _mainDbContext.Users;

            if (!isSuperAdmin)
            {
                var currentUser = await _mainDbContext.Users
                    .Where(u => u.Id == currentUserId)
                    .Select(u => new { u.FirmId })
                    .FirstAsync();

                query = query.Where(u => u.FirmId == currentUser.FirmId);
            }

            query = query.Where(u => !superAdminUserIds.Contains(u.Id));

            if (enable)
            {
                await query
                    .Where(u => !u.TwoFactorEnabled)
                    .ExecuteUpdateAsync(s =>
                        s.SetProperty(u => u.TwoFactorEnabled, true));
            }
            else
            {
                await query
                    .Where(u => u.TwoFactorEnabled)
                    .ExecuteUpdateAsync(s =>
                        s.SetProperty(u => u.TwoFactorEnabled, false));
            }


            return true;
        }

        public async Task<bool> GetGlobalMfaStatusAsync(Guid currentUserId, bool isSuperAdmin)
        {
            var superAdminRoleId = await _mainDbContext.Roles
                .Where(r => r.Name == "Super Admin")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            var superAdminUserIds = _mainDbContext.UserRoles
                .Where(ur => ur.RoleId == superAdminRoleId)
                .Select(ur => ur.UserId);

            IQueryable<User> query = _mainDbContext.Users;

            if (!isSuperAdmin)
            {
                var currentUser = await _mainDbContext.Users
                    .Where(u => u.Id == currentUserId)
                    .Select(u => new { u.FirmId })
                    .FirstAsync();

                query = query.Where(u => u.FirmId == currentUser.FirmId);
            }

            query = query.Where(u => !superAdminUserIds.Contains(u.Id));

            return await query.AnyAsync(u => u.TwoFactorEnabled);
        }
    }
}
