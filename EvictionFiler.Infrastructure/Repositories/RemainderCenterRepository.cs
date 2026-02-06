using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class RemainderCenterRepository : Repository<RemainderCenter>, IRemainderCenterRepository
    {
        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 

        public RemainderCenterRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;

        }
        public async Task<bool> DeleteAllAsync()
        {
            var allDelete = await _context.TblRemainderCenter
                .Where(x => x.IsDeleted != true)
                .ToListAsync();

            if (!allDelete.Any())
                return false;

            _context.RemoveRange(allDelete);
            return true;
        }
    }
}
