using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Application.DTOs.LandLordDto
{
    public class CreateToLandLordDto : DeletableBaseEntity
    {
		public string LandLordCode { get; set; } = string.Empty;
		[Required(ErrorMessage = "First Name is Required")]
		public string FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		//[Required(ErrorMessage = "Type Owner is Required")]
		public Guid? TypeOwnerId { get; set; }
		public string? TypeOwnerName { get; set; }
        public string? Phone { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string? EINorSSN { get; set; } = string.Empty;
		[Required(ErrorMessage = "Contact Person is Required")]

		public string? ContactPersonName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is Required")]

        public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public Guid? CityId {  get; set; }
		public string? CityName { get; set; } 
		public Guid? StateId { get; set; }
		public string? StateName { get; set; }
		public string Zipcode { get; set; } = string.Empty;
		public Guid? ClientId { get; set; }
        public string AttorneyOfRecord { get; set; } = string.Empty;
        public string? LawFirm { get; set; } = string.Empty;
        public DateOnly DateOfRefreeDeed { get; set; }  = DateOnly.FromDateTime(DateTime.Today);
		public Guid? LandlordTypeId { get; set; }
		public string? LandlordTypeName { get; set; }
		public string ? OtherLandlordTypeDescription { get; set; }
		public List<CreateToBuildingDto>? Buildings { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
