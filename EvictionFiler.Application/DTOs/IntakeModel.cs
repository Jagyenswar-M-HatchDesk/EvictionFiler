using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs
{
    public class IntakeModel : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "Client is required")]
        public Guid? ClientId { get; set; }
        public Guid? CourtId { get; set; }

        public string Selectedclient { get; set; }
        public string Status { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string Casecode { get; set; }
        public string Buildingcode { get; set; }
        public string FullName { get; set; }

        public Guid? LandlordId { get; set; }
        public string LandlordAddress { get; set; } = string.Empty;

        public string landlordName { get; set; }
        public string AttorneyOfRecord { get; set; } = string.Empty;
        public string? LawFirm { get; set; } = string.Empty;
        public string? ContactPersonName { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid? LandLordTypeId { get; set; }
        public string LandLordTypeName { get; set; }

        public string Mdr { get; set; }
        public string? BuildingZip { get; set; }
        public string? Units { get; set; }
        public string? UnitOrApartmentNumber { get; set; }
        public string? ApartmentNumber { get; set; }

        public Guid? BuildingId { get; set; }
        public Guid? BuildingStateId { get; set; }
        public string? BuildingState { get; set; }
        public string BuildingAddress { get; set; }
        public Guid? RegulationStatusId { get; set; }
        public string RegulationStatusName { get; set; }

        public string TenantName { get; set; }
        public string UnitNumber { get; set; }
        public bool? TenantRecord { get; set; }
        public bool? HasPossession { get; set; }
        public bool? OtherOccupants { get; set; }
        public Guid? IsUnitIllegalId { get; set; }
        public string? IsUnitIllegalName { get; set; }

        public Guid? TenancyTypeId { get; set; }

        public string? TenancyTypeName { get; set; }
        public bool? WrittenLease { get; set; }
        public DateOnly? LeaseEnd { get; set; }
        public DateOnly? DateNoticeServed { get; set; }
        public bool? IsERAPPaymentReceived { get; set; }
        public DateOnly? DateTenantMoved { get; set; }
        public Guid? RentDueEachMonthOrWeekId { get; set; }
        public Guid? TenantId { get; set; }
        public double? TenantShare { get; set; }
        public DateOnly? OralStart { get; set; }

        public DateOnly? OralEnd { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string? PredicateNotice { get; set; }
        public string? SocialService { get; set; }
        public string? LastRentPaid { get; set; }
        public string? Reference { get; set; }
        public string? Borough { get; set; }

        public bool? OralAgreeMent { get; set; }
        public bool? GoodCauseApplies { get; set; } = false;

        public int? CalculatedNoticeLength { get; set; }
        public double? MonthlyRent { get; set; }
        public double? TotalOwed { get; set; }
        public string Erap { get; set; } = "No";

        //[Required(ErrorMessage = "Type is required")]
        public Guid? CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public Guid? CaseProgramId { get; set; }

        // FOR Client 
        public string ClientCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }

        public string? ClientEmail { get; set; } = string.Empty;

        public Guid? ClientTypeId { get; set; }
        public string? Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public Guid? StateId { get; set; }
        public string? StateName { get; set; }
        public string? ZipCode { get; set; } = string.Empty;
        public string? ClientPhone { get; set; }

        public string Court { get; set; } = string.Empty;
        
        public string CourtAddress { get; set; } = string.Empty;
        public string CourtPhone { get; set; } = string.Empty;

        public string CourtNotes { get; set; } = string.Empty;
        public string CourtPart { get; set; } = string.Empty;
        public string CourtRoomNo { get; set; } = string.Empty;
        public string CourtVirtualLink { get; set; } = string.Empty;
        public string CourtCallIn { get; set; } = string.Empty;
        public string CourtConferenceId { get; set; } = string.Empty;
        public string Judge { get; set; } = string.Empty;
        public decimal? BillAmount { get; set; }

        public string? CourtLocation { get; set; }

        public string? County { get; set; }
        public string? Index { get; set; }
        public string? CourtRoom { get; set; }
        public string? OpposingCounsel { get; set; }
        public string? ManagingAgent { get; set; }
        public DateOnly? AppearanceDate { get; set; }

        public string? InvoiceTo { get; set; }
        public TimeOnly? AppearanceTime { get; set; }
        public Guid? HarassmentTypeId { get; set; }
        public Guid? DefenseTypeId { get; set; }
        public string? AttrneyEmail { get; set; }

        public string? Attrney { get; set; }
       
        public string? AttrneyContactInfo { get; set; }

        public Guid? CaseTypeHPDId { get; set; }
        public Guid? CaseTypePerDiemId { get; set; }
       

        public CaseTypeHPD? CaseTypeHPDs { get; set; }
        public CaseTypePerdiem? CaseTypePerdiems { get; set; }
        public List<Guid> SelectedCaseTypeHPDIds { get; set; } = new List<Guid>();
        public List<Guid> SelectedCaseTypePerDiemIds { get; set; } = new List<Guid>();

        public List<Guid> SelectedAppearanceTypeIds { get; set; } = new List<Guid>();
        public List<Guid> SelectedAppearanceTypePerDiemIds { get; set; } = new List<Guid>();
        public List<Guid> SelectedDocumentInstructionPerDiemIds { get; set; } = new List<Guid>();
        public List<Guid> SelectedReportingRequirementPerDiemIds { get; set; } = new List<Guid>();
        public List<Guid> SelectedReliefRespondentTypeIds { get; set; } = new List<Guid>();
        public List<Guid> SelectedReliefPetitionerTypeIds { get; set; } = new List<Guid>();
        public List<Guid> SelectedHarassmentTypeIds { get; set; } = new List<Guid>();

        public List<Guid> SelectedDefenseTypeIds { get; set; } = new List<Guid>();
        public Guid? PartyRepresentId { get; set; }
        public Guid? PartyRepresentPerDiemId { get; set; }

        public Guid? BilingTypeId { get; set; }

        public Guid? BuildingTypeId { get; set; }
        public Guid? RegistrationStatusTypeId { get; set; }

        public Guid? PaymentMethodId { get; set; }
        public string? TravelExpense { get; set; }
        public BilingType? BilingType { get; set; }
        public Guid? AppearanceTypeId { get; set; }

        public Guid? AppearanceTypePerdiemId { get; set; }

        public AppearanceType? AppearanceType { get; set; }
        public AppearanceTypePerDiem? AppearanceTypePerDiem { get; set; }

        public Guid? ReliefRespondentTypeId { get; set; }
    
        public ReliefRespondentType? ReliefRespondentType { get; set; }
        public Guid? ReliefPetitionerTypeId { get; set; }
     
        public ReliefPetitionerType? ReliefPetitionerType { get; set; }
        public string? Partynames { get; set; }
        public string? CaseBackground { get; set; }
        public decimal? BilingTypeInputValue { get; set; }
        public string? PerDiemAttorneyname { get; set; }
        public string? PerDiemSignature { get; set; }
        public DateOnly? PerDiemDate { get; set; }
       
        public string? SpecialInstruction { get; set; }


    }
}
