using EvictionFiler.Application.DTOs;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ICasesRepository
    {
        Task<List<LegalCase>> GetAllCasesAsync();
        Task<LegalCase?> GetCaseByIdAsync(Guid id);
        Task<bool> AddCaseAsync(CreateEditLegalCaseModel legalCase);
        Task UpdateCaseAsync(LegalCase legalCase);
        Task DeleteCaseAsync(Guid id);
        Task<List<CaseType>> GetAllCaseTypeAsync();
        Task<List<CaseSubType>> GetSubTypesByCaseTypeIdAsync(Guid caseTypeId);

	}

}
