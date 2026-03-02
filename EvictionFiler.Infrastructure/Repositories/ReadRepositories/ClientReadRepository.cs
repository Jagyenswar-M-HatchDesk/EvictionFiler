using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public class ClientReadRepository : ReadRepository<Client>,IClientReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public ClientReadRepository(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<ClientDetailDto> GetClientsDetailAsync(Guid caseId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var l = await context.LegalCases
                 .AsNoTracking()
                .Where(c => c.Id == caseId && c.IsDeleted != true)
                .Include(a => a.Clients)
                .FirstOrDefaultAsync();

            if (l == null) return null;

            return new ClientDetailDto
            {
                ClientId = l.Clients?.Id,
                ClientTypeId = l.Clients?.ClientTypeId,
                ClientPhone = l.Clients?.Phone,
               
                FirstName = l.Clients?.FirstName != null ? l.Clients?.FirstName : string.Empty,
                LastName = l.Clients?.LastName,
                ClientEmail = l.Clients?.Email,
                Address1 = l.Clients?.Address1,
                Address2 = l.Clients?.Address2,
                City = l.Clients?.City,
                StateName = l.Clients?.State?.Name,
                ZipCode = l.Clients?.ZipCode,
                Reference= l.Clients?.Reference

            };
            }

        public async Task<Guid?> UpdateClient(IntakeModel casedetails)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.ClientId = casedetails.ClientId;


            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;
        }
    }
}
