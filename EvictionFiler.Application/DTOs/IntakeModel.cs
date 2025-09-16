using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs
{
    public class IntakeModel
    {
        [Required] public string FullName { get; set; }
        [Required] public string Phone { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public string LandLordTypeId { get; set; }
        [Required] public string LandLordTypeName { get; set; }

        [Required] public string Mdr { get; set; }
        [Required] public int? Units { get; set; }
        [Required] public string BuildingAddress { get; set; }
        [Required] public string RegulationStatusId { get; set; }
        [Required] public string RegulationStatusName { get; set; }

        [Required] public string TenantName { get; set; }
        [Required] public string UnitNumber { get; set; }
        [Required] public string IsUnitIlligalId { get; set; }
        [Required] public string IsUnitIlligalName { get; set; }

        [Required] public decimal? MonthlyRent { get; set; }
        [Required] public decimal? TotalOwed { get; set; }
        public string Erap { get; set; } = "No";

        [Required] public string CaseTypeId { get; set; }
        [Required] public string CaseTypeName { get; set; }
    }
}
