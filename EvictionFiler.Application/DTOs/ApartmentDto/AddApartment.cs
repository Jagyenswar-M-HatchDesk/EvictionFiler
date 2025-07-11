using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class AddApartment
	{
		public Guid Id { get; set; }
		public string? ApartmentCode { get; set; }

		public string? TypeOfRentRegulation { get; set; }
		public string? Country { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zipcode { get; set; }
		public string? PremiseType { get; set; }
		public string? MDR_Number { get; set; }
		public string? BuildingUnits { get; set; }
		public string? Address_1 { get; set; }
		public string? Address_2 { get; set; }
		public string? PetitionerInterest { get; set; }
		public string? OtherProperties { get; set; }
		public bool? HasPriorCase { get; set; }
		public Guid? LandlordId { get; set; }


		


	}
}
