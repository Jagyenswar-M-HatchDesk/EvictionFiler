using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ILegalCaseService
    {
        Task<bool> AddLegalCasesAsync(CreateToEditLegalCaseModel dto);
        Task<List<LegalCase>> GetAllAsync();
        Task<CreateToEditLegalCaseModel?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(CreateToEditLegalCaseModel dto);
        Task DeleteAsync(Guid id);

	}
}
