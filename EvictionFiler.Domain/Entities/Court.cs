using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Domain.Entities.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class Courts : DeletableGuidEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Court { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        //public string? Part { get; set; } = string.Empty;
        //public string? RoomNo { get; set; } = string.Empty;
        //public string? VirtualLink { get; set; } = string.Empty;
        //public string? CallIn { get; set; } = string.Empty;
        //public string? ConferenceId { get; set; } = string.Empty;
        //public string? Judge { get; set; } = string.Empty;
        public Guid? CountyId { get; set; }
        [ForeignKey("CountyId")]
        public County? County { get; set; }

        public Guid? CourtTypeId { get; set; }
        [ForeignKey("CourtTypeId")]
        public CourtType? CourtTypes { get; set; }

        public ICollection<CourtPart> CourtParts { get; set; } = new List<CourtPart>();
    }
}
