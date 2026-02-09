using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class UnitIllegalRepository : Repository<IsUnitIllegal>, IUnitIllegalRepository
	{
		private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 

		public UnitIllegalRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
		{
			_context = context;
            _contextFactory = contextFactory;

        }

        public async Task<List<IsUnitIllegal>> GetAllUnitIllegal()
		{
			return await _context.MstIsUnitIllegal.ToListAsync();
		}
	}
}
