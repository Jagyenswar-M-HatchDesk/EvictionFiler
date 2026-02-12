using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.TransactionDtos
{
    public class CloverChargeResponse
    {
        public string id { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public bool paid { get; set; }
        public bool captured { get; set; }
        public string ref_num { get; set; }
        public string auth_code { get; set; }
        public long created { get; set; }
    }
}
