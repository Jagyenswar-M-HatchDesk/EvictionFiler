using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.DbContexts
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LandLord> LandLords { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<LegalCase> LegalCases { get; set; }


       
    }
}
