using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvictionFiler.Infrastructure.Repositories.Base
{
	public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : DeletableGuidEntity
	{
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
		private readonly DbSet<TEntity> _dbSet;

		protected Repository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory)
		{
            _contextFactory = contextFactory;
			_dbSet = context.Set<TEntity>();
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
			await db.Set<TEntity>().AddAsync(entity);
			await db.SaveChangesAsync();
			return entity;
		}

		public async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			await db.Set<TEntity>().AddRangeAsync(entities);
			await db.SaveChangesAsync();
		}

		public async Task UpdateRange(IEnumerable<TEntity> entities)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			var _dbSet = db.Set<TEntity>();

			ArgumentNullException.ThrowIfNull(entities);

            var idProperty = typeof(TEntity).GetProperty("Id");

			if (idProperty == null)
				throw new InvalidOperationException($"Type {typeof(TEntity).Name} does not contain a property named 'Id'.");

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

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            return await db.Set<TEntity>().AnyAsync(predicate!);
		}

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			return await db.Set<TEntity>().CountAsync(predicate!);
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			await using var db = await _contextFactory.CreateDbContextAsync();
			var entity = await db.Set<TEntity>().FindAsync(id);
			if (entity == null)
			{
				return false;
			}
			db.Set<TEntity>().Remove(entity);
			var result = await db.SaveChangesAsync();
			if (result > 0) return true;
			
			return false;

		}

		public async Task<bool> SoftDeleteAsync(Guid id)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            var entity = await db.Set<TEntity>().FindAsync(id);
			if (entity == null)
			{
				return false;
			}
			entity.IsDeleted = true;
            db.Entry(entity).State = EntityState.Modified;

            return true;

		}

		public async Task<TEntity?> FindAsync(
			Expression<Func<TEntity, bool>> predicate, 
			params Expression<Func<TEntity, object>>[]? includes)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            var query = db.Set<TEntity>().Where(predicate).AsQueryable();
			if (includes != null)
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return await query.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync(
			Expression<Func<TEntity, bool>>? predicate = null, 
			params Expression<Func<TEntity, object>>[]? includes)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            IQueryable<TEntity> query = db.Set<TEntity>().AsNoTracking();

            if (predicate != null)
				query = query.Where(predicate);

			if (includes != null)
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return await query.ToListAsync();
		}

		public IQueryable<TEntity> GetAllQuerable(
			Expression<Func<TEntity, bool>>? predicate = null, 
			params Expression<Func<TEntity, object>>[]? includes)
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

        public async Task<TEntity?> GetAsync(
			Guid? id)
		{
            await using var db = await _contextFactory.CreateDbContextAsync();
            if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await db.Set<TEntity>().FindAsync(id);
		}

        public async Task<TEntity?> UpdateAsync(
			TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await using var db = await _contextFactory.CreateDbContextAsync();
            db.Entry(entity).State = EntityState.Modified;

            var result = await db.SaveChangesAsync();
            return result > 0 ? entity : default;
        }
    }
}
