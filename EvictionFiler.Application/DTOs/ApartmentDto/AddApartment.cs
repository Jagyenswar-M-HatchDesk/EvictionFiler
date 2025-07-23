using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class AddApartment
	{
		public Guid Id { get; set; }

		public string? BuildingCode { get; set; } = string.Empty;
		
		public string? ApartmentCode { get; set; }
		public string? MDR_Number { get; set; }
		public int? BuildingUnits { get; set; }
		[Required(ErrorMessage = "Premise Type is required")]
		public Guid? PremiseTypeId { get; set; }
		public string? PremiseName { get; set; }

		[Required(ErrorMessage = "Rent Regulation is required")]
		public Guid? RentRegulationId { get; set; }

		public string? RentRegulationName { get; set; }
		public string? PetitionerInterest { get; set; }

		public string? Address_1 { get; set; }
		public string? Address_2 { get; set; }
		public string? City { get; set; }
		public Guid? StateId { get; set; }

		public string? StateName { get; set; }
		public string? Zipcode { get; set; }
		public DateOnly DateOfRefreeDeed { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public LandLordRole? LandlordType { get; set; }
		[Required(ErrorMessage = "Landlord is required")]
		public Guid? LandlordId { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDeleted { get; set; }

		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }




	}
}
