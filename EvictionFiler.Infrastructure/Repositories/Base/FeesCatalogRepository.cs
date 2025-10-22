
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class FeesCatalogRepository : IFeesCatalogRepository
    {
        private readonly MainDbContext _context;
        public FeesCatalogRepository(MainDbContext context) => _context = context;

        public Task<FeesCatalog?> GetByIdAsync(int id)
        {
            // Implementation of GetByIdAsync using FindAsync
            return _context.FeesCatalogs.FindAsync(id).AsTask();
        }

        public async Task<List<FeesCatalog>> GetAllAsync() =>
            await _context.FeesCatalogs.ToListAsync();

        public async Task AddAsync(FeesCatalog entity)
        {
            _context.FeesCatalogs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeesCatalog entity)
        {
            _context.FeesCatalogs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _context.FeesCatalogs.FindAsync(id);
            if (e != null)
            {
                _context.FeesCatalogs.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }
}