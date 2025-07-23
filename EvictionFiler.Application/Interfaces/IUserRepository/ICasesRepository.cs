using EvictionFiler.Application.DTOs;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
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
        Task<CreateEditLegalCaseModel?> GetCaseByIdAsync(Guid id);

		Task<bool> AddCaseAsync(CreateEditLegalCaseModel legalCase);
        Task<bool> UpdateCasesAsync(CreateEditLegalCaseModel legalCase);

		Task DeleteCaseAsync(Guid id);
        Task<List<CaseType>> GetAllCaseTypeAsync();
        Task<List<CaseSubType>> GetSubTypesByCaseTypeIdAsync(Guid caseTypeId);
        Task<List<ClientRole>> GetAllClientRole();
	}

}
