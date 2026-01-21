using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EvictionFiler.Domain.Entities
{
	public class LegalCase : DeletableBaseEntity
	{
		[Required]
		public string Casecode { get; set; } = string.Empty;
		public Guid? ClientId { get; set; }
		public Guid? BuildingId { get; set; }
		public Guid? LandLordId { get; set; }
		public Guid? TenantId { get; set; }


		[ForeignKey("ClientId")]
		public virtual Client? Clients { get; set; }

		[ForeignKey("BuildingId")]
		public virtual Building? Buildings { get; set; }

		[ForeignKey("LandLordId")]
		public virtual LandLord? LandLords { get; set; }

		[ForeignKey("TenantId")]
		public virtual Tenant? Tenants { get; set; }
		[MaxLength(100)]
		public string? CaseName { get; set; }
		public Guid? ClientRoleId { get; set; }
		[ForeignKey("ClientRoleId")]
		public ClientRole? ClientRole { get; set; }
		[MaxLength(100)]
		public string? LegalRepresentative { get; set; }
		public Guid? CaseTypeId { get; set; }
		[ForeignKey("CaseTypeId")]
		public CaseType? CaseType { get; set; }
		public Guid? CaseSubTypeId { get; set; }
		[ForeignKey("CaseSubTypeId")]
		public CaseSubType? CaseSubType { get; set; }

		public Guid? ReasonHoldoverId { get; set; }
		[ForeignKey("ReasonHoldoverId")]
		public ReasonHoldover? ReasonHoldover { get; set; }

		public Guid? IsUnitIllegalId { get; set; }
		[ForeignKey("IsUnitIllegalId")]
		public IsUnitIllegal? IsUnitIllegal { get; set; }

		public Guid? CourtTypeId { get; set; }
		[ForeignKey("CourtTypeId")]
		public CourtType? CourtTypes { get; set; }

		public bool? TenantRecord { get; set; }
		public bool? RenewalOffer { get; set; }
		public bool? HasPossession { get; set; }

		public bool? OtherOccupants { get; set; }

		public Guid? RentDueEachMonthOrWeekId { get; set; }
		[ForeignKey("RentDueEachMonthOrWeekId")]
		public DateRent? RentDueEachMonthOrWeek { get; set; }

		public double? MonthlyRent { get; set; }
		public double? LastPayment { get; set; }
		public double? TenantShare { get; set; }

		[MaxLength(250)]
		public string? SocialServices { get; set; }

		[MaxLength(50)]
		public string? LastMonthWeekRentPaid { get; set; }
		public string? DocketNo { get; set; }
		public double? TotalRentOwed { get; set; }
		public bool? IsERAPPaymentReceived { get; set; }
		public DateOnly? ERAPPaymentReceivedDate { get; set; }
		public Guid? TenancyTypeId { get; set; }
		[ForeignKey("TenancyTypeId")]
		public TenancyType? TenancyType { get; set; }
		public Guid? RegulationStatusId { get; set; }
		[ForeignKey("RegulationStatusId")]
		public RegulationStatus? RegulationStatus { get; set; }

		public Guid? LandlordTypeId { get; set; }
		[ForeignKey("LandlordTypeId")]
		public LandlordType? LandlordType { get; set; }
		public DateOnly DateOfRefreeDeed { get; set; }
		public string? ReasonDescription { get; set; }

		public string? ExplainDescription { get; set; }
		[MaxLength(100)]
		public string? Attrney { get; set; }
		[MaxLength(100)]
		public string? AttrneyContactInfo { get; set; }


		[MaxLength(50)]
		public string? Firm { get; set; }

		public Guid? SubCaseTypeId { get; set; }
		[ForeignKey("SubCaseTypeId")]
		public SubCaseType? SubCaseTypes { get; set; }


		public string? OtherPropertiesBuildingId { get; set; }

		public bool? tenantReceive { get; set; }
		public string? ExplainTenancyReceiveDescription { get; set; }
		public string? Assistance { get; set; }

		//new Property add 
		public bool? WrittenLease { get; set; }
		public bool? NextBussinessday { get; set; }
		public bool? leasedAttached { get; set; }
		public bool? ledgerAttached { get; set; }
		public bool? NoticeproofAttached { get; set; }
		public bool? RegistrationRentAttached { get; set; }
		public bool? GoodCauseExempt { get; set; }
		public bool? CourtDraftNop { get; set; }
		public bool WarrantRequested { get; set; }
		public DateOnly? DateTenantMoved { get; set; }

		public DateOnly? OralStart { get; set; }
		public DateOnly? LeaseStart { get; set; }
		public DateOnly? PlannedServiceDate { get; set; }

		public DateOnly? OralEnd { get; set; }
		public DateOnly? LastPaymentDate { get; set; }
		public Guid? RenewalStatusId { get; set; }
		[ForeignKey("RenewalStatusId")]
		public RenewalStatus? RenewalStatus { get; set; }
		public ICollection<AdditionalOccupants>? Addoccupants { get; set; }


		[NotMapped]
		public string? CreatedByName { get; set; }

		public string? UnitOrApartmentNumber { get; set; }
		public string? DeemedService { get; set; }
		public string? Expiry { get; set; }
		public string? AdditionalComments { get; set; }
		public string? AffidavitofService { get; set; }


		public DateOnly? LeaseEnd { get; set; }
		public DateOnly? DateNoticeServed { get; set; }
		public DateOnly? ExpirationDate { get; set; }
		public DateOnly? PreferedFilingDate { get; set; }
		public string? PredicateNotice { get; set; }
		public string? SocialService { get; set; }
		public string? LastRentPaid { get; set; }
		public string? Reference { get; set; }

		public bool? OralAgreeMent { get; set; }
		public bool? GoodCauseApplies { get; set; } = null;

		public int? CalculatedNoticeLength { get; set; }
		public Guid? CaseProgramId { get; set; }

		public Guid? CourtId { get; set; }
		[ForeignKey("CourtId")]
		public Courts? Courts { get; set; }
		public Guid? FilingMethodId { get; set; }
		[ForeignKey("FilingMethodId")]
		public FilingMethod? FilingMethods { get; set; }

		public decimal? BillAmount { get; set; }

		[MaxLength(100)]
		public string? AttrneyEmail { get; set; }

		public ICollection<CaseTypeHPD> CaseTypeHPDs { get; set; } = new List<CaseTypeHPD>();
		public ICollection<CaseTypePerdiem> CaseTypePerDiems { get; set; } = new List<CaseTypePerdiem>();
		public ICollection<AppearanceType> AppearanceType { get; set; } = new List<AppearanceType>();
		public ICollection<AppearanceTypePerDiem> AppearanceTypePerDiem { get; set; } = new List<AppearanceTypePerDiem>();
		public ICollection<ReliefRespondentType> ReliefRespondentType { get; set; } = new List<ReliefRespondentType>();
		public ICollection<ReliefPetitionerType> ReliefPetitionerType { get; set; } = new List<ReliefPetitionerType>();
		public ICollection<ArrearLedger> ArrearLedgers { get; set; } = new List<ArrearLedger>();

		public Guid? NoticeId { get; set; }
		[ForeignKey("NoticeId")]
		public FormTypes? FormTypes { get; set; }
		public Guid? ServiceMethodId { get; set; }
		[ForeignKey("ServiceMethodId")]
		public ServiceMethod? ServiceMethods { get; set; }

		public Guid? PartyRepresentPerDiemId { get; set; }

		[ForeignKey("PartyRepresentPerDiemId")]
		public PartyRepresentPerDiem? PartyRepresentPerDiems { get; set; }

		public Guid? PartyRepresentId { get; set; }
		[ForeignKey("PartyRepresentId")]
		public PartyRepresent? PartyRepresents { get; set; }

		public Guid? BilingTypeId { get; set; }
		[ForeignKey("BilingTypeId")]
		public BilingType? BilingType { get; set; }
		public Guid? PaymentMethodId { get; set; }
		[ForeignKey("PaymentMethodId")]
		public PaymentMethod? PaymentMethod { get; set; }

		public Guid? RatetypeId { get; set; }
		public decimal? Flatdescription { get; set; }
		public decimal? Hourlydescription { get; set; }
		[ForeignKey("RatetypeId")]
		public RateType? RateType { get; set; }
		public string? TravelExpense { get; set; }
		public string? PerDiemAttorneyname { get; set; }
		public string? PerDiemSignature { get; set; }
		public DateOnly? PerDiemDate { get; set; }
		public ICollection<HarassmentType> HarassmentTypse { get; set; } = new List<HarassmentType>();
		public ICollection<RemainderCenter> RemainderCenters { get; set; } = new List<RemainderCenter>();

		public ICollection<DefenseType> DefenseTypse { get; set; } = new List<DefenseType>();
		public ICollection<DocumentTypePerDiem> DocumentIntructionsTypse { get; set; } = new List<DocumentTypePerDiem>();
		public ICollection<ReportingTypePerDiem> ReportingTypePerDiems { get; set; } = new List<ReportingTypePerDiem>();


		public Guid? CourtLocationId { get; set; }
		[ForeignKey("CourtLocationId")]
		public Courts? CourtLocation { get; set; }
		public Guid? CourtPartId { get; set; }
		[ForeignKey("CourtPartId")]
		public CourtPart? CourtPart { get; set; }

		public Guid? MarshalId { get; set; }
		[ForeignKey("MarshalId")]
		public Marshal? Marshal { get; set; }
		public string? County { get; set; }
		public string? Index { get; set; }
		public string? CourtRoom { get; set; }
		public string? OpposingCounsel { get; set; }
		public string? ManagingAgent { get; set; }

		public string? Partynames { get; set; }
		public string? ReliefActionRequested { get; set; }
		public string? CaseBackground { get; set; }
		public string? SpecialInstruction { get; set; }
		public DateOnly? AppearanceDate { get; set; }

		public string? InvoiceTo { get; set; }
		public string? TenantName { get; set; }
		public TimeOnly? AppearanceTime { get; set; }

		public string Notes { get; set; } = string.Empty;

		public Guid? ExemptionBasisId { get; set; }
		[ForeignKey("ExemptionBasisId")]
		public ExemptionBasic? ExemptionBasis { get; set; }

		public Guid? ExemptionReasonId { get; set; }
		[ForeignKey("ExemptionReasonId")]
		public ExemptionReason? ExemptionReason { get; set; }

		public Guid? TenancyTypeForBuildingId { get; set; }
		[ForeignKey("TenancyTypeForBuildingId")]
		public TenancyTypeForBuilding? TenancyTypeForBuilding { get; set; }
		public bool? OwnerOccupied { get; set; }

		public bool? PrimaryResidence { get; set; }

		public bool? GoodCause { get; set; }

		public string? RentRegulationDescription { get; set; }

        public string? OppAttorneyname { get; set; }
        public string? OppAttorneyFirm { get; set; }
        public string? OppAttorneyEmail { get; set; }
        public string? OppAttorneyPhone { get; set; }
        public string? Aps_Agl { get; set; }
    }
}
