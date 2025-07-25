using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
