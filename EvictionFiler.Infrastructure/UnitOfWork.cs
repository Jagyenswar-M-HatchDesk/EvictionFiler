using EvictionFiler.Application;
using EvictionFiler.Infrastructure.DbContexts;

namespace EvictionFiler.Infrastructure
{
	public class UnitOfWork  : IUnitOfWork
	{
		private readonly MainDbContext _context; 

		public UnitOfWork(MainDbContext context)
		{
			this._context = context;
		}
		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
