
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeDto;
using EvictionFiler.Application.DTOs.PaginationDto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ICaseTypeService
    {
        Task<bool> Create(EditToCourtPartDto dto);
        Task<PaginationDto<EditToCourtPartDto>> GetAllCaseTypeAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateCaseTypeAsync(EditToCourtPartDto dto);

        Task<EditToCourtPartDto?> GetCaseTypeByIdAsync(Guid? id);
        Task<bool> DeleteCaseTypeAsync(Guid id);
        
    }
}
