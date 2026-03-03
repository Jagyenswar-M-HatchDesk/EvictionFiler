using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
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

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public  class RemainderCenterReadRepository : ReadRepository<RemainderCenter>, IRemainderCenterReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public RemainderCenterReadRepository(IDbContextFactory<MainDbContext> contextFactory):base(contextFactory)
        {
            this.contextFactory = contextFactory;
        }
    }
}
