//using EvictionFiler.Application.DTOs;
//using EvictionFiler.Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EvictionFiler.Infrastructure.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
       
//            private readonly MainDbContext _db;
//            private readonly IConfiguration _config;

//            public UserRepository(MainDbContext db, IConfiguration config)
//            {
//                _db = db;
//                _config = config;
//            }

//            public async Task<User?> GetByEmailAsync(string email)
//            {
//                return await _db.Users.Include(e => e.Role).FirstOrDefaultAsync(u => u.Email == email);
//            }

//            public async Task AddAsync(User user)
//            {
//                await _db.Users.AddAsync(user);
//            }

//            public async Task SaveChangesAsync()
//            {
//                await _db.SaveChangesAsync();
//            }

//            public async Task<bool> RegisterTenant(RegisterDto model)
//            {
//                var serverPrefix = _config.GetConnectionString("SqlServer");
//                var dbName = $"Tenant_{model.Email.Split('@')[0]}";
//                var connectionString = $"{serverPrefix};Database={dbName};MultipleActiveResultSets=True;";


//                var options = new DbContextOptionsBuilder<TenantDbContext>()
//                    .UseSqlServer(connectionString)
//                    .EnableSensitiveDataLogging()
//                    .LogTo(Console.WriteLine)
//                    .Options;

//                using var tenantDb = new TenantDbContext(options);
//                await tenantDb.Database.MigrateAsync(); // preferred over EnsureCreatedAsync
//                var role = _db.Roles.Where(e => e.Name == model.Role).FirstOrDefault();
//                var user = new User
//                {
//                    FirstName = model.Name,
//                    LastName = model.LastName,
//                    MiddleName = model.MiddleName,
//                    Email = model.Email,
//                    ConnectionString = connectionString,
//                    PasswordHash = new PasswordHasher<object>().HashPassword(null, model.Password),
//                    CreatedAt = DateTime.UtcNow,
//                    RoleId = role.Id,
//                    //SubscriptionId = 1
//                };
//                var adduser = await _db.Users.AddAsync(user);
//                await _db.SaveChangesAsync();

//                return true;
//            }

//            public async Task<IEnumerable<User>> GetAllUser()
//            {
//                var alluser = await _db.Users.Include(e => e.Role).ToListAsync();
//                return alluser;
//            }
//        }
//}
