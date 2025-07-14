using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Enums;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class EditApartmentDto
	{
		public Guid Id { get; set; }
		public string? ApartmentCode { get; set; }
		public string? MDR_Number { get; set; }
		public int? BuildingUnits { get; set; }

		public string? PremiseType { get; set; }
		public string? TypeOfRentRegulation { get; set; }
		public string? PetitionerInterest { get; set; }

		public string? Address_1 { get; set; }
		public string? Address_2 { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zipcode { get; set; }
		public DateOnly DateOfRefreeDeed { get; set; }
		public LandLordRole? LandlordType { get; set; }
		public Guid? LandlordId { get; set; }
	}
}
