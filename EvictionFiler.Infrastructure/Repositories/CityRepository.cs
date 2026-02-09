using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CityRepository : Repository<City> , ICityRepository
    {
        private readonly MainDbContext _maindbcontext;  
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CityRepository(MainDbContext mainDbContext,IDbContextFactory<MainDbContext>contextFactory) : base(mainDbContext, contextFactory) 
        {
            _maindbcontext = mainDbContext;
            this.contextFactory = contextFactory;
        }
        public async Task<List<City>> GetAlllAsync(Expression<Func<City, bool>>? predicate = null, params Expression<Func<City, object>>[]? includes)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            IQueryable<City> query = db.Set<City>();
            //var query = _dbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }
            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
