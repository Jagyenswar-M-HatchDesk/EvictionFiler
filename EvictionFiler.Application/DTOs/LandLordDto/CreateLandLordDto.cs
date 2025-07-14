using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Domain.Enums;

namespace EvictionFiler.Application.DTOs.LandLordDto
{
    public class CreateLandLordDto
    {
        public Guid Id { get; set; }
		public string? LandLordCode { get; set; } = string.Empty;
		[Required(ErrorMessage ="First Name is required")]
		public string? FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		public string? TypeOfOwner { get; set; }
		public string? Phone { get; set; } = string.Empty;
		[Required(ErrorMessage = "Email is required")]
		public string? Email { get; set; } = string.Empty;
		public string? EINorSSN { get; set; } = string.Empty;
		public string? OtherProperties { get; set; }
		public string? ContactPersonName { get; set; } = string.Empty;
		public string? Address1 { get; set; }
		public string? Address2 { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zipcode { get; set; }
		public Guid ClientId { get; set; }  
		public List<AddApartment>? Apartments { get; set; }

		public string? OtherLandlordTypeDescription { get; set; }
	}
}
