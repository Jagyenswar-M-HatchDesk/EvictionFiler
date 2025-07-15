using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Enums;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class EditApartmentDto
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Apt code is required")]
		public string? ApartmentCode { get; set; }
		public string? MDR_Number { get; set; }
		public int? BuildingUnits { get; set; }
		[Required(ErrorMessage = "Premise Type is required")]
		public string? PremiseType { get; set; }

		[Required(ErrorMessage = "Rent Regulation is required")]
		public string? TypeOfRentRegulation { get; set; }
		public string? PetitionerInterest { get; set; }

		public string? Address_1 { get; set; }
		public string? Address_2 { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zipcode { get; set; }
		public DateOnly DateOfRefreeDeed { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public LandLordRole? LandlordType { get; set; }
		[Required(ErrorMessage = "Landlord is required")]
		public Guid? LandlordId { get; set; }
	}
}
