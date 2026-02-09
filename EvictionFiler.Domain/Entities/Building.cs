using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Domain.Entities
{
    public class Building : DeletableGuidEntity
    {
		[Required]
		public string BuildingCode { get; set; } = string.Empty;
		[MaxLength(50)]
		public string? ApartmentCode { get; set; }
		[MaxLength(25)]
		public string? MDRNumber { get; set; }
		[MaxLength(50)]
		public string? BuildingUnits { get; set; }
		public Guid? PremiseTypeId { get; set; }
		[ForeignKey("PremiseTypeId")]
		public PremiseType ?PremiseType { get; set; }
		public Guid? RegulationStatusId { get; set; }
		[ForeignKey("RegulationStatusId")]
		public RegulationStatus ?RegulationStatus { get; set; }
		[MaxLength(250)]
		public string? PetitionerInterest { get; set; }
		[Required]
		[MaxLength(500)]
		public string Address1 { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Address2 { get; set; }
		public string? ManagingAgent { get; set; }
        public Guid? CityId { get; set; }
        [ForeignKey("CityId")]
        public City? Cities { get; set; }
        public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State ?State { get; set; }
		[MaxLength(20)]
		public string ?Zipcode { get; set; } = string.Empty;
	
		public Guid? LandlordId { get; set; }
		[ForeignKey("LandlordId")]
		public LandLord? Landlord { get; set; }

        public Guid? RegistrationStatusId { get; set; }


        [ForeignKey("RegistrationStatusId")]
        public Registrationstatus? RegistrationStatus { get; set; }

        public Guid? BuildingTypeId { get; set; }
        [ForeignKey("BuildingTypeId")]
        public BuildingType? BuildingType { get; set; }

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
        public string? RentRentRegulationOther { get; set; }
        public string? ExemptionBasisOther { get; set; }

        public ICollection<Tenant>? Tenants { get; set; }
	}
}
