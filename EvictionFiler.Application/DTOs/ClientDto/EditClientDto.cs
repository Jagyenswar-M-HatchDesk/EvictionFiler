using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LandLordDto;

namespace EvictionFiler.Application.DTOs.ClientDto
{
	public class EditClientDto 
	{
		public Guid Id { get; set; }


		[Required(ErrorMessage = "Client code is Required")]
		public string? ClientCode { get; set; } = string.Empty;
		[Required(ErrorMessage = " FirstName is Required")]
		public string? FirstName { get; set; } = string.Empty;

		public string? LastName { get; set; } = string.Empty;
		[Required(ErrorMessage = " Email is Required")]
		public string? Email { get; set; } = string.Empty;
		[Required(ErrorMessage = " Address is Required")]
		public string? Address_1 { get; set; } = string.Empty;
		public string? Address_2 { get; set; } = string.Empty;
		[Required(ErrorMessage = " City is Required")]
		public string? City { get; set; } = string.Empty;
		[Required(ErrorMessage = " State is Required")]
		public string? State { get; set; }
		[Required(ErrorMessage = "Client code is Required")]
		public int? ZipCode { get; set; }
		[Required(ErrorMessage = " Phone is Required")]
		public string? Phone { get; set; } = string.Empty;
		public string? CellPhone { get; set; } = string.Empty;
		[Required(ErrorMessage = " Fax is Required")]
		public string? Fax { get; set; } = string.Empty;
		public bool? GenarateOwnRd { get; set; }
		public List<EditLandlordDto>? LandLords { get; set; }
	}
}
