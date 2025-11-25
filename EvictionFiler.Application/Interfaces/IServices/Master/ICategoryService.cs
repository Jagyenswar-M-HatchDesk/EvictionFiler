

using EvictionFiler.Application.DTOs.MasterDtos.CategoryDto;
using EvictionFiler.Application.DTOs.MasterDtos.CategoryDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ICategoryService
    {
        Task<bool> Create(EditToCategoryDto dto);
        Task<PaginationDto<EditToCategoryDto>> GetAllCategoryAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateCategoryAsync(EditToCategoryDto dto);

        Task<EditToCategoryDto?> GetCategoryByIdAsync(Guid? id);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<List<EditToCategoryDto>> GetAllCategory();


    }
}
