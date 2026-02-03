using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class TenancyTypeRepository : Repository<TenancyType>, ITenancyTypeRepository
	{
		private readonly MainDbContext _context;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public TenancyTypeRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context)
	{
		_context = context;
            this.contextFactory = contextFactory;
        }

	public async Task<List<TenancyType>> GetAllTenancyType()
	{
            await using var db = await contextFactory.CreateDbContextAsync();
            return await db.MstTenancyTypes.ToListAsync();
	}
	
	}
}
