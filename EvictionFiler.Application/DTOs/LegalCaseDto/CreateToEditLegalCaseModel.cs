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
		
		public string? Casecode { get; set; }
		[Required(ErrorMessage = "Please select Reason Holdover.")]
		public Guid? ReasonHoldoverId { get; set; }
		public string? ReasonHoldoverName { get; set; }

		[Required(ErrorMessage = "Please select UnitIllegal.")]
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
		[Required(ErrorMessage = "Please select Tenancy Type.")]
		public Guid? TenancyTypeId { get; set; }

		[Required(ErrorMessage = "Please select Regulation Type.")]
		public Guid? RegulationStatusId { get; set; }
		[Required(ErrorMessage = "Please select LandLord Type.")]
		public Guid? LandlordTypeId { get; set; }
		public string? ReasonDescription { get; set; }

		public string? ExplainDescription { get; set; }

		public CreateToTenantDto ? tenants { get; set; }
	
	
	}
}
