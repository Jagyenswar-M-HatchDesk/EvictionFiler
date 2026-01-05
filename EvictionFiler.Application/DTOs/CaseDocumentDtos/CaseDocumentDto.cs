using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
