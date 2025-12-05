using EvictionFiler.Domain.Entities.Base.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities.Master
{
    public class SubCaseType : DeletableBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
