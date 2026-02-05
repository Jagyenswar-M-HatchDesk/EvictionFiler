using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ArrearLedgerDtos;
using EvictionFiler.Application.DTOs.CaseNoticeInfoDtos;
using EvictionFiler.Application.DTOs.FilingDtos;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
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
        //Task<PaginationDto<LegalCase>> GetAllAsync(int pageNumber, int pageSize , string searchTerm);
        Task<PaginationDto<LegalCase>> GetAllAsync(int pageNumber, int pageSize, CaseFilterDto Filters, string userId, bool isAdmin);

        Task<int> GetTotalCasesCountAsync(string userid, bool isAdmin);
        Task<CreateToEditLegalCaseModel?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(CreateToEditLegalCaseModel dto);
        Task<List<LegalCase>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id, bool isAdmin);
        Task<List<LegalCase>> GetTodayCasesAsync();
        Task<int> GetActiveCasesCountAsync(string userId, bool isAdmin);
        Task<Guid?> CreateCasesAsync(IntakeModel legalCase);
        Task<IntakeModel> GetCaseByIdAsync(Guid caseId);
        Task<Guid?> UpdateCaseAsync(IntakeModel legalCase);

        Task<bool> UpdateMarshalAsync(IntakeModel legalCase);
        Task<bool> UpdateWarrantRequested(IntakeModel legalCase);
        Task<bool> AddDocumentAsync(List<CaseDocument> document);
        Task<IEnumerable<CaseDocument>> CaseDocumentList(Guid Id);
        Task<bool> DeleteCaseDocument(Guid Id);
        Task<List<IntakeModel>> SearchCasebyCode(string code);
        Task<List<IntakeModel>> GetAllCase();

        Task<IEnumerable<FilingMethod>> FilingMethodList();

        Task<IEnumerable<ServiceMethod>> ServiceMethodList();

        Task<bool> AddArrearLedgerAsync(List<ArrearLedgerDto> Ledger);
        Task<bool> UpdateArrearLedgerAsync(List<ArrearLedgerDto> Ledger);
        Task<bool> DeleteArrearLedger(List<ArrearLedgerDto> Ledger);
        Task<IEnumerable<SubCaseType>> GetSubCaseList();
        Task<IEnumerable<City>> GetAllCitiesList();
        Task<IEnumerable<CourtType>> CourtTypeList();

        Task<bool> AddAdditionalrespondent(List<CaseAdditionalRespondent> respondent);
        Task<bool> AddAdditionalpetitioner(List<CaseAdditionalPetitioner> petitioner);

        Task<List<CaseAdditionalRespondent>> GetAdditionalrespondent(Guid respondentid);
        Task<List<CaseAdditionalPetitioner>> GetAdditionalpetitioner(Guid Petitionerid);
        Task<bool> DeleteAdditionalrespondent(CaseAdditionalRespondent respondent);
        Task<bool> DeleteAdditionalpetitioner(CaseAdditionalPetitioner petitioner);

        Task<bool> UpdateCourtandIndex(IntakeModel legalCase);
        Task<IEnumerable<CaseNotes>> GetAllCaseNotes();

        Task<bool> AddorEditGeneratedContent(FilingDto filing);
        Task<FilingDto?> GetFilings(Guid CaseId);
    }
}
