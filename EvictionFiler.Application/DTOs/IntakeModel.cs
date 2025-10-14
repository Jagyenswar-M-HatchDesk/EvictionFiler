﻿using EvictionFiler.Domain.Entities.Base.Base;
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
        //[Required(ErrorMessage = "Client is required")]
        public Guid? ClientId { get; set; }

        public string Selectedclient { get; set; }
        public string Status { get; set; }
        public string ClientName { get; set; }
        public string Casecode { get; set; }
        public string Buildingcode { get; set; }
        public string FullName { get; set; }

        public Guid? LandlordId { get; set; }
        public string LandlordAddress { get; set; } = string.Empty;

        public string landlordName { get; set; }
        public string AttorneyOfRecord { get; set; } = string.Empty;
        public string? LawFirm { get; set; } = string.Empty;
        public string? ContactPersonName { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid? LandLordTypeId { get; set; }
        public string LandLordTypeName { get; set; }

        public string Mdr { get; set; }
        public string? BuildingZip { get; set; }
        public string? Units { get; set; }
        public string? UnitOrApartmentNumber { get; set; }
        public string? ApartmentNumber { get; set; }

        public Guid? BuildingId { get; set; }
        public Guid? BuildingStateId { get; set; }
        public string BuildingAddress { get; set; }
        public Guid? RegulationStatusId { get; set; }
        public string RegulationStatusName { get; set; }

        public string TenantName { get; set; }
        public string UnitNumber { get; set; }
        public bool? TenantRecord { get; set; }
        public bool? HasPossession { get; set; }
        public bool? OtherOccupants { get; set; }
        public Guid? IsUnitIllegalId { get; set; }
        public string? IsUnitIllegalName { get; set; }

        public Guid? TenancyTypeId { get; set; }

        public string? TenancyTypeName { get; set; }
        public bool? WrittenLease { get; set; }
        public DateOnly? LeaseEnd { get; set; }
        public DateOnly? DateNoticeServed { get; set; }
        public bool? IsERAPPaymentReceived { get; set; }
        public DateOnly? DateTenantMoved { get; set; }
        public Guid? RentDueEachMonthOrWeekId { get; set; }
        public Guid? TenantId { get; set; }
        public double? TenantShare { get; set; }
        public DateOnly? OralStart { get; set; }

        public DateOnly? OralEnd { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string? PredicateNotice { get; set; }
        public string? SocialService { get; set; }
        public string? LastRentPaid { get; set; }
        public string? Reference { get; set; }
        public string? Borough { get; set; }

        public bool? OralAgreeMent { get; set; }
        public bool? GoodCauseApplies { get; set; } = false;

        public int? CalculatedNoticeLength { get; set; } 
        public double? MonthlyRent { get; set; }
        public double? TotalOwed { get; set; }
        public string Erap { get; set; } = "No";

        //[Required(ErrorMessage = "Type is required")]
        public Guid? CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public Guid? CaseProgramId { get; set; }

        // FOR Client 
        public string ClientCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }

        public string ClientEmail { get; set; } = string.Empty;

        public Guid? ClientTypeId { get; set; } 
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public Guid? StateId { get; set; }
        public string? StateName { get; set; }
        public string? ZipCode { get; set; } = string.Empty;
        public string? ClientPhone { get; set; }
    }
}
