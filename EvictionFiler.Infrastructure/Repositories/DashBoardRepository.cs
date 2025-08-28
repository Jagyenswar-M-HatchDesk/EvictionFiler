﻿using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.DashboardDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using PuppeteerSharp.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly MainDbContext _context;

        public DashBoardRepository(MainDbContext context) 
        {
            _context = context;
        }

        public async Task<List<string>> GetTenantSuggestions(string term)
        {
            term = term.ToLower().Trim();

            IQueryable<string> query;

            if (term.StartsWith("t")) 
            {
                query = _context.Tenants
                    .Where(c => c.TenantCode.ToLower().Contains(term))
                    .Select(c => c.TenantCode);
            }
            else
            {
                query = _context.Tenants
              .Where(c => (c.FirstName + " " + c.LastName).ToLower().StartsWith(term))
           .Select(c => c.FirstName + " " + c.LastName);
            }

            return await query.Take(5).ToListAsync();
        }

        public async Task<List<string>> GetLandlordSuggestions(string term)
        {
            term = term.ToLower().Trim();

            IQueryable<string> query;

            if (term.StartsWith("l")) 
            {
                query = _context.LandLords
                    .Where(c => c.LandLordCode.ToLower().Contains(term))
                    .Select(c => c.LandLordCode);
            }
            else
            {
                query = _context.LandLords
                        .Where(c => (c.FirstName + " " + c.LastName).ToLower().StartsWith(term))
                        .Select(c => c.FirstName + " " + c.LastName);
            }

            return await query.Take(5).ToListAsync();
        }


        public async Task<List<string>> GetCaseSuggestions(string term)
        {
            term = term.ToLower().Trim();

            return await _context.LegalCases
                .Where(c => c.Casecode.ToLower().Contains(term))
                .Select(c => c.Casecode)
                .Take(5)
                .ToListAsync();
        }

        public async Task<List<string>> GetReasonHoldoverSuggestions(string term)
        {
            term = term.ToLower().Trim();

            return await _context.MstReasonHoldover
                .Where(c => c.Name.ToLower().ToLower().StartsWith(term))
                .Select(c => c.Name)
                .Take(10)
                .ToListAsync();
        }




        public async Task<List<string>> GetClientSuggestions(string term)
        {
            term = term.ToLower().Trim();

            IQueryable<string> query;

            if (term.StartsWith("c")) 
            {
                query = _context.Clients
                    .Where(c => c.ClientCode.ToLower().Contains(term))
                    .Select(c => c.ClientCode);
            }
            else 
            {
                query = _context.Clients
              .Where(c => (c.FirstName + " " + c.LastName).ToLower().StartsWith(term))
           .Select(c => c.FirstName + " " + c.LastName);
            }

            return await query.Take(5).ToListAsync();
        }




        public async Task<PaginationDto<LegalCase>> Search(int pageNumber, int pageSize, CaseFilterDto filters)
        {
            var query = _context.LegalCases
                .AsNoTracking();

            // ✅ CaseCode filter
            if (!string.IsNullOrWhiteSpace(filters.CaseCode))
            {
                var caseCode = filters.CaseCode.ToLower();
                query = query.Where(c => (c.Casecode ?? "").ToLower().StartsWith(caseCode));
            }

            if (!string.IsNullOrWhiteSpace(filters.Client))
            {
                var clientFilter = filters.Client.ToLower();
                query = query.Where(c =>
                    c.Clients != null &&
                    (
                        (c.Clients.ClientCode ?? "").ToLower().StartsWith(clientFilter) ||
                        (((c.Clients.FirstName ?? "") + " " + (c.Clients.LastName ?? "")).ToLower().StartsWith(clientFilter))
                    )
                );
            }


            // ✅ Tenant filter
            if (!string.IsNullOrWhiteSpace(filters.Tenant))
            {
                var tenantFilter = filters.Tenant.ToLower();
                query = query.Where(c =>
                    (c.Tenants != null &&
                        (
                            (c.Tenants.TenantCode ?? "").ToLower().StartsWith(tenantFilter) ||
                            ((c.Tenants.FirstName ?? "") + " " + (c.Tenants.LastName ?? ""))
                                .ToLower()
                                .StartsWith(tenantFilter)
                        )
                    )
                );
            }

            if (!string.IsNullOrWhiteSpace(filters.LandLord))
            {
                var landlordFilter = filters.LandLord.ToLower();
                query = query.Where(c =>
                    (c.Tenants != null &&
                        (
                            (c.LandLords.LandLordCode ?? "").ToLower().StartsWith(landlordFilter) ||
                            ((c.LandLords.FirstName ?? "") + " " + (c.LandLords.LastName ?? ""))
                                .ToLower()
                                .StartsWith(landlordFilter)
                        )
                    )
                );
            }

            if (!string.IsNullOrWhiteSpace(filters.ReasonHoldover))
                query = query.Where(x => (x.ReasonHoldover.Name ?? "").ToLower().StartsWith(filters.ReasonHoldover.ToLower()));

            if (!string.IsNullOrWhiteSpace(filters.ActionDate) && DateTime.TryParse(filters.ActionDate, out var parsedDate))
                query = query.Where(x => x.CreatedOn.Date == parsedDate.Date);

            if (!string.IsNullOrWhiteSpace(filters.Status))
            {
                query = query.Where(x =>
                    (x.IsActive ? "active" : "inactive").ToLower().StartsWith(filters.Status.ToLower())
                );
            }



            var totalCount = await query.CountAsync();


            var items = await query
                .OrderByDescending(c => c.CreatedOn)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new LegalCase
                {
                    Id = c.Id,
                    Casecode = c.Casecode,
                    CreatedOn = c.CreatedOn,
                    ReasonHoldover = c.ReasonHoldover,
                    Clients = c.Clients != null ? new Client
                    {
                        FirstName = c.Clients.FirstName,
                        LastName = c.Clients.LastName,
                        ClientCode = c.Clients.ClientCode
                    } : new Client(),
                    LandLords = c.LandLords != null ? new LandLord
                    {
                        FirstName = c.LandLords.FirstName,
                        LastName = c.LandLords.LastName,
                        LandLordCode = c.LandLords.LandLordCode
                    } : new LandLord(),
                    Buildings = c.Buildings != null ? new Building
                    {
                        BuildingCode = c.Buildings.BuildingCode
                    } : new Building(),
                    Tenants = c.Tenants != null ? new Tenant
                    {
                        TenantCode = c.Tenants.TenantCode,
                        FirstName = c.Tenants.FirstName,
                        LastName = c.Tenants.LastName
                    } : new Tenant()
                })
                .ToListAsync();

            return new PaginationDto<LegalCase>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }

        
    }

}
