﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class UnitIllegalRepository : Repository<IsUnitIllegal>, IUnitIllegalRepository
	{
		private readonly MainDbContext _context;

		public UnitIllegalRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<IsUnitIllegal>> GetAllUnitIllegal()
		{
			return await _context.MstIsUnitIllegal.ToListAsync();
		}
	}
}
