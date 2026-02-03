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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class FormTypesRepository : Repository<FormTypes>, IFormTypesRepository
	{
		
        private readonly IDbContextFactory<MainDbContext> dbContextFactory;

        public FormTypesRepository(IDbContextFactory<MainDbContext> dbContextFactory): base(dbContextFactory.CreateDbContext())
        {
           
            this.dbContextFactory = dbContextFactory;
        }

		public async Task<List<FormTypes>> GetAllFormTYpes()
		{
            await using var db = dbContextFactory.CreateDbContext();
			return await db.MstFormTypes.ToListAsync();
		}

        public async Task<List<FormAddEditViewModelDto>> GetFormTypesByCaseTypeAsync(Guid? caseTypeId)
        {
            await using var db = dbContextFactory?.CreateDbContext();
            return await db.MstFormTypes
                .Where(f => f.CaseTypeId == caseTypeId && f.IsDeleted != true)
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
