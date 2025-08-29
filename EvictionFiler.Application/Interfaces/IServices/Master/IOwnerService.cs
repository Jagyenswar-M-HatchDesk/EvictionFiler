using EvictionFiler.Application.DTOs.MasterDtos.TypeOfOwnerDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IOwnerService
    {
        Task<bool> Create(EditToOwnerDto dto);
        Task<PaginationDto<EditToOwnerDto>> GetAllOwnerAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateOwnerAsync(EditToOwnerDto dto);

        Task<EditToOwnerDto?> GetOwnerByIdAsync(Guid? id);
        Task<bool> DeleteOwnerAsync(Guid id);
      
    }
}
