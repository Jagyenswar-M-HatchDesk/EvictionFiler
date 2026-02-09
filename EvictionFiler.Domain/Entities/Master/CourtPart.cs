using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities.Master
{
	public class CourtPart : DeletableGuidEntity
	{
        public Guid Id { get; set; }

        public string Tollfree { get; set; } = string.Empty;

        public string Part { get; set; } = string.Empty;
        public string RoomNo { get; set; } = string.Empty;
        public string VirtualLink { get; set; } = string.Empty;
        public string CallIn { get; set; } = string.Empty;
        public string ConferenceId { get; set; } = string.Empty;
        public Guid? CourtId { get; set; }
        [ForeignKey("CourtId")]
        public Courts? Courts { get; set; }
        public string Judge { get; set; } = string.Empty;

    }
}
