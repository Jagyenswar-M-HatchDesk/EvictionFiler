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
    public  class CaseNotesReadRepository : ReadRepository<CaseNotes> , ICaseNotesReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public CaseNotesReadRepository(IDbContextFactory<MainDbContext> contextFactory): base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
