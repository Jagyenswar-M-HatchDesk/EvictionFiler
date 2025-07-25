using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class ClientRoleRepository : Repository<ClientRole>, IClientRoleRepository
	{
		private readonly MainDbContext _context;

		public ClientRoleRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

		

		public async Task<List<ClientRole>>GetAllClientRole()
		{
			return await _context.MstClientRoles.ToListAsync();
		}
	}
}
 