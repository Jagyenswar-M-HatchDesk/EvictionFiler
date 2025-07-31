using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CasesRepository : ICasesRepository
    {
        private readonly MainDbContext _context;

        public CasesRepository(MainDbContext context)
        {
            _context = context;
        }

		public async Task<List<ClientRole>> GetAllClientRole()
		{
			return await _context.MstClientRoles.ToListAsync();
		}

		public async Task<List<LegalCase>> GetAllCasesAsync()
        {
            return await _context.LegalCases
                .Include(c => c.Clients)
				 .Include(c => c.ClientRole)
				.Include(c => c.Buildings)
				.Include(c=>c.ReasonHoldover)
				.Include(c=>c.CaseType)
				.Include(c=>c.CaseSubType)
                .Include(c => c.LandLords).Include(c=>c.Tenants)
                .ToListAsync();
        }

		public async Task<CreateToEditLegalCaseModel?> GetCaseByIdAsync(Guid id)
		{
			var legalCaseEntity = await _context.LegalCases
				.Include(c => c.Clients)
				.Include(c => c.Buildings)
				.Include(c => c.LandLords)
				.Include(c => c.Tenants)
				.FirstOrDefaultAsync(c => c.Id == id);

			if (legalCaseEntity == null)
				return null;

			var dto = new CreateToEditLegalCaseModel
			{
				Id = legalCaseEntity.Id,
				ClientId = legalCaseEntity.Clients.Id, 
				BuildingId = legalCaseEntity.Buildings?.Id,
				LandLordId = legalCaseEntity.LandLordId,
				TenantId = legalCaseEntity.Tenants?.Id,
				CaseName = legalCaseEntity.CaseName,
				ClientRoleId = legalCaseEntity.ClientRoleId,
				LegalRepresentative = legalCaseEntity.LegalRepresentative,
				CaseTypeId = legalCaseEntity.CaseTypeId,
				CaseSubTypeId = legalCaseEntity.CaseSubTypeId,
				Casecode = legalCaseEntity.Casecode,
				Attrney = legalCaseEntity.Attrney,
				AttrneyContactInfo = legalCaseEntity.AttrneyContactInfo,
				Firm = legalCaseEntity.Firm
			};

			return dto;
		}

		public async Task<bool> AddCaseAsync(CreateToEditLegalCaseModel legalCase)
        {
			var newcase = new LegalCase
			{
				Id = legalCase.Id,
				Casecode = await GenerateCaseCodeAsync(),
				TenantId = legalCase.TenantId,
				BuildingId = legalCase.BuildingId,
				LandLordId = legalCase.LandLordId,
				ClientId = legalCase.ClientId,
				CaseName = legalCase.CaseName,
				CaseTypeId = legalCase.CaseTypeId,
				CaseSubTypeId = legalCase.CaseSubTypeId,
				ClientRoleId = legalCase.ClientRoleId,
				ReasonHoldoverId = legalCase.ReasonHoldoverId,
				ExplainDescription = legalCase.ExplainDescription,
				ReasonDescription = legalCase.ReasonDescription,
				LegalRepresentative = legalCase.LegalRepresentative,
				IsUnitIllegalId = legalCase.IsUnitIllegalId,
				TenancyTypeId = legalCase.TenancyTypeId,
				RenewalOffer = legalCase.RenewalOffer,
				TenantRecord = legalCase.TenantRecord,
				HasPossession = legalCase.HasPossession,
				OtherOccupants = legalCase.OtherOccupants,
				TenantShare = legalCase.TenantShare,
				SocialServices = legalCase.SocialServices,
				LastMonthWeekRentPaid = legalCase.LastMonthWeekRentPaid,
				IsERAPPaymentReceived = legalCase.IsERAPPaymentReceived,
				ERAPPaymentReceivedDate = legalCase.ERAPPaymentReceivedDate,
				RegulationStatusId = legalCase.RegulationStatusId,
				LandlordTypeId = legalCase.LandlordTypeId,
				RentDueEachMonthOrWeek = legalCase.RentDueEachMonthOrWeek,
				MonthlyRent = legalCase.MonthlyRent,
				TotalRentOwed = legalCase.TotalRentOwed,

				Attrney = legalCase.Attrney,
				AttrneyContactInfo = legalCase.AttrneyContactInfo,
				Firm = legalCase.Firm,
				CreatedOn = DateTime.Now,
				

			};

            await _context.LegalCases.AddAsync(newcase);
            var result=await _context.SaveChangesAsync();

            if(result !=null)
            {
                return true;
            }
            return false;
        }

		public async Task<bool> UpdateCasesAsync(CreateToEditLegalCaseModel legalCase)
		{
			var existing = await _context.LegalCases.FirstOrDefaultAsync(x => x.Id == legalCase.Id);
			if (existing == null) return false;

			existing.TenantId = legalCase.TenantId;
			existing.BuildingId = legalCase.BuildingId;
			existing.LandLordId = legalCase.LandLordId;
			existing.ClientId = legalCase.ClientId;
			existing.CaseName = legalCase.CaseName;
			existing.ClientRoleId = legalCase.ClientRoleId;
			existing.LegalRepresentative = legalCase.LegalRepresentative;
			existing.Attrney = legalCase.Attrney;
			existing.AttrneyContactInfo = legalCase.AttrneyContactInfo;
			existing.Firm = legalCase.Firm;
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
			var lastCase = await _context.LegalCases
				.OrderByDescending(c => c.Casecode)
				.Select(c => c.Casecode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("EF"))
			{
				string numberPart = lastCase.Substring(2);
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			string newCode = "EF" + nextNumber.ToString("D10");
			return newCode;
		}

	}
}
