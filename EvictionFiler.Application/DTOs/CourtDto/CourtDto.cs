using EvictionFiler.Application.DTOs.CourtPart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CourtDto
{
    public  class CourtDto
    {

        public Guid Id { get; set; }
        //[Required(ErrorMessage = "Court Name is required")]
        public string Court { get; set; } = string.Empty;
        //[Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;
        //[Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
        public string Part { get; set; } = string.Empty;
        public string RoomNo { get; set; } = string.Empty;
        public string VirtualLink { get; set; } = string.Empty;
        public string CallIn { get; set; } = string.Empty;
        public string ConferenceId { get; set; } = string.Empty;
        public Guid? CountyId { get; set; } 
        public string CountyName { get; set; } = string.Empty;
        public string Judge { get; set; } = string.Empty;

        public List<CourtPartDto> CourtPart { get; set; } = new List<CourtPartDto>();
    }
}
