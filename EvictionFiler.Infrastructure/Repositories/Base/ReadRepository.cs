using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Grpc.Core.Metadata;

namespace EvictionFiler.Infrastructure.Repositories.Base
{
    public abstract class ReadRepository<T> : IReadRepository<T> where T : DeletableBaseEntity
    {
        private readonly MainDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        protected ReadRepository(IDbContextFactory<MainDbContext> contextFactory)
        {
          
            _contextFactory = contextFactory;
        }
       
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes)
        {
            var query = _dbSet.AsNoTracking().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync().ConfigureAwait(false);
        }





    }
}
