using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public class MarshalAndWarrantRepository:IMarshalAndWarrantRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public MarshalAndWarrantRepository(IDbContextFactory<MainDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<MarshalAndWarrantDetailDto> GetMarshalDetailAsync(Guid caseId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var l = await context.LegalCases
     .AsNoTracking()
     .Where(c => c.Id == caseId && c.IsDeleted != true)
     .Include(c => c.Marshal)
     .FirstOrDefaultAsync();

            return new MarshalAndWarrantDetailDto
            {
                Id = l.Marshal?.Id,
                FirstName = l.Marshal?.FirstName!=null? l.Marshal?.FirstName : string.Empty,
                LastName = l.Marshal?.LastName,
                MarshalPhone = l.Marshal?.Telephone,
                Docketno=l.Marshal?.DocketNo,
                WarrantRequested=l.WarrantRequested

            };



        }

        public async Task<Marshal> GetMarshalByIdAsync(Guid id)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Marshal.FirstOrDefaultAsync(x => x.Id == id) ?? new();
        }
    }
}
