using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.DTOs.LegalCaseDto
{
	public class CreateToEditLegalCaseModel 
	{
		public Guid Id { get; set; }
		public Guid ClientId { get; set; }
		public Guid? BuildingId { get; set; }
		public Guid? LandLordId { get; set; }
		public Guid? TenantId { get; set; }
		public Guid? CaseTypeId { get; set; }

		public string? Casecode { get; set; }
		[Required(ErrorMessage = "Please select Reason Holdover.")]
		public Guid? ReasonHoldoverId { get; set; }
		public string? ReasonHoldoverName { get; set; }

	
		public Guid? IsUnitIllegalId { get; set; }
		public bool? TenantRecord { get; set; }
		public bool? RenewalOffer { get; set; }
		public bool? HasPossession { get; set; }
		public bool? OtherOccupants { get; set; }
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
		
		public Guid? TenancyTypeId { get; set; }

		
		public Guid? RegulationStatusId { get; set; }
		
		public Guid? LandlordTypeId { get; set; }
		public string? ReasonDescription { get; set; }

		public string? ExplainDescription { get; set; }

		public CreateToTenantDto ? tenants { get; set; }

		public string? Attrney { get; set; }
		[MaxLength(100)]
		public string? AttrneyContactInfo { get; set; }
		[MaxLength(50)]
		public string? Firm { get; set; }

	}
}
