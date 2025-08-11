using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.TenantDto;
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
            return await _context.LegalCases.AsNoTracking()
								  .Select(c => new LegalCase()
								   {
									  Id = c.Id,
									  Casecode = c.Casecode,
									  ReasonHoldover = c.ReasonHoldover,
									  Clients = c.Clients != null ? new Client()
									  {
										  FirstName = c.Clients.FirstName,
										  LastName = c.Clients.LastName,
										  ClientCode = c.Clients.ClientCode
									  }: new Client(),
									  LandLords = c.LandLords != null ? new LandLord()
									  {
										  FirstName = c.LandLords.FirstName,
										  LastName = c.LandLords.LastName,
										  LandLordCode = c.LandLords.LandLordCode
									  } : new LandLord(),

										Buildings = c.Buildings != null ? new Building()
										{
									
											BuildingCode = c.Buildings.BuildingCode
										} : new Building(),
									  Tenants = c.Tenants != null ? new Tenant()
									  {

										  TenantCode = c.Tenants.TenantCode,
										  FirstName = c.Tenants.FirstName,
										  LastName = c.Tenants.LastName,
									  } : new Tenant()
								  })
								 .ToListAsync();
        }

		public async Task<CreateToEditLegalCaseModel?> GetCaseByIdAsync(Guid id)
		{
			var legalCaseEntity = await _context.LegalCases
				.Include(c => c.Clients)
				.Include(c => c.Buildings)
					.Include(c => c.CaseType)
				.Include(c => c.LandLords)
				.Include(c => c.Tenants)
				.Include(c=>c.RegulationStatus)
				.Include(c=>c.TenancyType)
				.Include(c => c.ReasonHoldover)
				.Include(c=>c.Buildings.State)
				.Include(c=>c.Buildings.Landlord.State)
					.Include(c => c.Buildings.Landlord.LandlordType)
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
				  ExplainDescription = legalCaseEntity.ExplainDescription,
				  ReasonHoldoverId = legalCaseEntity.ReasonHoldoverId,
				  ERAPPaymentReceivedDate = legalCaseEntity.ERAPPaymentReceivedDate,
				  IsERAPPaymentReceived = legalCaseEntity.IsERAPPaymentReceived,
				  HasPossession = legalCaseEntity.HasPossession,
				  IsUnitIllegalId = legalCaseEntity.IsUnitIllegalId,
				  LandlordTypeId = legalCaseEntity.LandlordTypeId,
				  LastMonthWeekRentPaid = legalCaseEntity.LastMonthWeekRentPaid,
				  MonthlyRent = legalCaseEntity.MonthlyRent,
				  OtherOccupants = legalCaseEntity.OtherOccupants,
				  RegulationStatusId=legalCaseEntity.RegulationStatusId,
				  RenewalOffer = legalCaseEntity.RenewalOffer,
				  RentDueEachMonthOrWeek = legalCaseEntity.RentDueEachMonthOrWeek,
				  SocialServices = legalCaseEntity.SocialServices,
				  TenancyTypeId = legalCaseEntity.TenancyTypeId,
				  TenantRecord = legalCaseEntity.TenantRecord,
				  TenantShare = legalCaseEntity.TenantShare,
				  CaseTypeId = legalCaseEntity.CaseTypeId,
				  Attrney = legalCaseEntity.Attrney,
				  AttrneyContactInfo = legalCaseEntity.AttrneyContactInfo,
				  Firm = legalCaseEntity.Firm,
				  tenantReceive = legalCaseEntity.tenantReceive,
				  ExplainTenancyReceiveDescription = legalCaseEntity.ExplainTenancyReceiveDescription,
				  
				  
				  TotalRentOwed = legalCaseEntity.TotalRentOwed,
				Casecode = legalCaseEntity.Casecode,

				tenants = legalCaseEntity.Tenants == null ? null : new CreateToTenantDto
				{
					FirstName = legalCaseEntity.Tenants.FirstName,
					LastName = legalCaseEntity.Tenants.LastName,
					BuildingId = legalCaseEntity.Tenants.BuildinId,
				     UnitOrApartmentNumber = legalCaseEntity.Tenants.UnitOrApartmentNumber,
					 

					

					Building = legalCaseEntity.Tenants.Building == null ? null : new EditToBuildingDto
					{
						Address1 = legalCaseEntity.Tenants.Building.Address1,
						Address2 = legalCaseEntity.Tenants.Building.Address2,
						Zipcode = legalCaseEntity.Tenants.Building.Zipcode,
						City = legalCaseEntity.Tenants.Building.City,
						StateId = legalCaseEntity.Tenants.Building.StateId,
						//StateName = legalCaseEntity.Tenants.Building.State.Name,
						MDRNumber = legalCaseEntity.Tenants.Building.MDRNumber,
						BuildingUnits = legalCaseEntity.Tenants.Building.BuildingUnits,
						RegulationStatusId = legalCaseEntity.Tenants.Building.RegulationStatusId
					},

					Landlord = legalCaseEntity.Tenants.Building.Landlord == null ? null : new EditToLandlordDto
					{
						FirstName = legalCaseEntity.Tenants.Building.Landlord.FirstName,
						LastName = legalCaseEntity.Tenants.Building.Landlord.LastName,
						Address1 = legalCaseEntity.Tenants.Building.Landlord.Address1,
						Address2 = legalCaseEntity.Tenants.Building.Landlord.Address2,
						Zipcode = legalCaseEntity.Tenants.Building.Landlord.Zipcode,
						City = legalCaseEntity.Tenants.Building.Landlord.City,
						StateId = legalCaseEntity.Tenants.Building.Landlord.StateId,
						//StateName = legalCaseEntity.Tenants.Building.Landlord.State.Name,
						Phone = legalCaseEntity.Tenants.Building.Landlord.Phone,
						Email = legalCaseEntity.Tenants.Building.Landlord.Email,
						LandlordTypeId = legalCaseEntity.Tenants.Building.Landlord.LandlordTypeId,
					}
				}
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
			    CaseTypeId = legalCase.CaseTypeId,
				ReasonHoldoverId = legalCase.ReasonHoldoverId,
				ExplainDescription = legalCase.ExplainDescription,
				ReasonDescription = legalCase.ReasonDescription,
			
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
				OtherPropertiesBuildingId = legalCase.OtherPropertiesBuildingId,
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
			existing.ClientId = legalCase.ClientId;
			existing.ReasonHoldoverId = legalCase.ReasonHoldoverId;
			existing.ExplainDescription = legalCase.ExplainDescription;
			existing.ReasonDescription = legalCase.ReasonDescription;
			existing.IsUnitIllegalId = legalCase.IsUnitIllegalId;
			existing.TenancyTypeId = legalCase.TenancyTypeId;
			existing.RenewalOffer = legalCase.RenewalOffer;
			existing.TenantRecord = legalCase.TenantRecord;
			existing.HasPossession = legalCase.HasPossession;
			existing.OtherOccupants = legalCase.OtherOccupants;
			existing.TenantShare = legalCase.TenantShare;
			existing.SocialServices = legalCase.SocialServices;
			existing.LastMonthWeekRentPaid = legalCase.LastMonthWeekRentPaid;
			existing.IsERAPPaymentReceived = legalCase.IsERAPPaymentReceived;
			existing.ERAPPaymentReceivedDate = legalCase.ERAPPaymentReceivedDate;
			existing.RegulationStatusId = legalCase.RegulationStatusId;
			existing.LandlordTypeId = legalCase.LandlordTypeId;
			existing.RentDueEachMonthOrWeek = legalCase.RentDueEachMonthOrWeek;
			existing.MonthlyRent = legalCase.MonthlyRent;
			existing.TotalRentOwed = legalCase.TotalRentOwed;
			existing.Attrney = legalCase.Attrney;
			existing.AttrneyContactInfo = legalCase.AttrneyContactInfo;
			existing.Firm = legalCase.Firm;
			existing.tenantReceive = legalCase.tenantReceive;
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
