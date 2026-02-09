using EvictionFiler.Application.DTOs.MasterDtos.TenancyTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;



namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ITenancyTypeService
    {
        Task<bool> Create(EditToTenancyTypeDto dto);
        Task<PaginationDto<EditToTenancyTypeDto>> GetAllTenancyTypeAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateTenancyTypeAsync(EditToTenancyTypeDto dto);

        Task<EditToTenancyTypeDto?> GetTenancyTypeByIdAsync(Guid? id);
        Task<bool> DeleteTenancyTypeAsync(Guid id);
        
    }
}
