using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class HarassmentTypeRepository : Repository<HarassmentType>, IHarassmentTypeRepository
    {
		private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 

		public HarassmentTypeRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
		{
			_context = context;
            _contextFactory = contextFactory;

        }

    }
}
