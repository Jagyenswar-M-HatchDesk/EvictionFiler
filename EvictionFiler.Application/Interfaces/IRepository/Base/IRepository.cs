using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.Base
{
	public interface IRepository<TEntity> where TEntity : class
    {
		Task<TEntity> AddAsync(TEntity entity);
		Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateRange(IEnumerable<TEntity> entities);
        Task<TEntity?> UpdateAsync(TEntity entity);
		Task<bool> DeleteAsync(Guid id);
        Task<bool> SoftDeleteAsync(Guid id);

        Task<TEntity?> GetAsync(
			Guid? id);

		Task<TEntity?> FindAsync(
			Expression<Func<TEntity, bool>> predicate, 
			params Expression<Func<TEntity, object>>[]? includes);

		Task<IEnumerable<TEntity>> GetAllAsync(
			Expression<Func<TEntity, bool>>? predicate = null, 
			params Expression<Func<TEntity, object>>[]? includes);

		IQueryable<TEntity> GetAllQuerable(
			Expression<Func<TEntity, bool>>? predicate = null,
			params Expression<Func<TEntity, object>>[]? includes);

		Task<int> CountAsync(
			Expression<Func<TEntity, bool>>? 
			predicate = null);

		Task<bool> AnyAsync(
			Expression<Func<TEntity, bool>>?
			predicate = null);
    }
}
