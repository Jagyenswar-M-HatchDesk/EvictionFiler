using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Domain.Entities.Master
{
    public class City : DeletableGuidEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
