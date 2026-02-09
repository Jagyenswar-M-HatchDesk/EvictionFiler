using EvictionFiler.Domain.Entities.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class RemainderCenter : DeletableGuidEntity
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
        public Guid? ReminderEscalateId { get; set; }
        [ForeignKey("ReminderEscalateId")]
        public ReminderEscalate? ReminderEscalates { get; set; }
        public Guid? ReminderCategoryId { get; set; }
        [ForeignKey("ReminderCategoryId")]
        public ReminderCategory? ReminderCategory { get; set; }

        public DateTime? When { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
        public string? ReminderName { get; set; }
        public bool? IsComplete { get; set; }
    }

}