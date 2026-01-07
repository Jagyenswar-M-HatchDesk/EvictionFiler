using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class CaseAppearance : DeletableBaseEntity
    {
        public Guid? CourtTodayId { get; set; }
        [ForeignKey("CourtTodayId")]
        public CourtToday? CourtToday { get; set; }

        public DateTime? AdjournDate { get; set; }
        public TimeOnly? AdjournTime { get; set; }


        public Guid? AdjournReasonId { get; set; }
        [ForeignKey("AdjournReasonId")]
        public AdjournedReason? AdjournReasons { get; set; }

        public DateTime? MotionDue {  get; set; }
        public DateTime? OppositionDue { get; set; }
        public DateTime? ReplyDue { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool JurisdictionWaived { get; set; }
        public bool MilitaryAffidavit {  get; set; }

        public bool WarrantIssued { get; set; }
        public DateTime? WarrantDate { get; set; }
        public DateTime? StayUntil { get; set; }

        //public decimal Amount = 1500;
        //public DateTime? PaymentStart;
        //public DateTime? PaymentEnd;

        public bool ReminderDeadlines { get; set; }
        public bool ReminderPayments {  get; set; }
    }
}
