using EvictionFiler.Application.DTOs.CaseWarrantDtos;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;

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
            var result =await _caseWarrantRepository.AddEditCaseWarrant(dto);
            return result;

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
