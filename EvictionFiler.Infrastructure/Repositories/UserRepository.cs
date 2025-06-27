using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            var serverPrefix = _config.GetConnectionString("SqlServer");
            var dbName = $"Tenant_{model.Email.Split('@')[0]}";
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
                TenantId = database.Id
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


        public async Task<IEnumerable<User>> GetAllUser()
        {
            var alluser = await _db.Users.Include(e => e.Roles).ToListAsync();
            return alluser;
        }
    }
}
