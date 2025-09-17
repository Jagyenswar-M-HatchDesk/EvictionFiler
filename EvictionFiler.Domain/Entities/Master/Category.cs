using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class Category : DeletableBaseEntity
	{
		[MaxLength(500)]
		public string Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Description { get; set; }
	
	}
}
