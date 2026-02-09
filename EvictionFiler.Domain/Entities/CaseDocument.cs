using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Domain.Entities.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class CaseDocument : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Path { get; set; } = string.Empty;

        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public LegalCase? Cases {  get; set; }
        public Guid? DocumentTypeId { get; set; }
        [ForeignKey("DocumentTypeId")]
        public DocumentType? DocumentTypes {  get; set; }
    }
}
