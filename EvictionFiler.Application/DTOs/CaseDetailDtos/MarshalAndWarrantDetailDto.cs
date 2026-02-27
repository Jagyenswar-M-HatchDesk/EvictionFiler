using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseDetailDtos
{
    public  class MarshalAndWarrantDetailDto
    {
        public Guid? Id;

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }

        public string MarshalName => FirstName + " " + LastName;
      
        public string MarshalPhone { get; set; }
        public string? Docketno { get; set; }
        public bool WarrantRequested { get; set; }
    }
}
