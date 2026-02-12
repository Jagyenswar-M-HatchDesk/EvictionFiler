using EvictionFiler.Application.Interfaces.IRepository;
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
    public  class RegisterRepository:IRegisterRepository
    {
        private readonly MainDbContext _db;

        public RegisterRepository( MainDbContext db)
        {
            _db = db;
        }

        public async Task<Guid?> GetSubscriptionIdByNameAsync(string name)
        {
            return await _db.SubscriptionTypes
                            .Where(x => x.Name == name)
                            .Select(x => x.Id)
                            .FirstOrDefaultAsync();
        }
        public async Task AddFirmAsync(Firms firm)
        {
            await _db.Firms.AddAsync(firm);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
