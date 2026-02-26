using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseDetailDtos
{
    public  class BuildingDetailDto
    {
        
      
     
        

        public Guid? BuildingId { get; set; }
        public string Mdr { get; set; }

        public string? BuildingTyeName { get; set; } 
        public string? RentRegulationType { get; set; } 
        public string? BuildingState { get; set; }
        public string? BuildingZip { get; set; }
        public string? Borough { get; set; }
        public string BuildingAddress { get; set; }
      
    }
}
