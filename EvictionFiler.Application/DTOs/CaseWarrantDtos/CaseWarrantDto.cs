using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseWarrantDtos
{
    public class CaseWarrantDto
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
        public Guid? LegalcaseId { get; set; }
    }
}
