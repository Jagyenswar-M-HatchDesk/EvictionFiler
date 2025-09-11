using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore;
using PdfSharpCore.Pdf.Filters;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Services
{
	public class LegalCaseService : ILegalCaseService
	{
		private readonly ICasesRepository _repository;
		private readonly IAdditionalOccupantsRepository _additionalOccupantsRepo;
		private readonly IUnitOfWork _unitOfWork;
		public LegalCaseService(ICasesRepository repository , IAdditionalOccupantsRepository additionalOccupantsRepo, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
			_additionalOccupantsRepo = additionalOccupantsRepo;

        }

        public async Task<int> GetTotalCasesCountAsync(string userId ,bool isAdmin)
        {
            return await _repository.GetTotalCasesCountAsync(userId , isAdmin);
        } 

        public async Task<int> GetActiveCasesCountAsync(string userId, bool isAdmin)
        {
            return await _repository.GetActiveCasesCountAsync(userId, isAdmin);
        }

        public async Task<bool> AddLegalCasesAsync(CreateToEditLegalCaseModel legalCase)
		{
            var addoccupants = new List<AdditionalOccupants>();
			var legalCases = new LegalCase
			{
				Id = legalCase.Id,
				Casecode = await _repository.GenerateCaseCodeAsync(),
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
				RentDueEachMonthOrWeekId = legalCase.RentDueEachMonthOrWeekId,
				MonthlyRent = legalCase.MonthlyRent,
				TotalRentOwed = legalCase.TotalRentOwed,
				Attrney = legalCase.Attrney,
				AttrneyContactInfo = legalCase.AttrneyContactInfo,
				Firm = legalCase.Firm,
				CreatedOn = DateTime.Now,
				OralStart = legalCase.OralStart,
				OralEnd = legalCase.OralEnd,
				WrittenLease = legalCase.WrittenLease,
				RenewalStatusId = legalCase.RenewalStatusId,
				DateTenantMoved = legalCase.DateTenantMoved,
				CreatedBy = legalCase.CreatedBy,
				
			
			};

                if (legalCase.AdditionalOccupants != null)
            {
                foreach (var o in legalCase.AdditionalOccupants)
                {
                    var additionaloccu = new AdditionalOccupants
                    {
                        //Id = o.Id,
                        Name = o.Name,
                        Relation = o.Relation,
                        LegalCaseId = legalCase.Id,
						CreatedOn = DateTime.Now,
						CreatedBy = legalCase.CreatedBy,

                    };

                    addoccupants.Add(additionaloccu);
                }
                ;


            }
            ;

			await _repository.AddAsync(legalCases);
			await _additionalOccupantsRepo.AddRangeAsync(addoccupants);

            var result = await _unitOfWork.SaveChangesAsync();

			if (result != null)
			{
				return true;
			}
			return false;
		}

		public async Task<PaginationDto<LegalCase>> GetAllAsync(int pageNumber, int pageSize ,CaseFilterDto Filters , string userId , bool isAdmin)
		{
			return await _repository.GetAllCasesAsync(pageNumber , pageSize , Filters , userId , isAdmin);
		}

        public async Task<List<LegalCase>>GetAllAsync()
        {
            return await _repository.GetAllCasesAsync();

        }

        public async Task<List<LegalCase>> GetTodayCasesAsync()
        {
            return await _repository.GetTodayCasesAsync();

        }

        public async Task<CreateToEditLegalCaseModel> GetByIdAsync(Guid id)
		{
			var legalCaseEntity = await _repository.GetAllQuerable(
		predicate: c => c.Id == id,
		(Expression<Func<LegalCase, object>>)(c => c.Clients),
		c =>c.Buildings,
		c =>c.CaseType,
		c =>c.LandLords,
		c =>c.Tenants,
		c =>c.RegulationStatus,
		c =>c.TenancyType,
        c => c.RenewalStatus,
        c =>c.ReasonHoldover,
		c =>c.Buildings.State,
		c=>c.Addoccupants,
		c =>c.Buildings.Landlord.State,
		c => c.Buildings.Landlord.LandlordType
	)
	.FirstOrDefaultAsync();

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
				RegulationStatusId = legalCaseEntity.RegulationStatusId,
				RenewalOffer = legalCaseEntity.RenewalOffer,
				RentDueEachMonthOrWeekId = legalCaseEntity.RentDueEachMonthOrWeekId,
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
				OralEnd = legalCaseEntity.OralEnd,
				OralStart = legalCaseEntity.OralStart,
				WrittenLease = legalCaseEntity.WrittenLease,
				RenewalStatusId = legalCaseEntity.RenewalStatusId,
				DateTenantMoved = legalCaseEntity.DateTenantMoved,
				Casecode = legalCaseEntity.Casecode,
				AdditionalOccupants = legalCaseEntity.Addoccupants
				.Select(o => new AdditionalOccupantDto
				{
					Id = o.Id,
					Name = o.Name,
					Relation = o.Relation,
					LegalCaseId = o.LegalCaseId,
					IsVisible = true
				}).ToList(),



				tenants = legalCaseEntity.Tenants == null ? null : new CreateToTenantDto
				{
					FirstName = legalCaseEntity.Tenants.FirstName,
					LastName = legalCaseEntity.Tenants.LastName,
					BuildingId = legalCaseEntity.Tenants.BuildinId,
					UnitOrApartmentNumber = legalCaseEntity.Tenants.UnitOrApartmentNumber,

					Building = legalCaseEntity.Tenants.Building == null ? null : new EditToBuildingDto
					{
						Id = legalCaseEntity.Tenants.Building.Id,
						Address1 = legalCaseEntity.Tenants.Building.Address1,
						Address2 = legalCaseEntity.Tenants.Building.Address2,
						Zipcode = legalCaseEntity.Tenants.Building.Zipcode,
						City = legalCaseEntity.Tenants.Building.City,
						StateId = legalCaseEntity.Tenants.Building.StateId,
						MDRNumber = legalCaseEntity.Tenants.Building.MDRNumber,
						BuildingUnits = legalCaseEntity.Tenants.Building.BuildingUnits,
						RegulationStatusId = legalCaseEntity.Tenants.Building.RegulationStatusId,

                        RegulationStatusName = legalCaseEntity.Tenants.Building.RegulationStatus.Name
                    },

					Landlord = legalCaseEntity.Tenants.Building.Landlord == null ? null : new EditToLandlordDto
					{
						Id = legalCaseEntity.Tenants.Building.Landlord.Id,
						FirstName = legalCaseEntity.Tenants.Building.Landlord.FirstName,
						LastName = legalCaseEntity.Tenants.Building.Landlord.LastName,
						Address1 = legalCaseEntity.Tenants.Building.Landlord.Address1,
						Address2 = legalCaseEntity.Tenants.Building.Landlord.Address2,
						Zipcode = legalCaseEntity.Tenants.Building.Landlord.Zipcode,
						City = legalCaseEntity.Tenants.Building.Landlord.City,
						StateId = legalCaseEntity.Tenants.Building.Landlord.StateId,
						Phone = legalCaseEntity.Tenants.Building.Landlord.Phone,
						Email = legalCaseEntity.Tenants.Building.Landlord.Email,
						LandlordTypeId = legalCaseEntity.Tenants.Building.Landlord.LandlordTypeId
					}
				}
			};

			return dto; 
		}

   

        public async Task<bool> UpdateAsync(CreateToEditLegalCaseModel legalCase)
        {
            var existing = await _repository.GetAsync(legalCase.Id);
            if (existing == null) return false;

            // Pehle existing legal case fields update karo (already hai)
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
            existing.RentDueEachMonthOrWeekId = legalCase.RentDueEachMonthOrWeekId;
            existing.MonthlyRent = legalCase.MonthlyRent;
            existing.TotalRentOwed = legalCase.TotalRentOwed;
            existing.Attrney = legalCase.Attrney;
            existing.AttrneyContactInfo = legalCase.AttrneyContactInfo;
            existing.Firm = legalCase.Firm;
            existing.tenantReceive = legalCase.tenantReceive;
            existing.CaseTypeId = legalCase.CaseTypeId;
            existing.OtherPropertiesBuildingId = legalCase.OtherPropertiesBuildingId;
            existing.CreatedOn = legalCase.CreatedOn;
            existing.OralEnd = legalCase.OralEnd;
            existing.OralStart = legalCase.OralStart;
            existing.WrittenLease = legalCase.WrittenLease;
            existing.DateTenantMoved = legalCase.DateTenantMoved;
            existing.RenewalStatusId = legalCase.RenewalStatusId;

       

            // Purane occupants delete karo jo DB me the
            var oldOccupants = await _additionalOccupantsRepo.GetAllAsync(x => x.LegalCaseId == legalCase.Id);
            foreach (var old in oldOccupants)
            {
                await _additionalOccupantsRepo.DeleteAsync(old.Id);
            }

            // Naye occupants insert karo
            if (legalCase.AdditionalOccupants != null && legalCase.AdditionalOccupants.Any())
            {
                foreach (var occ in legalCase.AdditionalOccupants)
                {
                    await _additionalOccupantsRepo.AddAsync(new AdditionalOccupants
                    {
                        Id = Guid.NewGuid(),
                        LegalCaseId = legalCase.Id,
                        Name = occ.Name,
                        Relation = occ.Relation
                    });
                }
            }

            // Save changes
            _repository.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(Guid id , bool isAdmin)
		{
            var cases = await _repository.GetAsync(id);
			if (isAdmin)
			{
                await _repository.DeleteAsync(cases.Id);

            }
            else
			{

                cases.IsDeleted = true;
                cases.IsActive = false;
            }

            var deleterecordes = await _unitOfWork.SaveChangesAsync();
            if (deleterecordes > 0)
                return true;
            return false;
        }
	}
}
