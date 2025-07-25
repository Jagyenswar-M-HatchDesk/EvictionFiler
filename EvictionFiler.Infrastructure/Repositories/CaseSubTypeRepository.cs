using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class CaseSubTypeRepository : Repository<CaseSubType>, ICaseSubTypeRepository
	{
		private readonly MainDbContext _context;

		public CaseSubTypeRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}


		public async Task<List<CaseSubType>> GetSubTypesByCaseTypeIdAsync(Guid caseTypeId)
		{
			var result = await _context.MstCaseSubTypes
				.Where(x => x.CaseTypeId == caseTypeId
					&& (x.IsActive == true || x.IsActive == null)
					&& (x.IsDeleted == false || x.IsDeleted == null))
				.ToListAsync();

			return result;
		}
	}
}
