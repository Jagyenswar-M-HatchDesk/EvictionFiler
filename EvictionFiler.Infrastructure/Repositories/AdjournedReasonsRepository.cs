using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
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
    public class AdjournedReasonsRepository : Repository<AdjournedReason> , IAdjournedReasonRepository
    {
        private readonly MainDbContext _maindbcontext; 
        private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        public AdjournedReasonsRepository(MainDbContext maindbcontext, IDbContextFactory<MainDbContext> contextFactory) : base(maindbcontext, contextFactory)
        {
            _maindbcontext = maindbcontext;
            _contextFactory = contextFactory;
        }
    }
}
