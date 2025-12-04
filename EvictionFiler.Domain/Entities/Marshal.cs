using EvictionFiler.Domain.Entities.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Domain.Entities
{
    public class Marshal : DeletableBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public int BadgeNumber { get; set; }

        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;

        public string OfficeAddress { get; set; } = string.Empty;
    }
}
