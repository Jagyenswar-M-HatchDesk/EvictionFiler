

//using EvictionFiler.Application.Interfaces.IRepository;
//using EvictionFiler.Domain.Entities.Master;
//using EvictionFiler.Infrastructure.DbContexts;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace EvictionFiler.Infrastructure.Repositories
//{
//    public class FeesCatalogAttorneyRosterRepository : IFeesCatalogAttorneyRosterRepository
//    {
//        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
//        public FeesCatalogAttorneyRosterRepository(MainDbContext context) => _context = context;


//        public Task<FeesCatalogAttorneyRoster?> GetByIdAsync(int id)
//        {
//            return _context.FeesCatalogAttorneyRosters.FindAsync(id).AsTask();
//        }

//        public async Task<List<FeesCatalogAttorneyRoster>> GetAllAsync() =>
//            await _context.FeesCatalogAttorneyRosters.ToListAsync();

//        public async Task AddAsync(FeesCatalogAttorneyRoster entity)
//        {
//            _context.FeesCatalogAttorneyRosters.Add(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(FeesCatalogAttorneyRoster entity)
//        {
//            _context.FeesCatalogAttorneyRosters.Update(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var e = await _context.FeesCatalogAttorneyRosters.FindAsync(id);
//            if (e != null)
//            {
//                _context.FeesCatalogAttorneyRosters.Remove(e);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}

using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class FeesCatalogAttorneyRosterRepository : IFeesCatalogAttorneyRosterRepository
    {
        private readonly MainDbContext _context; private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public FeesCatalogAttorneyRosterRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;

        }

        public async Task<List<FeesCatalogAttorneyRosterDto>> GetAllAsync()
        {
            var data = await _context.FeesCatalogAttorneyRosters.ToListAsync();
            return data.Select(e => new FeesCatalogAttorneyRosterDto()
            {
                Id = e.Id,
                Name = e.Name,
                BarNumber = e.BarNumber,
                Email = e.Email,
                HourlyRate = e.HourlyRate,
                Role = e.Role,
                TravelWait = e.TravelWait,
            }).ToList();
        }
        public Task<FeesCatalogAttorneyRoster?> GetByIdAsync(Guid id) =>
            _context.FeesCatalogAttorneyRosters.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        //public async Task AddAsync(FeesCatalogAttorneyRoster entity)
        //{
        //    _context.FeesCatalogAttorneyRosters.Add(entity);
        //    await _context.SaveChangesAsync();

        //}
        public async Task<Guid> AddAsync(FeesCatalogAttorneyRoster entity)
        {
            _context.FeesCatalogAttorneyRosters.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<bool> UpdateAsync(FeesCatalogAttorneyRosterDto entity)
        {
            var existing = await _context.FeesCatalogAttorneyRosters
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existing == null)
                return false;

            existing.Email = entity.Email;
            existing.Name = entity.Name;
            existing.BarNumber = entity.BarNumber;
            existing.Role = entity.Role;
            existing.TravelWait = entity.TravelWait;
            
            // Attach and mark modified
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.FeesCatalogAttorneyRosters.FindAsync(id);
            if (entity != null)
            {
                _context.FeesCatalogAttorneyRosters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
