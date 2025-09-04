
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

		public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		public string? StateName { get; set; }
		public string? Zipcode { get; set; } = string.Empty;
		[Required(ErrorMessage = "Select LandLord")]
		public Guid? LandlordId { get; set; }

		public List<CreateToTenantDto>? Tenants { get; set; }

        public string CompletedAddress
        {
            get
            {
                var parts = new List<string> { Address1, Address2, City, StateName, Zipcode };
                return string.Join(", ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
            }
        }

    }
}
