using EvictionFiler.Application.DTOs.CaseWarrantDtos;
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

                var added =await _caseWarrantRepository.AddAsync(addeddata);
                var result =await _unitOfWork.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
