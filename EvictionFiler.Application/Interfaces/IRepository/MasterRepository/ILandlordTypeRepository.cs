using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ILandlordTypeRepository : IRepository<LandlordType>
	{
		Task<List<LandlordType>> GetAllLandLordType();
	}
}
