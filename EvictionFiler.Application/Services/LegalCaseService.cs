using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.ArrearLedgerDtos;
using EvictionFiler.Application.DTOs.CaseNoticeInfoDtos;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;

using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Services
{
    public class LegalCaseService : ILegalCaseService
    {
       
        private readonly ICasesRepository _repository;
        private readonly ICaseTypeRepository _caseTypeRepository;
        private readonly ICaseTypeHPDRepository _caseTypeHPDRepository;
        private readonly ICaseTypePerDiemRepository _caseTypePerDiemRepository;
        private readonly IHarassmentTypeRepository _harassmentTypeRepository;
        private readonly IDefenseTypeRepository _defenseTypeRepository;
        private readonly IAppearanceTypeRepository _appearanceTypeRepository;
        private readonly IDocumentIntructionsTypesRepository _documentIntructionsTypesRepository;
        private readonly IReportingTypePerDiemRepository _reportingTypePerDiemRepository;
        private readonly IAppearanceTypePerDiemRepository _appearanceTypePerDiemRepository;
        private readonly IReliefPetitionerTypeRepository _reliefPetitionerTypeRepository;
        private readonly IReliefRespondenTypeRepository _reliefRespondenTypeRepository;
        private readonly ICaseNotesRepository _caseNotesRepository;


        private readonly ILandLordRepository _landlordrepo;
        private readonly IBuildingRepository _buildingrepo;
        private readonly ITenantRepository _tenantRepo;
        private readonly IAdditionalOccupantsRepository _additionalOccupantsRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICaseDocument _caseDocument;
        private readonly IArrearLedgerRepository _arrearLedger;
        private readonly IFilingMethodRepository _filingMethod;
        private readonly IServiceMethodRepository _serviceMethod;
        private readonly ICityRepository _cityRepository;
        private readonly ISubCaseTypeRepository _subCaseTypeRepository;
        private readonly ICourtTypeRepository _courtTypeRepository;
        private readonly ICaseRespondentRepository _respondantRepository;
        private readonly ICasePetitionerRepository _petitionerRepository;
        private readonly ICaseNoticeInfoRepository _caseNoticeInfoRepository;
        public LegalCaseService(ICasesRepository repository, ICaseNotesRepository caseNotesRepository, ICaseNoticeInfoRepository caseNoticeInfoRepository, ICaseRespondentRepository respondantRepository, ICasePetitionerRepository petitionerRepository, ICourtTypeRepository courtTypeRepository, ICityRepository cityRepository, ISubCaseTypeRepository subCaseTypeRepository, IServiceMethodRepository serviceMethod, IFilingMethodRepository filingMethod, IArrearLedgerRepository arrearLedger, IReportingTypePerDiemRepository reportingTypePerDiemRepository, IDocumentIntructionsTypesRepository documentIntructionsTypesRepository, IAppearanceTypePerDiemRepository appearanceTypePerDiemRepository, ICaseTypePerDiemRepository caseTypePerDiemRepository, ICaseDocument caseDocument, IReliefPetitionerTypeRepository reliefPetitionerTypeRepository, IReliefRespondenTypeRepository reliefRespondenTypeRepository, IAppearanceTypeRepository appearanceTypeRepository, IDefenseTypeRepository defenseTypeRepository, IHarassmentTypeRepository harassmentTypeRepository, ICaseTypeHPDRepository caseTypeHPDRepository, ITenantRepository tenantRepo, ILandLordRepository landlordrepo, ICaseTypeRepository caseTypeRepository, IBuildingRepository buildingrepo, IAdditionalOccupantsRepository additionalOccupantsRepo, IUnitOfWork unitOfWork)
        {
           
            _repository = repository;
            _tenantRepo = tenantRepo;
            _landlordrepo = landlordrepo;
            _buildingrepo = buildingrepo;
            _caseTypeRepository = caseTypeRepository;
            _caseTypeHPDRepository = caseTypeHPDRepository;
            _caseTypePerDiemRepository = caseTypePerDiemRepository;
            _harassmentTypeRepository = harassmentTypeRepository;
            _appearanceTypeRepository = appearanceTypeRepository;
            _reliefRespondenTypeRepository = reliefRespondenTypeRepository;
            _reliefPetitionerTypeRepository = reliefPetitionerTypeRepository;
            _documentIntructionsTypesRepository = documentIntructionsTypesRepository;
            _defenseTypeRepository = defenseTypeRepository;
            _reportingTypePerDiemRepository = reportingTypePerDiemRepository;
            _appearanceTypePerDiemRepository = appearanceTypePerDiemRepository;
            _unitOfWork = unitOfWork;
            _additionalOccupantsRepo = additionalOccupantsRepo;
            _caseDocument = caseDocument;
            _arrearLedger = arrearLedger;
            _filingMethod = filingMethod;
            _serviceMethod = serviceMethod;
            _cityRepository = cityRepository;
            _subCaseTypeRepository = subCaseTypeRepository;
            _courtTypeRepository = courtTypeRepository;
            _respondantRepository = respondantRepository;
            _petitionerRepository = petitionerRepository;
            _caseNoticeInfoRepository = caseNoticeInfoRepository;
            _caseNotesRepository = caseNotesRepository;
           

        }

        public async Task<List<IntakeModel>> SearchCasebyCode(string code)
        {
            var newcase = await _repository.SearchCasebyCode(code);
            return newcase;
        }
        public async Task<List<IntakeModel>> GetAllCase()
        {
            var cases = await _repository.GetAllAsync();

            var result = cases.Select(x => new IntakeModel
            {
                Id = x.Id,

                Casecode = x.Casecode,

            })
             .ToList();

            return result;


        }

        public async Task<Guid?> CreateCasesAsync(IntakeModel legalCase)
        {

            var legalCases = new LegalCase();

            var caseType = await _caseTypeRepository.GetAsync(legalCase.CaseTypeId);
            var billingTypes = await _caseTypeRepository.GetAllBilingTypes();

            var flatGuid = billingTypes
                .FirstOrDefault(x => x.Name.Equals("Flat Rate", StringComparison.OrdinalIgnoreCase))
                ?.Id;

            var hourlyGuid = billingTypes
                            .FirstOrDefault(x => x.Name.Equals("Hourly ($/hr)", StringComparison.OrdinalIgnoreCase))
                            ?.Id;

            if (caseType != null)
            {
                if (caseType.Name.Equals("Holdover", StringComparison.OrdinalIgnoreCase) ||
                     caseType.Name.Equals("NonPayment", StringComparison.OrdinalIgnoreCase) ||
                      caseType.Name.Equals("Non-Payment", StringComparison.OrdinalIgnoreCase) ||
                      caseType.Name.Equals("Non Payment", StringComparison.OrdinalIgnoreCase)
                    )
                {
                    // 🟢 HOLDOVER specific fields
                    legalCases.Id = Guid.NewGuid();
                    legalCases.Casecode = await _repository.GenerateCaseCodeAsync();
                    legalCases.ClientId = legalCase.ClientId;
                    legalCases.CaseTypeId = legalCase.CaseTypeId;
                    legalCases.SubCaseTypeId = legalCase.SubCaseTypeId;
                    legalCases.IsERAPPaymentReceived = legalCase.IsERAPPaymentReceived;

                    legalCases.MonthlyRent = legalCase.MonthlyRent;
                    legalCases.TotalRentOwed = legalCase.TotalOwed;
                    legalCases.TenantShare = legalCase.TenantShare;
                    legalCases.RentDueEachMonthOrWeekId = legalCase.RentDueEachMonthOrWeekId;
                    legalCases.OralStart = legalCase.OralStart;
                    legalCases.OralEnd = legalCase.OralEnd;
                    legalCases.WrittenLease = legalCase.WrittenLease;
                    legalCases.DateTenantMoved = legalCase.DateTenantMoved;
                    legalCases.CreatedOn = DateTime.Now;
                    legalCases.TenancyTypeId = legalCase.TenancyTypeId;
                    legalCases.LandLordId = legalCase.LandlordId;
                    legalCases.LandlordTypeId = legalCase.LandLordTypeId;
                    legalCases.CreatedBy = legalCase.CreatedBy;
                    legalCases.BuildingId = legalCase.BuildingId;
                    legalCases.TenantId = legalCase.TenantId;
                    legalCases.UnitOrApartmentNumber = legalCase.UnitOrApartmentNumber;
                    legalCases.LeaseEnd = legalCase.LeaseEnd;
                    legalCases.DateNoticeServed = legalCase.DateNoticeServed;
                    legalCases.ExpirationDate = legalCase.ExpirationDate;
                    legalCases.PredicateNotice = legalCase.PredicateNotice;
                    legalCases.SocialService = legalCase.SocialService;
                    legalCases.LastRentPaid = legalCase.LastRentPaid;
                    legalCases.Reference = legalCase.Reference;
                    legalCases.OralAgreeMent = legalCase.OralAgreeMent;
                    legalCases.GoodCauseApplies = legalCase.GoodCauseApplies;
                    legalCases.CalculatedNoticeLength = legalCase.CalculatedNoticeLength;
                    legalCases.CaseProgramId = legalCase.CaseProgramId;

                    legalCases.LastPayment = legalCase.LastPayment;
                    legalCases.Assistance = legalCase.Assistance;
                    legalCases.NextBussinessday = legalCase.NextBussinessday;
                    legalCases.leasedAttached = legalCase.leasedAttached;
                    legalCases.ledgerAttached = legalCase.ledgerAttached;
                    legalCases.NoticeproofAttached = legalCase.NoticeproofAttached;
                    legalCases.RegistrationRentAttached = legalCase.RegistrationRentAttached;
                    legalCases.GoodCauseExempt = legalCase.GoodCauseExempt;
                    legalCases.CourtDraftNop = legalCase.CourtDraftNop;
                    legalCases.LeaseStart = legalCase.LeaseStart;
                    legalCases.PlannedServiceDate = legalCase.PlannedServiceDate;
                    legalCases.LastPaymentDate = legalCase.LastPaymentDate;
                    legalCases.DeemedService = legalCase.DeemedService;
                    legalCases.Expiry = legalCase.Expiry;
                    legalCases.AdditionalComments = legalCase.AdditionalComments;
                    legalCases.AffidavitofService = legalCase.AffidavitofService;
                    legalCases.PreferedFilingDate = legalCase.PreferedFilingDate;
                    legalCases.FilingMethodId = legalCase.FilingMethodId;
                    legalCases.NoticeId = legalCase.NoticeId;
                    legalCases.ServiceMethodId = legalCase.ServiceMethodId;
                    legalCases.CourtLocationId = legalCase.CourtLocationId;
                    legalCases.CourtTypeId = legalCase.CourtTypeId;
                    legalCases.SubCaseTypeId = legalCase.SubCaseTypeId;

                }
                else if (caseType.Name.Equals("HPD", StringComparison.OrdinalIgnoreCase) || caseType.Name.Equals("Illegal Lockout", StringComparison.OrdinalIgnoreCase))
                {
                    // 🟣 HPD specific fields
                    legalCases.Id = Guid.NewGuid();
                    legalCases.Casecode = await _repository.GenerateCaseCodeAsync();
                    legalCases.ClientId = legalCase.ClientId;
                    legalCases.TenantId = legalCase.TenantId;
                    legalCases.CaseTypeId = legalCase.CaseTypeId;
                    legalCases.Attrney = legalCase.Attrney;
                    legalCases.AttrneyContactInfo = legalCase.AttrneyContactInfo;
                    legalCases.AttrneyEmail = legalCase.AttrneyEmail;
                    legalCases.CourtLocationId = legalCase.CourtLocationId;
                    legalCases.CourtRoom = legalCase.CourtRoom;
                    legalCases.Index = legalCase.Index;
                    legalCases.County = legalCase.County;
                    legalCases.PartyRepresentId = legalCase.PartyRepresentId;
                    legalCases.ManagingAgent = legalCase.ManagingAgent;
                    legalCases.OpposingCounsel = legalCase.OpposingCounsel;
                    legalCases.LandLordId = legalCase.LandlordId;
                    legalCases.BuildingId = legalCase.BuildingId;
                    legalCases.AppearanceDate = legalCase.AppearanceDate;
                    legalCases.AppearanceTime = legalCase.AppearanceTime;
                    legalCases.TenantName = legalCase.TenantName;
                    legalCases.CourtTypeId = legalCase.CourtTypeId;
                    legalCases.BilingTypeId = legalCase.BilingTypeId;
                    legalCases.InvoiceTo = legalCase.InvoiceTo;
                    legalCases.CaseTypeHPDs = await _repository.GetHPDByIdsAsync(legalCase.SelectedCaseTypeHPDIds);
                    legalCases.HarassmentTypse = await _repository.GetHarassmentTypeIdAsync(legalCase.SelectedHarassmentTypeIds);
                    legalCases.DefenseTypse = await _repository.GetDefenseTypeIdAsync(legalCase.SelectedDefenseTypeIds);
                    legalCases.AppearanceType = await _repository.GetApperenceTypeIdAsync(legalCase.SelectedAppearanceTypeIds);
                    legalCases.ReliefPetitionerType = await _repository.GetReliefPetitionerTypesListTypeIdAsync(legalCase.SelectedReliefPetitionerTypeIds);
                    legalCases.ReliefRespondentType = await _repository.GetReliefRespondentTypesListTypeIdAsync(legalCase.SelectedReliefRespondentTypeIds);
                }
                else if (caseType.Name.Equals("Per Diem", StringComparison.OrdinalIgnoreCase))
                {
                    // 🟣 HPD specific fields
                    legalCases.Id = Guid.NewGuid();
                    legalCases.Casecode = await _repository.GenerateCaseCodeAsync();
                    legalCases.ClientId = legalCase.ClientId;
                    legalCases.CaseTypeId = legalCase.CaseTypeId;
                    legalCases.Attrney = legalCase.Attrney;
                    legalCases.AttrneyContactInfo = legalCase.AttrneyContactInfo;
                    legalCases.AttrneyEmail = legalCase.AttrneyEmail;
                    legalCases.CourtLocationId = legalCase.CourtLocationId;
                    legalCases.CourtPartId = legalCase.CourtPartId;
                    legalCases.CourtTypeId = legalCase.CourtTypeId;
                    legalCases.CourtRoom = legalCase.CourtRoom;
                    legalCases.Index = legalCase.Index;
                    legalCases.County = legalCase.County;
                    legalCases.PartyRepresentPerDiemId = legalCase.PartyRepresentPerDiemId;
                    legalCases.Partynames = legalCase.Partynames;
                    legalCases.ManagingAgent = legalCase.ManagingAgent;
                    legalCases.OpposingCounsel = legalCase.OpposingCounsel;
                    legalCases.CaseBackground = legalCase.CaseBackground;
                    legalCases.SpecialInstruction = legalCase.SpecialInstruction;
                    legalCases.BilingTypeId = legalCase.BilingTypeId;
                    legalCases.AppearanceDate = legalCase.AppearanceDate;
                    legalCases.AppearanceTime = legalCase.AppearanceTime;
                    // Biling type save logic
                    if (legalCase.BilingTypeId == flatGuid)
                    {
                        legalCases.Flatdescription = legalCase.BilingTypeInputValue;
                        legalCases.Hourlydescription = null;
                    }
                    else if (legalCase.BilingTypeId == hourlyGuid)
                    {
                        legalCases.Hourlydescription = legalCase.BilingTypeInputValue;
                        legalCases.Flatdescription = null;
                    }

                    legalCases.TravelExpense = legalCase.TravelExpense;
                    legalCases.PaymentMethodId = legalCase.PaymentMethodId;
                    legalCases.PerDiemAttorneyname = legalCase.PerDiemAttorneyname;
                    legalCases.PerDiemSignature = legalCase.PerDiemSignature;
                    legalCases.PerDiemDate = legalCase.PerDiemDate;


                    legalCases.CaseTypePerDiems = await _repository.GetCaseTypePerDiemByIdsAsync(legalCase.SelectedCaseTypePerDiemIds);
                    legalCases.AppearanceTypePerDiem = await _repository.GetApperenceTypePerDiemIdAsync(legalCase.SelectedAppearanceTypePerDiemIds);
                    legalCases.DocumentIntructionsTypse = await _repository.GetDocumentIntructionsTypsIdAsync(legalCase.SelectedDocumentInstructionPerDiemIds);
                    legalCases.ReportingTypePerDiems = await _repository.GetReportingTypePerDiemsIdAsync(legalCase.SelectedReportingRequirementPerDiemIds);

                }

                legalCases.CreatedBy = legalCase.CreatedBy;
                legalCases.CreatedOn = DateTime.Now;

                var addedcase = await _repository.AddAsync(legalCases);
                var result = await _unitOfWork.SaveChangesAsync();

                if (result != null) return addedcase.Id;
            }

            return null;

        }


        public async Task<int> GetTotalCasesCountAsync(string userId, bool isAdmin)
        {
            return await _repository.GetTotalCasesCountAsync(userId, isAdmin);
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

        public async Task<PaginationDto<LegalCase>> GetAllAsync(int pageNumber, int pageSize, CaseFilterDto Filters, string userId, bool isAdmin)
        {
            return await _repository.GetAllCasesAsync(pageNumber, pageSize, Filters, userId, isAdmin);
        }

        public async Task<List<LegalCase>> GetAllAsync()
        {
            return await _repository.GetAllCasesAsync();

        }


        public async Task<List<LegalCase>> GetTodayCasesAsync()
        {
            return await _repository.GetTodayCasesAsync();

        }



        public async Task<IntakeModel> GetCaseByIdAsync(Guid caseId)
        {
            try
            {

                var caseEntity = await _repository.GetAllQuerable(
        predicate: c => c.Id == caseId,
        (Expression<Func<LegalCase, object>>)(c => c.Clients!),
        c => c.Buildings!,
        c => c.CaseType!,
        c => c.LandLords!,
        c => c.Tenants!,
        c => c.RegulationStatus!,
        c => c.TenancyType!,
        c => c.RenewalStatus!,
        c => c.ReasonHoldover!,
        c => c.ClientRole!,
        c => c.Buildings!.State!,
        c => c.Addoccupants!,
        c => c.Buildings!.Landlord!.State!,
        c => c.Buildings!.Landlord!.LandlordType!,
        c => c.CaseTypeHPDs,
        c => c.CaseTypePerDiems,
        c => c.PartyRepresents!,
        c => c.Buildings!.BuildingType!,
        c => c.Buildings!.RegistrationStatus!,
         c => c.Buildings!.ExemptionReason!,
           c => c.Buildings!.ExemptionBasis!,
             c => c.Buildings!.TenancyTypeForBuilding!,
        c => c.HarassmentTypse,
        c => c.DefenseTypse,
        c => c.ReliefPetitionerType,
        c => c.ReliefRespondentType,
        c => c.AppearanceType,
        c => c.AppearanceTypePerDiem,
        c => c.BilingType!,
        c => c.ReportingTypePerDiems,
        c => c.DocumentIntructionsTypse,
        c => c.CourtLocation!,
        c => c.CourtPart!,
        c => c.Courts!,
         c => c.CourtLocation!.County!,
         c => c.ArrearLedgers,
         c => c.Marshal,
         c => c.RemainderCenters

    //c=>c.RemainderCenter
    )
    .FirstOrDefaultAsync();

                if (caseEntity == null)
                    return null!;

                if (caseEntity.CaseType!.Name == "Holdover" || caseEntity.CaseType.Name == "NonPayment" || caseEntity.CaseType.Name == "HPD" || caseEntity.CaseType.Name == "Illegal Lockout")
                {
                    var intakeModel = new IntakeModel
                    {
                        // for Case
                        Id = caseEntity.Id,
                        SubCaseTypeId = caseEntity.SubCaseTypeId,
                        Casecode = caseEntity.Casecode,
                        ClientId = caseEntity!.Clients!.Id,
                        CaseTypeName = caseEntity.CaseType.Name,
                        CaseTypeId = caseEntity.CaseTypeId,
                        CreatedOn = caseEntity.CreatedOn,
                        Status = caseEntity.IsActive ? "Active" : "Inactive",
                        //for Client
                        ClientCode = caseEntity.Clients.ClientCode,
                        ClientName = $"{caseEntity.Clients.FirstName} {caseEntity.Clients.LastName}",
                        ClientTypeId = caseEntity.Clients.ClientTypeId,
                        ClientEmail = caseEntity.Clients.Email,
                        ClientPhone = caseEntity.Clients.Phone,
                        Reference = caseEntity.Reference,
                        Address1 = caseEntity.Clients.Address1,
                        Address2 = caseEntity.Clients.Address2,
                        City = caseEntity.Clients.City,
                        StateName = caseEntity.Clients.State != null ? caseEntity.Clients.State.Name : string.Empty,
                        ZipCode = caseEntity.Clients.ZipCode,
                        MarshalId = caseEntity.MarshalId,
                        RemainderDate = caseEntity.RemainderCenters?
                    .OrderByDescending(x => x.When)
                    .FirstOrDefault()?.When,


                        // Landlord
                        LandlordId = caseEntity.LandLordId,
                        landlordName = $"{caseEntity.LandLords!.FirstName} {caseEntity.LandLords.LastName}",
                        ContactPersonName = caseEntity.LandLords.ContactPersonName,
                        LawFirm = caseEntity.LandLords.LawFirm,
                        AttorneyOfRecord = caseEntity.LandLords.AttorneyOfRecord,
                        LandlordAddress = caseEntity.LandLords.Address1,


                        // Building
                        BuildingId = caseEntity.BuildingId,
                        Buildingcode = caseEntity.Buildings.BuildingCode,
                        Mdr = caseEntity.Buildings?.MDRNumber,
                        Borough = caseEntity.Buildings?.Cities != null ? caseEntity.Buildings?.Cities.Name : null,
                        BoroughorCityId = caseEntity.Buildings != null ? caseEntity.Buildings.CityId : Guid.Empty,
                        Units = caseEntity.Buildings != null ? caseEntity.Buildings?.BuildingUnits : null,
                        BuildingState = caseEntity.Buildings!.State != null ? caseEntity.Buildings.State.Name : string.Empty,
                        BuildingAddress = caseEntity.Buildings?.Address1!,
                        BuildingZip = caseEntity.Buildings!.Zipcode,
                        BuildingStateId = caseEntity.Buildings! != null ? caseEntity.Buildings.StateId : Guid.Empty,
                        RegulationStatusId = caseEntity.Buildings?.RegulationStatusId ?? Guid.Empty,
                        BuildingTypeId = caseEntity.Buildings.BuildingTypeId,
                        RegistrationStatusTypeId = caseEntity.Buildings.RegistrationStatusId,
                        ExemptionReasonId = caseEntity.Buildings.ExemptionReasonId,
                        ExemptionBasisId = caseEntity.Buildings.ExemptionBasisId,
                        GoodCause = caseEntity.Buildings.GoodCause != null ? caseEntity.Buildings.GoodCause.Value : false,
                        OwnerOccupied = caseEntity.Buildings.OwnerOccupied != null ? caseEntity.Buildings.OwnerOccupied.Value : false,



                        // Tenant
                        TenantId = caseEntity.TenantId,
                        TenantName = caseEntity.Tenants != null ? $"{caseEntity.Tenants?.FirstName} {caseEntity.Tenants?.LastName}" : string.Empty,
                        ApartmentNumber = caseEntity.Tenants != null ? caseEntity.Tenants?.UnitOrApartmentNumber : string.Empty,
                        TenancyTypeId = caseEntity.Tenants != null ? caseEntity.Tenants.TenancyTypeId : Guid.Empty,
                        PrimaryResidence = caseEntity.Tenants != null ? caseEntity.Tenants.PrimaryResidence : false,
                        MonthlyRent = caseEntity.Tenants != null ? caseEntity.Tenants.MonthlyRent : 0,
                        TenantShare = caseEntity.Tenants != null ? caseEntity.Tenants.TenantShare : 0,
                        RentDueEachMonthOrWeekId = caseEntity.Tenants != null ? caseEntity.Tenants.RentDueEachMonthOrWeekId : Guid.Empty,

                        WrittenLease = caseEntity.WrittenLease,
                        OralAgreeMent = caseEntity.OralAgreeMent,
                        CaseProgramId = caseEntity.CaseProgramId,
                        GoodCauseApplies = caseEntity.GoodCauseApplies,
                        DateTenantMoved = caseEntity.DateTenantMoved,
                        LeaseEnd = caseEntity.LeaseEnd,
                        //TenancyTypeId = caseEntity.TenancyTypeId,
                        DateNoticeServed = caseEntity.DateNoticeServed,
                        CalculatedNoticeLength = caseEntity.CalculatedNoticeLength,
                        ExpirationDate = caseEntity.ExpirationDate,
                        PredicateNotice = caseEntity.PredicateNotice,


                        TotalOwed = caseEntity.TotalRentOwed,

                        SocialService = caseEntity.SocialService,
                        LastRentPaid = caseEntity.LastRentPaid,


                        //CourtId = caseEntity.CourtId != null ? caseEntity.CourtId : Guid.Empty,
                        Court = caseEntity.CourtLocation != null ? caseEntity.CourtLocation.Court! : "",
                        CourtAddress = caseEntity.CourtLocation != null ? caseEntity.CourtLocation.Address! : "",
                        CourtPartId = caseEntity.CourtPartId != null ? caseEntity.CourtPartId : Guid.Empty,
                        CourtPart = caseEntity.CourtPart != null ? caseEntity.CourtPart.Part : string.Empty,
                        CourtRoom = caseEntity.CourtPart != null ? caseEntity.CourtPart.RoomNo : string.Empty,
                        CourtLocationId = caseEntity.CourtLocationId,
                        CourtName = caseEntity.CourtLocation != null ? $"{caseEntity.CourtLocation.Court}" : "",
                        Judge = caseEntity.CourtPart != null ? caseEntity.CourtPart.Judge : string.Empty,
                        //CourtConferenceId = caseEntity.Courts != null ? caseEntity.Courts.ConferenceId : "",
                        //CourtCallIn = caseEntity.Courts != null ? caseEntity.Courts.CallIn : "",
                        //CourtNotes = caseEntity.Courts != null ? caseEntity.Courts.Notes : "",
                        //CourtPart = caseEntity.Courts != null ? caseEntity.Courts.Part : "",
                        //CourtPhone = caseEntity.Courts != null ? caseEntity.Courts.Phone : "",
                        //CourtRoomNo = caseEntity.Courts != null ? caseEntity.Courts.RoomNo : "",
                        //CourtVirtualLink = caseEntity.Courts != null ? caseEntity.Courts.VirtualLink : "",
                        Attrney = caseEntity.Attrney,
                        AttrneyContactInfo = caseEntity.AttrneyContactInfo,
                        AttrneyEmail = caseEntity.AttrneyEmail,

                        MarshalName = caseEntity.Marshal != null ? $"{caseEntity.Marshal?.FirstName} {caseEntity.Marshal?.LastName}" : string.Empty,
                        MarshalPhone = caseEntity.Marshal != null ? caseEntity.Marshal.Telephone : string.Empty,
                        Docketno = caseEntity.Marshal != null ? caseEntity.Marshal.DocketNo : string.Empty,
                        WarrantRequested = caseEntity.WarrantRequested,
                        Index = caseEntity.Index,
                        County = caseEntity.County,
                        ManagingAgent = caseEntity.ManagingAgent,
                        OpposingCounsel = caseEntity.OpposingCounsel,
                        AppearanceDate = caseEntity.AppearanceDate,
                        AppearanceTime = caseEntity.AppearanceTime,
                        InvoiceTo = caseEntity.InvoiceTo,
                        BilingTypeId = caseEntity.BilingTypeId,

                        OppAttorneyFirm = caseEntity.OppAttorneyFirm,
                        OppAttorneyEmail = caseEntity.OppAttorneyEmail,
                        OppAttorneyname = caseEntity.OppAttorneyname,
                        OppAttorneyPhone = caseEntity.OppAttorneyPhone,
                        Aps_Agl = caseEntity.Aps_Agl,

                        SelectedCaseTypeHPDIds = caseEntity.CaseTypeHPDs
                                              .Select(x => x.Id)
                                              .ToList(),
                        SelectedHarassmentTypeIds = caseEntity.HarassmentTypse
                                              .Select(x => x.Id)
                                              .ToList(),
                        SelectedDefenseTypeIds = caseEntity.DefenseTypse
                                              .Select(x => x.Id)
                                              .ToList(),
                        SelectedAppearanceTypeIds = caseEntity.AppearanceType
                                              .Select(x => x.Id)
                                              .ToList(),

                        SelectedReliefPetitionerTypeIds = caseEntity.ReliefPetitionerType
                                              .Select(x => x.Id)
                                              .ToList(),
                        SelectedReliefRespondentTypeIds = caseEntity.ReliefRespondentType
                                              .Select(x => x.Id)
                                              .ToList(),
                        PartyRepresentId = caseEntity.PartyRepresentId,
                        PremiseTypeId = caseEntity.Buildings != null ? caseEntity.Buildings.PremiseTypeId : null,


                        UnitOrApartmentNumber = caseEntity.Tenants != null ? caseEntity.Tenants!.UnitOrApartmentNumber : string.Empty,
                        FirstName = caseEntity.Tenants != null ? caseEntity.Tenants.FirstName : string.Empty,
                        LastName = caseEntity.Tenants != null ? caseEntity.Tenants.LastName : string.Empty,
                        BillAmount = caseEntity.BillAmount ?? 0,

                        LastPayment = caseEntity.LastPayment,
                        Assistance = caseEntity.Assistance,
                        NextBussinessday = caseEntity.NextBussinessday,
                        leasedAttached = caseEntity.leasedAttached != null ? caseEntity.leasedAttached.Value : false,
                        ledgerAttached = caseEntity.ledgerAttached != null ? caseEntity.ledgerAttached.Value : false,
                        NoticeproofAttached = caseEntity.NoticeproofAttached != null ? caseEntity.NoticeproofAttached.Value : false,
                        RegistrationRentAttached = caseEntity.RegistrationRentAttached != null ? caseEntity.RegistrationRentAttached.Value : false,
                        GoodCauseExempt = caseEntity.GoodCauseExempt,
                        CourtDraftNop = caseEntity.CourtDraftNop,
                        LeaseStart = caseEntity.LeaseStart,
                        PlannedServiceDate = caseEntity.PlannedServiceDate,
                        LastPaymentDate = caseEntity.LastPaymentDate,
                        DeemedService = caseEntity.DeemedService,
                        Expiry = caseEntity.Expiry,
                        AdditionalComments = caseEntity.AdditionalComments,
                        AffidavitofService = caseEntity.AffidavitofService,
                        PreferedFilingDate = caseEntity.PreferedFilingDate,
                        FilingMethodId = caseEntity.FilingMethodId,
                        NoticeId = caseEntity.NoticeId,
                        ServiceMethodId = caseEntity.ServiceMethodId,
                        CountyId = caseEntity.CourtLocation != null ? caseEntity.CourtLocation?.CountyId : null,
                        CourtTypeId = caseEntity.CourtTypeId,
                        CountyName = caseEntity.CourtLocation != null ? caseEntity.CourtLocation?.County?.Name : string.Empty,



                        ArrearLedgers = caseEntity.ArrearLedgers != null ? caseEntity.ArrearLedgers.Select(e => new ArrearLedgerDto()
                        {
                            Id = e.Id,
                            Notes = e.Notes,
                            Amount = e.Amount,
                            LegalCaseId = e.LegalCaseId,
                            Month = e.Month,
                        }).ToList() : new List<ArrearLedgerDto>()
                    };
                    return intakeModel;
                }
                if (caseEntity.CaseType.Name == "Per Diem")
                {
                    var billingTypes = await _caseTypeRepository.GetAllBilingTypes();
                    var flatGuid = billingTypes
               .FirstOrDefault(x => x.Name.Equals("Flat Rate", StringComparison.OrdinalIgnoreCase))
               ?.Id;

                    var hourlyGuid = billingTypes
                                    .FirstOrDefault(x => x.Name.Equals("Hourly ($/hr)", StringComparison.OrdinalIgnoreCase))
                                    ?.Id;
                    var intakeModel = new IntakeModel
                    {
                        // for Case
                        Id = caseEntity.Id,
                        Casecode = caseEntity.Casecode,
                        ClientId = caseEntity.Clients!.Id,
                        CaseTypeName = caseEntity.CaseType.Name,
                        CaseTypeId = caseEntity.CaseTypeId,
                        CreatedOn = caseEntity.CreatedOn,
                        Status = caseEntity.IsActive ? "Active" : "Inactive",
                        //for Client
                        ClientCode = caseEntity.Clients.ClientCode,
                        ClientName = $"{caseEntity.Clients.FirstName} {caseEntity.Clients.LastName}",
                        ClientTypeId = caseEntity.Clients.ClientTypeId,
                        ClientEmail = caseEntity.Clients.Email,
                        ClientPhone = caseEntity.Clients.Phone,
                        Reference = caseEntity.Reference,
                        Address1 = caseEntity.Clients.Address1,
                        Address2 = caseEntity.Clients.Address2,
                        City = caseEntity.Clients.City,
                        StateName = caseEntity.Clients.State != null ? caseEntity.Clients.State.Name : string.Empty,
                        ZipCode = caseEntity.Clients.ZipCode,
                        MarshalId = caseEntity.MarshalId,

                        Attrney = caseEntity.Attrney,
                        AttrneyContactInfo = caseEntity.AttrneyContactInfo,
                        AttrneyEmail = caseEntity.AttrneyEmail,
                        CourtLocationId = caseEntity.CourtLocationId,
                        CourtName = caseEntity.CourtLocation != null ? $"{caseEntity.CourtLocation.Court}" : "",
                        CourtRoom = caseEntity.CourtRoom,
                        Index = caseEntity.Index,
                        CourtTypeId = caseEntity.CourtTypeId,
                        CourtPartId = caseEntity.CourtPartId,
                        CountyId = caseEntity.CourtLocation != null ? caseEntity.CourtLocation.CountyId : null,


                        OpposingCounsel = caseEntity.OpposingCounsel,
                        Partynames = caseEntity.Partynames,
                        CaseBackground = caseEntity.CaseBackground,
                        SpecialInstruction = caseEntity.SpecialInstruction,
                        CountyName = caseEntity.CourtLocation?.County?.Name ?? string.Empty,


                        TravelExpense = caseEntity.TravelExpense,
                        BilingTypeId = caseEntity.BilingTypeId,
                        PerDiemAttorneyname = caseEntity.PerDiemAttorneyname,
                        AppearanceDate = caseEntity.AppearanceDate,
                        AppearanceTime = caseEntity.AppearanceTime,
                        PerDiemDate = caseEntity.PerDiemDate,
                        Docketno = caseEntity.DocketNo,


                        PerDiemSignature = caseEntity.PerDiemSignature,
                        SelectedCaseTypePerDiemIds = caseEntity.CaseTypePerDiems
                                              .Select(x => x.Id)
                                              .ToList(),

                        SelectedAppearanceTypePerDiemIds = caseEntity.AppearanceTypePerDiem
                                              .Select(x => x.Id)
                                              .ToList(),

                        SelectedDocumentInstructionPerDiemIds = caseEntity.DocumentIntructionsTypse
                                              .Select(x => x.Id)
                                              .ToList(),
                        SelectedReportingRequirementPerDiemIds = caseEntity.ReportingTypePerDiems
                                              .Select(x => x.Id)
                                              .ToList(),
                        PartyRepresentPerDiemId = caseEntity.PartyRepresentPerDiemId,


                        PaymentMethodId = caseEntity.PaymentMethodId,

                    };


                    if (flatGuid != null && caseEntity.BilingTypeId == flatGuid)
                    {
                        intakeModel.BilingTypeInputValue = caseEntity.Flatdescription;
                    }
                    else if (hourlyGuid != null && caseEntity.BilingTypeId == hourlyGuid)
                    {
                        intakeModel.BilingTypeInputValue = caseEntity.Hourlydescription;
                    }




                    return intakeModel;
                }


                return null!;


            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }


        public async Task<CreateToEditLegalCaseModel> GetByIdAsync(Guid id)
        {
            var legalcaseEntity = await _repository.GetAllQuerable(
        predicate: c => c.Id == id,
        (Expression<Func<LegalCase, object>>)(c => c.Clients),
        c => c.Buildings,
        c => c.CaseType,
        c => c.LandLords,
        c => c.Tenants,
        c => c.RegulationStatus,
        c => c.TenancyType,
        c => c.RenewalStatus,
        c => c.ReasonHoldover,
        c => c.Buildings.State,
        c => c.Addoccupants,
        c => c.Buildings.Landlord.State,
        c => c.Buildings.Landlord.LandlordType
    )
    .FirstOrDefaultAsync();

            if (legalcaseEntity == null)
                return null;

            var dto = new CreateToEditLegalCaseModel
            {
                Id = legalcaseEntity.Id,

                //ClientId = legalcaseEntity.Clients.Id,

                BuildingId = legalcaseEntity.Buildings?.Id,
                LandLordId = legalcaseEntity.LandLordId,
                TenantId = legalcaseEntity.Tenants?.Id,
                ExplainDescription = legalcaseEntity.ExplainDescription,
                ReasonHoldoverId = legalcaseEntity.ReasonHoldoverId,
                ERAPPaymentReceivedDate = legalcaseEntity.ERAPPaymentReceivedDate,
                IsERAPPaymentReceived = legalcaseEntity.IsERAPPaymentReceived,
                HasPossession = legalcaseEntity.HasPossession,
                IsUnitIllegalId = legalcaseEntity.IsUnitIllegalId,
                LandlordTypeId = legalcaseEntity.LandlordTypeId,
                LastMonthWeekRentPaid = legalcaseEntity.LastMonthWeekRentPaid,
                MonthlyRent = legalcaseEntity.MonthlyRent,
                OtherOccupants = legalcaseEntity.OtherOccupants,
                RegulationStatusId = legalcaseEntity.RegulationStatusId,
                RenewalOffer = legalcaseEntity.RenewalOffer,
                RentDueEachMonthOrWeekId = legalcaseEntity.RentDueEachMonthOrWeekId,
                SocialServices = legalcaseEntity.SocialServices,
                TenancyTypeId = legalcaseEntity.TenancyTypeId,
                TenantRecord = legalcaseEntity.TenantRecord,
                TenantShare = legalcaseEntity.TenantShare,
                CaseTypeId = legalcaseEntity.CaseTypeId,
                Attrney = legalcaseEntity.Attrney,
                AttrneyContactInfo = legalcaseEntity.AttrneyContactInfo,
                Firm = legalcaseEntity.Firm,
                tenantReceive = legalcaseEntity.tenantReceive,
                ExplainTenancyReceiveDescription = legalcaseEntity.ExplainTenancyReceiveDescription,
                TotalRentOwed = legalcaseEntity.TotalRentOwed,
                OralEnd = legalcaseEntity.OralEnd,
                OralStart = legalcaseEntity.OralStart,
                WrittenLease = legalcaseEntity.WrittenLease,
                RenewalStatusId = legalcaseEntity.RenewalStatusId,
                DateTenantMoved = legalcaseEntity.DateTenantMoved,
                Casecode = legalcaseEntity.Casecode,
                AdditionalOccupants = legalcaseEntity.Addoccupants
                .Select(o => new AdditionalOccupantDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Relation = o.Relation,
                    LegalCaseId = o.LegalCaseId,
                    IsVisible = true
                }).ToList(),

                Client = legalcaseEntity.Clients == null ? null : new EditToClientDto
                {
                    Id = legalcaseEntity.Clients.Id,
                    FirstName = legalcaseEntity.Clients.FirstName,
                    LastName = legalcaseEntity.Clients.LastName,

                    Email = legalcaseEntity.Clients.Email,
                    ClientTypeId = legalcaseEntity.ClientRoleId,
                    Reference = legalcaseEntity.Reference,
                },



                tenants = legalcaseEntity.Tenants == null ? null : new CreateToTenantDto
                {
                    FirstName = legalcaseEntity.Tenants.FirstName,
                    LastName = legalcaseEntity.Tenants.LastName,
                    BuildingId = legalcaseEntity.Tenants.BuildinId,
                    UnitOrApartmentNumber = legalcaseEntity.Tenants.UnitOrApartmentNumber,

                    Building = legalcaseEntity.Tenants.Building == null ? null : new EditToBuildingDto
                    {
                        Id = legalcaseEntity.Tenants.Building.Id,
                        Address1 = legalcaseEntity.Tenants.Building.Address1,
                        Address2 = legalcaseEntity.Tenants.Building.Address2,
                        Zipcode = legalcaseEntity.Tenants.Building.Zipcode,
                        CityId = legalcaseEntity.Tenants.Building.CityId,
                        CityName = legalcaseEntity.Tenants.Building.Cities.Name,
                        StateId = legalcaseEntity.Tenants.Building.StateId,
                        MDRNumber = legalcaseEntity.Tenants.Building.MDRNumber,
                        BuildingUnits = legalcaseEntity.Tenants.Building.BuildingUnits,
                        RegulationStatusId = legalcaseEntity.Tenants.Building.RegulationStatusId,

                        RegulationStatusName = legalcaseEntity.Tenants.Building.RegulationStatus.Name
                    },

                    Landlord = legalcaseEntity.Tenants.Building.Landlord == null ? null : new EditToLandlordDto
                    {
                        Id = legalcaseEntity.Tenants.Building.Landlord.Id,
                        FirstName = legalcaseEntity.Tenants.Building.Landlord.FirstName,
                        LastName = legalcaseEntity.Tenants.Building.Landlord.LastName,
                        Address1 = legalcaseEntity.Tenants.Building.Landlord.Address1,
                        Address2 = legalcaseEntity.Tenants.Building.Landlord.Address2,
                        Zipcode = legalcaseEntity.Tenants.Building.Landlord.Zipcode,
                        CityId = legalcaseEntity.Tenants.Building.Landlord.CityId,
                        StateId = legalcaseEntity.Tenants.Building.Landlord.StateId,
                        Phone = legalcaseEntity.Tenants.Building.Landlord.Phone,
                        Email = legalcaseEntity.Tenants.Building.Landlord.Email,
                        LandlordTypeId = legalcaseEntity.Tenants.Building.Landlord.LandlordTypeId
                    }
                }
            };

            return dto;
        }

        // new update 
        public async Task<Guid?> UpdateCaseAsync(IntakeModel legalCase)
        {
            try
            {
                var existingCase = await _repository.GetAsync(legalCase.Id);
                if (existingCase == null) return null;

                var billingTypes = await _caseTypeRepository.GetAllBilingTypes();

                var flatGuid = billingTypes
                    .FirstOrDefault(x => x.Name.Equals("Flat Rate", StringComparison.OrdinalIgnoreCase))
                    ?.Id;

                var hourlyGuid = billingTypes
                                .FirstOrDefault(x => x.Name.Equals("Hourly ($/hr)", StringComparison.OrdinalIgnoreCase))
                                ?.Id;
                //var landlord = await _landlordrepo.GetAsync(existingCase.LandLordId);
                //var building = await _buildingrepo.GetAsync(existingCase.BuildingId);
                //var tenant = await _tenantRepo.GetAsync(existingCase.TenantId);

                existingCase.ClientId = legalCase.ClientId;
                existingCase.CaseTypeId = legalCase.CaseTypeId;
                existingCase.IsERAPPaymentReceived = legalCase.IsERAPPaymentReceived;
                existingCase.SubCaseTypeId = legalCase.SubCaseTypeId;
                existingCase.MonthlyRent = legalCase.MonthlyRent;
                existingCase.TotalRentOwed = legalCase.TotalOwed;
                existingCase.TenantShare = legalCase.TenantShare;
                existingCase.RentDueEachMonthOrWeekId = legalCase.RentDueEachMonthOrWeekId;
                existingCase.OralStart = legalCase.OralStart;
                existingCase.OralEnd = legalCase.OralEnd;
                existingCase.WrittenLease = legalCase.WrittenLease;
                existingCase.DateTenantMoved = legalCase.DateTenantMoved;
                //CreatedBy = legalCase.CreatedBy,
                existingCase.CreatedOn = DateTime.Now;
                existingCase.TenancyTypeId = legalCase.TenancyTypeId;
                // Foreign keys
                existingCase.LandLordId = legalCase.LandlordId;
                //existingCase.LandlordTypeId = legalCase.LandLordTypeId;
                existingCase.CreatedBy = legalCase.CreatedBy;

                existingCase.BuildingId = legalCase.BuildingId;
                existingCase.TenantId = legalCase.TenantId;
                existingCase.TenantName = legalCase.TenantName;

                existingCase.UnitOrApartmentNumber = legalCase.UnitOrApartmentNumber;
                existingCase.LeaseEnd = legalCase.LeaseEnd;
                existingCase.DateNoticeServed = legalCase.DateNoticeServed;
                existingCase.ExpirationDate = legalCase.ExpirationDate;
                existingCase.PredicateNotice = legalCase.PredicateNotice;
                existingCase.SocialService = legalCase.SocialService;
                existingCase.LastRentPaid = legalCase.LastRentPaid;
                existingCase.Reference = legalCase.Reference;
                existingCase.OralAgreeMent = legalCase.OralAgreeMent;
                existingCase.GoodCauseApplies = legalCase.GoodCauseApplies;
                existingCase.CalculatedNoticeLength = legalCase.CalculatedNoticeLength;
                existingCase.Attrney = legalCase.Attrney;
                existingCase.AttrneyContactInfo = legalCase.AttrneyContactInfo;
                existingCase.AttrneyEmail = legalCase.AttrneyEmail;
                existingCase.CourtLocationId = legalCase.CourtLocationId;
                existingCase.CourtRoom = legalCase.CourtRoom;
                existingCase.Index = legalCase.Index;
                existingCase.County = legalCase.County;
                existingCase.ManagingAgent = legalCase.ManagingAgent;
                existingCase.OpposingCounsel = legalCase.OpposingCounsel;
                existingCase.AppearanceDate = legalCase.AppearanceDate;
                existingCase.AppearanceTime = legalCase.AppearanceTime;
                existingCase.InvoiceTo = legalCase.InvoiceTo;
                existingCase.DateTenantMoved = legalCase.DateTenantMoved;
                existingCase.Attrney = legalCase.Attrney;
                existingCase.AttrneyContactInfo = legalCase.AttrneyContactInfo;
                existingCase.AttrneyEmail = legalCase.AttrneyEmail;
                existingCase.CourtLocationId = legalCase.CourtLocationId;
                existingCase.Index = legalCase.Index;
                existingCase.Partynames = legalCase.Partynames;
                existingCase.CaseBackground = legalCase.CaseBackground;
                existingCase.TravelExpense = legalCase.TravelExpense;
                existingCase.PerDiemAttorneyname = legalCase.PerDiemAttorneyname;
                existingCase.PerDiemDate = legalCase.PerDiemDate;
                existingCase.PerDiemSignature = legalCase.PerDiemSignature;
                existingCase.CourtPartId = legalCase.CourtPartId != Guid.Empty ? legalCase.CourtPartId : null;

                existingCase.LastPayment = legalCase.LastPayment;
                existingCase.Assistance = legalCase.Assistance;
                existingCase.NextBussinessday = legalCase.NextBussinessday;
                existingCase.leasedAttached = legalCase.leasedAttached;
                existingCase.ledgerAttached = legalCase.ledgerAttached;
                existingCase.NoticeproofAttached = legalCase.NoticeproofAttached;
                existingCase.RegistrationRentAttached = legalCase.RegistrationRentAttached;
                existingCase.GoodCauseExempt = legalCase.GoodCauseExempt;
                existingCase.CourtDraftNop = legalCase.CourtDraftNop;
                existingCase.LeaseStart = legalCase.LeaseStart;
                existingCase.PlannedServiceDate = legalCase.PlannedServiceDate;
                existingCase.LastPaymentDate = legalCase.LastPaymentDate;
                existingCase.DeemedService = legalCase.DeemedService;
                existingCase.Expiry = legalCase.Expiry;
                existingCase.AdditionalComments = legalCase.AdditionalComments;
                existingCase.AffidavitofService = legalCase.AffidavitofService;
                existingCase.PreferedFilingDate = legalCase.PreferedFilingDate;
                existingCase.FilingMethodId = legalCase.FilingMethodId;
                existingCase.NoticeId = legalCase.NoticeId;
                existingCase.ServiceMethodId = legalCase.ServiceMethodId;
                existingCase.CourtLocationId = legalCase.CourtLocationId;
                existingCase.CourtTypeId = legalCase.CourtTypeId;

                existingCase.GoodCauseExempt = legalCase.GoodCauseExempt;
                existingCase.leasedAttached = legalCase.leasedAttached;
                existingCase.ledgerAttached = legalCase.ledgerAttached;
                existingCase.NoticeproofAttached = legalCase.NoticeproofAttached;
                existingCase.RegistrationRentAttached = legalCase.RegistrationRentAttached;
                existingCase.AdditionalComments = legalCase.AdditionalComments;
                existingCase.DocketNo = legalCase.Docketno;

                existingCase.OppAttorneyEmail = legalCase.OppAttorneyEmail;
                existingCase.OppAttorneyFirm = legalCase.OppAttorneyFirm;
                existingCase.OppAttorneyname = legalCase.OppAttorneyname;
                existingCase.OppAttorneyPhone = legalCase.OppAttorneyPhone;
                existingCase.Aps_Agl = legalCase.Aps_Agl;


                if (legalCase.PartyRepresentPerDiemId != null && legalCase.PartyRepresentPerDiemId != Guid.Empty)
                {
                    existingCase.PartyRepresentPerDiemId = legalCase.PartyRepresentPerDiemId;

                }

                if (legalCase.PartyRepresentId != null && legalCase.PartyRepresentId != Guid.Empty)
                {
                    existingCase.PartyRepresentId = legalCase.PartyRepresentId;

                }

                if (legalCase.BilingTypeId != null && legalCase.BilingTypeId != Guid.Empty)
                {
                    existingCase.BilingTypeId = legalCase.BilingTypeId;

                }

                if (legalCase.PaymentMethodId != null && legalCase.PaymentMethodId != Guid.Empty)
                {
                    existingCase.PaymentMethodId = legalCase.PaymentMethodId;

                }

                if (legalCase.CaseProgramId != null && legalCase.CaseProgramId != Guid.Empty)
                {
                    existingCase.CaseProgramId = legalCase.CaseProgramId;

                }
                if (legalCase.CourtId != null && legalCase.CourtId != Guid.Empty)
                {
                    existingCase.CourtId = legalCase.CourtId;

                }
                existingCase.BillAmount = legalCase.BillAmount;

                var updated = _repository.UpdateAsync(existingCase);


                existingCase.CaseTypeHPDs.Clear();
                existingCase.CaseTypePerDiems.Clear();
                existingCase.HarassmentTypse.Clear();
                existingCase.DefenseTypse.Clear();
                existingCase.AppearanceType.Clear();
                existingCase.AppearanceTypePerDiem.Clear();
                existingCase.DocumentIntructionsTypse.Clear();
                existingCase.ReportingTypePerDiems.Clear();
                existingCase.ReliefRespondentType.Clear();
                existingCase.ReliefPetitionerType.Clear();

                if (legalCase.SelectedCaseTypePerDiemIds != null)
                {
                    foreach (var id in legalCase.SelectedCaseTypePerDiemIds)
                    {
                        var ct = await _caseTypePerDiemRepository.GetAsync(id);
                        if (ct != null)
                        {
                            existingCase.CaseTypePerDiems.Add(ct);
                        }
                    }
                }

                if (legalCase.SelectedDocumentInstructionPerDiemIds != null)
                {
                    foreach (var id in legalCase.SelectedDocumentInstructionPerDiemIds)
                    {
                        var ct = await _documentIntructionsTypesRepository.GetAsync(id);
                        if (ct != null)
                        {
                            existingCase.DocumentIntructionsTypse.Add(ct);
                        }
                    }
                }

                if (legalCase.SelectedReportingRequirementPerDiemIds != null)
                {
                    foreach (var id in legalCase.SelectedReportingRequirementPerDiemIds)
                    {
                        var ct = await _reportingTypePerDiemRepository.GetAsync(id);
                        if (ct != null)
                        {
                            existingCase.ReportingTypePerDiems.Add(ct);
                        }
                    }
                }

                if (legalCase.SelectedCaseTypeHPDIds != null)
                {
                    foreach (var id in legalCase.SelectedCaseTypeHPDIds)
                    {
                        var hpd = await _caseTypeHPDRepository.GetAsync(id);
                        if (hpd != null)
                        {
                            existingCase.CaseTypeHPDs.Add(hpd);
                        }
                    }
                }

                if (legalCase.SelectedAppearanceTypeIds != null)
                {
                    foreach (var id in legalCase.SelectedAppearanceTypeIds)
                    {
                        var hpd = await _appearanceTypeRepository.GetAsync(id);
                        if (hpd != null)
                        {
                            existingCase.AppearanceType.Add(hpd);
                        }
                    }
                }

                if (legalCase.SelectedAppearanceTypePerDiemIds != null)
                {
                    foreach (var id in legalCase.SelectedAppearanceTypePerDiemIds)
                    {
                        var hpd = await _appearanceTypePerDiemRepository.GetAsync(id);
                        if (hpd != null)
                        {
                            existingCase.AppearanceTypePerDiem.Add(hpd);
                        }
                    }
                }

                if (legalCase.SelectedReliefPetitionerTypeIds != null)
                {
                    foreach (var id in legalCase.SelectedReliefPetitionerTypeIds)
                    {
                        var hpd = await _reliefPetitionerTypeRepository.GetAsync(id);
                        if (hpd != null)
                        {
                            existingCase.ReliefPetitionerType.Add(hpd);
                        }
                    }
                }

                if (legalCase.SelectedReliefRespondentTypeIds != null)
                {
                    foreach (var id in legalCase.SelectedReliefRespondentTypeIds)
                    {
                        var hpd = await _reliefRespondenTypeRepository.GetAsync(id);
                        if (hpd != null)
                        {
                            existingCase.ReliefRespondentType.Add(hpd);
                        }
                    }
                }

                if (legalCase.SelectedHarassmentTypeIds != null)
                {
                    foreach (var id in legalCase.SelectedHarassmentTypeIds)
                    {
                        var hpharasmentType = await _harassmentTypeRepository.GetAsync(id);
                        if (hpharasmentType != null)
                        {
                            existingCase.HarassmentTypse.Add(hpharasmentType);
                        }
                    }
                }

                if (legalCase.SelectedDefenseTypeIds != null)
                {
                    foreach (var id in legalCase.SelectedDefenseTypeIds)
                    {
                        var defenseType = await _defenseTypeRepository.GetAsync(id);
                        if (defenseType != null)
                        {
                            existingCase.DefenseTypse.Add(defenseType);
                        }
                    }
                }
                if (legalCase.BilingTypeId == flatGuid)
                {
                    existingCase.Flatdescription = legalCase.BilingTypeInputValue;
                    existingCase.Hourlydescription = null;
                }
                else if (legalCase.BilingTypeId == hourlyGuid)
                {
                    existingCase.Hourlydescription = legalCase.BilingTypeInputValue;
                    existingCase.Flatdescription = null;
                }

                var result = await _unitOfWork.SaveChangesAsync();

                if (result > 0) return existingCase.Id;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }


        }

        public async Task<bool> UpdateMarshalAsync(IntakeModel legalCase)
        {
            try
            {
                var existingCase = await _repository.GetAsync(legalCase.Id);
                if (existingCase == null) return false;

                existingCase.MarshalId = legalCase.MarshalId!;

                var result = await _unitOfWork.SaveChangesAsync();

                if (result > 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public async Task<bool> UpdateWarrantRequested(IntakeModel legalCase)
        {
            try
            {
                var existingCase = await _repository.GetAsync(legalCase.Id);
                if (existingCase == null) return false;

                existingCase.WarrantRequested = legalCase.WarrantRequested!;

                var result = await _unitOfWork.SaveChangesAsync();

                if (result > 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

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


        public async Task<bool> DeleteAsync(Guid id, bool isAdmin)
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

        public async Task<bool> AddDocumentAsync(List<CaseDocument> document)
        {
            await _caseDocument.AddRangeAsync(document);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CaseDocument>> CaseDocumentList(Guid Id)
        {
            var doclist = _caseDocument.GetAllQuerable();
            var returnlist = await doclist.Where(e => e.LegalCaseId == Id).OrderByDescending(e => e.CreatedOn).ToListAsync();
            return returnlist;
        }

        public async Task<bool> DeleteCaseDocument(Guid Id)
        {
            var doclist = await _caseDocument.DeleteAsync(Id);
            if (doclist)
            {
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();
            }
            return doclist;
        }

        public async Task<IEnumerable<FilingMethod>> FilingMethodList()
        {
            var doclist = _filingMethod.GetAllQuerable();
            var returnlist = await doclist.OrderBy(e => e.Name).ToListAsync();
            return returnlist;
        }

        public async Task<IEnumerable<ServiceMethod>> ServiceMethodList()
        {
            return await _serviceMethod.GetServiceMethodsAsync();
        }

        public async Task<IEnumerable<CourtType>> CourtTypeList()
        {
            var doclist = _courtTypeRepository.GetAllQuerable();
            var returnlist = await doclist.OrderBy(e => e.Name).ToListAsync();
            return returnlist;
        }
        public async Task<bool> AddArrearLedgerAsync(List<ArrearLedgerDto> Ledger)
        {
            try
            {
                var LedgerList = Ledger.Select(e => new ArrearLedger()
                {
                    Id = e.Id,
                    LegalCaseId = e.LegalCaseId,
                    CaseNoticeId = e.CaseNoticeId,
                    Amount = e.Amount,
                    Notes = e.Notes,
                    Month = e.Month,
                    CreatedOn = DateTime.Now,
                }).ToList();
                await _arrearLedger.AddRangeAsync(LedgerList);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UpdateArrearLedgerAsync(List<ArrearLedgerDto> Ledger)
        {
            try
            {
                foreach (var row in Ledger)
                {
                    var existingLedger = await _arrearLedger.GetAsync(row.Id);

                    existingLedger.Amount = row.Amount;
                    existingLedger.Notes = row.Notes;
                    existingLedger.Month = row.Month;
                }

                //await _arrearLedger.UpdateRange(LedgerList);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> DeleteArrearLedger(List<ArrearLedgerDto> Ledger)
        {
            try
            {
                foreach (var row in Ledger)
                {
                    var doclist = await _arrearLedger.DeleteAsync(row.Id);
                }

                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<City>> GetAllCitiesList()
        {
            var doclist = _cityRepository.GetAllQuerable();
            var returnlist = await doclist.OrderBy(e => e.Name).ToListAsync();
            return returnlist;
        }

        public async Task<IEnumerable<SubCaseType>> GetSubCaseList()
        {
            var doclist = _subCaseTypeRepository.GetAllQuerable();
            var returnlist = await doclist.OrderBy(e => e.Name).ToListAsync();
            return returnlist;
        }

        public async Task<bool> AddAdditionalrespondent(List<CaseAdditionalRespondent> respondent)
        {
            await _respondantRepository.AddRangeAsync(respondent);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAdditionalrespondent(CaseAdditionalRespondent respondent)
        {
            await _respondantRepository.DeleteAsync(respondent.Id);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<List<CaseAdditionalRespondent>> GetAdditionalrespondent(Guid respondentid)
        {
            var respondant = _respondantRepository.GetAllQuerable();
            var result = await respondant.Where(e => e.LandlordId == respondentid).ToListAsync();
            return result;
        }

        public async Task<List<CaseAdditionalPetitioner>> GetAdditionalpetitioner(Guid Petitionerid)
        {
            var respondant = _petitionerRepository.GetAllQuerable();
            var result = await respondant.Where(e => e.TenantId == Petitionerid).ToListAsync();
            return result;
        }

        public async Task<bool> AddAdditionalpetitioner(List<CaseAdditionalPetitioner> petitioner)
        {
            await _petitionerRepository.AddRangeAsync(petitioner);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAdditionalpetitioner(CaseAdditionalPetitioner petitioner)
        {
            await _petitionerRepository.DeleteAsync(petitioner.Id);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CaseNotes>> GetAllCaseNotes()
        {
            return await _caseNotesRepository.GetAllAsync();

        }


    }


}
