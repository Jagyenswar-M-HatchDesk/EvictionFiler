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
    public class FilingMethodRepository : Repository<FilingMethod> , IFilingMethodRepository
    {
        private readonly MainDbContext _context;
        public FilingMethodRepository(MainDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
