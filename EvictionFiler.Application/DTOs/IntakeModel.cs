using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs
{
    public class IntakeModel : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        [Required] public Guid ClientId { get; set; }
        public string Casecode { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string Phone { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public Guid? LandLordTypeId { get; set; }
        [Required] public string LandLordTypeName { get; set; }

        [Required] public string Mdr { get; set; }
        [Required] public string? Units { get; set; }
        [Required] public string BuildingAddress { get; set; }
        [Required] public Guid? RegulationStatusId { get; set; }
        [Required] public string RegulationStatusName { get; set; }

        [Required] public string TenantName { get; set; }
        [Required] public string UnitNumber { get; set; }
        public bool? TenantRecord { get; set; }
        public bool? HasPossession { get; set; }
        public bool? OtherOccupants { get; set; }
        [Required] public Guid IsUnitIlligalId { get; set; }
        [Required] public string IsUnitIlligalName { get; set; }

        public Guid? TenancyTypeId { get; set; }

        public string? TenancyTypeName { get; set; }
        public bool? WrittenLease { get; set; }
        public bool? IsERAPPaymentReceived { get; set; }
        public DateOnly? DateTenantMoved { get; set; }
        public Guid? RentDueEachMonthOrWeekId { get; set; }
        public double? TenantShare { get; set; }
        public DateOnly? OralStart { get; set; }

        public DateOnly? OralEnd { get; set; }

        [Required] public double? MonthlyRent { get; set; }
        [Required] public double? TotalOwed { get; set; }
        public string Erap { get; set; } = "No";

        [Required] public Guid CaseTypeId { get; set; }
        [Required] public string CaseTypeName { get; set; }

        // FOR Client 
        public string ClientCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string ClientEmail { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public Guid? StateId { get; set; }
        public string? StateName { get; set; }
        public string? ZipCode { get; set; } = string.Empty;
        public string? ClientPhone { get; set; }
    }
}
