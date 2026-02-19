using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs
{
    public class PipeLineChartItem
    {
        
            public string Month { get; set; }
            public int NonPayment { get; set; }
            public int Holdover { get; set; }
            public int Other { get; set; }
        

    }
}
