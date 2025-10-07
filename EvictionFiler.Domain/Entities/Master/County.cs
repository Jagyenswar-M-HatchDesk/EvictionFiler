using System.ComponentModel.DataAnnotations;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class County : DeletableBaseEntity
	{
		[MaxLength(50)]
		public string  Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Description { get; set; }

	}
}
