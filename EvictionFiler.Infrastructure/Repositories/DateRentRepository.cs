using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class DateRentRepository : Repository<DateRent>, IDateRentRepository
    {
        private readonly MainDbContext _context; 
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public DateRentRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
        {
            _context = context;
            this.contextFactory = contextFactory;
        }
    
        public async  Task<List<DateRent>> GetAllDateRent()
        {
            await using var db = await contextFactory.CreateDbContextAsync();
            return await db.MstDateRent.ToListAsync();
        }
    }
}
