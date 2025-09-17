using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly MainDbContext _context;

		public CategoryRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Category>> GetAllCategory()
		{
			return await _context.MstCategories.ToListAsync();
		}
	
	}
}
