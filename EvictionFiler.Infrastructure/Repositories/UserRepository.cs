using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Polly;

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
            return await _db.Users.Include(e => e.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        //public async Task<bool> RegisterStaff(RegisterDto model, Guid? FirmId)
        //{
        //    try
        //    {
        //        var role = await _roleManager.FindByNameAsync(model.Role);
        //        if (role == null)
        //        {
        //            role = new Role { Name = model.Role };
        //            await _roleManager.CreateAsync(role);
        //        }

        //        var user = new User
        //        {
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            MiddleName = model.MiddleName,
        //            Email = model.Email,
        //            UserName = model.Email,
        //            CreatedOn = DateTime.UtcNow,
        //            UpdatedOn = DateTime.UtcNow,
        //            RoleId = role.Id,
        //            IsActive = true,
        //            FirmId = FirmId

        //        };

        //        var createResult = await _userManager.CreateAsync(user, model.Password);
        //        if (!createResult.Succeeded)
        //        {

        //            return false;
        //        }

        //        await _userManager.AddToRoleAsync(user, model.Role);
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public async Task<bool> RegisterTenant(RegisterDto model, Guid? FirmId)
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
                    FirmId = model.FirmId ?? FirmId

                };

                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (!createResult.Succeeded)
                {

                    return false;
                }

                await _userManager.AddToRoleAsync(user, model.Role);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var alluser = await _db.Users.Include(e => e.Role).Include(e => e.Firms).Where(e => e.IsActive == true && e.IsDeleted == false).ToListAsync();
            return alluser;
        }
        public async Task<IEnumerable<User>> GetAllStaffMember(Guid Firmid)
        {
            var allstaff = await _db.Users.Where(e => e.FirmId == Firmid && e.IsActive == true && e.IsDeleted == false && e.Role.Name.StartsWith("Staff")).Include(e => e.Role).ToListAsync();
            return allstaff;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _db.Users.Include(u => u.Role).Include(u => u.Firms).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateUserAsync(RegisterDto updatedUser)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            var role = await _roleManager.FindByNameAsync(updatedUser.Role);
            if (role == null)
            {
                role = new Role { Name = updatedUser.Role };
                await _roleManager.CreateAsync(role);
            }
            if (user == null) return false;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.MiddleName = updatedUser.MiddleName;
            user.Email = updatedUser.Email;
            user.UserName = updatedUser.Email;
            user.UpdatedOn = DateTime.UtcNow;
            user.PhoneNumber = updatedUser.Phone??null;
            user.RoleId = role.Id;
            user.IsActive = true;
            user.FirmId = updatedUser.FirmId;

            _db.Users.Update(user);
            var result = await _db.SaveChangesAsync();
            if (result > 0) return true;

            return false;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;

            user.IsDeleted = true;
            user.UpdatedOn = DateTime.UtcNow;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _db.Users
                      .AsNoTracking()
                      .Where(u => u.Id == id)
                      .Select(u => new UserDto()
                      {
                          UserId = u.Id,
                          FirstName = u.FirstName,
                          LastName = u.LastName,
                          Email = u.Email,
                          Role = u.Role != null ? new UserRoleDto() { RoleId = u.Role.Id, RoleName = u.Role.Name ?? string.Empty } : null,
                          Firm = u.Firms != null ?
                                                      new UserFirmDto()
                                                      {
                                                          FirmId = u.Firms.Id,
                                                          FirmName = u.Firms.Name ?? string.Empty,
                                                          UserSubscription = u.Firms.SubscriptionTypes != null
                                                             ? new UserSubscriptionDto()
                                                             {
                                                                 SubscriptionId = u.Firms.SubscriptionTypes.Id,
                                                                 SubscriptionName = u.Firms.SubscriptionTypes.Name ?? string.Empty
                                                             }
                                                             : null
                                                      }
                                                    : null
                      }).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetFirmOwnerAsync(Guid firmId)
        {
            var user = await _db.Users.Include(u => u.Role).Include(u => u.Firms).ThenInclude(f => f.SubscriptionTypes)
                .FirstOrDefaultAsync(u => u.FirmId == firmId && u.Role != null && u.Role.Name.ToLower() == "admin" && u.IsActive && !(u.IsDeleted ?? false));           
            return user;
        }

        public async Task<List<User>> GetUsersByFirmIdAsync(Guid firmId)
        {
            return await _db.Users.Include(u => u.Role).Where(u => u.FirmId == firmId).ToListAsync();
        }

        public async Task<bool> IsEmailExistsAsync(string email, Guid? excludeUserId = null)
        {
            //return await _db.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower() && (excludeUserId == null || u.Id != excludeUserId));
            return await _db.Users
        .AnyAsync(u =>
            u.Email.ToLower() == email &&
            (!excludeUserId.HasValue || u.Id != excludeUserId.Value)
        );
        }

    }
}
