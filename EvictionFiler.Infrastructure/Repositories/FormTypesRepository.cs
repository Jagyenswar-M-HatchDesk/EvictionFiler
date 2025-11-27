using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class FormTypesRepository : Repository<FormTypes>, IFormTypesRepository
	{
		private readonly MainDbContext _context;

		public FormTypesRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<FormTypes>> GetAllFormTYpes()
		{
			return await _context.MstFormTypes.ToListAsync();
		}

        public async Task<List<FormAddEditViewModelDto>> GetFormTypesByCaseTypeAsync(Guid? caseTypeId)
        {
            return await _context.MstFormTypes
                .Where(f => f.CaseTypeId == caseTypeId)
                .Select(f => new FormAddEditViewModelDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Rate = f.Rate,
                })
                .ToListAsync();
        }

    }
}
