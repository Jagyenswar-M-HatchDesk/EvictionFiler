using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public class LandlordReadRepository : ReadRepository<LandLord>, ILandlordReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public LandlordReadRepository(IDbContextFactory<MainDbContext> contextFactory):base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<LandlordDetailDto> GetLandlordDetailAsync(Guid caseId)
        {
            await using var  context= _contextFactory.CreateDbContext();
            var l = await context.LegalCases
     .AsNoTracking()
     .Where(c => c.Id == caseId && c.IsDeleted!=true)
     .Include(c => c.LandLords)
     .Include(x => x.LandlordType)
     .FirstOrDefaultAsync();


            if (l == null) return null;

            return new LandlordDetailDto
            {
                LandlordId = l.LandLords.Id,
               
                FirstName = l.LandLords.FirstName,
                LastName = l.LandLords.LastName,
               
                LandlordAddress = l.LandLords.Address1,
               
                LandLordTypeId = l.LandlordTypeId,
                LandLordTypeName = l.LandlordType != null ? l.LandlordType.Name : string.Empty,
               
                ContactPersonName = l.LandLords.ContactPersonName,
               
            };
        }

    }
}
