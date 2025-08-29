using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.MasterDtos.LandlordTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;




namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ILandlordTypeService
    {
        Task<bool> Create(EditToLandlordTypeDto dto);
        Task<PaginationDto<EditToLandlordTypeDto>> GetAllLandlordTypeAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateLandlordTypeAsync(EditToLandlordTypeDto dto);

        Task<EditToLandlordTypeDto?> GetLandlordTypeByIdAsync(Guid? id);
        Task<bool> DeleteLandlordTypeAsync(Guid id);
       
    }
}
