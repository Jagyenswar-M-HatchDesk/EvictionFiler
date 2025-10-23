using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class CaseHearing
    {

        public Guid Id { get; set; }
        public DateTime HearingDate { get; set; }
        public string? Caption { get; set; }
        public Guid? CourtId { get; set; }
        [ForeignKey("CourtId")]
        public Courts? Courts { get; set; }
        public Guid? LegalCaseId { get; set; }

        [ForeignKey("LegalCaseId")]
        public LegalCase? LegalCase { get; set; }
    }
}
