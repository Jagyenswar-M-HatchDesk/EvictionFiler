using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs
{
    public class CreateEditLegalCaseModel
    {
        public Guid? Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? ApartmentId { get; set; }
        public Guid? LandLordId { get; set; }
        public string? CaseName { get; set; }
        public string? LandLordName { get; set; }
        public string? LandLordEmail { get; set; }
        public string? LandLordPhone { get; set; }
        public string? Attorney { get; set; }
        public string? Firm { get; set; }
        public string? RegisteredAgent { get; set; }
        public bool? IsCorporateOwner { get; set; }
    }
}
