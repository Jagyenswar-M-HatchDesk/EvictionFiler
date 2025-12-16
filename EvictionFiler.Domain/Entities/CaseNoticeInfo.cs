using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class CaseNoticeInfo : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        public Guid? DateRentId { get; set; }
        [ForeignKey("DateRentId")]
        public DateRent? DateRents { get; set; }
        public Guid? TenancyTypeId { get; set; }
        [ForeignKey("TenancyTypeId")]
        public TenancyType? TenancyTypes { get; set; }
        public Guid? LegalCaseId { get; set; }
        [ForeignKey("LegalCaseId")]
        public LegalCase? LegalCaes { get; set; }
        public Guid? FormtypeId { get; set; }
        [ForeignKey("FormtypeId")]
        public FormTypes? FormType { get; set; }

        public int? MonthlyRent { get; set; }
        public int? TenantShare { get; set; }
        public string? SocialService { get; set; }
        public string? PredicateNotice { get; set; }
        public string? AdditionalComments { get; set; }
        public int? LastPaidAmt { get; set; }
        public int? Totalowed { get; set; }
        public int? CalcNoticeLength { get; set; }
        public DateOnly? DateofLastPayment { get; set; }
        public DateOnly? DateNoticeServed { get; set; }
        public DateOnly? ExpirationDate { get; set; }

        public bool? GoodCauseExempt { get; set; }
        public bool? LeasedAttached { get; set; }
        public bool? LedgerAttached { get; set; }
        public bool? NoticeProofattached { get; set; }
        public bool? RegistrationRentHistory { get; set; }

    }
}
