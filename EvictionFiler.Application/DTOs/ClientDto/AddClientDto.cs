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


	
		public string? ClientCode { get; set; } = string.Empty;
		[Required(ErrorMessage = " FirstName is Required")]
		public string? FirstName { get; set; } = string.Empty;
	
		public string? LastName { get; set; } = string.Empty;
		[Required(ErrorMessage = " Email is Required")]
		public string? Email { get; set; } = string.Empty;
	
		public string? Address_1 { get; set; } = string.Empty;
        public string? Address_2 { get; set; } = string.Empty;

		public string? City { get; set; } = string.Empty;

		public Guid? StateId { get; set; }

		public string ? StateName {  get; set; } = string.Empty;
		public int? ZipCode { get; set; }
	
		public string? Phone { get; set; } = string.Empty;
        public string? CellPhone { get; set; } = string.Empty;
		
		public string? Fax { get; set; } = string.Empty;
  
		public List<CreateLandLordDto>? LandLords { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDeleted { get; set; }

		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }


	}
}
