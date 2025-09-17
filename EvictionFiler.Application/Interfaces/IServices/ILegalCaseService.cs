using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ILegalCaseService
    {
        Task<bool> AddLegalCasesAsync(CreateToEditLegalCaseModel dto);
        //Task<PaginationDto<LegalCase>> GetAllAsync(int pageNumber, int pageSize , string searchTerm);
        Task<PaginationDto<LegalCase>> GetAllAsync(int pageNumber, int pageSize, CaseFilterDto Filters , string userId, bool isAdmin);

        Task<int> GetTotalCasesCountAsync(string userid, bool isAdmin);
        Task<CreateToEditLegalCaseModel?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(CreateToEditLegalCaseModel dto);
        Task<List<LegalCase>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id, bool isAdmin);
        Task<List<LegalCase>> GetTodayCasesAsync();
        Task<int> GetActiveCasesCountAsync(string userId, bool isAdmin);
        Task<bool> CreateCasesAsync(IntakeModel legalCase);
        Task<IntakeModel> GetCaseByIdAsync(Guid caseId);
        Task<bool> UpdateCaseAsync(IntakeModel legalCase);


    }
}
