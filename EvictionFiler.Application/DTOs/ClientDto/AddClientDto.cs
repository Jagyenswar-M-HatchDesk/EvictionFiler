using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;

namespace EvictionFiler.Application.DTOs.ClientDto
{
    public class CreateClientDto
    {
        public Guid Id { get; set; }


		[Required]
		public string? ClientCode { get; set; } = string.Empty;
		[Required]
		public string? FirstName { get; set; } = string.Empty;
		[Required]
		public string? LastName { get; set; } = string.Empty;
		[Required]
		public string? Email { get; set; } = string.Empty;
		[Required]
		public string? Address_1 { get; set; } = string.Empty;
        public string? Address_2 { get; set; } = string.Empty;
		[Required]
		public string? City { get; set; } = string.Empty;
		[Required]
		public string? State { get; set; }
		[Required]
		public int? ZipCode { get; set; }
		[Required]
		public string? Phone { get; set; } = string.Empty;
        public string? CellPhone { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public bool? GenarateOwnRd { get; set; }
		//public string? LandlordName { get; set; }
		//public string? LandlordEmail { get; set; }

		public List<CreateLandLordDto>? LandLords { get; set; }

	

	}
}
