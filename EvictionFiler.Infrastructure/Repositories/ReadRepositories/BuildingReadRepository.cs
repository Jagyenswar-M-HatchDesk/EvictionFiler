using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public  class BuildingReadRepository: ReadRepository<Building>, IBuildingReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public BuildingReadRepository(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
           
        }
        public async Task<BuildingDetailDto> GetBuildingDetailAsync(Guid caseId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var l = await context.LegalCases
     .AsNoTracking()
     .Where(c => c.Id == caseId && c.IsDeleted != true)
     .Include(c => c.Buildings)
     .ThenInclude(b => b.Cities)
     .Include(c => c.Buildings)
     .ThenInclude(b => b.State)

     .FirstOrDefaultAsync();


            if (l == null) return null;

            return new BuildingDetailDto
            {
                BuildingId = l.Buildings.Id,

                Mdr = l.Buildings.MDRNumber,
               

                BuildingAddress = l.Buildings.Address1,

                Borough= l.Buildings.Cities != null ? l.Buildings.Cities.Name : null,
                BuildingState = l.Buildings.State != null ? l.Buildings.State.Name : string.Empty,
                BuildingZip = l.Buildings.Zipcode,

                
            };
        }
    }
}
