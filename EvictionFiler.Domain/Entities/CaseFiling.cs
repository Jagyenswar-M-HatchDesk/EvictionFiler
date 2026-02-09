using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class CaseFiling :DeletableGuidEntity
    {
        public string? GeneratedOSC { get; set; }
        public string? GeneratedMotion { get; set; }
        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public LegalCase? LegalCases { get; set; }
    }
}
