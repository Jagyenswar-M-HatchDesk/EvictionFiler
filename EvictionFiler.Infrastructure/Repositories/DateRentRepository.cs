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
    public class DateRentRepository : Repository<DateRent>, IDateRentRepository
    {
        private readonly MainDbContext _context;

        public DateRentRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }
    
        public async  Task<List<DateRent>> GetAllDateRent()
        {
            return await _context.MstDateRent.ToListAsync();
        }
    }
}
