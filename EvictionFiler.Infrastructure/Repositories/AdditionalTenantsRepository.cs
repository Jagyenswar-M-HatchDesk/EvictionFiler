using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class AdditionalTenantsRepository : Repository<AdditioanlTenants>, IAdditionalTenantsRepository
    {
        private readonly MainDbContext _context;

        public AdditionalTenantsRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAdditionalTenant(List<AddtionalTenantDto> tenant)
        {
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

                await _context.AdditioanlTenants.AddRangeAsync(newtenant);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public async Task<bool> UpdateAdditionalTenant(AddtionalTenantDto tenant)
        {
            try
            {
                var existing = await GetAdditionalTenantsById(tenant.Id);
                if (existing == null) return false;

                existing.FirstName = tenant.FirstName;
                existing.LastName = tenant.LastName;
                existing.IsActive = tenant.IsActive;
                existing.TenantId = tenant.TenantId;
                existing.IsDeleted = tenant.IsDeleted;

                _context.AdditioanlTenants.Update(existing);
                var result = _context.SaveChanges();

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
            try
            {
                var tenants = await _context.AdditioanlTenants.Where(e => e.TenantId == Id).ToListAsync();
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
            try
            {
                var tenant = await _context.AdditioanlTenants.Where(e => e.Id == Id).FirstOrDefaultAsync();
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
