using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.OccupantDto
{
	public class AdditionalOccupantDto
	{
		public Guid Id { get; set; }
		public string ?Name { get; set; }
		public string ?Relation { get; set; }

		public Guid? TenantId { get; set; }
		public bool IsChecked { get; set; }
	}
}
