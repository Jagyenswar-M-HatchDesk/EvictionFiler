using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CasesRepository : ICasesRepository
    {
        private readonly MainDbContext _context;

        public CasesRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<List<LegalCase>> GetAllCasesAsync()
        {
            return await _context.LegalCases
                .Include(c => c.Clients)
                .Include(c => c.Apartments)
                .Include(c => c.LandLords).Include(c=>c.Tenant)
                .ToListAsync();
        }

        public async Task<LegalCase?> GetCaseByIdAsync(Guid id)
        {
            return await _context.LegalCases
                .Include(c => c.Clients)
                .Include(c => c.Apartments)
                .Include(c => c.LandLords).Include(c=>c.Tenant)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> AddCaseAsync(CreateEditLegalCaseModel legalCase)
        {
            var newcase = new LegalCase
            {
                Id = legalCase.Id,
                TenantId = legalCase.TenantId,
                ApartmentId = legalCase.ApartmentId,
                LandLordId = legalCase.LandLordId,
                ClientId = legalCase.ClientId,
                CaseName = legalCase.CaseName,
                ClientRole = legalCase.ClientRole,
                LegalRepresentative = legalCase.LegalRepresentative,
                Casecode = legalCase.Casecode,
                CaseType = legalCase.CaseType,
                Company = legalCase.Company,
                Contact = legalCase.Contact,
                PhoneorEmail = legalCase.PhoneorEmail,
                MDRNo = legalCase.MDRNo,
                ResidentalUnits = legalCase.ResidentalUnits,
                CommercialUnits = legalCase.CommercialUnits,
                Address = legalCase.Address,
                AptNo = legalCase.AptNo,
                Borough = legalCase.Borough,
                ZIP = legalCase.ZIP,
                Class = legalCase.Class,
                YearBuilt = legalCase.YearBuilt,
                CreatedAt = DateTime.UtcNow,
            };

            await _context.LegalCases.AddAsync(newcase);
            var result=await _context.SaveChangesAsync();

            if(result !=null)
            {
                return true;
            }
            return false;
        }

        public async Task UpdateCaseAsync(LegalCase legalCase)
        {
            _context.LegalCases.Update(legalCase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCaseAsync(Guid id)
        {
            var legalCase = await _context.LegalCases.FindAsync(id);
            if (legalCase != null)
            {
                _context.LegalCases.Remove(legalCase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
