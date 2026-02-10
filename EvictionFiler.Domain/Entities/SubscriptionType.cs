using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class SubscriptionType : DeletableBaseEntity
    {
        public Guid Id {  get; set; }
        public string? Name { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
    }
}
