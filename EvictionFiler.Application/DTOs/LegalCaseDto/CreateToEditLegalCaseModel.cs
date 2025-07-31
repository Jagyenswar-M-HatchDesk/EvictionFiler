using System.ComponentModel.DataAnnotations;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.DTOs.LegalCaseDto
{
	public class CreateToEditLegalCaseModel : IValidatableObject
	{
		public Guid Id { get; set; }
		public Guid ClientId { get; set; }
		public Guid? BuildingId { get; set; }
		public Guid? LandLordId { get; set; }
		public Guid? TenantId { get; set; }
		public string? CaseName { get; set; }
		[Required(ErrorMessage = "Case role is required")]
		public Guid? ClientRoleId { get; set; }
		public string? ClientRoleName { get; set; }
		public string? LegalRepresentative { get; set; }
		public string? Casecode { get; set; }

		[Required(ErrorMessage = "Case Type is required")]
		public Guid? CaseTypeId { get; set; }
		public string? CaseTypeName { get; set; }

		public Guid? CaseSubTypeId { get; set; }
		public string? CaseSubTypeName { get; set; }

		[Required(ErrorMessage = "Attorney is required")]
		public string Attrney { get; set; } = string.Empty;

		[Required(ErrorMessage = "Contact Info is required")]
		public string AttrneyContactInfo { get; set; } = string.Empty;

		[Required(ErrorMessage = "Firm is required")]
		public string Firm { get; set; } = string.Empty;

		public Guid? ReasonHoldoverId { get; set; }
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
		public string?SelectedCaseTypeName { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (SelectedCaseTypeName == "Holdover" && CaseSubTypeId == null)
			{
				yield return new ValidationResult("Case Sub Type is required for Holdover case type.", new[] { nameof(CaseSubTypeId) });
			}
		}
	}
}
