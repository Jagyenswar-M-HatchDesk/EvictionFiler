using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                await _mainDbContext.CaseAdditionalTenants.AddRangeAsync(newCaseadditionalTenants);
                var result = _mainDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public async Task<CaseAdditionalTenants> GetCaseTenantById(Guid Id)
        {
            var occupants = _mainDbContext.CaseAdditionalTenants.Where(e => e.Id == Id).FirstOrDefault();
            return occupants;
        }
        public async Task<List<CaseAdditionalTenants>> GetAdditionalCaseTenants(Guid? Id)
        {
            try
            {
                var tenants = _mainDbContext.CaseAdditionalTenants.Where(e => e.LegalCaseId == Id).ToList();
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
            try
            {
                foreach (var toupdate in occupant)
                {
                    var existing = await GetCaseTenantById(toupdate.Id);
                    if (existing == null) return false;

                    existing.FirstName = toupdate.FirstName;
                    existing.LastName = toupdate.LastName;

                    _mainDbContext.CaseAdditionalTenants.Update(existing);

                }
                var result = await _mainDbContext.SaveChangesAsync();
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
            foreach(var todelete in Tenant)
            {
                var tenant = await _mainDbContext.CaseAdditionalTenants.FindAsync(todelete.Id);
                if (tenant == null)
                {
                    return false;
                }
                _mainDbContext.CaseAdditionalTenants.Remove(tenant);
            }
            
            var result = await _mainDbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

    }
}
