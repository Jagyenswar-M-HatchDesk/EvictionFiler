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
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        private readonly MainDbContext _context;

        public UnitRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
