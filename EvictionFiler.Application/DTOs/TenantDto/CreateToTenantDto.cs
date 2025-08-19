using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.OccupantDto;

namespace EvictionFiler.Application.DTOs.TenantDto
{
    public class CreateToTenantDto
    {
		public string TenantCode { get; set; } = string.Empty;
		[Required(ErrorMessage = "First Name is Required")]
		public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last Name is Required")]
        public string? LastName { get; set; }
	
		public string Email { get; set; } = string.Empty;
		public string? Phone { get; set; } = string.Empty;
		public string? AdditionalTenant { get; set; }
     
        public Guid? LanguageId { get; set; }
		public string? LanguageName { get; set; }
		public string? SSN { get; set; }

		public bool? TenantRecord { get; set; }
		public bool ?HasPossession { get; set; }
		public bool? HasRegulatedTenancy { get; set; }
		public bool? OtherOccupants { get; set; }
		public bool? HasPriorCase { get; set; }
        [Required(ErrorMessage = "Select Building")]
        public Guid? BuildingId { get; set; }

		//Rent Details
		public bool? RenewalOffer { get; set; }
        [Required(ErrorMessage = "Date Rent (M/W) is Required")]
        public Guid? RentDueEachMonthOrWeekId { get; set; }

        public string? RentDueEachMonthOrWeekName { get; set; }
        [Required(ErrorMessage = "Monthly Rent is Required")]
        public double? MonthlyRent { get; set; }
		public double? TenantShare { get; set; }
		public string? SocialServices { get; set; }
		public string? LastMonthWeekRentPaid { get; set; }
		public double? TotalRentOwed { get; set; }
		public bool? IsERAP { get; set; }
		public bool IsERAPPaymentReceived { get; set; }
		public DateOnly? ERAPPaymentReceivedDate { get; set; }
        [Required(ErrorMessage = "Unit/ApartmentNumber is Required")]
        public string? UnitOrApartmentNumber { get; set; }
		[Required(ErrorMessage = "IsUnitIllegal is Required")]
		public Guid? IsUnitIllegalId { get; set; }
		public string? IsUnitIllegalName { get; set; }
		[Required(ErrorMessage = "Tenancy Type is Required")]
		public Guid? TenancyTypeId { get; set; }

		public Guid? AdditialTenantsId { get; set; }
		public string? TenancyTypeName { get; set; }
		public string ?TenancyTypeDescription { get; set; }

		public List<AddtionalTenantDto>? AdditioalTenants { get; set; }
		public EditToBuildingDto? Building { get; set; }
		public EditToLandlordDto? Landlord { get; set; }
        public DateOnly? MoveInDate { get; set; }
        public string? CompletedAddress { get; set; }

    }
}
