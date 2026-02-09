
using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class AdditionalOccupantsRepository : Repository<AdditionalOccupants>, IAdditionalOccupantsRepository
    {
        private readonly MainDbContext _context;
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public AdditionalOccupantsRepository(MainDbContext context, IDbContextFactory<MainDbContext> contextFactory) : base(context, contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;
        }

        public async Task AddAdditionalOccupant(List<AdditionalOccupantDto> tenant)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            try
            {
                var newoccupants = tenant.Select(e => new AdditionalOccupants()
                {
                    Id = Guid.NewGuid(),
                    Name = e.Name,
                    LegalCaseId = e.LegalCaseId,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,

                }).ToList();

                await db.AdditionalOccupants.AddRangeAsync(newoccupants);
                var result = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<bool> UpdateAdditionalOccupant(List<AdditionalOccupantDto> occupant)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            try
            {
                foreach(var toupdate in occupant)
                {
                    var existing = await GetAllOccupantsById(toupdate.Id);
                    if (existing == null) return false;

                    existing.Name = toupdate.Name;

                    db.AdditionalOccupants.Update(existing);
                    
                }
                var result = await db.SaveChangesAsync();
                if (result > 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<List<AdditionalOccupants>> GetAllOccupantsByCaseId(Guid legalcaseId)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            var occupants = await db.AdditionalOccupants.Where(e => e.LegalCaseId == legalcaseId).ToListAsync();
            return occupants;
        }

        public async Task<AdditionalOccupants> GetAllOccupantsById(Guid Id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            var occupants = await db.AdditionalOccupants.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return occupants;
        }
        public async Task<bool> DeleteOccupants(Guid Id)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();

            var occupants = await db.AdditionalOccupants.FindAsync(Id);
            if (occupants == null)
            {
                return false;
            }
            db.AdditionalOccupants.Remove(occupants);
            var result = await db.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}
