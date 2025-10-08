using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class CaseTypeRepository : Repository<CaseType>, ICaseTypeRepository
	{
		private readonly MainDbContext _context;

		public CaseTypeRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

        public async Task<List<CaseStatus>> GetAllCaseStatus()
        {
            return await _context.MstCaseStatus.ToListAsync();
        }

        public async Task<List<CaseType>> GetAllCaseType()
		{
			return await _context.MstCaseTypes.ToListAsync();
		}

        public async Task<List<County>> GetAllCounty()
        {
            return await _context.MstCounties.ToListAsync();
        }

        public async Task<List<CourtPart>> GetAllCourtPart()
        {
            return await _context.MstCourtPart.ToListAsync();
        }
    }
}
