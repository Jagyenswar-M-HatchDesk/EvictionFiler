using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseFilingRepository : Repository<CaseFiling> , ICaseFilingRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public CaseFilingRepository(MainDbContext mainDbContext, IDbContextFactory<MainDbContext> contextFactory) : base(mainDbContext, contextFactory)
        {
            _mainDbContext = mainDbContext;
            _contextFactory = contextFactory;
        }
    }
}
