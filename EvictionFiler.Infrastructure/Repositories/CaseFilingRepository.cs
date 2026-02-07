using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
