using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface ICaseService
	{
		Task<List<CaseType>> GetAllCaseType();
		Task<List<CaseSubType>> GetAllCaseSubTypes(Guid CaseTypeId);
		Task<List<ClientRole>> GetAllClientRole();
	}
}
