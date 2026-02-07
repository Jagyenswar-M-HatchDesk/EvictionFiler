using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly MainDbContext _db;
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(MainDbContext db, IDbContextFactory<MainDbContext> contextFactory, IConfiguration config, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _db = db;
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _contextFactory = contextFactory;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            return await db.Users.Include(e => e.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            await db.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            await db.SaveChangesAsync();
        }

        public async Task<bool> RegisterTenant(RegisterDto model)
        {
            try
            {
                //var serverPrefix = _config.GetConnectionString("SqlServer");
                //var dbName = $"{model.Role}_{model.Email.Split('@')[0]}";
                //var connectionString = $"{serverPrefix};Database={dbName};MultipleActiveResultSets=True;";

                //var database = new UserDatabase
                //{
                //    Id = Guid.NewGuid(),
                //    DatabaseName = dbName,
                //    ConnectionString = connectionString,
                //    CreatedOn = DateTime.UtcNow,
                //    UpdatedOn = DateTime.UtcNow,
                //};
                //await _db.UserDatabases.AddAsync(database);
                //await _db.SaveChangesAsync();

                //var options = new DbContextOptionsBuilder<TenantDbContext>()
                //    .UseSqlServer(connectionString)
                //    .EnableSensitiveDataLogging()
                //    .LogTo(Console.WriteLine)
                //    .Options;

                //using var tenantDb = new TenantDbContext(options);
                //await tenantDb.Database.MigrateAsync();

                // Ensure role exists in main DB
                var role = await _roleManager.FindByNameAsync(model.Role);
                if (role == null)
                {
                    role = new Role { Name = model.Role };
                    await _roleManager.CreateAsync(role);
                }

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    Email = model.Email,
                    UserName = model.Email,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    RoleId = role.Id,
                    IsActive = true,
                   
                };

                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (!createResult.Succeeded)
                {
                   
                    return false;
                }

                await _userManager.AddToRoleAsync(user, model.Role);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public async Task<IEnumerable<User>> GetAllUser()
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            var alluser = await db.Users.Include(e => e.Role).ToListAsync();
            return alluser;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            return await db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateUserAsync(User updatedUser)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            if (user == null) return false;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.MiddleName = updatedUser.MiddleName;
            user.Email = updatedUser.Email;
            user.UserName = updatedUser.Email;
            user.UpdatedOn = DateTime.UtcNow;
            user.IsActive = updatedUser.IsActive;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;

            user.IsDeleted = true;
            user.UpdatedOn = DateTime.UtcNow;

            db.Users.Update(user);
            await db.SaveChangesAsync();
            return true;
        }


    }
}
