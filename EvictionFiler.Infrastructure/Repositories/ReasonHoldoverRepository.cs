using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class ReasonHoldoverRepository :  Repository<ReasonHoldover>, IReasonHoldoverRepository
	{
		private readonly MainDbContext _context;

		public ReasonHoldoverRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<ReasonHoldover>> GetAllTReasonHoldover()
		{
			return await _context.MstReasonHoldover.ToListAsync();
		}
	}
}
