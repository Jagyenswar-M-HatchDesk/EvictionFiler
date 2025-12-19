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
    public class CaseHearing : DeletableBaseEntity
    {

        public Guid Id { get; set; }
        public DateTime? HearingDate { get; set; }
        public TimeOnly? HearingTime { get; set; }
        public string? Caption { get; set; }
        public string? IndexNo { get; set; }
        public Guid? CourtId { get; set; }
        [ForeignKey("CourtId")]
        public Courts? Courts { get; set; }
        public Guid? LegalCaseId { get; set; }

        [ForeignKey("LegalCaseId")]
        public LegalCase? LegalCase { get; set; }

        public Guid? AppearanceModeId { get; set; }

        [ForeignKey("AppreanceModeId")]
        public AppearanceMode? AppearanceModes { get; set; }
        public Guid? AppearanceTypeId { get; set; }

        [ForeignKey("AppearanceTypeId")]
        public AppearanceType? AppearanceTypes { get; set; }
        public Guid? VirtualPlatformId { get; set; }

        [ForeignKey("VirtualPlatformId")]
        public VirtualPlatform? VirtualPlatforms { get; set; }

        public string? RoomNo { get; set; }
        public string? Judge { get; set; }

        public Guid? CaseTypeId { get; set; }
        [ForeignKey("CaseTypeId")]
        public CaseType? CaseTypes { get; set; }

        public Guid? CountyId { get; set; }
        [ForeignKey("CountyId")]
        public County? Counties { get; set; }

        public Guid? CourtPartId { get; set; }
        [ForeignKey("CourtPartId")]
        public CourtPart? CourtParts { get; set; }

        public Guid? CaseStatusId { get; set; }
        [ForeignKey("CaseStatusId")]
        public CaseStatus? CaseStatus { get; set; }
    }
}
