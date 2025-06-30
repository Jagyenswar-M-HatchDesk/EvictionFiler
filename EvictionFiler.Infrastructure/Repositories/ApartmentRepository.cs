using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvictionFiler.Application.Interfaces.IUserRepository;

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
            return await _context.Appartments.ToListAsync();
        }

        public async Task AddAsync(Appartment appartment)
        {
            _context.Appartments.Add(appartment);
            await _context.SaveChangesAsync();
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