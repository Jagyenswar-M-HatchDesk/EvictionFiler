using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
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

        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        protected ReadRepository(IDbContextFactory<MainDbContext> contextFactory)
        {
          
            _contextFactory = contextFactory;
        }

     
        public async Task<T?> GetAsync(object id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await db.Set<T>().FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity)
        {
           await  using var db =  await _contextFactory.CreateDbContextAsync();
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            params Expression<Func<T, object>>[]? includes)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            IQueryable<T> query = db.Set<T>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }
        public async Task<IQueryable<T>> GetAllQuerable(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            IQueryable<T> query = db.Set<T>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query;
        }
        public async Task<T?> AddAsync(T entity)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            await db.Set<T>().AddAsync(entity);
           var result= await db.SaveChangesAsync();
            if (result > 0) 
                return entity;

            return null;
        }


    }
}
