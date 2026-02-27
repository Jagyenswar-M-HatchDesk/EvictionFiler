using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseDetailDtos
{
    public  class ClientDetailDto
    {

      
        public Guid? ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }

      
        public string? ClientEmail { get; set; } = string.Empty;
        public string ClientPhone { get; set; }=string.Empty;
        public Guid? ClientTypeId { get; set; }
        public string? Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public string? Reference { get; set; }
        public string? StateName { get; set; }
        public string? ZipCode { get; set; } = string.Empty;
    }
}
