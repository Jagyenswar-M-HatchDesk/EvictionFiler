using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
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
    }
}
