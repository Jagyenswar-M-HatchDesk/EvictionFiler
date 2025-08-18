using EvictionFiler.Application.Interfaces.IRepository;
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
    public class RenewalStatusRepository : Repository<RenewalStatus>, IRenewalStatusRepository
    {
        private readonly MainDbContext _context;

        public RenewalStatusRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

    
          public async Task<List<RenewalStatus>> GetAllRenewalStatus()
        {
            return await _context.MstRenewalStatus.ToListAsync();
        }
    }
}
