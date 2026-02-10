using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class Firms : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FAX { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
        [ForeignKey("SubscriptionTypeId")]
        public SubscriptionType? SubscriptionTypes { get; set; }

    }
}
