using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public interface ILandlordReadRepository : IReadRepository<LandLord>
    {
        Task<LandlordDetailDto> GetLandlordDetailAsync(Guid caseId);
        Task<List<EditToLandlordDto>> GetByClientIdAsync(Guid? clientId);
        Task<EditToLandlordDto> GetLandlordByIdAsync(Guid landlordId);
        Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query, Guid clientId);
        Task<string?> GetLastLandLordCodeAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<Guid?> UpdateCaseLandlord(IntakeModel casedetails);



    }
}
