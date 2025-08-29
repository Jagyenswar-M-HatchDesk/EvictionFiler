using EvictionFiler.Application.DTOs.MasterDtos.RentRegulationDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IRentRegulationService
    {
        Task<bool> Create(EditToRentRegulationDto dto);
        Task<PaginationDto<EditToRentRegulationDto>> GetAllRentRegulationAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateRentRegulationAsync(EditToRentRegulationDto dto);

        Task<EditToRentRegulationDto?> GetRentRegulationByIdAsync(Guid? id);
        Task<bool> DeleteRentRegulationAsync(Guid id);
      
    }
}
