using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
    public class AddApartment
    {
        public Guid Id { get; set; }
        public string? City { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;
        public string? ZipCode { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Extention { get; set; } = string.Empty;
        public string? CellPhone { get; set; } = string.Empty;
    }
}
