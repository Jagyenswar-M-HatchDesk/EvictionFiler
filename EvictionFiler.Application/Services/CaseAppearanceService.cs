using EvictionFiler.Application.DTOs.CaseAppearanceDtos;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class CaseAppearanceService : ICaseAppearanceService
    {
        private readonly ICaseAppearanceRepository _repository;
        private readonly IUnitOfWork _unitofwork;
        public CaseAppearanceService(ICaseAppearanceRepository repository, IUnitOfWork unitofwork)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }

        public async Task<bool> AddCaseAppearance(CaseAppearanceDto data)
        {
            try
            {
                var toadd = new CaseAppearance
                {
                    AdjournDate = data.AdjournDate,
                    AdjournReasonId = data.AdjournReasonId,
                    AdjournTime = data.AdjournTime,
                    MilitaryAffidavit = data.MilitaryAffidavit,
                    CourtTodayId = data.CourtTodayId,
                    LegalCaseId = data.LegalCaseId,
                    JurisdictionWaived = data.JurisdictionWaived,
                    MotionDue = data.MotionDue,
                    OppositionDue = data.OppositionDue,
                    ReminderPayments = data.ReminderPayments,
                    ReminderDeadlines = data.ReminderDeadlines,
                    ReplyDue = data.ReplyDue,
                    ReturnDate = data.ReturnDate,
                    StayUntil = data.StayUntil,
                    WarrantDate = data.WarrantDate,
                    WarrantIssued = data.WarrantIssued,

                };

                var added = await _repository.AddAsync(toadd);
                var result = await _unitofwork.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
