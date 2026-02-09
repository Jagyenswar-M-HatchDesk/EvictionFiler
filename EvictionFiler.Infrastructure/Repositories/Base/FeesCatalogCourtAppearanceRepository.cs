

using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class FeesCatalogCourtAppearanceRepository : IFeesCatalogCourtAppearanceRepository
    {
        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public FeesCatalogCourtAppearanceRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;
        }

        // Added missing GetByIdAsync
        public Task<FeesCatalogCourtAppearance?> GetByIdAsync(Guid id)
        {
            return _context.FeesCatalogCourtAppearances.FindAsync(id).AsTask();
        }

        public async Task<List<FeesCatalogCourtAppearanceDto>> GetAllAsync()
        {
           var data = await _context.FeesCatalogCourtAppearances.ToListAsync();
            return data.Select(e => new FeesCatalogCourtAppearanceDto()
            {
                Id = e.Id,
                AttorneyHourly = e.AttorneyHourly,
                County = e.County,
                CourtAppearance = e.CourtAppearance,
                PerDiem = e.PerDiem,
            }).ToList();
        }
        public async Task<Guid?> AddAsync(FeesCatalogCourtAppearance entity)
        {
            _context.FeesCatalogCourtAppearances.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(FeesCatalogCourtAppearanceDto entity)
        {
            var existing = await _context.FeesCatalogCourtAppearances.FindAsync(entity.Id);
            if (existing != null)
            {
                existing.CourtAppearance = entity.CourtAppearance;
                existing.County = entity.County;
                existing.PerDiem = entity.PerDiem;
                existing.AttorneyHourly = entity.AttorneyHourly;


                _context.FeesCatalogCourtAppearances.Update(existing);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task DeleteAsync(Guid id)
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

