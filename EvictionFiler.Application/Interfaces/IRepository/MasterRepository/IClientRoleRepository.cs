using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface IClientRoleRepository
	{
		Task<List<ClientRole>> GetAllClientRole();
	}
}
