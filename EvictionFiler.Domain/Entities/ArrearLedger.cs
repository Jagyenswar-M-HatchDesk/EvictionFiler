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
    public class ArrearLedger : DeletableBaseEntity
    {

        [Key]
        public Guid Id { get; set; }
        public string? Month { get; set; }
        public double Amount { get; set; }
        public string? Notes { get; set; }

        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public LegalCase? LegalCase { get; set; }

        public Guid? CaseNoticeId { get; set; }
        [ForeignKey("CaseNoticeId")]
        public CaseNoticeInfo? CaseNoticeInfo { get; set; }
    }
}
