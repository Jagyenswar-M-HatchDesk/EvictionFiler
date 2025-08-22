using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IManageFormService
    {
      
        Task<PaginationDto<FormAddEditViewModelDto>> GetAllFormAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> CreateForm(FormAddEditViewModelDto dto);
        Task<FormAddEditViewModelDto?> GetFormByIdAsync(Guid? id);
        Task<bool> DeleteFormAsync(Guid id);
        Task<bool> UpdateFormAsync(FormAddEditViewModelDto form);
    }
}
