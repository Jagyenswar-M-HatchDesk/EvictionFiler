using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.CaseDocumentDtos
{
    public class CaseDocumentDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Path { get; set; } = string.Empty;

        public Guid? LegalCaseId { get; set; }
        [Required(ErrorMessage = "Document Type is Required")]
        public Guid? DocumentTypeId { get; set; }
        
    }
}
