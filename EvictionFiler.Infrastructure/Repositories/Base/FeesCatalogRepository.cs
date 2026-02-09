
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class FeesCatalogRepository : IFeesCatalogRepository
    {
        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public FeesCatalogRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;
        }

        public Task<FeesCatalog?> GetByIdAsync(Guid id)
        {
            // Implementation of GetByIdAsync using FindAsync
            return _context.FeesCatalogs.FindAsync(id).AsTask();
        }

        public async Task<List<FeesCatalogDto>> GetAllByCategoryAsync(string Category)
        {
            var feescatalog = await _context.FeesCatalogs.Include(e=>e.Form).Where(e => e.Category == Category).ToListAsync();
            return feescatalog.Select(e=> new FeesCatalogDto()
            {
                Id = e.Id,
                Label = e.Form != null ? e.Form.Name : "",
                Code = e.Code,
                Rate = e.Rate,
                Unit = e.Unit,
                LabelId = e.LabelId,

            }).ToList();
        }
        public async Task<List<FeesCatalog>> GetAllAsync() =>
            await _context.FeesCatalogs.ToListAsync();
        public async Task<Guid?> AddAsync(FeesCatalogDto entity)
        {
            if(entity == null) return null;

            var fees = new FeesCatalog()
            {
                Id = entity.Id,
                Label = entity.Label,
                Code = entity.Code,
                Rate = entity.Rate,
                Unit = entity.Unit,
                LabelId = entity.LabelId,
                Category = entity.Category,

            };

            _context.FeesCatalogs.Add(fees);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(FeesCatalogDto entity)
        {
            var data = await _context.FeesCatalogs.FindAsync(entity.Id);
            if (data == null) return false;

            data.Unit = entity.Unit;
            data.Label = entity.Label;
            data.Code = entity.Code;
            data.Rate = entity.Rate;
            data.LabelId = entity.LabelId;
            data.Category = entity.Category;

            _context.FeesCatalogs.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(Guid id)
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