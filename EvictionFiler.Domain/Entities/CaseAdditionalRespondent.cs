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
    public class CaseAdditionalRespondent : DeletableBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid? LandlordId { get; set; }
        [ForeignKey("LandlordId")]
        public LandLord? LandLord { get; set; }
        public Guid? LegalcaseId { get; set; }
        [ForeignKey("LegalcaseId")]
        public LegalCase? LegalCase { get; set; }
    }
}
