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
    public class CaseProgramRepository : Repository<CaseProgram> , ICaseProgramRepository
    {
        private readonly MainDbContext _context;

        public CaseProgramRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CaseProgram>> GetAllCaseProgram()
        {
            return await _context.MstCaseProgram.ToListAsync();
        }
    }
}
