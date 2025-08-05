
using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.TenantDto;


namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class CreateToBuildingDto
	{
		
		public string BuildingCode { get; set; } = string.Empty;
		[Required(ErrorMessage = "Code is Required")]
		public string? ApartmentCode { get; set; }
		public string? MDRNumber { get; set; }
		public string? BuildingUnits { get; set; }
		[Required(ErrorMessage = "Premise Type is Required")]
		public Guid? PremiseTypeId { get; set; }
		public string? PremiseTypeName { get; set; }

		[Required(ErrorMessage = "RegulationStatus is Required")]
		public Guid? RegulationStatusId { get; set; }
		public string? RegulationStatusName { get; set; }
		public string? PetitionerInterest { get; set; }
		
		public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		public string? StateName { get; set; }
		public string ?Zipcode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Select LandLord")]
        public Guid? LandlordId { get; set; }

		public List<CreateToTenantDto>? Tenants { get; set; }

	}
}
