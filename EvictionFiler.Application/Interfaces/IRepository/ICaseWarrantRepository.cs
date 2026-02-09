using EvictionFiler.Application.DTOs.CaseWarrantDtos;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICaseWarrantRepository : IRepository<CaseWarrant>
    {
        Task<bool> AddEditCaseWarrant(CaseWarrantDto dto);
    }
}
