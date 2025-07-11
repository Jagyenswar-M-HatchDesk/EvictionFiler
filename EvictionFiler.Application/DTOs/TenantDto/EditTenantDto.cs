using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.TenantDto
{
	public class EditTenantDto
	{
		public Guid Id { get; set; }
		public string? TenantCode { get; set; } = string.Empty;
		public string? Name { get; set; } = string.Empty;
		public string? Registration_No { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public string? Phone { get; set; } = string.Empty;
		public string? Language { get; set; } = string.Empty;
		public string? Apt { get; set; } = string.Empty;
		public string? Borough { get; set; } = string.Empty;
		public string? Name_Relation { get; set; } = string.Empty;
		public DateTime DOB { get; set; }
		public double Rent { get; set; }
		public string? LeaseStatus { get; set; } = string.Empty;

		public bool? TenantRecord { get; set; }
		public bool? HasPossession { get; set; }

		public bool? HasRegulatedTenancy { get; set; }
		public bool? OtherOccupants { get; set; }
		public string? SSN { get; set; } = string.Empty;
		public string? Address { get; set; } = string.Empty;
		public Guid? ApartmentId { get; set; }
	}
}
