using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseWarrantRepository : Repository<CaseWarrant> ,ICaseWarrantRepository
    {
        private readonly MainDbContext _mainDbContext;
        public CaseWarrantRepository(MainDbContext mainDbContext) : base(mainDbContext) 
        {
            _mainDbContext = mainDbContext;
        }
    }
}
