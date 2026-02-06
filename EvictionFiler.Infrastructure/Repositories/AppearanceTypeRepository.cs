using EvictionFiler.Application.DTOs.MasterDtos.ApperenceTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeHPDDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypePerDiemDto;
using EvictionFiler.Application.DTOs.MasterDtos.DefenseTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.DocumentInstructionPerDiemDto;
using EvictionFiler.Application.DTOs.MasterDtos.HarassmentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefPetitionerTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefRespondentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReportingRequirementPerDiemDto;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Linq.Expressions;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class AppearanceTypeRepository : Repository<AppearanceType>, IAppearanceTypeRepository
	{
		private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public AppearanceTypeRepository(MainDbContext context,IDbContextFactory<MainDbContext>contextFactory) : base(context , contextFactory)
		{
			_context = context;
            this.contextFactory = contextFactory;
        }
        public async Task<IEnumerable<AppearanceType>> GetAllAsync1(Expression<Func<AppearanceType, bool>>? predicate = null, params Expression<Func<AppearanceType, object>>[]? includes)
        {


            await using var context = await contextFactory.CreateDbContextAsync();

            IQueryable<AppearanceType> query = context.Set<AppearanceType>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
