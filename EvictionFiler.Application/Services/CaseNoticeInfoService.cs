using EvictionFiler.Application.DTOs.CaseNoticeInfoDtos;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class CaseNoticeInfoService : ICaseNoticeInfoService
    {
        private readonly ICaseNoticeInfoRepository _repo;
        private readonly IUnitOfWork _work;
        public CaseNoticeInfoService(ICaseNoticeInfoRepository repo, IUnitOfWork work)
        {
            _repo = repo;
            _work = work;
        }

        public async Task<List<CaseNoticeInfoDto>> GetAllCasenoticeInfo(Guid caseId)
        {
            //var list = await _repo.GetAllQueryablewithThenInclude(predicate: a=>a.LegalCaseId == caseId , include: b=>b.Include(c=>c.FormType).ThenInclude(d=>d.))
            var list = await _repo.GetAllAsync(predicate: a => a.LegalCaseId == caseId, includes: b => b.FormType);
            var result = list.Select(e => new CaseNoticeInfoDto
            {
                DateNoticeServed = e.DateNoticeServed,
                CalcNoticeLength = e.CalcNoticeLength,
                FormTypeName = e.FormType != null ? e.FormType.Name : string.Empty,

            }).ToList();
            return result;
        }

        public async Task<Guid?> AddCaseNoticeInfo(CaseNoticeInfoDto dto)
        {
            try
            {
                var Casenoticeinfo = new CaseNoticeInfo()
                {
                    LegalCaseId = dto.LegalCaseId,
                    DateNoticeServed = dto.DateNoticeServed,
                    AdditionalComments = dto.AdditionalComments,
                    CalcNoticeLength = dto.CalcNoticeLength,
                    DateofLastPayment = dto.DateofLastPayment,
                    DateRentId = dto.DateRentId,
                    ExpirationDate = dto.ExpirationDate,
                    FormtypeId = dto.FormTypeId,
                    TenancyTypeId = dto.TenancyTypeId,
                    GoodCauseExempt = dto.GoodCauseExempt,
                    LastPaidAmt = dto.LastPaidAmt,
                    LeasedAttached = dto.LeasedAttached,
                    LedgerAttached = dto.LedgerAttached,
                    MonthlyRent = dto.MonthlyRent,
                    NoticeProofattached = dto.NoticeProofattached,
                    PredicateNotice = dto.PredicateNotice,
                    RegistrationRentHistory = dto.RegistrationRentHistory,
                    SocialService = dto.SocialService,
                    TenantShare = dto.TenantShare,
                    Totalowed = dto.Totalowed,
                    LeaseEnd = dto.LeaseEnd,
                    LeaseStart = dto.LeaseStart,
                    WrittenLease = dto.WrittenLease,
                    Assistance = dto.Assistance,
                    CreatedOn = DateTime.Now,
                };
                var addedcasenoticeinfo = await _repo.AddAsync(Casenoticeinfo);
                var result = await _work.SaveChangesAsync();
                return result > 0 ? addedcasenoticeinfo.Id : null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Guid?> AddOrUpdateCaseNoticeInfo(CaseNoticeInfoDto dto)
        {
            try
            {
                //var entity = await _caseNoticeInfoRepository.GetAllAsync();
                var casinfo = await _repo.GetByCaseAndFormTypeAsync(dto.LegalCaseId.Value, dto.FormTypeId.Value);
                
                if (casinfo == null)
                {
                    casinfo = new CaseNoticeInfo
                    {
                        LegalCaseId = dto.LegalCaseId,
                        DateNoticeServed = dto.DateNoticeServed,
                        AdditionalComments = dto.AdditionalComments,
                        CalcNoticeLength = dto.CalcNoticeLength,
                        DateofLastPayment = dto.DateofLastPayment,
                        DateRentId = dto.DateRentId,
                        ExpirationDate = dto.ExpirationDate,
                        FormtypeId = dto.FormTypeId,
                        TenancyTypeId = dto.TenancyTypeId,
                        GoodCauseExempt = dto.GoodCauseExempt,
                        LastPaidAmt = dto.LastPaidAmt,
                        LeasedAttached = dto.LeasedAttached,
                        LedgerAttached = dto.LedgerAttached,
                        MonthlyRent = dto.MonthlyRent,
                        NoticeProofattached = dto.NoticeProofattached,
                        PredicateNotice = dto.PredicateNotice,
                        RegistrationRentHistory = dto.RegistrationRentHistory,
                        SocialService = dto.SocialService,
                        TenantShare = dto.TenantShare,
                        Totalowed = dto.Totalowed,
                        LeaseEnd = dto.LeaseEnd,
                        LeaseStart = dto.LeaseStart,
                        WrittenLease = dto.WrittenLease,
                        Assistance = dto.Assistance,
                        CreatedOn = DateTime.Now,
                    };

                    await _repo.AddAsync(casinfo);
                }
                else
                {
                    casinfo.DateNoticeServed = dto.DateNoticeServed;
                    casinfo.AdditionalComments = dto.AdditionalComments;
                    casinfo.CalcNoticeLength = dto.CalcNoticeLength;
                    casinfo.DateofLastPayment = dto.DateofLastPayment;
                    casinfo.DateRentId = dto.DateRentId;
                    casinfo.ExpirationDate = dto.ExpirationDate;
                    casinfo.TenancyTypeId = dto.TenancyTypeId;
                    casinfo.GoodCauseExempt = dto.GoodCauseExempt;
                    casinfo.LastPaidAmt = dto.LastPaidAmt;
                    casinfo.LeasedAttached = dto.LeasedAttached;
                    casinfo.LedgerAttached = dto.LedgerAttached;
                    casinfo.MonthlyRent = dto.MonthlyRent;
                    casinfo.NoticeProofattached = dto.NoticeProofattached;
                    casinfo.PredicateNotice = dto.PredicateNotice;
                    casinfo.RegistrationRentHistory = dto.RegistrationRentHistory;
                    casinfo.SocialService = dto.SocialService;
                    casinfo.TenantShare = dto.TenantShare;
                    casinfo.Totalowed = dto.Totalowed;
                    casinfo.LeaseEnd = dto.LeaseEnd;
                    casinfo.LeaseStart = dto.LeaseStart;
                    casinfo.WrittenLease = dto.WrittenLease;
                    casinfo.Assistance = dto.Assistance;
                    casinfo.UpdatedOn = DateTime.Now;

                    // 🔴 REQUIRED FIXES
                    //await _caseNoticeInfoRepository.UpdateAsync(casinfo);
                }

                var result = await _work.SaveChangesAsync();
                return result > 0 ? casinfo.Id : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
