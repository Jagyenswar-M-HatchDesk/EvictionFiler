
using EvictionFiler.Application.DTOs.MasterDtos.UnitIllegalDto;
using EvictionFiler.Application.DTOs.PaginationDto;


namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IUnitIllegalService
    {
        Task<bool> Create(EditToUnitIllegalDto dto);
        Task<PaginationDto<EditToUnitIllegalDto>> GetAllUnitIllegalAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateUnitIllegalAsync(EditToUnitIllegalDto dto);

        Task<EditToUnitIllegalDto?> GetUnitIllegalByIdAsync(Guid? id);
        Task<bool> DeleteUnitIllegalAsync(Guid id);
      
    }
}
