using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
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

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CalanderRepository : Repository<Calander>, ICalanderRepository
    {
        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 

        public CalanderRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;
        }

    }
}
