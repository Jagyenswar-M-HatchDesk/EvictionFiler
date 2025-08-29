using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class TypeOwnerRepository : Repository<TypeOfOwner>, ITypeOwnerRepository
	{
		private readonly MainDbContext _context;

		public TypeOwnerRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<TypeOfOwner>> GetAllOwner()
		{
			return await _context.MstTypeOfOwners.ToListAsync();
		}
	}
}
