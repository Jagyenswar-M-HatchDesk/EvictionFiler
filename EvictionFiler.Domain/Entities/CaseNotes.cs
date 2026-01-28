using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class CaseNotes : DeletableBaseEntity
    {
        public string Notes { get; set; } = string.Empty;
        public Guid? LegalcaseId { get; set; }
        [ForeignKey("LegalcaseId")]
        public LegalCase? LegalCases { get; set; }
    }
}
