using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class CaseFiling :DeletableBaseEntity
    {
        [Key]
        public Guid Id {  get; set; }
        public string? GeneratedOSC { get; set; }
        public string? GeneratedMotion { get; set; }
        public string? GeneratedOpposition { get; set; }
        public string? GeneratedReply { get; set; }
        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public LegalCase? LegalCases { get; set; }

    }
}
