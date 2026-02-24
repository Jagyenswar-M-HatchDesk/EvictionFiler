using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
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
    public  class CitiesRepository : ReadRepository<City>, ICitiesRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public CitiesRepository(IDbContextFactory<MainDbContext> contextFactory):base(contextFactory)
        {
            _contextFactory = contextFactory;

        }

    }
}
