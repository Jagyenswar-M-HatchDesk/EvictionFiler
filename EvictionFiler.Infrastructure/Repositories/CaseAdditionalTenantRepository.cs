using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseAdditionalTenantRepository : Repository<CaseAdditionalTenants>, ICaseAdditionalTenantRepository
    {
        private readonly MainDbContext _mainDbContext; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        public CaseAdditionalTenantRepository(MainDbContext mainDbContext, IDbContextFactory<MainDbContext> contextFactory) : base(mainDbContext, contextFactory)
        {
            _mainDbContext = mainDbContext;
            _contextFactory = contextFactory;
        }

        public async Task AddAdditionalCaseTenant(List<AddtionalTenantDto> tenant)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            try
            {
                var newCaseadditionalTenants = tenant.Select(e => new CaseAdditionalTenants()
                {
                    Id = Guid.NewGuid(),
                    FirstName = e.FirstName!,
                    LastName = e.LastName,
                    LegalCaseId = e.LegalCaseId,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,

                }).ToList();

                await db.CaseAdditionalTenants.AddRangeAsync(newCaseadditionalTenants);
                var result = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public async Task<CaseAdditionalTenants> GetCaseTenantById(Guid Id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            var occupants = db.CaseAdditionalTenants.Where(e => e.Id == Id).FirstOrDefault();
            return occupants;
        }
        public async Task<List<CaseAdditionalTenants>> GetAdditionalCaseTenants(Guid? Id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            try
            {
                var tenants = db.CaseAdditionalTenants.Where(e => e.LegalCaseId == Id).ToList();
                if (tenants.Count > 0) return tenants;

                return new List<CaseAdditionalTenants>();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<bool> UpdateAdditionalCaseTenant(List<AddtionalTenantDto> occupant)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            try
            {
                foreach (var toupdate in occupant)
                {
                    var existing = await GetCaseTenantById(toupdate.Id);
                    if (existing == null) return false;

                    existing.FirstName = toupdate.FirstName;
                    existing.LastName = toupdate.LastName;

                    db.CaseAdditionalTenants.Update(existing);

                }
                var result = await db.SaveChangesAsync();
                if (result > 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<bool> DeleteAdditionalTenants(List<AddtionalTenantDto> Tenant)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            foreach (var todelete in Tenant)
            {
                var tenant = await db.CaseAdditionalTenants.FindAsync(todelete.Id);
                if (tenant == null)
                {
                    return false;
                }
                db.CaseAdditionalTenants.Remove(tenant);
            }
            
            var result = await db.SaveChangesAsync();
            return result > 0 ? true : false;
        }

    }
}
