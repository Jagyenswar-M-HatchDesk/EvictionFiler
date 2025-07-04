using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LandLordDto;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
    public class AddApartment
    {
        public Guid Id { get; set; }
        public string? ApartmentCode { get; set; }
        public string? PremiseType { get; set; }
        public string? Address_1 { get; set; }
        public string? Address_2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zipcode { get; set; }
        public string? MDR_Number { get; set; }
        public string? PetitionerInterest { get; set; }
        public Guid? LandlordId { get; set; }
		public string? Tanent { get; set; }


	}
}
