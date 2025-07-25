using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.TenantDto
{
    public class CreateToTenantDto
    {
		public string TenantCode { get; set; } = string.Empty;
		[Required(ErrorMessage = "FirstName is Required")]
		public string FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; }
		public string? Registration_No { get; set; }
		[Required(ErrorMessage = "Email is Required")]
		public string Email { get; set; } = string.Empty;
		public string? Phone { get; set; } = string.Empty;
		public string? Name_Relation { get; set; }
		public Guid?LanguageId { get; set; }
		public string? LanguageName { get; set; }
		[Required(ErrorMessage = "Address is Required")]
		public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public string ?City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		public string? StateName { get; set; }
		public string ?Zipcode { get; set; } = string.Empty;
		public DateOnly? DOB { get; set; }
		public double? Rent { get; set; }
		public string? SSN { get; set; }
		public string? Apt { get; set; }
		public string? Borough { get; set; }
		public bool? TenantRecord { get; set; }
		public bool? HasPossession { get; set; }
		public bool? HasRegulatedTenancy { get; set; }
		public bool? OtherOccupants { get; set; }
		public bool? HasPriorCase { get; set; }
		public Guid? BuildingId { get; set; }
		

	}
}
