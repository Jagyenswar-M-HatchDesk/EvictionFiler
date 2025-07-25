using System.ComponentModel.DataAnnotations;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class LandlordType : DeletableBaseEntity
	{
		[MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		[MaxLength(500)]
		public string? Description { get; set; }
	}
}
