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
    public class ReminderCategoryRepository : Repository<ReminderCategory> , IReminderCategoryRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public ReminderCategoryRepository(MainDbContext mainDbContext,IDbContextFactory<MainDbContext>contextFactory) : base(mainDbContext) 
        {
            _mainDbContext = mainDbContext;
            this.contextFactory = contextFactory;
        }
        public async Task<IEnumerable<ReminderCategory>> GetAllAsync1(Expression<Func<ReminderCategory, bool>>? predicate = null, params Expression<Func<ReminderCategory, object>>[]? includes)
        {


            await using var context = await contextFactory.CreateDbContextAsync();

            IQueryable<ReminderCategory> query = context.Set<ReminderCategory>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync().ConfigureAwait(false);
        }

    }
}
