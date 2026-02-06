using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
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
    public class CaseAppreanceRepository : Repository<CaseAppearance>, ICaseAppearanceRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CaseAppreanceRepository(MainDbContext mainDbContext,IDbContextFactory<MainDbContext>contextFactory) : base(mainDbContext) 
        {
            _mainDbContext = mainDbContext;
            this.contextFactory = contextFactory;
        }
        public async Task<List<CaseAppearance>> GetAlllAsync(Expression<Func<CaseAppearance, bool>>? predicate = null, params Expression<Func<CaseAppearance, object>>[]? includes)
        {
            await using var db = await contextFactory.CreateDbContextAsync();

            IQueryable<CaseAppearance> query = db.Set<CaseAppearance>();
           
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
