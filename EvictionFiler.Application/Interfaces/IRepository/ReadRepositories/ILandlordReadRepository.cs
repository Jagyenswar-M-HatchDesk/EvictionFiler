using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public interface ILandlordReadRepository : IReadRepository<LandLord>
    {
        Task<LandlordDetailDto> GetLandlordDetailAsync(Guid caseId);

    }
}
