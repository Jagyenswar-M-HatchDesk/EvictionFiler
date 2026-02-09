using EvictionFiler.Application.DTOs.MasterDtos.CountyDto;

//using EvictionFiler.Application.DTOs.MasterDtos.CountyHPDDto;
//using EvictionFiler.Application.DTOs.MasterDtos.CountyPerDiemDto;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class CountyRepository : Repository<County>, ICountyRepository
	{
		private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 

		public CountyRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;

        }

        public async Task<List<EditToCountyDto>> SearchCounty(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<EditToCountyDto>();

            searchTerm = searchTerm.Trim().ToLower();



            var counties = await _context.MstCounties
                .Where(e =>
                    (e.Name != null && e.Name.ToLower().Contains(searchTerm))

                )
                .Select(e => new EditToCountyDto
                {
                    Id = e.Id,
                    Name = e.Name,

                })
                .ToListAsync();

            return counties ?? new List<EditToCountyDto>();
        }

    }
}
