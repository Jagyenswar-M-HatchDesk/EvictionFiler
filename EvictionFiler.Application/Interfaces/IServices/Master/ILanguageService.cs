

using EvictionFiler.Application.DTOs.MasterDtos.LanguageDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ILanguageService
    {
        Task<bool> Create(EditToLanguageDto dto);
        Task<PaginationDto<EditToLanguageDto>> GetAllLanguageAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateLanguageAsync(EditToLanguageDto dto);

        Task<EditToLanguageDto?> GetLanguageByIdAsync(Guid? id);
        Task<bool> DeleteLanguageAsync(Guid id);
        
    }
}
