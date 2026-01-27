using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Domain.Entities
{
    public class LandLord : DeletableBaseEntity
	{
		[Required]
		public string LandLordCode { get; set; } = string.Empty;
		[MaxLength(100)]
		public string FirstName { get; set; } = string.Empty;
		[MaxLength(100)]
		public string? LastName { get; set; } = string.Empty;
		public Guid? TypeOfOwnerId { get; set; }
		[ForeignKey("TypeOfOwnerId")]
		public TypeOfOwner? TypeOfOwner { get; set; }
		[MaxLength(50)]
		public string? Phone { get; set; } = string.Empty;
		[MaxLength(250)]
		public string Email { get; set; } = string.Empty;
		[MaxLength(50)]
		public string? EINorSSN { get; set; } = string.Empty;
		[MaxLength(50)]
		public string? ContactPersonName { get; set; } = string.Empty;
		[MaxLength(500)]
		public string Address1 { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Address2 { get; set; }

		public Guid? CityId { get; set; }
		[ForeignKey("CityId")]
		public City? City {  get; set; }

		//public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State? State { get; set; }
		[MaxLength(50)]
		public string Zipcode { get; set; } = string.Empty;

		public DateOnly DateOfRefreeDeed { get; set; }
		public Guid? LandlordTypeId { get; set; }
		[ForeignKey("LandlordTypeId")]
		public LandlordType? LandlordType { get; set; }
		public Guid? ClientId { get; set; }
		[ForeignKey("ClientId")]
		public Client? Client { get; set; } 

		public ICollection<Building>? Buildings { get; set; }
        public string AttorneyOfRecord { get; set; } = string.Empty;
        public string? LawFirm { get; set; } = string.Empty;

    }
}
