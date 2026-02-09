using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class AdditionalTenantsRepository : Repository<AdditioanlTenants>, IAdditionalTenantsRepository
    {
        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        public AdditionalTenantsRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;
        }

        public async Task AddAdditionalTenant(List<AddtionalTenantDto> tenant)
        {
            await using var db = await _contextFactory.CreateDbContextAsync(); 
            try
            {
                var newtenant = tenant.Select(e => new AdditioanlTenants()
                {
                    Id = Guid.NewGuid(),
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    IsActive = e.IsActive,
                    TenantId = e.TenantId,
                    IsDeleted = e.IsDeleted,
                    CreatedOn = e.CreatedOn

                }).ToList();

                await db.AdditioanlTenants.AddRangeAsync(newtenant);
                var result = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public async Task<bool> UpdateAdditionalTenant(List<AddtionalTenantDto> tenant)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            try
            {
                foreach (var item in tenant)
                {
                    var existing = await GetAdditionalTenantsById(item.Id);
                    if (existing == null) return false;

                    existing.FirstName = item.FirstName;
                    existing.LastName = item.LastName;
                    existing.IsActive = item.IsActive;
                    existing.TenantId = item.TenantId;
                    existing.IsDeleted = item.IsDeleted;

                    db.AdditioanlTenants.Update(existing);
                }
                var result = db.SaveChanges();

                if (result > 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<List<AdditioanlTenants>> GetAdditionalTenants(Guid? Id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            try
            {
                var tenants = await db.AdditioanlTenants.Where(e => e.TenantId == Id).ToListAsync();
                if (tenants.Count > 0) return tenants;

                return new List<AdditioanlTenants>();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<AdditioanlTenants> GetAdditionalTenantsById(Guid? Id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            try
            {
                var tenant = await db.AdditioanlTenants.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (tenant != null) return tenant;

                return new AdditioanlTenants();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
    }
}
