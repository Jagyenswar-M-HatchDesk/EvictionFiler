using EvictionFiler.Application.DTOs.MasterDtos.RenewalStatusDto;
using EvictionFiler.Application.DTOs.PaginationDto;


namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IRenewalStatusService
    {
        Task<bool> Create(EditToRenewalStatusDto dto);
        Task<PaginationDto<EditToRenewalStatusDto>> GetAllRenewalStatusAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateRenewalStatusAsync(EditToRenewalStatusDto dto);

        Task<EditToRenewalStatusDto?> GetRenewalStatusByIdAsync(Guid? id);
        Task<bool> DeleteRenewalStatusAsync(Guid id);
        
    }
}
