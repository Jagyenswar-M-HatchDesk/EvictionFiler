using EvictionFiler.Application.DTOs.ApartmentDto;
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

        public async Task<List<DashboardSearchResultDto>> SearchDashboardAsync(string searchText)
        {
            var result = new List<DashboardSearchResultDto>();
            searchText = searchText?.Trim().ToLower();

            // 1️⃣ Search by Client Name
            var clients = await _context.Clients
                .Include(c=>c.State)
         .Include(c => c.LandLords)
             .ThenInclude(l => l.State)
         .Include(c => c.LandLords)
             .ThenInclude(l => l.TypeOfOwner)
         .Include(c => c.LandLords)
             .ThenInclude(l => l.LandlordType)
         .Include(c => c.LandLords)
             .ThenInclude(l => l.Buildings)
                 .ThenInclude(b => b.State)
         .Include(c => c.LandLords)
             .ThenInclude(l => l.Buildings)
                 .ThenInclude(b => b.PremiseType)
         .Include(c => c.LandLords)
             .ThenInclude(l => l.Buildings)
                 .ThenInclude(b => b.RegulationStatus)
         .Include(c => c.LandLords)
             .ThenInclude(l => l.Buildings)
                 .ThenInclude(b => b.Tenants)
                     .ThenInclude(t => t.State)
         .Where(c =>
             EF.Functions.Like((c.FirstName + " " + c.LastName).ToLower(), $"%{searchText}%") ||
             EF.Functions.Like(c.FirstName.ToLower(), $"%{searchText}%") ||
             EF.Functions.Like(c.LastName.ToLower(), $"%{searchText}%") ||
             EF.Functions.Like(c.ClientCode.ToLower(), $"%{searchText}%")
         )
         .ToListAsync();



            foreach (var client in clients)
            {
                foreach (var landlord in client.LandLords)
                {
                    foreach (var building in landlord.Buildings)
                    {
                        foreach (var tenant in building.Tenants)
                        {
                            result.Add(new DashboardSearchResultDto
                            {
                                ClientDto = new CreateToClientDto
                                {

                                    ClientCode = client.ClientCode,   
                                    FirstName = client.FirstName,     
                                    LastName = client.LastName,       
                                    Email = client.Email,            
                                    Address1 = client.Address1,    
                                    Address2 = client.Address2,       
                                    City = client.City,              
                                    StateId = client.StateId,   
                                    StateName = client.State.Name,
                                    ZipCode = client.ZipCode,         
                                    Phone = client.Phone,        
                                    CellPhone = client.CellPhone,    
                                    Fax = client.Fax,                
                               
                                },
                                LandLordDto = new CreateToLandLordDto
                                {

                                    LandLordCode = landlord.LandLordCode,
                                    FirstName = landlord.FirstName,
                                    LastName = landlord.LastName,
                                    TypeOwnerId = landlord.TypeOfOwnerId,
                                    TypeOwnerName = landlord.TypeOfOwner.Name,
                                    Phone = landlord.Phone,
                                    Email = landlord.Email,
                                    EINorSSN = landlord.EINorSSN,
                                    ContactPersonName = landlord.ContactPersonName,
                                    Address1 = landlord.Address1,
                                    Address2 = landlord.Address2,
                                    City = landlord.City,
                                    StateId = landlord.StateId,
                                    //StateName = landlord.State.Name,
                                    Zipcode = landlord.Zipcode,
                                    DateOfRefreeDeed = landlord.DateOfRefreeDeed,
                                    LandlordTypeId = landlord.LandlordTypeId,
                                    
                                     LandlordTypeName= landlord.LandlordType.Name,
                                   
                                },
                                BuildingDto = new CreateToBuildingDto
                                {

                                    BuildingCode = building.BuildingCode,
                                    ApartmentCode = building.ApartmentCode,
                                    MDRNumber = building.MDRNumber,
                                    BuildingUnits = building.BuildingUnits,
                                    PremiseTypeId = building.PremiseTypeId,
                                    PremiseTypeName = building.PremiseType.Name,
                                    RegulationStatusId = building.RegulationStatusId,
                                    RegulationStatusName = building.RegulationStatus.Name,
                                    PetitionerInterest = building.PetitionerInterest,
                                    Address1 = building.Address1,
                                    Address2 = building.Address2,
                                    City = building.City,
                                    StateId = building.StateId,
                                    StateName = building.State != null ? building.State.Name : null,
                                    Zipcode = building.Zipcode,

                                },
                                TenantDto = new CreateToTenantDto
                                {

                                    TenantCode = tenant.TenantCode,
                                    FirstName = tenant.FirstName,
                                    LastName = tenant.LastName,
                                    Email = tenant.Email,
                                    Phone = tenant.Phone,
                                    LanguageId = tenant.LanguageId,
                                    TenancyTypeId = tenant.TenancyTypeId,
                                    SSN = tenant.SSN,
                                    TenantRecord = tenant.TenantRecord,
                                    RenewalOffer = tenant.RenewalOffer,
                                    HasPossession = tenant.HasPossession,
                                    HasRegulatedTenancy = tenant.HasRegulatedTenancy,
                                    OtherOccupants = tenant.OtherOccupants,
                                    HasPriorCase = tenant.HasPriorCase,
                                    
                                    RentDueEachMonthOrWeekId = tenant.RentDueEachMonthOrWeekId,
                                    MonthlyRent = tenant.MonthlyRent,
                                    TenantShare = tenant.TenantShare,
                                    SocialServices = tenant.SocialServices,
                                 
                                    ERAPPaymentReceivedDate = tenant.ERAPPaymentReceivedDate,
                                    UnitOrApartmentNumber = tenant.UnitOrApartmentNumber,
                                    IsUnitIllegalId = tenant.IsUnitIllegalId,
                                    MoveInDate = tenant.MoveInDate,
                                }
                            });
                        }
                    }
                }
            }

            // 2️⃣ Search by Landlord Name
            var landlords = await _context.LandLords
              .Include(l => l.State)
              .Include(l => l.TypeOfOwner)
                .Include(l => l.LandlordType)
             .Include(l => l.Buildings)
                 .ThenInclude(b => b.State)
       
             .Include(l => l.Buildings)
                 .ThenInclude(b => b.PremiseType)
        
             .Include(l => l.Buildings)
                 .ThenInclude(b => b.RegulationStatus)
        
             .Include(l => l.Buildings)
                 .ThenInclude(b => b.Tenants)
                     .ThenInclude(t => t.State)
                  .Where(l =>
                             (l.FirstName + " " + l.LastName).ToLower().Contains(searchText.ToLower()) // ✅ Full Name
                             || l.FirstName.ToLower().Contains(searchText.ToLower())                  // ✅ First Name
                             || l.LastName.ToLower().Contains(searchText.ToLower())
                               || l.LandLordCode.ToLower().Contains(searchText) // ✅ Last Name
                         )
                .ToListAsync();

            foreach (var landlord in landlords)
            {
                foreach (var building in landlord.Buildings)
                {
                    foreach (var tenant in building.Tenants)
                    {
                        result.Add(new DashboardSearchResultDto
                        {
                            LandLordDto = new CreateToLandLordDto
                            {

                                LandLordCode = landlord.LandLordCode,
                                FirstName = landlord.FirstName,
                                LastName = landlord.LastName,
                                TypeOwnerId = landlord.TypeOfOwnerId,
                                TypeOwnerName = landlord.TypeOfOwner.Name,
                                Phone = landlord.Phone,
                                Email = landlord.Email,
                                EINorSSN = landlord.EINorSSN,
                                ContactPersonName = landlord.ContactPersonName,
                                Address1 = landlord.Address1,
                                Address2 = landlord.Address2,
                                City = landlord.City,
                                StateId = landlord.StateId,
                                //StateName = landlord.State.Name,
                                Zipcode = landlord.Zipcode,
                                DateOfRefreeDeed = landlord.DateOfRefreeDeed,
                                LandlordTypeId = landlord.LandlordTypeId,

                                LandlordTypeName = landlord.LandlordType.Name,
                            },
                            BuildingDto = new CreateToBuildingDto
                            {
                                BuildingCode = building.BuildingCode,
                                ApartmentCode = building.ApartmentCode,
                                MDRNumber = building.MDRNumber,
                                BuildingUnits = building.BuildingUnits,
                                PremiseTypeId = building.PremiseTypeId,
                                PremiseTypeName = building.PremiseType.Name,
                                RegulationStatusId = building.RegulationStatusId,
                                RegulationStatusName = building.RegulationStatus.Name,
                                PetitionerInterest = building.PetitionerInterest,
                                Address1 = building.Address1,
                                Address2 = building.Address2,
                                City = building.City,
                                StateId = building.StateId,
                                StateName = building.State != null ? building.State.Name : null,
                                Zipcode = building.Zipcode,

                            },
                            TenantDto = new CreateToTenantDto
                            {
                                TenantCode = tenant.TenantCode,
                                FirstName = tenant.FirstName,
                                LastName = tenant.LastName,
                                Email = tenant.Email,
                                Phone = tenant.Phone,
                                LanguageId = tenant.LanguageId,
                                TenancyTypeId = tenant.TenancyTypeId,
                                SSN = tenant.SSN,
                                TenantRecord = tenant.TenantRecord,
                                RenewalOffer = tenant.RenewalOffer,
                                HasPossession = tenant.HasPossession,
                                HasRegulatedTenancy = tenant.HasRegulatedTenancy,
                                OtherOccupants = tenant.OtherOccupants,
                                HasPriorCase = tenant.HasPriorCase,

                                RentDueEachMonthOrWeekId = tenant.RentDueEachMonthOrWeekId,
                                MonthlyRent = tenant.MonthlyRent,
                                TenantShare = tenant.TenantShare,
                                SocialServices = tenant.SocialServices,

                                ERAPPaymentReceivedDate = tenant.ERAPPaymentReceivedDate,
                                UnitOrApartmentNumber = tenant.UnitOrApartmentNumber,
                                IsUnitIllegalId = tenant.IsUnitIllegalId,
                                MoveInDate = tenant.MoveInDate,
                            }
                        });
                    }
                }
            }

            // 3️⃣ Search by Building Name
            var buildings = await _context.Buildings

                .Include(b=>b.State)
                 .Include(b => b.PremiseType)
                   .Include(b => b.RegulationStatus)
                 .Include(b => b.Tenants)
                     .ThenInclude(t => t.State)
                .Where(b => b.BuildingCode.ToLower().Contains(searchText))
                .ToListAsync();

            foreach (var building in buildings)
            {
                foreach (var tenant in building.Tenants)
                {
                    result.Add(new DashboardSearchResultDto
                    {
                        BuildingDto = new CreateToBuildingDto
                        {
                            BuildingCode = building.BuildingCode,
                            ApartmentCode = building.ApartmentCode,
                            MDRNumber = building.MDRNumber,
                            BuildingUnits = building.BuildingUnits,
                            PremiseTypeId = building.PremiseTypeId,
                            PremiseTypeName = building.PremiseType.Name,
                            RegulationStatusId = building.RegulationStatusId,
                            RegulationStatusName = building.RegulationStatus.Name,
                            PetitionerInterest = building.PetitionerInterest,
                            Address1 = building.Address1,
                            Address2 = building.Address2,
                            City = building.City,
                            StateId = building.StateId,
                            StateName = building.State != null ? building.State.Name : null,
                            Zipcode = building.Zipcode,

                        },
                        TenantDto = new CreateToTenantDto
                        {

                            TenantCode = tenant.TenantCode,
                            FirstName = tenant.FirstName,
                            LastName = tenant.LastName,
                            Email = tenant.Email,
                            Phone = tenant.Phone,
                            LanguageId = tenant.LanguageId,
                            TenancyTypeId = tenant.TenancyTypeId,
                            SSN = tenant.SSN,
                            TenantRecord = tenant.TenantRecord,
                            RenewalOffer = tenant.RenewalOffer,
                            HasPossession = tenant.HasPossession,
                            HasRegulatedTenancy = tenant.HasRegulatedTenancy,
                            OtherOccupants = tenant.OtherOccupants,
                            HasPriorCase = tenant.HasPriorCase,

                            RentDueEachMonthOrWeekId = tenant.RentDueEachMonthOrWeekId,
                            MonthlyRent = tenant.MonthlyRent,
                            TenantShare = tenant.TenantShare,
                            SocialServices = tenant.SocialServices,

                            ERAPPaymentReceivedDate = tenant.ERAPPaymentReceivedDate,
                            UnitOrApartmentNumber = tenant.UnitOrApartmentNumber,
                            IsUnitIllegalId = tenant.IsUnitIllegalId,
                            MoveInDate = tenant.MoveInDate,
                        }
                    });
                }
            }

            // 4️⃣ Search by Tenant Name
            var tenants = await _context.Tenants
                  .Where(t =>
                             (t.FirstName + " " + t.LastName).ToLower().Contains(searchText.ToLower()) // ✅ Full Name
                             || t.FirstName.ToLower().Contains(searchText.ToLower())                  // ✅ First Name
                             || t.LastName.ToLower().Contains(searchText.ToLower())
                               || t.TenantCode.ToLower().Contains(searchText) // ✅ Last Name
                         )
                .ToListAsync();

            foreach (var tenant in tenants)
            {
                result.Add(new DashboardSearchResultDto
                {
                    TenantDto = new CreateToTenantDto
                    {

                        TenantCode = tenant.TenantCode,
                        FirstName = tenant.FirstName,
                        LastName = tenant.LastName,
                        Email = tenant.Email,
                        Phone = tenant.Phone,
                        LanguageId = tenant.LanguageId,
                        TenancyTypeId = tenant.TenancyTypeId,
                        SSN = tenant.SSN,
                        TenantRecord = tenant.TenantRecord,
                        RenewalOffer = tenant.RenewalOffer,
                        HasPossession = tenant.HasPossession,
                        HasRegulatedTenancy = tenant.HasRegulatedTenancy,
                        OtherOccupants = tenant.OtherOccupants,
                        HasPriorCase = tenant.HasPriorCase,

                        RentDueEachMonthOrWeekId = tenant.RentDueEachMonthOrWeekId,
                        MonthlyRent = tenant.MonthlyRent,
                        TenantShare = tenant.TenantShare,
                        SocialServices = tenant.SocialServices,

                        ERAPPaymentReceivedDate = tenant.ERAPPaymentReceivedDate,
                        UnitOrApartmentNumber = tenant.UnitOrApartmentNumber,
                        IsUnitIllegalId = tenant.IsUnitIllegalId,
                        MoveInDate = tenant.MoveInDate,
                    }
                });
            }

            // 5️⃣ Search by Case Number / Case Type
            var cases = await _context.LegalCases 
                .Include(cs=>cs.CaseType)
                 .Include(cs => cs.ReasonHoldover)
                .Where(cs => cs.Casecode.ToLower().Contains(searchText)
                          || cs.CaseType.Name.ToLower().Contains(searchText))
                .ToListAsync();

            foreach (var legalCase in cases)
            {
                result.Add(new DashboardSearchResultDto
                {
                    caseDto = new CreateToEditLegalCaseModel
                    {
                        Id = legalCase.Id,
                        Casecode = legalCase.Casecode,
                        CaseTypeName = legalCase.CaseType.Name,
                        ReasonHoldoverName = legalCase.ReasonHoldover.Name,
                        Attrney = legalCase.Attrney,
                        AttrneyContactInfo = legalCase.AttrneyContactInfo,
                        Firm = legalCase.Firm


                    },

                });
            }

            return result;
        }
    }

}
