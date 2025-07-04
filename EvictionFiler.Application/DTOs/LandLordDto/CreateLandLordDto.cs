using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;

namespace EvictionFiler.Application.DTOs.LandLordDto
{
    public class CreateLandLordDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? EINorSSN { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? MaillingAddress { get; set; } = string.Empty;
        public string? Attorney { get; set; } = string.Empty;
        public string? Firm { get; set; } = string.Empty;
        public string? LandLordCode { get; set; } = string.Empty;
        public bool? isCorporeateOwner { get; set; }
        public string? RegisteredAgent { get; set; } = string.Empty;
        public Guid ClientId { get; set; }  
		public List<AddApartment>? Apartments { get; set; }
	}
}
