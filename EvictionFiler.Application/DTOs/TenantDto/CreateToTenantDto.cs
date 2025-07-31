using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;

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
		public string? SSN { get; set; }
		public string? Borough { get; set; }
		public bool? TenantRecord { get; set; }
		public bool ?HasPossession { get; set; }
		public bool? HasRegulatedTenancy { get; set; }
		public bool? OtherOccupants { get; set; }
		public bool? HasPriorCase { get; set; }
		public Guid? BuildingId { get; set; }

		//Rent Details
		public bool? RenewalOffer { get; set; }
		public string? RentDueEachMonthOrWeek { get; set; }
		public double? MonthlyRent { get; set; }
		public double? TenantShare { get; set; }
		public string? SocialServices { get; set; }
		public string? LastMonthWeekRentPaid { get; set; }
		public double? TotalRentOwed { get; set; }
		public bool? IsERAP { get; set; }
		public bool IsERAPPaymentReceived { get; set; }
		public DateOnly? ERAPPaymentReceivedDate { get; set; }
		public string? UnitOrApartmentNumber { get; set; }

		public Guid? IsUnitIllegalId { get; set; }
		public string? IsUnitIllegalName { get; set; }
		public Guid? TenancyTypeId { get; set; }
		public string? TenancyTypeName { get; set; }
		public string ?TenancyTypeDescription { get; set; }

		public EditToBuildingDto? Building { get; set; }
		public EditToLandlordDto? Landlord { get; set; }

		public List<Guid> SelectedIllegalUnits { get; set; } = new();

	}
}
