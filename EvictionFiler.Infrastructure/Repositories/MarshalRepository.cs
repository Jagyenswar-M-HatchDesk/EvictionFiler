using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class MarshalRepository : IMarshalRepositroy
    {
        private readonly MainDbContext _db;

        public MarshalRepository(MainDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Marshal>> GetAllMarshalAsync()
        {
            return await _db.Marshal.ToListAsync();
        }

        public async Task<Marshal> GetMarshalByIdAsync(Guid id)
        {
            return await _db.Marshal.FirstOrDefaultAsync(x => x.Id == id) ?? new();
        }
        public async Task<Marshal> AddMarshalAsync(Marshal marshal)
        {
            await _db.Marshal.AddAsync(marshal);
            await _db.SaveChangesAsync();
            return marshal;
        }

        public async Task<Marshal> UpdateMarshalAsync(Marshal marshal)
        {
            var existing = await _db.Marshal.FindAsync(marshal.Id);

            if (existing == null)
                return null;

            existing.FirstName = marshal.FirstName;
            existing.LastName = marshal.LastName;
            existing.Email = marshal.Email;
            existing.BadgeNumber = marshal.BadgeNumber;
            existing.Telephone = marshal.Telephone;
            existing.Fax = marshal.Fax;
            existing.OfficeAddress = marshal.OfficeAddress;

            await _db.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> DeleteMarshalAsync(Guid id)
        {
            var marshal = await _db.Marshal.FindAsync(id);

            if (marshal == null)
                return false;

            _db.Marshal.Remove(marshal);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
