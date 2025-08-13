
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class AdditionalOccupantsRepository : Repository<AdditionalOccupants>, IAdditionalOccupantsRepository
	{
		private readonly MainDbContext _context;

		public AdditionalOccupantsRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}
	
	}
}
