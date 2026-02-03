using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class AppearanceModeRepository :  Repository<AppearanceMode>, IAppearanceModeRepository
    {
            private readonly MainDbContext _mainDbContext;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public AppearanceModeRepository(MainDbContext mainDbContext,IDbContextFactory<MainDbContext> contextFactory) : base(mainDbContext)
            {
                _mainDbContext = mainDbContext;
            this.contextFactory = contextFactory;
        }
        public async Task<IEnumerable<AppearanceMode>> GetAllAsync1(Expression<Func<AppearanceMode, bool>>? predicate = null, params Expression<Func<AppearanceMode, object>>[]? includes)
        {


            await using var context = await contextFactory.CreateDbContextAsync();

            IQueryable<AppearanceMode> query = context.Set<AppearanceMode>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync().ConfigureAwait(false);
        }

    }
}
