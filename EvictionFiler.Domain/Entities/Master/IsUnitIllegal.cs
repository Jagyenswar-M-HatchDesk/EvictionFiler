using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class IsUnitIllegal : DeletableBaseEntity
	{
		[MaxLength(50)]
		public string Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Description { get; set; }
	}
}
