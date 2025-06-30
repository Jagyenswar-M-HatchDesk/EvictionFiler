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
        Task<List<LegalCase>> GetAllAsync();
        Task<LegalCase?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateEditLegalCaseModel model);
        Task UpdateAsync(CreateEditLegalCaseModel model);
        Task DeleteAsync(Guid id);
    }
}
