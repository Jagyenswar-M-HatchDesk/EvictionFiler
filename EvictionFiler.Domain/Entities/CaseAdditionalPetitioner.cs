using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class CaseAdditionalPetitioner : DeletableGuidEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? TenantId { get; set; }
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; }
        public Guid? LegalcaseId { get; set; }
        [ForeignKey("LegalcaseId")]
        public LegalCase? LegalCase { get; set; }
    }
}
