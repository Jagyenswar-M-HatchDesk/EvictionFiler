
using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities.Base.Base;


namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class CreateToBuildingDto : DeletableBaseEntity
	{

		public string BuildingCode { get; set; } = string.Empty;
		
		public string? ApartmentCode { get; set; }
        [Required(ErrorMessage = "MDR Number is Required")]
        public string? MDRNumber { get; set; }
        [Required(ErrorMessage = "Building Unit is Required")]
        public string? BuildingUnits { get; set; }
		[Required(ErrorMessage = "Premise Type is Required")]
		public Guid? PremiseTypeId { get; set; }
		public string? PremiseTypeName { get; set; }

		[Required(ErrorMessage = "RegulationStatus is Required")]
		public Guid? RegulationStatusId { get; set; }
		public string? RegulationStatusName { get; set; }
		public string? PetitionerInterest { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
        [Required(ErrorMessage = "Agent is Required")]
        public string? ManagingAgent { get; set; }
		public string? CityName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Select City")]
        public Guid? CityId { get; set; }
        [Required(ErrorMessage = "Select State")]
        public Guid? StateId { get; set; }
		public string? StateName { get; set; }
        [Required(ErrorMessage = "Zipcode is Required")]
        public string? Zipcode { get; set; } = string.Empty;
		[Required(ErrorMessage = "Select LandLord")]
		public Guid? LandlordId { get; set; }
        public Guid? ExemptionBasisId { get; set; }
        public Guid? ExemptionreasonId { get; set; }
        [Required(ErrorMessage = "Select Registration Status")]
        public Guid? RegistrationStatusId { get; set; }
        public Guid? BuildingTypeId { get; set; }

        public bool? OwnerOccupied { get; set; }

        public List<CreateToTenantDto>? Tenants { get; set; }

        public string CompletedAddress
		{
			get
			{
				var parts = new List<string> { Address1, Address2, CityName, StateName, Zipcode };
				return string.Join(", ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
			}
			
		}

	}
}
