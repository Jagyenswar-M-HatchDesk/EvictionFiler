using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.TransactionDtos
{
    public class TransactionDto : DeletableBaseEntity
    {
        public Guid Id { get; set; }

        public string? CloverChargeId { get; set; }

        public int? Amount { get; set; }
        public string? Currency { get; set; }

        public string? Status { get; set; }
        public bool? Paid { get; set; }
        public bool? Captured { get; set; }

        public string? ReferenceNumber { get; set; }
        public string? AuthorizationCode { get; set; }

        public DateTime? CreatedUtc { get; set; }

        public Guid? CaseId { get; set; }
        [ForeignKey("CaseId")]
        public LegalCase? LegalCase { get; set; }
    }
}
