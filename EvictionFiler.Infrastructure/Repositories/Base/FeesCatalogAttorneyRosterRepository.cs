

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
//        private readonly MainDbContext _context;
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

using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class FeesCatalogAttorneyRosterRepository : IFeesCatalogAttorneyRosterRepository
    {
        private readonly MainDbContext _context;
        public FeesCatalogAttorneyRosterRepository(MainDbContext context) => _context = context;

        public async Task<List<FeesCatalogAttorneyRoster>> GetAllAsync() =>
            await _context.FeesCatalogAttorneyRosters.AsNoTracking().ToListAsync();

        public Task<FeesCatalogAttorneyRoster?> GetByIdAsync(int id) =>
            _context.FeesCatalogAttorneyRosters.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        //public async Task AddAsync(FeesCatalogAttorneyRoster entity)
        //{
        //    _context.FeesCatalogAttorneyRosters.Add(entity);
        //    await _context.SaveChangesAsync();

        //}
        public async Task<int> AddAsync(FeesCatalogAttorneyRoster entity)
        {
            _context.FeesCatalogAttorneyRosters.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<bool> UpdateAsync(FeesCatalogAttorneyRoster entity)
        {
            var existing = await _context.FeesCatalogAttorneyRosters
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existing == null)
                throw new KeyNotFoundException($"Attorney Roster with Id {entity.Id} not found.");

            // Attach and mark modified
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int id)
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
