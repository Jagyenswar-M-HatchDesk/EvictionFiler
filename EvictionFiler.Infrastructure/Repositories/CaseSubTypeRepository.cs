using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class CaseSubTypeRepository : Repository<CaseSubType>, ICaseSubTypeRepository
    {
		private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 

		public CaseSubTypeRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;

        }

        public Task<List<CaseSubType>> GetSubTypesByCaseTypeIdAsync(Guid caseTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
