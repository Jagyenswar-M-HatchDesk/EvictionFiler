using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Application.DTOs.ApartmentDto;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly MainDbContext _context;

        public ApartmentRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<Appartment?> GetByIdAsync(Guid id)
        {
            return await _context.Appartments.FindAsync(id);
        }

        public async Task<List<Appartment>> GetAllAsync()
        {
            return await _context.Appartments.Where(e=>e.IsDeleted != true).ToListAsync();
        }

        public async Task<bool> AddAsync(AddApartment appartment)
        {
            var newapartment = new Appartment
            {
                Id = appartment.Id,
                ApartmentCode = appartment.ApartmentCode,
                City = appartment.City,
                State = appartment.State,
                PremiseType= appartment.PremiseType,
                Address_1 = appartment.Address_1,
                Address_2 = appartment.Address_2,
                Zipcode = appartment.Zipcode,
                Country = appartment.Country,
                MDR_Number = appartment.MDR_Number,
                PetitionerInterest = appartment.PetitionerInterest,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,

            };
            _context.Appartments.Add(newapartment);
            var result =await _context.SaveChangesAsync();
            if(result != null)
                return true;
            return false;
        }

        public async Task UpdateAsync(Appartment appartment)
        {
            _context.Appartments.Update(appartment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var appartment = await _context.Appartments.FindAsync(id);
            if (appartment != null)
            {
                _context.Appartments.Remove(appartment);
                await _context.SaveChangesAsync();
            }
        }
    }
}