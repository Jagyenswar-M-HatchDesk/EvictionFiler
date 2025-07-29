using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Domain.Entities
{
    public class Building : DeletableBaseEntity
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
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State ?State { get; set; }
		[MaxLength(20)]
		public string ?Zipcode { get; set; } = string.Empty;
	
		public Guid? LandlordId { get; set; }
		[ForeignKey("LandlordId")]
		public LandLord? Landlord { get; set; }

		public ICollection<Tenant>? Tenants { get; set; }
	}
}
