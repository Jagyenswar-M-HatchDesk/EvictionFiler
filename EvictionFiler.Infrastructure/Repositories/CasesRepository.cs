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

		public async Task<List<CaseType>> GetAllCaseTypeAsync()
		{
			return await _context.CaseTypes.ToListAsync();
		}

		public async Task<List<CaseSubType>> GetSubTypesByCaseTypeIdAsync(Guid caseTypeId)
		{
			return await _context.CaseSubTypes
				.Where(x => x.CaseTypeId == caseTypeId && x.IsActive == true && x.IsDeleted != true)
				.ToListAsync();
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
                Casecode = await GenerateCaseCodeAsync(),
                TenantId = legalCase.TenantId,
                ApartmentId = legalCase.ApartmentId,
                LandLordId = legalCase.LandLordId,
                ClientId = legalCase.ClientId,
                CaseName = legalCase.CaseName,
                ClientRole = legalCase.ClientRole,
                LegalRepresentative = legalCase.LegalRepresentative,
                //CaseType = legalCase.CaseType,
                Company = legalCase.Company,
                Contact = legalCase.Contact,
                PhoneorEmail = legalCase.PhoneorEmail,
                MDRNo = legalCase.MDRNo,
                ResidentalUnits = legalCase.ResidentalUnits,
                CommercialUnits = legalCase.CommercialUnits,
                Address = legalCase.Address,
                AptNo = legalCase.AptNo,
                Borough = legalCase.Borough,
                Attrney = legalCase.Attrney,
                AttrneyContactInfo = legalCase.AttrneyContactInfo,
                Firm = legalCase.Firm,  
                ZIP = legalCase.ZIP,
                Class = legalCase.Class,
                YearBuilt = legalCase.YearBuilt,
                CreatedAt = DateTime.UtcNow,
                IsActive =true,
                IsDeleted = false
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

		public async Task<string> GenerateCaseCodeAsync()
		{
			// Get the latest case from DB
			var lastCase = await _context.LegalCases
				.OrderByDescending(c => c.Casecode)
				.Select(c => c.Casecode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("CC"))
			{
				string numberPart = lastCase.Substring(2); // Remove 'EF'
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			// Generate new CaseCode
			string newCode = "CC" + nextNumber.ToString("D10"); // D10 = 10 digits
			return newCode;
		}




	}
}
