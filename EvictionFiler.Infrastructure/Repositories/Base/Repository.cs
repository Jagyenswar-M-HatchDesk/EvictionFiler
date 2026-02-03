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
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly DbSet<T> _dbSet;

		protected Repository(MainDbContext context)
		{
			_context = context;
            this.contextFactory = contextFactory;
            _dbSet = context.Set<T>();
		}
		public async Task<T> AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			return entity;
		}
		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await _dbSet.AddRangeAsync(entities);
		}

		// Update method ke neeche ya kahin bhi jod sakte ho

		public void UpdateRange(IEnumerable<T> entities)
		{
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
					_context.Entry(localEntity).State = EntityState.Detached;
				}

				_context.Entry(entity).State = EntityState.Modified;
			}
		}




		public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
		{
			return await _dbSet.AnyAsync(predicate!);
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
		{
			return await _dbSet.CountAsync(predicate!);
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity == null)
			{
				return false;
			}
			_dbSet.Remove(entity);
			return true;

		}
		public async Task<bool> SoftDeleteAsync(Guid id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity == null)
			{
				return false;
			}
			entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;

            return true;

		}




		public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includes)
		{
			var query = _dbSet.Where(predicate).AsQueryable();
			if (includes != null)
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return await query.FirstOrDefaultAsync();
		}


		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes)
		{
         

            IQueryable<T> query = _dbSet.AsNoTracking();

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
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbSet.FindAsync(id);
		}

        public T UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _dbSet.Attach(entity);
            return entity;
        }




    }
}
