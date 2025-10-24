using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvictionFiler.Infrastructure.DataSeeding
{
    public class InitialDataGenerator
    {
        public static IEnumerable<Language> GetLangauge()
        {
            var now = DateTime.UtcNow;
            return new List<Language>
            {
                new Language() { Name = "English", CreatedOn = now },
                new Language() { Name = "Spanish", CreatedOn = now },
                new Language() { Name = "Hindi", CreatedOn = now },
                new Language() { Name = "French", CreatedOn = now },
                new Language() { Name = "Chienese", CreatedOn = now },
            };
        }

        public static IEnumerable<CaseType> GetCaseTypes()
        {
            var now = DateTime.UtcNow;
            return new List<CaseType>
            {
                new CaseType() { Name = "Holdover", CreatedOn = now },
                new CaseType() { Name = "NonPayment", CreatedOn = now },
                new CaseType() { Name = "HPD", CreatedOn = now },
                new CaseType() { Name = "Per Diem", CreatedOn = now },
            };
        }

        public static IEnumerable<ClientRole> GetClientRoles()
        {
            var now = DateTime.UtcNow;
            return new List<ClientRole>
            {
                new ClientRole() { Name = "Attorney", Description="Represents the legal counsel for the landlord or client", CreatedOn = now, CreatedBy=Guid.Parse("84722E9D-806C-4F49-94D7-A55DE8D2D76E") },
                new ClientRole() { Name = "Managing Agent", Description="Represents the property management agent handling the case", CreatedOn = now, CreatedBy=Guid.Parse("84722E9D-806C-4F49-94D7-A55DE8D2D76E") },
                new ClientRole() { Name = "Owner/Landlord", Description="Represents the property owner or landlord", CreatedOn = now, CreatedBy=Guid.Parse("84722E9D-806C-4F49-94D7-A55DE8D2D76E") },
            };
        }


        public static IEnumerable<CaseProgram> GetCasePrograms()
        {
            var now = DateTime.UtcNow;
            return new List<CaseProgram>
            {
                new CaseProgram() { Name = "Section 8",  CreatedOn = now, CreatedBy=Guid.Parse("84722E9D-806C-4F49-94D7-A55DE8D2D76E") },
                new CaseProgram() { Name = "City FHEPS", CreatedOn = now, CreatedBy=Guid.Parse("84722E9D-806C-4F49-94D7-A55DE8D2D76E") },
            };
        }
        public static IEnumerable<RenewalStatus> GetRenewalStatus()
        {
            var now = DateTime.UtcNow;
            return new List<RenewalStatus>
            {
                new RenewalStatus() { Name = "Renewed", CreatedOn = now },
                new RenewalStatus() { Name = "Not Renewed", CreatedOn = now },
            };
        }

        public static IEnumerable<PremiseType> GetPremiseType()
        {
            var now = DateTime.UtcNow;
            return new List<PremiseType>
            {
                new PremiseType() { Name = "One Family", CreatedOn = now },
                new PremiseType() { Name = "Two Family", CreatedOn = now },
                new PremiseType() { Name = "Three Family", CreatedOn = now },
                new PremiseType() { Name = "Four Family", CreatedOn = now },
            };
        }

        public static IEnumerable<RegulationStatus> GetRegulationStatus()
        {
            var now = DateTime.UtcNow;
            return new List<RegulationStatus>
            {
                new RegulationStatus() { Name = "Rent Stablised", CreatedOn = now },
                new RegulationStatus() { Name = "Controlled", CreatedOn = now },
                new RegulationStatus() { Name = "Market", CreatedOn = now },
                new RegulationStatus() { Name = "Section 8", CreatedOn = now },
                new RegulationStatus() { Name = "FHEPS", CreatedOn = now },
                new RegulationStatus() { Name = "Other", CreatedOn = now },
            };
        }

        public static IEnumerable<DateRent> GetDateRent()
        {
            var now = DateTime.UtcNow;
            return Enumerable.Range(1, 31)
                .Select(i => new DateRent { Name = i.ToString(), CreatedOn = now })
                .ToList();
        }

        public static IEnumerable<State> GetState()
        {
            var now = DateTime.UtcNow;
            return new List<State>
            {
                new State() { Name = "Georgia", CreatedOn = now },
                new State() { Name = "Calofornia", CreatedOn = now },
                new State() { Name = "Florida", CreatedOn = now },
                new State() { Name = "New York", CreatedOn = now },
            };
        }

        public static IEnumerable<TypeOfOwner> GetTypeOfOwner()
        {
            var now = DateTime.UtcNow;
            return new List<TypeOfOwner>
            {
                new TypeOfOwner() { Name = "Corportaion", CreatedOn = now },
                new TypeOfOwner() { Name = "LLC", CreatedOn = now },
                new TypeOfOwner() { Name = "Individual", CreatedOn = now },
                new TypeOfOwner() { Name = "Other", CreatedOn = now },
            };
        }

        public static IEnumerable<FormTypes> GetFormTypes()
        {
            var now = DateTime.UtcNow;
            return new List<FormTypes>
            {
                new FormTypes() { Name = "90 Days Notice", CaseTypeName = "HoldOver", HTML = "", CreatedOn = now },
                new FormTypes() { Name = "5 Days Notice", CaseTypeName = "NonPayment", HTML = "", CreatedOn = now },
                new FormTypes() { Name = "14 Days Notice", CaseTypeName = "NonPayment", HTML = "", CreatedOn = now },
            };
        }

        public static IEnumerable<LandlordType> GetLandlordTypes()
        {
            var now = DateTime.UtcNow;
            return new List<LandlordType>
            {
                new LandlordType() { Name = "OwnerOfRecord", CreatedOn = now },
                new LandlordType() { Name = "Agent", CreatedOn = now },
                new LandlordType() { Name = "RefereeOwner", CreatedOn = now },
                new LandlordType() { Name = "Other", CreatedOn = now },
            };
        }

        public static IEnumerable<TenancyType> GetTenancyTypes()
        {
            var now = DateTime.UtcNow;
            return new List<TenancyType>
            {
                new TenancyType() { Name = "Month-to-Month", CreatedOn = now },
                new TenancyType() { Name = "At Will", CreatedOn = now },
                new TenancyType() { Name = "Squatter", CreatedOn = now },
                new TenancyType() { Name = "Section-8", CreatedOn = now },
                new TenancyType() { Name = "Other", CreatedOn = now },
            };
        }

        public static IEnumerable<IsUnitIllegal> GetIsUnitIllegal()
        {
            var now = DateTime.UtcNow;
            return new List<IsUnitIllegal>
            {
                new IsUnitIllegal() { Name = "Basement Apartment", CreatedOn = now },
                new IsUnitIllegal() { Name = "Roming House ", CreatedOn = now },
                new IsUnitIllegal() { Name = "Attic", CreatedOn = now },
                new IsUnitIllegal() { Name = "None", CreatedOn = now },
            };
        }

        public static IEnumerable<ReasonHoldover> GetReasonHoldover()
        {
            var now = DateTime.UtcNow;
            return new List<ReasonHoldover>
            {
                new ReasonHoldover() { Name = "Month-to-Month", CreatedOn = now },
                new ReasonHoldover() { Name = "Licencsee", CreatedOn = now },
                new ReasonHoldover() { Name = "Non-Primary Residence", CreatedOn = now },
                new ReasonHoldover() { Name = "Squatter", CreatedOn = now },
                new ReasonHoldover() { Name = "Tenant Vacated", CreatedOn = now },
                new ReasonHoldover() { Name = "Lease Violation", CreatedOn = now },
                new ReasonHoldover() { Name = "Commercial", CreatedOn = now },
                new ReasonHoldover() { Name = "Prior Owner", CreatedOn = now },
                new ReasonHoldover() { Name = "At Will", CreatedOn = now },
                new ReasonHoldover() { Name = "Other", CreatedOn = now },
            };
        }
    }
}
