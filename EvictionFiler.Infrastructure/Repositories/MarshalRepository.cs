using EvictionFiler.Application.DTOs.MarshalsDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class MarshalRepository : IMarshalRepositroy
    {
        private readonly MainDbContext _db;
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public MarshalRepository(MainDbContext db, IDbContextFactory<MainDbContext> contextFactory)
        {
            _db = db;
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Marshal>> GetAllMarshalAsync()
        {
            return await _db.Marshal.ToListAsync();
        }


        public async Task<List<MarshalDto>> SearchMarshalbyname(string name)
        {
            var tenant = await _db.Marshal.Where(e => e.FirstName.Contains(name)).Select(dto => new MarshalDto
            {

               FirstName = dto.FirstName,
                LastName = dto.LastName,


            }).ToListAsync();
            if (tenant == null)
                return new List<MarshalDto>();
            return tenant;
        }
        public async Task<Marshal> GetMarshalByIdAsync(Guid id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            return await db.Marshal.FirstOrDefaultAsync(x => x.Id == id) ?? new();
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
            existing.DocketNo = marshal.DocketNo;

            await _db.SaveChangesAsync();
            return existing;
        }
        public async Task<Marshal> UpdateMarshalDocketnoAsync(Guid marhsalid, string docket)
        {
            var existing = await _db.Marshal.FindAsync(marhsalid);

            if (existing == null)
                return null;

           
            existing.DocketNo = docket;

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
