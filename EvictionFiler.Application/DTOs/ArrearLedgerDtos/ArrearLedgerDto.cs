namespace EvictionFiler.Application.DTOs.ArrearLedgerDtos
{
    public class ArrearLedgerDto
    {
        public Guid Id { get; set; }
        public string? Month { get; set; }
        public double Amount { get; set; }
        public string? Notes { get; set; }
        public Guid? LegalCaseId { get; set; }
        public Guid? CaseNoticeId { get; set; }
    }
}
