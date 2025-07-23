using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Domain.Entities
{
	public class Tenant : Base
	{
		[Key]
		public Guid Id { get; set; }
		public string? TenantCode { get; set; } = string.Empty;
		public string? FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		public string? Registration_No { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public string? Phone { get; set; } = string.Empty;
		public string? Name_Relation { get; set; } = string.Empty;
		public Guid? LanguageId { get; set; }
		[ForeignKey("LanguageId")]
		public Language? Languages { get; set; }
		public string? Address_1 { get; set; }
		public string? Address_2 { get; set; }
		public string? City { get; set; }
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State? States { get; set; }
		public string? Zipcode { get; set; }
		public DateOnly DOB { get; set; }
		public double Rent { get; set; }
		public string? SSN { get; set; } = string.Empty;
		public string? Apt { get; set; } = string.Empty;
		public string? Borough { get; set; } = string.Empty;

		public bool? TenantRecord { get; set; }
		public bool? HasPossession { get; set; }

		public bool? HasRegulatedTenancy { get; set; }
		public bool? OtherOccupants { get; set; }

		public bool? HasPriorCase { get; set; }
		public Guid? ApartmentId { get; set; }
		[ForeignKey("ApartmentId")]
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public Appartment? Apartments { get; set; }
	}
}
