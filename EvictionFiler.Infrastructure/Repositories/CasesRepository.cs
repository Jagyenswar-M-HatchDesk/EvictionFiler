using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

		public async Task<CreateEditLegalCaseModel?> GetCaseByIdAsync(Guid id)
		{
			var legalCaseEntity = await _context.LegalCases
				.Include(c => c.Clients)
				.Include(c => c.Apartments)
				.Include(c => c.LandLords)
				.Include(c => c.Tenant)
				.FirstOrDefaultAsync(c => c.Id == id);

			if (legalCaseEntity == null)
				return null;

			// Map entity to DTO
			var dto = new CreateEditLegalCaseModel
			{
				Id = legalCaseEntity.Id,
				ClientId = legalCaseEntity.Clients.Id, // or appropriate logic
				ApartmentId = legalCaseEntity.Apartments.Id,
				LandLordId = legalCaseEntity.LandLordId,
				TenantId = legalCaseEntity.Tenant?.Id,
				CaseName = legalCaseEntity.CaseName,
				ClientRole = legalCaseEntity.ClientRole,
				LegalRepresentative = legalCaseEntity.LegalRepresentative,
				CaseTypeId = legalCaseEntity.CaseTypeId,
				CaseSubTypeId = legalCaseEntity.CaseSubTypeId,
				Casecode = legalCaseEntity.Casecode,

				// section4
				Company = legalCaseEntity.Company,
				Contact = legalCaseEntity.Contact,
				PhoneorEmail = legalCaseEntity.PhoneorEmail,
				MDRNo = legalCaseEntity.MDRNo,
				ResidentalUnits = legalCaseEntity.ResidentalUnits,
				CommercialUnits = legalCaseEntity.CommercialUnits,
				AllUnitsRehistered = legalCaseEntity.AllUnitsRehistered,
				HPDViolation = legalCaseEntity.HPDViolation,

				// section5
				Address = legalCaseEntity.Address,
				AptNo = legalCaseEntity.AptNo,
				Borough = legalCaseEntity.Borough,
				ZIP = legalCaseEntity.ZIP,
				Class = legalCaseEntity.Class,
				YearBuilt = legalCaseEntity.YearBuilt,
				HeatorHotWater = legalCaseEntity.HeatorHotWater,
				RentStablized = legalCaseEntity.RentStablized,

				// section6
				SeekinEviction = legalCaseEntity.SeekinEviction,
				ExemptUnit = legalCaseEntity.ExemptUnit,
				RentIncreases = legalCaseEntity.RentIncreases,
				Monthsunpaid = legalCaseEntity.Monthsunpaid,
				OthersGrounds = legalCaseEntity.OthersGrounds,

			

				Attrney = legalCaseEntity.Attrney,
				AttrneyContactInfo = legalCaseEntity.AttrneyContactInfo,
				Firm = legalCaseEntity.Firm
			};

			return dto;
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

		public async Task<bool> UpdateCasesAsync(CreateEditLegalCaseModel legalCase)
		{
			var existing = await _context.LegalCases.FirstOrDefaultAsync(x => x.Id == legalCase.Id);
			if (existing == null) return false;


			existing.TenantId = legalCase.TenantId;
			existing.ApartmentId = legalCase.ApartmentId;
			existing.LandLordId = legalCase.LandLordId;
			existing.ClientId = legalCase.ClientId;
			existing.CaseName = legalCase.CaseName;
			existing.ClientRole = legalCase.ClientRole;
			existing.LegalRepresentative = legalCase.LegalRepresentative;

			existing.Company = legalCase.Company;
			existing.Contact = legalCase.Contact;
			existing.PhoneorEmail = legalCase.PhoneorEmail;
			existing.MDRNo = legalCase.MDRNo;
                existing.ResidentalUnits = legalCase.ResidentalUnits;
			existing.CommercialUnits = legalCase.CommercialUnits;
			existing.Address = legalCase.Address;
			existing.AptNo = legalCase.AptNo;
			existing.Borough = legalCase.Borough;
			existing.Attrney = legalCase.Attrney;
			existing.AttrneyContactInfo = legalCase.AttrneyContactInfo;
			existing.Firm = legalCase.Firm;
			existing.ZIP = legalCase.ZIP;
			existing.Class = legalCase.Class;
			existing.YearBuilt = legalCase.YearBuilt;
			existing.CreatedAt = DateTime.UtcNow;
			existing.IsActive = true;
			existing.IsDeleted = false;
			existing.CaseSubTypeId = legalCase.CaseSubTypeId;
			existing.CaseTypeId = legalCase.CaseTypeId;



			_context.LegalCases.Update(existing);
			await _context.SaveChangesAsync();

			return true;
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
