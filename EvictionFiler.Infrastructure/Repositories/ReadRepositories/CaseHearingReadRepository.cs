using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public  class CaseHearingReadRepository : ReadRepository<CaseHearing>, ICaseHearingReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _dbContextFactory;

        public CaseHearingReadRepository(IDbContextFactory<MainDbContext> dbContextFactory): base(dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
