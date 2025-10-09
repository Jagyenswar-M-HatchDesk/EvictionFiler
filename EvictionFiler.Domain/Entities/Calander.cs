using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class Calander : DeletableBaseEntity
    {
   
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string ?Room { get; set; }
        public string ?Caption { get; set; }
        public string ?Index { get; set; }
       
        public string Judge { get; set; }

        public Guid? CountyId { get; set; }
        [ForeignKey("CountyId")]
        public County County { get; set; } 

        public Guid? CourtPartId { get; set; }
        [ForeignKey("CourtPartId")]
        public CourtPart CourtPart { get; set; } 

        public Guid? CaseStatusId { get; set; }
        [ForeignKey("CaseStatusId")]
        public CaseStatus CaseStatus { get; set; }

        public Guid? CaseTypeId { get; set; }
        [ForeignKey("CaseTypeId")]
        public CaseType CaseType { get; set; } 

        public string? LastAction { get; set; }
    }
}
