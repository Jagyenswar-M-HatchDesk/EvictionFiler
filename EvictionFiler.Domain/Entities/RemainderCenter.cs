using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class RemainderCenter : DeletableBaseEntity
    {
        [MaxLength(50)]
        public string CaseName { get; set; } = string.Empty;

        public Guid? CaseId { get; set; }
        [ForeignKey("CaseId")]
        public LegalCase? Case { get; set; }
        [MaxLength(50)]
        public Guid? TenantId { get; set; }
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; }
        [MaxLength(50)]
        public Guid? CountyId { get; set; }
        [ForeignKey("CountyId")]
        public County? County { get; set; }

        [MaxLength(50)]
        public string? Index { get; set; }

        public Guid? RemainderTypeId { get; set; }
        [ForeignKey("RemainderTypeId")]
        public RemainderType? RemainderType { get; set; }

        public DateTime? When { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }

}