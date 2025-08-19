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
    public class AdditionalTenantsRepository : Repository<AdditioanlTenants>, IAdditionalTenantsRepository
    {
        private readonly MainDbContext _context;

        public AdditionalTenantsRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }
    
    }
}
