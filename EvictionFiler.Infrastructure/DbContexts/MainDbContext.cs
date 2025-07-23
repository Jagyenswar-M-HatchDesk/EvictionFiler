using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Infrastructure.DbContexts
{
    public class MainDbContext : IdentityDbContext<User, Role, Guid>
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserDatabase> UserDatabases { get; set; }
   
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LandLord> LandLords { get; set; }

		public DbSet<CaseType> mst_CaseTypes { get; set; }
		public DbSet<CaseSubType> mst_CaseSubTypes { get; set; }
		public DbSet<Appartment> Appartments { get; set; }
        public DbSet<LegalCase> LegalCases { get; set; }

		public DbSet<TypeOfOwner> mst_TypeOfOwners { get; set; }
		public DbSet<ClientRole> mst_ClienrRoles { get; set; }
		public DbSet<Language> mst_Languages { get; set; }
		public DbSet<PremiseType> mst_PremiseTypes { get; set; }
		public DbSet<RegulationStatus> mst_regulationStatus { get; set; }
		public DbSet<State> mst_State { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.Parse("f5ab29da-356e-42df-a3ad-d91bbf644550"), Name = "Admin" , NormalizedName= "ADMIN" },
                new Role { Id = Guid.Parse("56355bf6-e335-428a-b718-00cb79e5273d"), Name = "Law Firm", NormalizedName = "LAW FIRM" },
                new Role { Id = Guid.Parse("2bb5c3bf-8dd8-4415-9090-1d428c792533"), Name = "Property Manager", NormalizedName = "PROPERTY MANAGER" }

            );



            //var password = new PasswordHasher<object>().HashPassword(null, "Abcd@1234");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("84722e9d-806c-4f49-94d7-a55de8d2d76e"),
                    FirstName = "Admin",
                    CreatedAt = new DateTime(2024, 6, 19, 12, 0, 0, DateTimeKind.Utc), 
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    IsActive = true,
                    RoleId = Guid.Parse("f5ab29da-356e-42df-a3ad-d91bbf644550"),
                    EmailConfirmed = true,
                    SecurityStamp = "38fef087-d2ad-4e78-9823-123456789abc", 
                    ConcurrencyStamp = "12456e31-62c3-4db3-a8fc-987654321def", 
                    PasswordHash = "AQAAAAIAAYagAAAAEHXHMy52Ji1wPk8MrXLQrX8XKJekP1rHPXwmwtgFmlmiCdkN7lYlOlLlaOVXJ2SKcw=="
                }
            );


            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("84722e9d-806c-4f49-94d7-a55de8d2d76e"),        
                    RoleId = Guid.Parse("f5ab29da-356e-42df-a3ad-d91bbf644550")         
                }
            );
        }
    }
}
