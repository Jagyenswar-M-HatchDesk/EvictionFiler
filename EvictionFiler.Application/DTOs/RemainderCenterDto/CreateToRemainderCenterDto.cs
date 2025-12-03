using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.RemainderCenterDto
{
    public class CreateToRemainderCenterDto : DeletableBaseEntity
    {
        public string CaseName { get; set; } = string.Empty;

        public Guid? TenantId { get; set; }
        public string? TenantName { get; set; }

        public Guid? CountyId { get; set; }
        public string? CountyName { get; set; }

        public string? Index { get; set; }

        public string? RemainderTypeName { get; set; }
        public Guid? RemainderTypeId { get; set; }
      
        public DateTime? When { get; set; }

     
        public string? Notes { get; set; }
    }
}
