using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class ExemptionReasonRepository : Repository<ExemptionReason> , IExemptionReasonRepository
    {
        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public ExemptionReasonRepository(MainDbContext context,IDbContextFactory<MainDbContext>contextFactory) : base(context, contextFactory) 
        {
            _context = context;
            this.contextFactory = contextFactory;
        }
        public async Task<IEnumerable<ExemptionReason>> GetAllAsync5(Expression<Func<ExemptionReason, bool>>? predicate = null, params Expression<Func<ExemptionReason, object>>[]? includes)
        {


            await using var context = await contextFactory.CreateDbContextAsync();

            IQueryable<ExemptionReason> query = context.Set<ExemptionReason>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
