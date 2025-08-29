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

		
		public async Task<List<CaseType>> GetAllCaseType()
		{
			return await _context.MstCaseTypes.ToListAsync();
		}

		
	}
}
