using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class CaseNotes : DeletableGuidEntity
    {
        public string Notes { get; set; } = string.Empty;
        public Guid? LegalcaseId { get; set; }
        [ForeignKey("LegalcaseId")]
        public LegalCase? LegalCases { get; set; }
    }
}
