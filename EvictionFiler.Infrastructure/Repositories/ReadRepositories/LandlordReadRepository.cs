using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Polly;
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
                ClientId = l.ClientId,
                LandlordId = l.LandLords.Id,
               
                FirstName = l.LandLords.FirstName,
                LastName = l.LandLords.LastName,
               
                LandlordAddress = l.LandLords.Address1,
               
                LandLordTypeId = l.LandlordTypeId,
                LandLordTypeName = l.LandlordType != null ? l.LandlordType.Name : string.Empty,
               
                ContactPersonName = l.LandLords.ContactPersonName,
               
            };
        }

        public async Task<List<EditToLandlordDto>> GetByClientIdAsync(Guid? clientId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var query = await context.LandLords
                .Where(x => x.ClientId == clientId && x.IsDeleted != true)
                .Include(x => x.State)
                .Include(x => x.LandlordType)
                .Include(x => x.TypeOfOwner)
                .OrderBy(x => x.FirstName)
                .OrderBy(x => x.LastName)
                .Take(10)
                .ToListAsync();



            return query.Select(l => new EditToLandlordDto
            {
                Id = l.Id,
                LandLordCode = l.LandLordCode,
                FirstName = l.FirstName,
                LastName = l.LastName,
                EINorSSN = l.EINorSSN,
                Phone = l.Phone,
                Email = l.Email,
                Address1 = l.Address1,
                Address2 = l.Address2,
                StateId = l.StateId,
                LandlordTypeId = l.LandlordTypeId,
                LandlordTypeName = l.LandlordType != null ? l.LandlordType.Name : string.Empty,
                StateName = l.State != null ? l.State.Name : string.Empty,
                TypeOwnerName = l.TypeOfOwner != null ? l.TypeOfOwner.Name : string.Empty,
                CityId = l.CityId,
                Zipcode = l.Zipcode,
                ContactPersonName = l.ContactPersonName,
                TypeOwnerId = l.TypeOfOwnerId,
                ClientId = l.ClientId,
                IsDeleted = l.IsDeleted,
                IsActive = l.IsActive,


            }).ToList();
        }
        public async Task<EditToLandlordDto> GetLandlordByIdAsync(Guid landlordId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var l = await context.LandLords
               .Include(x => x.State)
                .Include(x => x.LandlordType)
                .Include(x => x.TypeOfOwner)
                .FirstOrDefaultAsync(x => x.Id == landlordId && x.IsDeleted != true);

            if (l == null) return null;

            return new EditToLandlordDto
            {
                Id = l.Id,
                LandLordCode = l.LandLordCode,
                FirstName = l.FirstName,
                LastName = l.LastName,
                EINorSSN = l.EINorSSN,
                Phone = l.Phone,
                Email = l.Email,
                Address1 = l.Address1,
                Address2 = l.Address2,
                StateId = l.StateId,
                LandlordTypeId = l.LandlordTypeId,
                LandlordTypeName = l.LandlordType != null ? l.LandlordType.Name : string.Empty,
                StateName = l.State != null ? l.State.Name : string.Empty,
                TypeOwnerName = l.TypeOfOwner != null ? l.TypeOfOwner.Name : string.Empty,
                CityId = l.CityId,
                Zipcode = l.Zipcode,
                ContactPersonName = l.ContactPersonName,
                TypeOwnerId = l.TypeOfOwnerId,
                ClientId = l.ClientId,
                IsDeleted = l.IsDeleted,
                IsActive = l.IsActive,
            };
        }
        public async Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query, Guid clientId)
        {
            await using var context = _contextFactory.CreateDbContext();
            query = query?.Trim().ToLower() ?? "";

            var landlords = await context.LandLords.Include(e => e.State).Include(e => e.TypeOfOwner)
                .Where(l =>
                    l.ClientId == clientId &&
                    l.IsDeleted != true &&
                    (
                        l.FirstName.ToLower().StartsWith(query) ||
                        l.LastName.ToLower().StartsWith(query) ||
                        l.LandLordCode.ToLower().StartsWith(query)
                    )
                )
                .Select(l => new EditToLandlordDto
                {
                    Id = l.Id,
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    Address1 = l.Address1,
                    Address2 = l.Address2,
                    CityId = l.CityId,
                    Zipcode = l.Zipcode,
                    StateId = l.StateId,

                    Email = l.Email,
                    Phone = l.Phone,
                    LandLordCode = l.LandLordCode,
                    EINorSSN = l.EINorSSN,
                    ContactPersonName = l.ContactPersonName,
                    TypeOwnerId = l.TypeOfOwnerId,
                    LandlordTypeName = l.LandlordType != null ? l.LandlordType.Name : string.Empty,
                    StateName = l.State != null ? l.State.Name : string.Empty,
                    TypeOwnerName = l.TypeOfOwner != null ? l.TypeOfOwner.Name : string.Empty,
                })
                .ToListAsync();

            return landlords;
        }
        public async Task<string?> GetLastLandLordCodeAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.LandLords
                .OrderByDescending(l => l.LandLordCode)
                .Select(l => l.LandLordCode)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid?> UpdateCaseLandlord(IntakeModel casedetails)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.LandLordId = casedetails.LandlordId;



            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;


        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.SaveChangesAsync(cancellationToken);
        }



    }
}
