using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseHearing
{
    public class CaseHearingDto : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime HearingDate { get; set; }
        public DateTime HearingDateTo { get; set; }
        public TimeOnly HearingTime { get; set; }
        public string? Caption { get; set; }
        public string? IndexNo { get; set; }
        public Guid? CourtId { get; set; }
        public string? RoomNo { get; set; }
        public string? Judge { get; set; }

        public Guid? LegalCaseId { get; set; }

        public Guid? CaseTypeId { get; set; }
        public string? CaseTypeName { get; set; }
        public Guid? CountyId { get; set; }
        public string? CountyName { get; set; }

        public Guid? CourtPartId { get; set; }
        public string? CourtPart { get; set; }

        public Guid? CaseStatusId { get; set; }
        public string? CaseStatusName { get; set; }


        public DateTime? CreatedOn { get; set; }
    }
}
