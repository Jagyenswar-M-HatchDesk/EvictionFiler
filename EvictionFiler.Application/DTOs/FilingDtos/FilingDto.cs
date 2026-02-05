using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.FilingDtos
{
    public class FilingDto : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        public string? GeneratedOSC { get; set; }
        public string? GeneratedMotion { get; set; }
        public Guid? LegalCaseId { get; set; }

    }
}
