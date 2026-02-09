using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Domain.Entities.Base
{
    public abstract class BaseEntity<TKey>
    where TKey : notnull
    {
        [Key]
        public virtual TKey Id { get; set; } = default!;
    }
}
