using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ICaseTypeRepository : IRepository<CaseType>
    {

        public Task<List<CaseType>> GetAllCaseType();
        public Task<List<CourtPart>> GetAllCourtPart();
        public Task<List<CaseStatus>> GetAllCaseStatus();
        public Task<List<County>> GetAllCounty();
        public  Task<List<CaseTypeHPD>> GetAllCaseTypeHPD();
        public  Task<List<PartyRepresent>> GetAllpartyRepresenting();
        public  Task<List<BuildingType>> GetAllBuildingTypes();
        public  Task<List<Registrationstatus>> GetAllRegistrationstatus();
        public  Task<List<HarassmentType>> GetAllHarassmentTypes();

        public  Task<List<DefenseType>> GetAllDefenseTypes();

        public Task<List<AppearanceType>> GetAllAppearanceTypes();
        public Task<List<ReliefPetitionerType>> GetAllReliefPetitionerTypes();
        public Task<List<ReliefRespondentType>> GetAllReliefRespondentTypes();
        public Task<List<BilingType>> GetAllBilingTypes();
        


    }
}
