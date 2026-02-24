using EvictionFiler.Application.DTOs.ArrearLedgerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.CaseDetailDtos
{
    public  class TenantDetailDto
    {
        public Guid? CaseTypeId { get; set; }
        public Guid? TenantId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public  Guid? BuildingId { get; set; }
        public string? TenantName { get; set; }
        public string? UnitOrApartmentNumber { get; set; }
    
        public string? ApartmentNumber { get; set; }
        public string CaseTypeName { get; set; }
        public string? BuildingState { get; set; }
        public string? BuildingZip { get; set; }
        public string? Borough { get; set; }
        public string BuildingAddress { get; set; }
       public DateOnly? LastPaymentDate{get; set; }
        public double? TotalOwed { get; set; }
        public double? MonthlyRent { get; set; }
        public Guid? TenancyTypeId { get; set; }
        public Guid? RentDueEachMonthOrWeekId { get; set; }
        public bool PrimaryResidence { get; set; }
        public double? LastPayment { get; set; }
        public DateOnly? DateTenantMoved { get; set; }
        public string? PredicateNotice { get; set; }
        public int? CalculatedNoticeLength { get; set; }
        public double? TenantShare { get; set; }
        public string? SocialService { get; set; }
        public DateOnly? LeaseEnd { get; set; }
        public DateOnly? LeaseStart { get; set; }
        public List<ArrearLedgerDto> ArrearLedgers { get; set; } = new List<ArrearLedgerDto>();
    }
}
