using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.Base
{
	public interface IRepository<T>
	{
		Task<T> AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
        //Task RemoveRange(IEnumerable<T> entities);
        Task UpdateRange(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);


		Task<bool> DeleteAsync(Guid id);
		Task<T?> GetAsync(object id);
		Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includes);
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes);
		IQueryable<T> GetAllQuerable(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes);
		Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
		Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);

		Task<bool> SoftDeleteAsync(Guid id);

		public IQueryable<T> GetAllQueryablewithThenInclude(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IQueryable<T>>? include = null);



    }
}
