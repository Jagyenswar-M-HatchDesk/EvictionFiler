using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICasesRepository : IRepository<LegalCase>
    {
        Task<Guid?> UpdateCaseTenant(IntakeModel casedetails);
        //Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize , string searchTerm);
        Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize, CaseFilterDto filters, string userId, bool isAdmin);
        Task<List<LegalCase>> GetAllCasesAsync();
        Task<string> GenerateCaseCodeAsync();
        Task<List<LegalCase>> GetTodayCasesAsync();
        Task<int> GetTotalCasesCountAsync(string userId, bool isAdmin);
        Task<int> GetActiveCasesCountAsync(string userId, bool isAdmin);
        Task<List<CaseTypeHPD>> GetHPDByIdsAsync(List<Guid> ids);
        Task<List<HarassmentType>> GetHarassmentTypeIdAsync(List<Guid> ids);
        Task<List<DefenseType>> GetDefenseTypeIdAsync(List<Guid> ids);
        Task<List<AppearanceType>> GetApperenceTypeIdAsync(List<Guid> ids);
        Task<List<ReliefPetitionerType>> GetReliefPetitionerTypesListTypeIdAsync(List<Guid> ids);
        Task<List<ReliefRespondentType>> GetReliefRespondentTypesListTypeIdAsync(List<Guid> ids);
        Task<List<CaseTypePerdiem>> GetCaseTypePerDiemByIdsAsync(List<Guid> ids);
        Task<List<AppearanceTypePerDiem>> GetApperenceTypePerDiemIdAsync(List<Guid> ids);
        Task<List<DocumentTypePerDiem>> GetDocumentIntructionsTypsIdAsync(List<Guid> ids);
        Task<List<ReportingTypePerDiem>> GetReportingTypePerDiemsIdAsync(List<Guid> ids);
        Task<List<IntakeModel>> SearchCasebyCode(string code);

        Task<Guid?> UpdateCaseLandlord(IntakeModel casedetails);
        Task<Guid?> UpdateCaseBuilding(IntakeModel casedetails);
        Task<Guid?> UpdateClient(IntakeModel casedetails);
        Task<List<LegalCase>> GetAlllAsync(Expression<Func<LegalCase, bool>>? predicate = null, params Expression<Func<LegalCase, object>>[]? includes);

        Task<Guid?> UpdateCaseCourt(IntakeModel casedetails);
        Task<bool> UpdateMarshal(IntakeModel legalCase);
    }

}
