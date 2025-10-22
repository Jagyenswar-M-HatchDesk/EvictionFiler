

using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class FeesCatalogCourtAppearanceRepository : IFeesCatalogCourtAppearanceRepository
    {
        private readonly MainDbContext _context;
        public FeesCatalogCourtAppearanceRepository(MainDbContext context) => _context = context;

        // Added missing GetByIdAsync
        public Task<FeesCatalogCourtAppearance?> GetByIdAsync(int id)
        {
            return _context.FeesCatalogCourtAppearances.FindAsync(id).AsTask();
        }

        public async Task<List<FeesCatalogCourtAppearance>> GetAllAsync() =>
            await _context.FeesCatalogCourtAppearances.ToListAsync();

        public async Task AddAsync(FeesCatalogCourtAppearance entity)
        {
            _context.FeesCatalogCourtAppearances.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeesCatalogCourtAppearance entity)
        {
            _context.FeesCatalogCourtAppearances.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _context.FeesCatalogCourtAppearances.FindAsync(id);
            if (e != null)
            {
                _context.FeesCatalogCourtAppearances.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }
}

