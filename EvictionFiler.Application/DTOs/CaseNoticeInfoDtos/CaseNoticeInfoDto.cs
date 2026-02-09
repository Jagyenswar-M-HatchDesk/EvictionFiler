namespace EvictionFiler.Application.DTOs.CaseNoticeInfoDtos
{
    public class CaseNoticeInfoDto
    {
        public Guid? Id { get; set; }
        //[Required]
        public Guid? DateRentId { get; set; }
        //[Required(ErrorMessage = "Select Tenancy Type")]
        public Guid? TenancyTypeId { get; set; }
        //[Required(ErrorMessage = "Select Form")]
        public Guid? FormTypeId { get; set; }
        public string? FormTypeName { get; set; }
        //[Required]
        public int? MonthlyRent { get; set; }
        public Guid? LegalCaseId { get; set; }
        public int? TenantShare { get; set; }
        public string? SocialService { get; set; }
        public string? PredicateNotice { get; set; }
        public string? AdditionalComments { get; set; }
        public string? Assistance { get; set; }
        public int? LastPaidAmt { get; set; }
        public int? Totalowed { get; set; }
        public int? CalcNoticeLength { get; set; }
        //[Required]
        public decimal? BillAmount { get; set; }
        public DateOnly? DateofLastPayment { get; set; }
        //[Required(ErrorMessage = "Notice Date Required")]
        public DateOnly? DateNoticeServed { get; set; }
        public DateOnly? LeaseStart { get; set; }
        public DateOnly? LeaseEnd { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public bool GoodCauseExempt { get; set; } = false;
        public bool LeasedAttached { get; set; }
        public bool LedgerAttached { get; set; }
        public bool NoticeProofattached { get; set; }
        public bool RegistrationRentHistory { get; set; }
        public bool? WrittenLease { get; set; }

    }
}
