using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public class TenantReadRepository : ReadRepository<Tenant>, ITenantReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public TenantReadRepository(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<TenantDetailDto> GetTenantDetailAsync(Guid caseId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var l = await context.LegalCases
     .AsNoTracking()
     .Where(c => c.Id == caseId && c.IsDeleted != true)
     .Include(c => c.Tenants)
     

     .FirstOrDefaultAsync();


            if (l == null) return null;

            return new TenantDetailDto
            {
                TenantId = l.Tenants.Id,

                UnitOrApartmentNumber = l.UnitOrApartmentNumber,
                TenantName = $"{l.Tenants.FirstName} {l.Tenants.LastName}"





            };
        }
        
    }

}