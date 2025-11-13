using EvictionFiler.Application.DTOs.MasterDtos.ApperenceTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeHPDDto;
using EvictionFiler.Application.DTOs.MasterDtos.DefenseTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.HarassmentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefPetitionerTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefRespondentTypeDto;
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
        


    }
}
