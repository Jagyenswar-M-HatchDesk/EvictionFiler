using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class RemainderCenterRepository : Repository<RemainderCenter>, IRemainderCenterRepository
    {
        private readonly MainDbContext _context;

        public RemainderCenterRepository(MainDbContext context) : base(context)
        {
            _context = context;
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
