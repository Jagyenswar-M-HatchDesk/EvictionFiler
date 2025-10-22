using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class Courts : DeletableBaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Court { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public string? Part { get; set; } = string.Empty;
        public string? RoomNo { get; set; } = string.Empty;
        public string? VirtualLink { get; set; } = string.Empty;
        public string? CallIn { get; set; } = string.Empty;
        public string? ConferenceId { get; set; } = string.Empty;
        public string? Judge { get; set; } = string.Empty;


    }
}
