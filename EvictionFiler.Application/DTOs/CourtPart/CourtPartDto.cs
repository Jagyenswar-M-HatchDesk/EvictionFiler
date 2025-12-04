using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CourtPart
{
    public class CourtPartDto
    {
        public Guid Id { get; set; }
       
        public string Tollfree { get; set; } = string.Empty;
        [Required(ErrorMessage = "Part is required.")]
        public string? Part { get; set; } 
        [Required(ErrorMessage = "Room No. is required.")]
        public string? RoomNo { get; set; } 
        public string VirtualLink { get; set; } = string.Empty;
        public string CallIn { get; set; } = string.Empty;
        public string ConferenceId { get; set; } = string.Empty;
        public Guid? CourtId { get; set; }
        public string Judge { get; set; } = string.Empty;
        public string Index { get; set; } = string.Empty;
        public string Court { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
    }
}
