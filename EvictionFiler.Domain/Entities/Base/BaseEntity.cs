using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities.Base
{
	public abstract class BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual Guid Id { get; set; }
	}
}
