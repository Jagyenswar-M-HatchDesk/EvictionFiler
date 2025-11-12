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

        public static IEnumerable<BilingType> GetBilingTypes()
        {
            var now = DateTime.UtcNow;
            return new List<BilingType>
            {
                new BilingType() { Name = "Hourly ($/hr)", CreatedOn = now },
                new BilingType() { Name = "Flat Rate", CreatedOn = now },
                
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

        public static IEnumerable<CaseTypeHPD> GetCaseTypesHPD()
        {
            var now = DateTime.UtcNow;
            return new List<CaseTypeHPD>
            {
                new CaseTypeHPD() { Name = "HPD Harassment Proceeding", CreatedOn = now },
                new CaseTypeHPD() { Name = "HPD Code Enforcement / Repairs", CreatedOn = now },
                new CaseTypeHPD() { Name = "Other", CreatedOn = now },
                
            };
        }
        public static IEnumerable<BuildingType> GetBuildingTypes()
        {
            var now = DateTime.UtcNow;
            return new List<BuildingType>
            {
                new BuildingType() { Name = "Multiple Dwelling", CreatedOn = now },
                new BuildingType() { Name = "Two-Family", CreatedOn = now },
                new BuildingType() { Name = "Other", CreatedOn = now },

            };
        }

        public static IEnumerable<DefenseType> GetDefensetypes()
        {
            var now = DateTime.UtcNow;
            return new List<DefenseType>
            {
                new DefenseType() { Name = "All services are being provided; no interruption proven", CreatedOn = now },
                new DefenseType() { Name = "Tenant has refused access for repairs", CreatedOn = now },
                new DefenseType() { Name = "Tenant caused conditions complained of", CreatedOn = now },
                new DefenseType() { Name = "Tenant owes rent / is using harassment claim as defense", CreatedOn = now },
                new DefenseType() { Name = "Violations cited were corrected / do not exist", CreatedOn = now },
                new DefenseType() { Name = "Other defenses", CreatedOn = now },

            };
        }

        public static IEnumerable<ReliefPetitionerType> GetReliefPetitionerTypes()
        {
            var now = DateTime.UtcNow;
            return new List<ReliefPetitionerType>
            {
                new ReliefPetitionerType() { Name = "Order to Correct", CreatedOn = now },
                new ReliefPetitionerType() { Name = "Civil Penalties against Landlord", CreatedOn = now },
                new ReliefPetitionerType() { Name = "Finding of Harassment", CreatedOn = now },
                new ReliefPetitionerType() { Name = "Access Order for repairs", CreatedOn = now },
                new ReliefPetitionerType() { Name = "Restoration to possession (if lockout)", CreatedOn = now },
                new ReliefPetitionerType() { Name = "Other", CreatedOn = now },

            };
        }

        public static IEnumerable<ReliefRespondentType> GetReliefRespondentTypes()
        {
            var now = DateTime.UtcNow;
            return new List<ReliefRespondentType>
            {
                new ReliefRespondentType() { Name = "Dismissal of Proceeding", CreatedOn = now },
                new ReliefRespondentType() { Name = "Vacatur of Orders to Correct", CreatedOn = now },
                new ReliefRespondentType() { Name = "Denial of Harassment Finding", CreatedOn = now },
                new ReliefRespondentType() { Name = "Access Order for repairs", CreatedOn = now },
                new ReliefRespondentType() { Name = "Costs / Sanctions against Tenant", CreatedOn = now },
                new ReliefRespondentType() { Name = "Other", CreatedOn = now },

            };
        }

        public static IEnumerable<AppearanceType> GetAppearanceTypes()
        {
            var now = DateTime.UtcNow;
            return new List<AppearanceType>
            {
                new AppearanceType() { Name = "First Appearance / Intake", CreatedOn = now },
                new AppearanceType() { Name = "Trial / Hearing", CreatedOn = now },
                new AppearanceType() { Name = "Motion / OSC Return Date", CreatedOn = now },
                new AppearanceType() { Name = "Adjournment / Stipulation", CreatedOn = now },
                   new AppearanceType() { Name = "Other", CreatedOn = now },

            };
        }


        public static IEnumerable<HarassmentType> GetHarassmentTypes()
        {
            var now = DateTime.UtcNow;
            return new List<HarassmentType>
            {
                new HarassmentType() { Name = "Repeated interruptions of essential services (heat, hot water, gas, electricity)", CreatedOn = now },
                new HarassmentType() { Name = "Failure to make necessary repairs", CreatedOn = now },
                new HarassmentType() { Name = "Threats, intimidation, or verbal abuse", CreatedOn = now },
                 new HarassmentType() { Name = "Illegal lockout attempts / changed locks", CreatedOn = now },
                  new HarassmentType() { Name = "Unlawful entry into apartment", CreatedOn = now },
                   new HarassmentType() { Name = "Commenced frivolous court proceedings", CreatedOn = now },
                    new HarassmentType() { Name = "Other acts", CreatedOn = now },

            };
        }
        public static IEnumerable<Registrationstatus> GetRegistrationStatus()
        {
            var now = DateTime.UtcNow;
            return new List<Registrationstatus>
            {
                new Registrationstatus() { Name = "Registered", CreatedOn = now },
                new Registrationstatus() { Name = "Not Registered", CreatedOn = now },
                new Registrationstatus() { Name = "UnKnown ", CreatedOn = now },

            };
        }



        public static IEnumerable<PartyRepresent> GetPartyRepresent()
        {
            var now = DateTime.UtcNow;
            return new List<PartyRepresent>
            {
                new PartyRepresent() { Name = "Petitioner (Tenant/Occupant)", CreatedOn = now },
                new PartyRepresent() { Name = "Respondent (Landlord/Owner/Managing Agent)", CreatedOn = now },
               

            };
        }

        public static IEnumerable<County> GetCounty()
        {
            var now = DateTime.UtcNow;
            return new List<County>
            {
                new County() { Name = "New York", CreatedOn = now },
                new County() { Name = "Kings", CreatedOn = now },
                new County() { Name = "Queens", CreatedOn = now },
                new County() { Name = "Bronx", CreatedOn = now },

            };
        }

        public static IEnumerable<CourtPart> GetCourtPart()
        {
            var now = DateTime.UtcNow;
            return new List<CourtPart>
            {
                new CourtPart() { Name = "Intake 1", CreatedOn = now },
                new CourtPart() { Name = "Part A", CreatedOn = now },
                new CourtPart() { Name = "Part B", CreatedOn = now },
                new CourtPart() { Name = "Part C", CreatedOn = now },

            };
        }
        public static IEnumerable<CaseStatus> GetCaseStatus()
        {
            var now = DateTime.UtcNow;
            return new List<CaseStatus>
            {
                new CaseStatus() { Name = "Open", CreatedOn = now },
                new CaseStatus() { Name = "Active", CreatedOn = now },
                new CaseStatus() { Name = "Settled", CreatedOn = now },
                new CaseStatus() { Name = "Pending", CreatedOn = now },
                new CaseStatus() { Name = "Under Review", CreatedOn = now },
                new CaseStatus() { Name = "Continued", CreatedOn = now },
                new CaseStatus() { Name = "Dismissed", CreatedOn = now },

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
