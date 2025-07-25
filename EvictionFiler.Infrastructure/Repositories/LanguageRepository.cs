using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class LanguageRepository : Repository<Language>, ILanguageRepository
	{
		private readonly MainDbContext _context;

		public LanguageRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Language>> GetAllLanguage()
		{
			return await _context.MstLanguages.ToListAsync();
		}
	
	}
}
