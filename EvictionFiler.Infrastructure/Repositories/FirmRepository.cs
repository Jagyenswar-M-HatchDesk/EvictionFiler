using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class FirmRepository : Repository<Firms>, IFirmRepository
    {
        private readonly MainDbContext _mainDbContext;
        //private readonly IDbContextFactory<MainDbContext> _dbContextFactory;
        public FirmRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            //_dbContextFactory = dbContextFactory;
            _mainDbContext = mainDbContext;
        }

        public async Task<Guid?> RegisterFirm(FirmDto dto)
        {

            var newFirm = new Firms();
            if (dto != null)
            {
                var firm = new Firms();
                if (dto.Name != null)
                {
                    firm = await _mainDbContext.Firms.Where(e => e.Name.ToLower().Contains(dto.Name.ToLower())).FirstOrDefaultAsync();
                }
                if (firm == null)
                {
                    newFirm = new Firms()
                    {
                        Name = dto.Name,
                        FAX = dto.FAX,
                        Address = dto.Address,
                        Phone = dto.Phone,
                        Email = dto.Email,
                        Website = dto.Website,
                        CreatedOn = DateTime.Now,
                        SubscriptionTypeId = dto.SubscriptionTypeId,
                    };

                    await _mainDbContext.Firms.AddAsync(newFirm);
                    var result = await _mainDbContext.SaveChangesAsync();
                    if (result > 0) return newFirm.Id;
                }
                return firm.Id;
            }

            return null;
        }

        public async Task<bool> UpdateFirm(FirmDto dto)
        {
            if (dto == null || dto.Id == Guid.Empty)
                return false;

            var firm = await _mainDbContext.Firms.FirstOrDefaultAsync(f => f.Id == dto.Id);
            if (firm == null)
                return false;

            // Update fields
            firm.Name = dto.Name;
            firm.Email = dto.Email;
            firm.Phone = dto.Phone;
            firm.FAX = dto.FAX;
            firm.Address = dto.Address;
            firm.Website = dto.Website;
            firm.SubscriptionTypeId = dto.SubscriptionTypeId;
            firm.UpdatedOn = DateTime.UtcNow;

            _mainDbContext.Firms.Update(firm);
            var result = await _mainDbContext.SaveChangesAsync();
            return result > 0;
        }

    }
}
