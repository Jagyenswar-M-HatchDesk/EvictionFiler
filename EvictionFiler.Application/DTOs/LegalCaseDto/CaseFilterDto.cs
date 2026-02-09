namespace EvictionFiler.Application.DTOs.LegalCaseDto
{
    public class CaseFilterDto
    {
      
            public string? CaseCode { get; set; }
            public string? Client { get; set; }
            public string? Tenant { get; set; }
            public string? LandLord { get; set; }
            public string? ReasonHoldover { get; set; }
            public string? CaseType { get; set; }
            public string? Status { get; set; }
            public string? ActionDate { get; set; }
        public Guid? CaseTypeId { get; set; }


    }
}
