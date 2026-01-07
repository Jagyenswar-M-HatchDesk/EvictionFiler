using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities.Master
{
    public class AdjournedReason : DeletableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
