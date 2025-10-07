using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ICaseTypeRepository : IRepository<CaseType>
    {

		Task<List<CaseType>> GetAllCaseType();
        //Task<List<CourtPart>> GetAllCourtPart();
        //Task<List<CaseStatus>> GetAllCaseStatus();
        //Task<List<County>> GetAllCounty();
        

    }
}
