using EvictionFiler.Application;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        private MainDbContext? _context;

        public UnitOfWork(IDbContextFactory<MainDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private MainDbContext Context => _context ??= _contextFactory.CreateDbContext();

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        // Transaction management methods
        public async Task BeginTransactionAsync() => await Context.Database.BeginTransactionAsync();
        public async Task CommitTransactionAsync() => await Context.Database.CommitTransactionAsync();
        public async Task RollbackTransactionAsync() => await Context.Database.RollbackTransactionAsync();
        public async ValueTask DisposeAsync()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
