using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class VirtualPlatformRepository : Repository<VirtualPlatform> , IVirtualPlatformRepository
    {
        private readonly MainDbContext _maindbcontext; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public VirtualPlatformRepository(MainDbContext mainDbContext,IDbContextFactory<MainDbContext> contextFactory) : base(mainDbContext, contextFactory) 
        {
            _maindbcontext = mainDbContext;
            this.contextFactory = contextFactory;
        }
        public async Task<IEnumerable<VirtualPlatform>> GetAllAsync1(Expression<Func<VirtualPlatform, bool>>? predicate = null, params Expression<Func<VirtualPlatform, object>>[]? includes)
        {


            await using var context = await contextFactory.CreateDbContextAsync();

            IQueryable<VirtualPlatform> query = context.Set<VirtualPlatform>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
