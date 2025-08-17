using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ILegalCaseService
    {
        Task<bool> AddLegalCasesAsync(CreateToEditLegalCaseModel dto);
        Task<PaginationDto<LegalCase>> GetAllAsync(int pageNumber, int pageSize);

		Task<CreateToEditLegalCaseModel?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(CreateToEditLegalCaseModel dto);
        Task DeleteAsync(Guid id);

	}
}
