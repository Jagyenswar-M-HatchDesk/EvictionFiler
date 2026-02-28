using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseDetailDtos
{
    public  class CourtDetailDto
    {
        public Guid Id { get; set; }
        public string Court { get; set; }=string.Empty;
        public Guid? CourtTypeId { get; set; }

        public Guid? CourtPartId { get; set; } = null;
        public string CourtPart { get; set; } = string.Empty;
        public Guid? CourtLocationId { get; set; }
        public string? CourtLocation { get; set; }

        public string? Borough { get; set; }
        public Guid? CountryId { get; set; }
        public string? Country { get; set; }
        public string CourtRoomNo { get; set; } = string.Empty;

        public string? CourtRoom { get; set; }
        public string Judge { get; set; } = string.Empty;
        public DateTime? NextCourtDate { get; set; }
        public string? Index { get; set; }

    }
}
