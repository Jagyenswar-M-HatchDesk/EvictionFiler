namespace EvictionFiler.Application.DTOs.CaseAppearanceDtos
{
    public class CaseAppearanceDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid? CourtTodayId { get; set; }
        public string? CourtTodayName { get; set; }


        public DateTime? AdjournDate { get; set; }
        public TimeOnly? AdjournTime { get; set; }


        public Guid? AdjournReasonId { get; set; }

        public Guid? LegalCaseId { get; set; }


        public DateTime? MotionDue { get; set; } = null;
        public DateTime? OppositionDue { get; set; }
        public DateTime? ReplyDue { get; set; } = null;
        public DateTime? ReturnDate { get; set; }

        public bool JurisdictionWaived { get; set; }
        public bool MilitaryAffidavit { get; set; }

        public bool WarrantIssued { get; set; }
        public DateTime? WarrantDate { get; set; }
        public DateTime? StayUntil { get; set; }

        //public decimal Amount = 1500;
        //public DateTime? PaymentStart;
        //public DateTime? PaymentEnd;

        public bool ReminderDeadlines { get; set; }
        public bool ReminderPayments { get; set; }

        public DateTime? AppreanceDate { get; set; }
    }
}
