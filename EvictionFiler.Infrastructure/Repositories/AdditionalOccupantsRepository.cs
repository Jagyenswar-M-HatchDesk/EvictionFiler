
using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.DTOs.TenantDto;
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

        public AdditionalOccupantsRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAdditionalOccupant(List<AdditionalOccupantDto> tenant)
        {
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

                await _context.AdditionalOccupants.AddRangeAsync(newoccupants);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<bool> UpdateAdditionalOccupant(AdditionalOccupantDto occupant)
        {
            try
            {
                var existing = await GetAllOccupantsById(occupant.Id);
                if (existing == null) return false;

                existing.Name = occupant.Name;

                _context.AdditionalOccupants.Update(existing);
                var result =await _context.SaveChangesAsync();
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
            var occupants = await _context.AdditionalOccupants.Where(e => e.LegalCaseId == legalcaseId).ToListAsync();
            return occupants;
        }

        public async Task<AdditionalOccupants> GetAllOccupantsById(Guid Id)
        {
            var occupants = await _context.AdditionalOccupants.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return occupants;
        }

    }
}
