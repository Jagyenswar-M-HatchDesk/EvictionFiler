using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Grpc.Core.Metadata;

namespace EvictionFiler.Infrastructure.Repositories.Base
{
	public abstract class Repository<T> : IRepository<T> where T : DeletableBaseEntity
	{
		private readonly MainDbContext _context;
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
		private readonly DbSet<T> _dbSet;

		protected Repository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory)
		{
			_context = context;
            _contextFactory = contextFactory;
			_dbSet = context.Set<T>();
		}
		public async Task<T> AddAsync(T entity)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
			await db.Set<T>().AddAsync(entity);
			await db.SaveChangesAsync();
			return entity;
		}
		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			await db.Set<T>().AddRangeAsync(entities);
			await db.SaveChangesAsync();

		}

		// Update method ke neeche ya kahin bhi jod sakte ho

		public async Task UpdateRange(IEnumerable<T> entities)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			var _dbSet = db.Set<T>();

			if (entities == null)
				throw new ArgumentNullException(nameof(entities));

			var idProperty = typeof(T).GetProperty("Id");

			if (idProperty == null)
				throw new InvalidOperationException($"Type {typeof(T).Name} does not contain a property named 'Id'.");

			foreach (var entity in entities)
			{
				var entityId = idProperty.GetValue(entity);

				var localEntity = _dbSet.Local.FirstOrDefault(e =>
					idProperty.GetValue(e)?.Equals(entityId) == true);

				if (localEntity != null)
				{
					db.Entry(localEntity).State = EntityState.Detached;
				}

				db.Entry(entity).State = EntityState.Modified;
			}

			await db.SaveChangesAsync();
		}




		public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            return await db.Set<T>().AnyAsync(predicate!);
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			return await db.Set<T>().CountAsync(predicate!);
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			var entity = await db.Set<T>().FindAsync(id);
			if (entity == null)
			{
				return false;
			}
			db.Set<T>().Remove(entity);
			var result = await db.SaveChangesAsync();
			if (result > 0) return true;
			
			return false;

		}
		public async Task<bool> SoftDeleteAsync(Guid id)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            var entity = await db.Set<T>().FindAsync(id);
			if (entity == null)
			{
				return false;
			}
			entity.IsDeleted = true;
            db.Entry(entity).State = EntityState.Modified;

            return true;

		}




		public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includes)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            var query = db.Set<T>().Where(predicate).AsQueryable();
			if (includes != null)
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return await query.FirstOrDefaultAsync();
		}


		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes)
		{

            await using var db = await _contextFactory.CreateDbContextAsync();
            IQueryable<T> query = db.Set<T>().AsNoTracking();

            if (predicate != null)
				query = query.Where(predicate);

			if (includes != null)
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return await query.ToListAsync().ConfigureAwait(false);
		}


		public IQueryable<T> GetAllQuerable(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes)
		{
			
			var query = _dbSet.AsQueryable();
			if (predicate != null)
			{
				query = query.Where(predicate).AsQueryable();
			}
			if (includes != null)
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return query;
		}

        public IQueryable<T> GetAllQueryablewithThenInclude(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
                query = query.Where(predicate);

            if (include != null)
                query = include(query);

            return query;
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
            await using var db = await _contextFactory.CreateDbContextAsync();
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
			db.Attach(entity);
			await db.SaveChangesAsync();
			return entity;
        }




    }
}
