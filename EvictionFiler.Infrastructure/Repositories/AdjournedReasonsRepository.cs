using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
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
        public AdjournedReasonsRepository(MainDbContext maindbcontext) : base(maindbcontext) 
        {
            _maindbcontext = maindbcontext;
        }
    }
}
