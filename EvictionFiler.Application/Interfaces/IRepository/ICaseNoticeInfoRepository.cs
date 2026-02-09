using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICaseNoticeInfoRepository : IRepository<CaseNoticeInfo>
    {
        Task<CaseNoticeInfo?> GetByCaseAndFormTypeAsync(Guid legalCaseId, Guid formTypeId);
    }
}
