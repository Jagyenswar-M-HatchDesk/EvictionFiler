using EvictionFiler.Application.DTOs.CaseWarrantDtos;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class CaseWarrantService : ICaseWarrantService
    {
        private readonly ICaseWarrantRepository _caseWarrantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CaseWarrantService(ICaseWarrantRepository caseWarrantRepository, IUnitOfWork unitOfWork)
        {
            _caseWarrantRepository = caseWarrantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCaseWarrant(CaseWarrantDto dto)
        {
            try
            {
                var existing = await _caseWarrantRepository.FindAsync(predicate: e => e.LegalCaseId == dto.LegalcaseId);
                if (existing != null)
                {
                    existing.ReFileDate = dto.ReFileDate;
                    existing.WarrantRequested = dto.WarrantRequested;
                    existing.WarrantIssued = dto.WarrantIssued;
                    existing.WarrantRejected = dto.WarrantRejected;
                    existing.EvictionExecuted = dto.EvictionExecuted;
                    existing.ExecutionEligible = dto.ExecutionEligible;
                    existing.NoticeServed = dto.NoticeServed;
                    existing.MarshalId = dto.MarshalId;
                    existing.LegalCaseId = dto.LegalcaseId;
                    existing.UpdatedOn = DateTime.Now;

                    var result = await _unitOfWork.SaveChangesAsync();
                    return result > 0 ? true : false;
                }
                else
                {
                    var addeddata = new CaseWarrant
                    {
                        ReFileDate = dto.ReFileDate,
                        WarrantRequested = dto.WarrantRequested,
                        WarrantIssued = dto.WarrantIssued,
                        WarrantRejected = dto.WarrantRejected,
                        EvictionExecuted = dto.EvictionExecuted,
                        ExecutionEligible = dto.ExecutionEligible,
                        NoticeServed = dto.NoticeServed,
                        MarshalId = dto.MarshalId,
                        LegalCaseId = dto.LegalcaseId,
                        CreatedOn = DateTime.Now,
                    };

                    var added = await _caseWarrantRepository.AddAsync(addeddata);
                    var result = await _unitOfWork.SaveChangesAsync();
                    return result > 0 ? true : false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public async Task<CaseWarrantDto> GetWarrantDetails(Guid caseId)
        {
            var existing = await _caseWarrantRepository.FindAsync(predicate: e=>e.LegalCaseId == caseId);
            if(existing == null) return new CaseWarrantDto();
            var result = new CaseWarrantDto
            {
                ReFileDate = existing.ReFileDate,
                WarrantRequested = existing.WarrantRequested,
                WarrantIssued = existing.WarrantIssued,
                WarrantRejected = existing.WarrantRejected,
                EvictionExecuted = existing.EvictionExecuted,
                ExecutionEligible = existing.ExecutionEligible,
                NoticeServed = existing.NoticeServed,
                MarshalId = existing.MarshalId,
                LegalcaseId = existing.LegalCaseId,

            };

            return result;
        }
    }
}
