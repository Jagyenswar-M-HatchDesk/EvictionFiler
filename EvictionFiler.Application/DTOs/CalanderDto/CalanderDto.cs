using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CalanderDto
{
    public class CalanderDto : DeletableBaseEntity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string? Room { get; set; }
        public string? Caption { get; set; }
        public string? Index { get; set; }

        public string Judge { get; set; }

        public Guid? CountyId { get; set; }
        public string? CountyName { get; set; }

        public Guid? CourtPartId { get; set; }
        public string? CourtPartName { get; set; }


        public Guid? CaseStatusId { get; set; }
        public string? CaseStatusName { get; set; }


        public Guid? CaseTypeId { get; set; }
        public string? CaseTypeName { get; set; }


        public string? LastAction { get; set; }
        public string? OppositeAttorney { get; set; }
    }
}
