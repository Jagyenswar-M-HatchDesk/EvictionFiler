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

        public async Task<List<CaseAppearanceDto>> GetAllCaseAppreance(Guid caseId)
        {
            var appreaaces = await _repository.GetAllAsync( predicate: x => x.LegalCaseId == caseId, includes: a=>a.CourtToday!);
            var result = appreaaces.Select(e => new CaseAppearanceDto
            {
                Id = e.Id,
                AdjournDate = e.AdjournDate,
                AdjournReasonId = e.AdjournReasonId,
                AdjournTime = e.AdjournTime,
                MotionDue = e.MotionDue,
                ReminderPayments = e.ReminderPayments,
                ReminderDeadlines = e.ReminderDeadlines,
                ReplyDue = e.ReplyDue,
                ReturnDate = e.ReturnDate,
                CourtTodayId = e.CourtTodayId,
                OppositionDue = e.OppositionDue,
                JurisdictionWaived = e.JurisdictionWaived,
                StayUntil = e.StayUntil,
                WarrantDate = e.WarrantDate,
                WarrantIssued = e.WarrantIssued,
                MilitaryAffidavit= e.MilitaryAffidavit,
                LegalCaseId = e.LegalCaseId,
                CourtTodayName = e.CourtToday != null ? e.CourtToday.Name : string.Empty,


            }).ToList();
            return result;
        }
        public async Task<bool> UpdateCaseAppreance(CaseAppearanceDto appearance)
        {
            var existing = await _repository.GetAsync(appearance.Id);

            existing.MotionDue = appearance.MotionDue;
            existing.ReplyDue = appearance.ReplyDue;
            existing.OppositionDue = appearance.OppositionDue;
            existing.ReturnDate = appearance.ReturnDate;

            var result = await _unitofwork.SaveChangesAsync();
            return result > 0 ? true : false;
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
