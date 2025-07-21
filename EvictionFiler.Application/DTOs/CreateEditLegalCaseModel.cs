using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs
{
	public class CreateEditLegalCaseModel : IValidatableObject
	{
		public Guid Id { get; set; }
		public Guid? ClientId { get; set; }
		public Guid? ApartmentId { get; set; }
		public Guid? LandLordId { get; set; }
		public Guid? TenantId { get; set; }
		public string? CaseName { get; set; }
		public string? ClientRole { get; set; }
		public string? LegalRepresentative { get; set; }
		public string? Casecode { get; set; }

		//section4
		public string? Company { get; set; }
		public string? Contact { get; set; }
		public string? PhoneorEmail { get; set; }
		public string? MDRNo { get; set; }
		public string? ResidentalUnits { get; set; }
		public string? CommercialUnits { get; set; }
		public bool? AllUnitsRehistered { get; set; }
		public bool? HPDViolation { get; set; }

		//section5
		public string? Address { get; set; }
		public string? AptNo { get; set; }
		public string? Borough { get; set; }
		public string? ZIP { get; set; }
		public string? Class { get; set; }
		public string? YearBuilt { get; set; }
		public bool? HeatorHotWater { get; set; }
		public bool? RentStablized { get; set; }

		//section6
		public bool? SeekinEviction { get; set; }
		public bool? ExemptUnit { get; set; }
		public bool? RentIncreases { get; set; }
		public int? Monthsunpaid { get; set; }
		public string? OthersGrounds { get; set; }

		[Required(ErrorMessage = "Case Type is required")]
		public Guid? CaseTypeId { get; set; }
		public string? CaseTypeName { get; set; }

		// Removed Required from here
		public Guid? CaseSubTypeId { get; set; }

		public string? CaseSubTypeName { get; set; }

		[Required(ErrorMessage = "Attorney is required")]
		public string Attrney { get; set; }

		[Required(ErrorMessage = "Contact Info is required")]
		public string AttrneyContactInfo { get; set; }

		[Required(ErrorMessage = "Firm is required")]
		public string Firm { get; set; }

		// 👇 Add this property to receive selected case type name from the component
		public string SelectedCaseTypeName { get; set; }

		// ✅ IValidatableObject method
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (SelectedCaseTypeName == "Holdover" && CaseSubTypeId == null)
			{
				yield return new ValidationResult("Case Sub Type is required for Holdover case type.", new[] { nameof(CaseSubTypeId) });
			}
		}
	}
}
