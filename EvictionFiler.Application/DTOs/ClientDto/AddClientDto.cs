using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.ClientDto
{
    public class CreateClientDto
    {
        public Guid Id { get; set; }
        public string? ClientCode { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Address_1 { get; set; } = string.Empty;
        public string? Address_2 { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public int? State { get; set; }
        public int? ZipCode { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public string? CellPhone { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public bool? GenarateOwnRd { get; set; }
    }
}
