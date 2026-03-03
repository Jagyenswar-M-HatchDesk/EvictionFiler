using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.DashboardDto
{
   public class DashboardTileDto
    {

        public string Icon { get; set; } = "";
        public string Href { get; set; } = "";
        public string Label { get; set; } = "";
        public string Value { get; set; } = "";
    }
}
