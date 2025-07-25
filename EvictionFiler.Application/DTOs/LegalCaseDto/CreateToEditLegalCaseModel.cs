using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.LegalCaseDto
{
	public class CreateToEditLegalCaseModel : IValidatableObject
	{
		public Guid Id { get; set; }
		public Guid? ClientId { get; set; }
		public Guid? ApartmentId { get; set; }
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
