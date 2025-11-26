using System.ComponentModel.DataAnnotations;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class HarassmentType : DeletableBaseEntity
	{
		[MaxLength(250)]
		public string  Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Description { get; set; }
        public virtual ICollection<LegalCase> LegalCases { get; set; } = new List<LegalCase>();

    }
}
