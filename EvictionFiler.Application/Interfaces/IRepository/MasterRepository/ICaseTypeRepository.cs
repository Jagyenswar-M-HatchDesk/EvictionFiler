using EvictionFiler.Application.DTOs.MasterDtos.ApperenceTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeHPDDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypePerDiemDto;
using EvictionFiler.Application.DTOs.MasterDtos.DefenseTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.DocumentInstructionPerDiemDto;
using EvictionFiler.Application.DTOs.MasterDtos.HarassmentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefPetitionerTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefRespondentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReportingRequirementPerDiemDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ICaseTypeRepository : IRepository<CaseType>
    {

        public Task<List<CaseType>> GetAllCaseType();
        public Task<List<CourtPart>> GetAllCourtPart();
        public Task<List<CaseStatus>> GetAllCaseStatus();
        public Task<List<County>> GetAllCounty();
        public  Task<List<CaseTypeHPDDto>> GetAllCaseTypeHPD();
        public  Task<List<PartyRepresent>> GetAllpartyRepresenting();
        public  Task<List<BuildingType>> GetAllBuildingTypes();
        public  Task<List<Registrationstatus>> GetAllRegistrationstatus();
        public  Task<List<HarassmentTypeDto>> GetAllHarassmentTypes();

        public  Task<List<DefenseTypeDto>> GetAllDefenseTypes();

        public Task<List<ApperenceTypeDto>> GetAllAppearanceTypes();
        public Task<List<ReliefPetitionerTypeDto>> GetAllReliefPetitionerTypes();
        public Task<List<ReliefRespondentTypeDto>> GetAllReliefRespondentTypes();
        public Task<List<BilingType>> GetAllBilingTypes();
       public Task<List<CaseTypePerDiemDto>> GetAllCaseTypePerDiem();
        Task<List<PartyRepresentPerDiem>> GetAllpartyRepresentingPerDiem();
        Task<List<ApperenceTypeDto>> GetAllAppearanceTypesPerDiem();
        Task<List<DocumentInstructionPerDiemDto>> GetAllDocumentInstructionPerDiem();
        Task<List<ReportingRequirementPerDiemDto>> GetAllReportingRequirementPerDiem();
        Task<List<PaymentMethod>> GetAllPaymentMethod();




    }
}
