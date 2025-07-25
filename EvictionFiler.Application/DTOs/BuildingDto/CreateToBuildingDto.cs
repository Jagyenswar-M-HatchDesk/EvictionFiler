using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class CreateToBuildingDto
	{
		
		public string BuildingCode { get; set; } = string.Empty;
		[Required(ErrorMessage = "Code is Required")]
		public string? ApartmentCode { get; set; }
		public string? MDRNumber { get; set; }
		public string? BuildingUnits { get; set; }
		[Required(ErrorMessage = "Premise Type is Required")]
		public Guid? PremiseTypeId { get; set; }
		public string? PremiseTypeName { get; set; }

		[Required(ErrorMessage = "RegulationStatus is Required")]
		public Guid? RegulationStatusId { get; set; }
		public string? RegulationStatusName { get; set; }
		public string? PetitionerInterest { get; set; }
		[Required(ErrorMessage = "Address 1 is Required")]
		public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		public string? StateName { get; set; }
		public string ?Zipcode { get; set; } = string.Empty;
		public DateOnly DateOfRefreeDeed { get; set; }
		
		public Guid? LandlordTypeId { get; set; }
		public string? LandlordTypeName { get; set; }
		public Guid? LandlordId { get; set; }

		public List<CreateToTenantDto>? Tenants { get; set; }

	}
}
