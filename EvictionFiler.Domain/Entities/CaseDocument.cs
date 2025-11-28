using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class CaseDocument
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Path { get; set; } = string.Empty;

        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public LegalCase? Cases {  get; set; }
    }
}
