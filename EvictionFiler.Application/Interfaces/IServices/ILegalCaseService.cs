using EvictionFiler.Application.DTOs;
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
        Task<bool> AddLegalCasesAsync(CreateEditLegalCaseModel dto);
        Task<List<LegalCase>> GetAllAsync();
        Task<CreateEditLegalCaseModel?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(CreateEditLegalCaseModel dto);
        Task DeleteAsync(Guid id);

	}
}
