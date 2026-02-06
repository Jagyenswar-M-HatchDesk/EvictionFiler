using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class ReasonHoldoverRepository :  Repository<ReasonHoldover>, IReasonHoldoverRepository
	{
		private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 

		public ReasonHoldoverRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
		{
			_context = context;
            _contextFactory = contextFactory;

        }

        public async Task<List<ReasonHoldover>> GetAllTReasonHoldover()
		{
			return await _context.MstReasonHoldover.ToListAsync();
		}
	}
}
