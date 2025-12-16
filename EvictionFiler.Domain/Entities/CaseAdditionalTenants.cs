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
    public class CaseAdditionalTenants : DeletableBaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? LastName { get; set; }
        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public virtual LegalCase? LegalCases { get; set; }
    }
}
