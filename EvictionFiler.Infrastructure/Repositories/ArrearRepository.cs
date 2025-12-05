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
    public class ArrearRepository : Repository<ArrearLedger>, IArrearLedgerRepository
    {
        private readonly MainDbContext _context;
        public ArrearRepository(MainDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
