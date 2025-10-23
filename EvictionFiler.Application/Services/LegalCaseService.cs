using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;

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
using EvictionFiler.Application.DTOs.LegalCaseDto;

namespace EvictionFiler.Application.Services
{
    public class LegalCaseService : ILegalCaseService
    {
        private readonly ICasesRepository _repository;

        private readonly ILandLordRepository _landlordrepo;
        private readonly IBuildingRepository _buildingrepo;
        private readonly ITenantRepository _tenantRepo;
        private readonly IAdditionalOccupantsRepository _additionalOccupantsRepo;
        private readonly IUnitOfWork _unitOfWork;
        public LegalCaseService(ICasesRepository repository, ITenantRepository tenantRepo, ILandLordRepository landlordrepo, IBuildingRepository buildingrepo, IAdditionalOccupantsRepository additionalOccupantsRepo, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _tenantRepo = tenantRepo;
            _landlordrepo = landlordrepo;
            _buildingrepo = buildingrepo;
            _unitOfWork = unitOfWork;
            _additionalOccupantsRepo = additionalOccupantsRepo;

        }

        public async Task<Guid?> CreateCasesAsync(IntakeModel legalCase)
        {
            //// 1. Save Landlord
            //var landlord = new LandLord
            //{
            //    Id = Guid.NewGuid(),
            //    LandLordCode = await _landlordrepo.GenerateLandlordCodeAsync(),
            //    FirstName = legalCase.FullName,
            //    Phone = legalCase.Phone,
            //    Email = legalCase.Email,
            //    LandlordTypeId = legalCase.LandLordTypeId,
            //    CreatedBy = legalCase.CreatedBy,
            //    CreatedOn = DateTime.Now,


            //};
            //await _landlordrepo.AddAsync(landlord);
            //await _unitOfWork.SaveChangesAsync();

            //// 2. Save Building
            //var building = new Building
            //{
            //    Id = Guid.NewGuid(),
            //    BuildingCode = await _buildingrepo.GenerateBuildingCodeAsync(),
            //    MDRNumber = legalCase.Mdr,
            //    BuildingUnits = legalCase.Units,
            //    Address1 = legalCase.BuildingAddress,
            //    RegulationStatusId = legalCase.RegulationStatusId,
            //    CreatedBy = legalCase.CreatedBy,
            //    CreatedOn = DateTime.Now,
            //};
            //await _buildingrepo.AddAsync(building);
            //await _unitOfWork.SaveChangesAsync();

            //// 3. Save Tenant
            //var tenant = new Tenant
            //{
            //    Id = Guid.NewGuid(),
            //    TenantCode = await _tenantRepo.GenerateTenantCodeAsync(),
            //    FirstName = legalCase.FullName,
            //    UnitOrApartmentNumber = legalCase.UnitNumber,
            //    IsUnitIllegalId = legalCase.IsUnitIllegalId,

            //    TenantRecord = legalCase.TenantRecord,
            //    HasPossession = legalCase.HasPossession,
            //    OtherOccupants = legalCase.OtherOccupants,
            //    CreatedBy = legalCase.CreatedBy,
            //    CreatedOn = DateTime.Now,
            //};
            //await _tenantRepo.AddAsync(tenant);
            //await _unitOfWork.SaveChangesAsync();

            // 4. Save Legal Case with foreign keys
            var legalCases = new LegalCase
            {
                Id = Guid.NewGuid(),
                Casecode = await _repository.GenerateCaseCodeAsync(),
                ClientId = legalCase.ClientId,
                CaseTypeId = legalCase.CaseTypeId,
                IsERAPPaymentReceived = legalCase.IsERAPPaymentReceived,

                MonthlyRent = legalCase.MonthlyRent,
                TotalRentOwed = legalCase.TotalOwed,
                TenantShare = legalCase.TenantShare,
                RentDueEachMonthOrWeekId = legalCase.RentDueEachMonthOrWeekId,
                OralStart = legalCase.OralStart,
                OralEnd = legalCase.OralEnd,
                WrittenLease = legalCase.WrittenLease,
                DateTenantMoved = legalCase.DateTenantMoved,
                //CreatedBy = legalCase.CreatedBy,
                CreatedOn = DateTime.Now,
                TenancyTypeId = legalCase.TenancyTypeId,
                // Foreign keys
                LandLordId = legalCase.LandlordId,
                LandlordTypeId = legalCase.LandLordTypeId,
                CreatedBy = legalCase.CreatedBy,

                BuildingId = legalCase.BuildingId,
                TenantId = legalCase.TenantId,

                UnitOrApartmentNumber = legalCase.UnitOrApartmentNumber,
                LeaseEnd = legalCase.LeaseEnd,
                DateNoticeServed = legalCase.DateNoticeServed,
                ExpirationDate = legalCase.ExpirationDate,
                PredicateNotice = legalCase.PredicateNotice,
                SocialService = legalCase.SocialService,
                LastRentPaid = legalCase.LastRentPaid,
                Reference = legalCase.Reference,
                OralAgreeMent = legalCase.OralAgreeMent,
                GoodCauseApplies = legalCase.GoodCauseApplies,
                CalculatedNoticeLength = legalCase.CalculatedNoticeLength,
                CaseProgramId = legalCase.CaseProgramId,
            };

            var addedcase = await _repository.AddAsync(legalCases);
            var result = await _unitOfWork.SaveChangesAsync();

            if( result != null) return addedcase.Id;

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
        (Expression<Func<LegalCase, object>>)(c => c.Clients),
        c => c.Buildings,
        c => c.CaseType,
        c => c.LandLords,
        c => c.Tenants,
        c => c.RegulationStatus,
        c => c.TenancyType,
        c => c.RenewalStatus,
        c => c.ReasonHoldover,
        c => c.ClientRole,
        c => c.Buildings.State,
        c => c.Addoccupants,
        c => c.Buildings.Landlord.State,
        c => c.Buildings.Landlord.LandlordType
    )
    .FirstOrDefaultAsync();

                if (caseEntity == null)
                    return null;

                var intakeModel = new IntakeModel
                {
                    // for Case
                    Id = caseEntity.Id,
                    Casecode = caseEntity.Casecode,
                    ClientId = caseEntity.Clients.Id,
                    CaseTypeName = caseEntity.CaseType.Name,
                    //IsERAPPaymentReceived = caseEntity.IsERAPPaymentReceived,
                    CaseTypeId = caseEntity.CaseTypeId,

                    //OralStart = caseEntity.OralStart,
                    //OralEnd = caseEntity.OralEnd,
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

                    // Landlord
                    LandlordId = caseEntity.LandLordId,
                    landlordName = $"{caseEntity.LandLords.FirstName} {caseEntity.LandLords.LastName}",
                    ContactPersonName = caseEntity.LandLords.ContactPersonName,
                    LawFirm = caseEntity.LandLords.LawFirm,
                    AttorneyOfRecord = caseEntity.LandLords.AttorneyOfRecord,
                    LandlordAddress = caseEntity.LandLords.Address1,
                    //FullName = caseEntity.LandLords?.FirstName,
                    //Phone = caseEntity.LandLords?.Phone,
                    //Email = caseEntity.LandLords?.Email,
                    //LandLordTypeId = caseEntity.LandLords?.LandlordTypeId ?? Guid.Empty,

                    // Building
                    BuildingId = caseEntity.BuildingId,
                    Buildingcode = caseEntity.Buildings.BuildingCode,
                    Mdr = caseEntity.Buildings?.MDRNumber,
                    UnitOrApartmentNumber = caseEntity.Buildings.ApartmentCode,
                    //ApartmentNumber = caseEntity.Buildings.ApartmentCode,
                    Borough = caseEntity.Buildings?.City,
                    Units = caseEntity.Buildings?.BuildingUnits,
                    BuildingState = caseEntity.Buildings.State.Name,
                    BuildingAddress = caseEntity.Buildings?.Address1,
                    BuildingZip = caseEntity.Buildings.Zipcode,
                    RegulationStatusId = caseEntity.Buildings?.RegulationStatusId ?? Guid.Empty,
                    //RegulationStatusName = caseEntity.Buildings.RegulationStatus.Name,

                    // Tenant
                    TenantId = caseEntity.TenantId,
                    TenantName = $"{caseEntity.Tenants?.FirstName} {caseEntity.Tenants?.LastName}",
                    ApartmentNumber = caseEntity.Tenants?.UnitOrApartmentNumber,

                    WrittenLease = caseEntity.WrittenLease,
                    OralAgreeMent = caseEntity.OralAgreeMent,
                    CaseProgramId = caseEntity.CaseProgramId,
                    GoodCauseApplies = caseEntity.GoodCauseApplies,
                    DateTenantMoved = caseEntity.DateTenantMoved,
                    LeaseEnd = caseEntity.LeaseEnd,
                    TenancyTypeId = caseEntity.TenancyTypeId,
                    DateNoticeServed = caseEntity.DateNoticeServed,
                    CalculatedNoticeLength = caseEntity.CalculatedNoticeLength,
                    ExpirationDate = caseEntity.ExpirationDate,
                    PredicateNotice = caseEntity.PredicateNotice,
                    RentDueEachMonthOrWeekId = caseEntity.RentDueEachMonthOrWeekId,
                    MonthlyRent = caseEntity.MonthlyRent,
                    TotalOwed = caseEntity.TotalRentOwed,
                    TenantShare = caseEntity.TenantShare,
                    SocialService = caseEntity.SocialService,
                    LastRentPaid = caseEntity.LastRentPaid,
                    //IsUnitIllegalId = caseEntity.Tenants?.IsUnitIllegalId ?? Guid.Empty,
                    //TenantRecord = caseEntity.Tenants?.TenantRecord,
                    //HasPossession = caseEntity.Tenants?.HasPossession,
                    //OtherOccupants = caseEntity.Tenants?.OtherOccupants

                    CourtId = caseEntity.CourtId,
                    Court = caseEntity.Courts.Court,
                    CourtAddress = caseEntity.Courts.Address,
                    CourtConferenceId = caseEntity.Courts.ConferenceId,
                    CourtCallIn = caseEntity.Courts.CallIn,
                    CourtNotes = caseEntity.Courts.Notes,
                    CourtPart = caseEntity.Courts.Part,
                    CourtPhone = caseEntity.Courts.Phone,
                    CourtRoomNo = caseEntity.Courts.RoomNo,
                    CourtVirtualLink = caseEntity.Courts.VirtualLink,
                };

                return intakeModel;
            }
            catch(Exception ex)
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

                ClientId = legalcaseEntity.Clients.Id,
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
                        City = legalcaseEntity.Tenants.Building.City,
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
                        City = legalcaseEntity.Tenants.Building.Landlord.City,
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

                //var landlord = await _landlordrepo.GetAsync(existingCase.LandLordId);
                //var building = await _buildingrepo.GetAsync(existingCase.BuildingId);
                //var tenant = await _tenantRepo.GetAsync(existingCase.TenantId);

                existingCase.ClientId = legalCase.ClientId;
                existingCase.CaseTypeId = legalCase.CaseTypeId;
                existingCase.IsERAPPaymentReceived = legalCase.IsERAPPaymentReceived;

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
                existingCase.CaseProgramId = legalCase.CaseProgramId;

                existingCase.CourtId = legalCase.CourtId;

                var updated = _repository.UpdateAsync(existingCase);
                var result = await _unitOfWork.SaveChangesAsync();

                if (result > 0) return updated.Id;

                return null;
            }
            catch(Exception ex)
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
    }
}
