using System.ComponentModel.DataAnnotations;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Application.DTOs.ClientDto
{
    public class CreateToClientDto : DeletableBaseEntity
    {
		public string ClientCode { get; set; } = string.Empty;
		[Required(ErrorMessage ="First Name is Required")]
		public string FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; }
		[Required(ErrorMessage = "Email is Required")]
		public string Email { get; set; } = string.Empty;
		public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		public string? StateName { get; set; }
		public string ?ZipCode { get; set; } = string.Empty;
		public string? Phone { get; set; }
		public string? CellPhone { get; set; }
		public string? Fax { get; set; }
		public bool Status { get; set; }
		public List<CreateToLandLordDto> LandLords { get; set; } = new();

		public string ? CreatedByName { get; set; }
	

	}
}
