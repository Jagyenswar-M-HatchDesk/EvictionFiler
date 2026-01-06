using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class CaseWarrant : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? WarrantRequested { get; set; }
        public DateTime? WarrantIssued { get; set; }
        public DateTime? WarrantRejected { get; set; }
        public DateTime? ReFileDate { get; set; }
        public DateTime? NoticeServed { get; set; }
        public DateTime? ExecutionEligible { get; set; }
        public DateTime? EvictionExecuted { get; set; }

        public string Status { get; set; } = "Pending";

        public Guid? MarshalId { get; set; }
        [ForeignKey("MarshalId")]
        public Marshal? Marshal { get; set; }
        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public LegalCase? LegalCases { get; set; }

    }
}
