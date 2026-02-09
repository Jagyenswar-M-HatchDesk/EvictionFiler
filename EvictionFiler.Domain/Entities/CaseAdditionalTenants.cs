using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class CaseAdditionalTenants : DeletableGuidEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? LastName { get; set; }
        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public virtual LegalCase? LegalCases { get; set; }
    }
}
