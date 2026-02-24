using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.ArrearLedgerDtos;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Domain.Entities.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.TenantDto
{
    public class CreateToTenantDto : DeletableBaseEntity
    {
		public string TenantCode { get; set; } = string.Empty;
		[Required(ErrorMessage = "First Name is Required")]
		public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last Name is Required")]
        public string? LastName { get; set; }

		public string TenantName => $"{FirstName} {LastName}";
        public double? LastPayment { get; set; }
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
        [Required(ErrorMessage = "Primary Residence is Required")]
		 public bool PrimaryResidence { get; set; }
        [Required(ErrorMessage = "Select Building")]
        public Guid? BuildingId { get; set; }

		//Rent Details
		public bool? RenewalOffer { get; set; }
        [Required(ErrorMessage = "Select Rent Due date")]
		public Guid? RentDueEachMonthOrWeekId { get; set; }

		public string? RentDueEachMonthOrWeekName { get; set; }
        [Required(ErrorMessage = "Monthly Rent is required")]

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
		public Guid? IsUnitIllegalId { get; set; }
		public string? IsUnitIllegalName { get; set; }
        [Required(ErrorMessage = "Select Tenancy type")]

        public Guid? TenancyTypeId { get; set; }

		public Guid? AdditialTenantsId { get; set; }
		public string? TenancyTypeName { get; set; }
		public string ?TenancyTypeDescription { get; set; }

        public DateOnly? LastPaymentDate { get; set; }
        public List<AddtionalTenantDto>? AdditioalTenants { get; set; }
		public EditToBuildingDto? Building { get; set; }
		public EditToLandlordDto? Landlord { get; set; }
        public EditToClientDto? Client { get; set; }
        public DateOnly? MoveInDate { get; set; }
        public string? CompletedAddress { get; set; }
        public DateOnly? LeaseEnd { get; set; }
        public DateOnly? LeaseStart { get; set; }
        public double? TotalOwed { get; set; }
        

    }
}
