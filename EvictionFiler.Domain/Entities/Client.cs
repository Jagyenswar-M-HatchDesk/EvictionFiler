using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class Client
    {
        public string Id { get; set; }
        public string ClientCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }


    }
}
