using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ArrearLedgerDtos;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Google.Protobuf.WellKnownTypes;
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
    public class TenantReadRepository : ReadRepository<Tenant>, ITenantReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public TenantReadRepository(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<TenantDetailDto> GetTenantDetailAsync(Guid caseId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var l = await context.LegalCases
     .AsNoTracking()
     .Where(c => c.Id == caseId && c.IsDeleted != true)

     .Include(c => c.CaseType)
     .Include(c=>c.Buildings)

     .ThenInclude(b=>b.Cities!)
     .Include(c => c.Tenants).ThenInclude(a => a.Building!)
     .ThenInclude(b => b.State)
     .Include(c => c.Tenants!.Building!.Cities)



     .FirstOrDefaultAsync();


            if (l == null) return null;

            return new TenantDetailDto
            {
                LastPaymentDate= l.LastPaymentDate,
                MonthlyRent = l.Tenants?.MonthlyRent,
                TenancyTypeId = l.Tenants?.TenancyTypeId,
                RentDueEachMonthOrWeekId = l.Tenants?.RentDueEachMonthOrWeekId,
                PrimaryResidence = l.Tenants.PrimaryResidence,
                LastPayment = l.LastPayment,
                DateTenantMoved = l.DateTenantMoved,
                PredicateNotice = l.PredicateNotice,
                CalculatedNoticeLength= l.CalculatedNoticeLength,
                TotalOwed = l.TotalRentOwed,
                TenantShare = l.Tenants?.TenantShare,
                SocialService = l.SocialService,
                LeaseStart = l.LeaseStart,
                LeaseEnd = l.LeaseEnd,
                TenantId = l.Tenants?.Id,
                CaseTypeName = l.CaseType != null ? l.CaseType.Name : string.Empty,
                UnitOrApartmentNumber = l.Tenants?.UnitOrApartmentNumber,
                ApartmentNumber= l.Tenants?.UnitOrApartmentNumber,
                TenantName = $"{l.Tenants?.FirstName} {l.Tenants?.LastName}",

                BuildingId = l.Tenants?.BuildinId,
                BuildingAddress = l.Tenants?.Building?.Address1,

                Borough = l.Tenants?.Building?.Cities != null ? l.Tenants?.Building?.Cities?.Name : null,
                BuildingState = l.Tenants?.Building?.State != null ? l.Tenants?.Building?.State?.Name : string.Empty,
                BuildingZip = l.Tenants?.Building?.Zipcode,
                ArrearLedgers = l.ArrearLedgers != null ? l.ArrearLedgers.Select(e => new ArrearLedgerDto()
                {
                    Id = e.Id,
                    Notes = e.Notes,
                    Amount = e.Amount,
                    LegalCaseId = e.LegalCaseId,
                    Month = e.Month,
                }).ToList() : new List<ArrearLedgerDto>()

            };
        }


        public async Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId)
        {
            await using var context = _contextFactory.CreateDbContext();
            // 1️⃣ Get BuildingIds for the selected Client
            var buildingIds = await context.Buildings
                .Where(b => b.Id == clientId)
                .Select(b => b.Id)
                .ToListAsync();

            // 2️⃣ Get Tenants under those buildings
            var tenants = await context.Tenants
                .Where(t =>
                    t.IsDeleted != true &&
                    t.BuildinId != null &&
                    buildingIds.Contains(t.BuildinId.Value)
                )
                .Select(t => new EditToTenantDto
                {
                    Id = t.Id,
                    TenantCode = t.TenantCode,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    SSN = t.SSN,
                    Email = t.Email,
                    Phone = t.Phone,
                    ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
                    LanguageId = t.LanguageId,
                    LanguageName = t.Language.Name,
                    UnitOrApartmentNumber = t.UnitOrApartmentNumber,
                    MonthlyRent = t.MonthlyRent,
                    TenantShare = t.TenantShare,
                    TenancyTypeId = t.TenancyTypeId,
                    TenancyTypeName = t.TenancyType.Name,
                    RentDueEachMonthOrWeekId = t.RentDueEachMonthOrWeekId,
                    IsUnitIllegalId = t.IsUnitIllegalId,
                    PrimaryResidence = t.PrimaryResidence,

                })
                .ToListAsync();

            return tenants;
        }

        public async Task<List<CaseType>> GetAllCaseType()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.MstCaseTypes.ToListAsync();
        }

        public async Task<List<TenancyType>> GetAllTenancyType()
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            return await db.MstTenancyTypes.ToListAsync();
        }
        public async Task<List<DateRent>> GetAllDateRent()
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            return await db.MstDateRent.ToListAsync();
        }
        public async Task<Guid?> UpdateCaseTenant(IntakeModel casedetails)
        {

            await using var db = await _contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.TenantId = casedetails.TenantId;
            existingCase.TenantName = casedetails.TenantName;
        
           

            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;

        }
    }

}