using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseDetailDtos
{
    public  class TenantDetailDto
    {
        public Guid? TenantId { get; set; }
        public string? TenantName { get; set; }
        public string? UnitOrApartmentNumber { get; set; }
    }
}
