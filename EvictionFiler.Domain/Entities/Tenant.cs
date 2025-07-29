using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Domain.Entities
{
	public class Tenant : DeletableBaseEntity
	{
		[Required]
		public string TenantCode { get; set; } = string.Empty;
		[MaxLength(100)]
		public string FirstName { get; set; } = string.Empty;
		[MaxLength(100)]
		public string? LastName { get; set; }
		[MaxLength(50)]
		public string? Registration_No { get; set; }
		[MaxLength(250)]
		public string Email { get; set; } = string.Empty;
		[MaxLength(50)]
		public string? Phone { get; set; } = string.Empty;
		[MaxLength(100)]
		public string? Name_Relation { get; set; } 
		public Guid? LanguageId { get; set; }
		[ForeignKey("LanguageId")]
		public Language? Language { get; set; }
		[MaxLength(500)]
		public string Address1 { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Address2 { get; set; }
		[MaxLength(100)]
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State? State { get; set; }
		public string? Zipcode { get; set; } = string.Empty;

		public Guid? TenancyTypeId { get; set; }
		[ForeignKey("TenancyTypeId")]
		public TenancyType? TenancyType { get; set; }
		[MaxLength(50)]
		public string? SSN { get; set; }
		[MaxLength(50)]
		public string? Borough { get; set; } 
		public bool? TenantRecord { get; set; }
		public bool? RenewalOffer { get; set; }
		public bool? HasPossession { get; set; }
		public bool? HasRegulatedTenancy { get; set; }
		public bool? OtherOccupants { get; set; }
		public bool? HasPriorCase { get; set; }
		public Guid? BuildinId { get; set; }
		[ForeignKey("BuildinId")]
		public Building? Building { get; set; }

		//Rent Details
		[MaxLength(50)]
		public string? RentDueEachMonthOrWeek { get; set; }
		public double? MonthlyRent { get; set; }
		public double? TenantShare { get; set; }

		[MaxLength(250)]
		public string? SocialServices { get; set; }

		[MaxLength(50)]
		public string? LastMonthWeekRentPaid { get; set; }
		public double? TotalRentOwed { get; set; }
		public bool? IsERAPPaymentReceived { get; set; }
		public DateOnly? ERAPPaymentReceivedDate { get; set; }
		public string? UnitOrApartmentNumber { get; set; }

		public Guid? IsUnitIllegalId { get; set; }
		[ForeignKey("IsUnitIllegalId")]
		public IsUnitIllegal? IsUnitIllegal { get; set; }

	}
}
