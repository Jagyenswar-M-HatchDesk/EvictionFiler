using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class TenancyTypeRepository : Repository<TenancyType>, ITenancyTypeRepository
	{
		private readonly MainDbContext _context;

	public TenancyTypeRepository(MainDbContext context) : base(context)
	{
		_context = context;
	}

	public async Task<List<TenancyType>> GetAllTenancyType()
	{
		return await _context.MstTenancyTypes.ToListAsync();
	}
	
	}
}
