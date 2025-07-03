using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly MainDbContext _db;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(MainDbContext db, IConfiguration config, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _db = db;
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _db.Users.Include(e => e.Roles).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RegisterTenant(RegisterDto model)
        {
            try
            {
                var serverPrefix = _config.GetConnectionString("SqlServer");
                var dbName = $"{model.Role}_{model.Email.Split('@')[0]}";
                var connectionString = $"{serverPrefix};Database={dbName};MultipleActiveResultSets=True;";

                var database = new UserDatabase
                {
                    Id = Guid.NewGuid(),
                    DatabaseName = dbName,
                    ConnectionString = connectionString,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                await _db.UserDatabases.AddAsync(database);
                await _db.SaveChangesAsync();

                // Create and migrate tenant database
                var options = new DbContextOptionsBuilder<TenantDbContext>()
                    .UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine)
                    .Options;

                using var tenantDb = new TenantDbContext(options);
                await tenantDb.Database.MigrateAsync();

                // Ensure role exists in main DB
                var role = await _roleManager.FindByNameAsync(model.Role);
                if (role == null)
                {
                    role = new Role { Name = model.Role };
                    await _roleManager.CreateAsync(role);
                }

                // Create user (main DB)
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    Email = model.Email,
                    UserName = model.Email,
                    //EmailConfirmed = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    RoleId = role.Id,
                    TenantId = database.Id,
                    IsActive = true,
                    //CreatedBy
                };

                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (!createResult.Succeeded)
                {
                    // optionally log createResult.Errors
                    return false;
                }

                await _userManager.AddToRoleAsync(user, model.Role);

                // Optional: create the same user in the tenant DB
                // If tenant uses Identity, you need to set up UserManager for tenantDb as well
                // Otherwise, use raw EF to add user profile there

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public async Task<IEnumerable<User>> GetAllUser()
        {
            var alluser = await _db.Users.Include(e => e.Roles).ToListAsync();
            return alluser;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateUserAsync(User updatedUser)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            if (user == null) return false;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.MiddleName = updatedUser.MiddleName;
            user.Email = updatedUser.Email;
            user.UserName = updatedUser.Email;
            user.UpdatedAt = DateTime.UtcNow;
            user.IsActive = updatedUser.IsActive;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;

            user.IsDeleted = true;
            user.UpdatedAt = DateTime.UtcNow;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }


    }
}
