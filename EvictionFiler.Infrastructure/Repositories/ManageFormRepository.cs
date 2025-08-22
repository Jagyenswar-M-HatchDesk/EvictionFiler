using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class ManageFormRepository : IManageFormRepository
    {
        private readonly MainDbContext _context;
        public ManageFormRepository(MainDbContext context)
        { 
            _context = context;
        }

        public async Task<List<FormTypes>> GetAllForm()
        {
            var forms = await _context.MstFormTypes.ToListAsync();
            return forms;
        }
    }
}
