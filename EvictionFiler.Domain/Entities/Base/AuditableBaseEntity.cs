using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities.Base.Base
{
	public class AuditableBaseEntity :  BaseEntity
	{
		public Guid CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsActive { get; set; }	= true;
		public DateTime? UpdatedOn { get; set; }
		public Guid? UpdatedBy { get; set; }
	}

	public abstract class DeletableBaseEntity : AuditableBaseEntity
	{
		public Guid? DeletedBy { get; set; }
		public bool? IsDeleted { get; set; } = false;
		[Column(TypeName = "DateTime")]
		public DateTime? DeletedAt { get; set; }
	}
}

