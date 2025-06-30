using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CasesRepository : ICasesRepository
    {
        private readonly MainDbContext _context;

        public CasesRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<List<LegalCase>> GetAllCasesAsync()
        {
            return await _context.LegalCases
                .Include(c => c.Clients)
                .Include(c => c.Apartments)
                .Include(c => c.LandLords)
                .ToListAsync();
        }

        public async Task<LegalCase?> GetCaseByIdAsync(Guid id)
        {
            return await _context.LegalCases
                .Include(c => c.Clients)
                .Include(c => c.Apartments)
                .Include(c => c.LandLords)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCaseAsync(LegalCase legalCase)
        {
            legalCase.Id = Guid.NewGuid(); 
            await _context.LegalCases.AddAsync(legalCase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCaseAsync(LegalCase legalCase)
        {
            _context.LegalCases.Update(legalCase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCaseAsync(Guid id)
        {
            var legalCase = await _context.LegalCases.FindAsync(id);
            if (legalCase != null)
            {
                _context.LegalCases.Remove(legalCase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
