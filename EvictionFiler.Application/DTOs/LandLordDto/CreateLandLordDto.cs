using System;
using System.Collections.Generic;
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
		public string? Name { get; set; } = string.Empty;
		public string? FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		public string? LandLordCode { get; set; } = string.Empty;
		public string? TypeOfOwner { get; set; }
		public string? Phone { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public string? EINorSSN { get; set; } = string.Empty;
		public string? Attorney { get; set; } = string.Empty;
		public string? AttorneyContactInfo { get; set; } = string.Empty;
		public string? Firm { get; set; } = string.Empty;
		public string? ContactPersonName { get; set; } = string.Empty;
		public DateOnly ?DateOfRefreeDeed { get; set; }
		public string? MaillingAddress { get; set; } = string.Empty;
		public LandLordRole? LandlordType { get; set; }
		public string? Country { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zipcode { get; set; }
		public string? Address1{ get; set; }
		public string? Address2 { get; set; }
		public Guid ClientId { get; set; }  
		public List<AddApartment>? Apartments { get; set; }

		public string? OtherLandlordTypeDescription { get; set; }
	}
}
