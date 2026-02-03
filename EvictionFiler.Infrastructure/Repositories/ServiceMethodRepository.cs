using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
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
    public class ServiceMethodRepository : Repository<ServiceMethod> , IServiceMethodRepository
    {
        private readonly MainDbContext _context;
        private readonly IDbContextFactory<MainDbContext> dbContextFactory;

        public ServiceMethodRepository(MainDbContext context, IDbContextFactory<MainDbContext> dbContextFactory) : base(context) 
        {
            _context = context;
            this.dbContextFactory = dbContextFactory;
        }
        public async Task<List<ServiceMethod>> GetServiceMethodsAsync()
        {
            await using var context = await dbContextFactory.CreateDbContextAsync();

            return await context.MstServiceMethod.OrderBy(e => e.Name)
                                                   .ToListAsync();
        }
    }
}
