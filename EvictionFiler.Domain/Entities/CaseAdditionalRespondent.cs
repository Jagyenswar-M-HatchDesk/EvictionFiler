using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class CaseAdditionalRespondent : DeletableGuidEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid? LandlordId { get; set; }
        [ForeignKey("LandlordId")]
        public LandLord? LandLord { get; set; }
        public Guid? LegalcaseId { get; set; }
        [ForeignKey("LegalcaseId")]
        public LegalCase? LegalCase { get; set; }
    }
}
