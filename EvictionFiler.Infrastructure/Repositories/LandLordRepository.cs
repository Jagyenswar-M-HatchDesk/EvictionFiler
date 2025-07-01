using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class LandLordRepository : ILandLordRepository
    {
        private readonly MainDbContext _mainDbContext;
        public LandLordRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<bool> AddLandLord(CreateLandLordDto dto)
        {
            var newlandlord = new LandLord
            {
                Id = dto.Id,
                LandLordCode = dto.LandLordCode,
                Name = dto.Name,
                EINorSSN = dto.EINorSSN,
                Phone = dto.Phone,
                Email = dto.Email,
                MaillingAddress = dto.MaillingAddress,
                Attorney = dto.Attorney,
                Firm = dto.Firm,
                isCorporeateOwner = dto.isCorporeateOwner,
                RegisteredAgent = dto.RegisteredAgent,
            };

            _mainDbContext.LandLords.Add(newlandlord);
            var result = await _mainDbContext.SaveChangesAsync();

            if(result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<LandLord>> GetAllLandLordsAsync()
        {
            return await _mainDbContext.LandLords
                .Where(x => x.IsDeleted != true) // Optional: filter soft-deleted
                .ToListAsync();
        }

        public async Task<LandLord?> GetLandLordByIdAsync(Guid id)
        {
            return await _mainDbContext.LandLords
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);
        }

        public async Task<bool> UpdateLandLordAsync(CreateLandLordDto dto)
        {
            var existing = await _mainDbContext.LandLords.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.EINorSSN = dto.EINorSSN;
            existing.Phone = dto.Phone;
            existing.Email = dto.Email;
            existing.MaillingAddress = dto.MaillingAddress;
            existing.Attorney = dto.Attorney;
            existing.Firm = dto.Firm;
            existing.isCorporeateOwner = dto.isCorporeateOwner;
            existing.RegisteredAgent = dto.RegisteredAgent;

            _mainDbContext.LandLords.Update(existing);
            await _mainDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteLandLordAsync(Guid id)
        {
            var landLord = await _mainDbContext.LandLords.FirstOrDefaultAsync(x => x.Id == id);
            if (landLord == null) return false;

            landLord.IsDeleted = true; // Mark as deleted
            _mainDbContext.LandLords.Update(landLord);
            await _mainDbContext.SaveChangesAsync();

            return true;
        }


    }
}
