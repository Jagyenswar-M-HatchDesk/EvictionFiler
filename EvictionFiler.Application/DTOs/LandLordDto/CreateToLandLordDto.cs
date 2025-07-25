using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.ApartmentDto;

namespace EvictionFiler.Application.DTOs.LandLordDto
{
    public class CreateToLandLordDto
    {
		public string LandLordCode { get; set; } = string.Empty;
		[Required(ErrorMessage = "First Name is Required")]
		public string FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Type Owner is Required")]
		public Guid? TypeOwnerId { get; set; }
		public string? TypeOwnerName { get; set; }
		public string? Phone { get; set; } = string.Empty;
		[Required(ErrorMessage = "	Email is Required")]
		public string Email { get; set; } = string.Empty;
		public string? EINorSSN { get; set; } = string.Empty;
		public string? ContactPersonName { get; set; } = string.Empty;
		[Required(ErrorMessage = "	Address1 is Required")]
		public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		public string? StateName { get; set; }
		public string Zipcode { get; set; } = string.Empty;
		public Guid? ClientId { get; set; }
		public string ? OtherLandlordTypeDescription { get; set; }
		public List<CreateToBuildingDto>? Buildings { get; set; }
	}
}
