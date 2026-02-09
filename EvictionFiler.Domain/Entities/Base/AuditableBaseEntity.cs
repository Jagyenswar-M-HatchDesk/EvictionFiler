using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities.Base
{
    public abstract class AuditableBaseEntity<TKey> : BaseEntity<TKey>
    where TKey : notnull
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }

        protected AuditableBaseEntity()
        {
            CreatedOn = DateTime.UtcNow;
        }
        public void SetUpdated(Guid userId)
        {
            UpdatedBy = userId;
            UpdatedOn = DateTime.UtcNow;
        }
    }
    public abstract class AuditableGuidEntity : AuditableBaseEntity<Guid> { }

    public abstract class DeletableBaseEntity<TKey> : AuditableBaseEntity<TKey>
    where TKey : notnull
    {
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Column(TypeName = "datetime2")]
        public DateTime? DeletedAt { get; set; }

        public void SoftDelete(Guid userId)
        {
            if (IsDeleted)
                return;

            IsDeleted = true;
            DeletedBy = userId;
            DeletedAt = DateTime.UtcNow;
            IsActive = false;
        }
    }
    public abstract class DeletableGuidEntity : DeletableBaseEntity<Guid> { }
}

