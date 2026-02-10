using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.AspNetCore.Identity;
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
        public static IEnumerable<AdjournedReason> GetAdjournedReasons()
        {
            var now = DateTime.UtcNow;
            return new List<AdjournedReason>
            {
                new AdjournedReason() { Name = "By Court", CreatedOn = now },
                new AdjournedReason() { Name = "By Stipulation", CreatedOn = now },
                new AdjournedReason() { Name = "Motion Practice", CreatedOn = now },
               
            };
        }
        public static IEnumerable<Role> GetUserRoles()
        {
            var now = DateTime.UtcNow;
            return new List<Role>
            {
                new Role() { Name = "Super Admin", Description="Owner of the app.", CreatedOn = now },
                new Role() { Name = "Admin", Description="Owner of a firm.", CreatedOn = now },
                new Role() { Name = "Staff Member", Description="Employee of a firm", CreatedOn = now },
                new Role() { Name = "Client", Description="Client of a firm.", CreatedOn = now },
               
            };
        }
        public static IEnumerable<SubscriptionType> GetSubscriptionTypes()
        {
            var now = DateTime.UtcNow;
            return new List<SubscriptionType>
            {
                new SubscriptionType() { Name = "Enterprises", CreatedOn = now },
                new SubscriptionType() { Name = "PayAsYouGo", CreatedOn = now },
               
            };
        }
        
        public static IEnumerable<User> GetUser()
        {
            var now = DateTime.UtcNow;
            return new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Admin12",
                    CreatedOn = DateTime.Now,
                    Email = "admin12@gmail.com",
                    UserName = "admin12@gmail.com",
                    NormalizedEmail = "ADMIN12@GMAIL.COM",
                    NormalizedUserName = "ADMIN12@GMAIL.COM",
                    IsActive = true,
                    RoleId = Guid.Parse("f5ab29da-356e-42df-a3ad-d91bbf644550"),
                    EmailConfirmed = true,
                    SecurityStamp = "38fef087-d2ad-4e78-9823-123456789abc",
                    ConcurrencyStamp = "12456e31-62c3-4db3-a8fc-987654321def",
                    PasswordHash = new PasswordHasher<object>().HashPassword(null, "Abcd@1234")
                }
            };
        }
        
              public static IEnumerable<AppearanceTypeforHearing> GetAppearanceTypeforHearing()
        {
            var now = DateTime.UtcNow;
            return new List<AppearanceTypeforHearing>
            {
                new AppearanceTypeforHearing() { Name = "Virtual", CreatedOn = now },
                new AppearanceTypeforHearing() { Name = "1st Time", CreatedOn = now },
                new AppearanceTypeforHearing() { Name = "Motion", CreatedOn = now },
                new AppearanceTypeforHearing() { Name = "Pre-Trial", CreatedOn = now },
                new AppearanceTypeforHearing() { Name = "Part X", CreatedOn = now },
                  new AppearanceTypeforHearing() { Name = "Transverse / Trial", CreatedOn = now },
                    new AppearanceTypeforHearing() { Name = "Post Evict", CreatedOn = now },
                      new AppearanceTypeforHearing() { Name = "Harassment", CreatedOn = now },
                      new AppearanceTypeforHearing() { Name = "HPD", CreatedOn = now },
                      new AppearanceTypeforHearing() { Name = "Trial", CreatedOn = now },
                         new AppearanceTypeforHearing() { Name = "Inquest", CreatedOn = now },
                          new AppearanceTypeforHearing() { Name = "Compliance Status", CreatedOn = now },
                           new AppearanceTypeforHearing() { Name = "OSC / Emergency", CreatedOn = now },
            };
        }

        public static IEnumerable<SubCaseType> GetSubCaseTypes()
        {
            var now = DateTime.UtcNow;
            return new List<SubCaseType>
            {
                new SubCaseType() { Name = "Commercial", CreatedOn = now },
                new SubCaseType() { Name = "Residential", CreatedOn = now },
            };
        }
        public static IEnumerable<ReminderEscalate> GetReminderEscalates()
        {
            var now = DateTime.UtcNow;
            return new List<ReminderEscalate>
            {
                new ReminderEscalate() { Name = "Admin", CreatedOn = now },
                new ReminderEscalate() { Name = "None", CreatedOn = now },
                new ReminderEscalate() { Name = "Supervising Attorney", CreatedOn = now },
            };
        }
        public static IEnumerable<ReminderCategory> GetReminderCategory()
        {
            var now = DateTime.UtcNow;
            return new List<ReminderCategory>
            {
                new ReminderCategory() { Name = "Court", CreatedOn = now },
                new ReminderCategory() { Name = "Payment", CreatedOn = now },
                new ReminderCategory() { Name = "Warrant", CreatedOn = now },
                new ReminderCategory() { Name = "Critical", CreatedOn = now },
            };
        }
        public static IEnumerable<CourtToday> GetCourtToday()
        {
            var now = DateTime.UtcNow;
            return new List<CourtToday>
            {
                new CourtToday() { Name = "Adjourned", CreatedOn = now },
                new CourtToday() { Name = "Adjourned for Motion Practice", CreatedOn = now },
                new CourtToday() { Name = "Stipulation (No Judgement)", CreatedOn = now },
                new CourtToday() { Name = "Stipulation With Judgement", CreatedOn = now },
                new CourtToday() { Name = "Final Judgement + Warrant", CreatedOn = now },
                new CourtToday() { Name = "Money Judgement Only", CreatedOn = now },
                new CourtToday() { Name = "Case Settled / Discontinued", CreatedOn = now },
            };
        }
        public static IEnumerable<DocumentType> GetDocumentType()
        {
            var now = DateTime.UtcNow;
            return new List<DocumentType>
            {
                new DocumentType() { Name = "Show on the detail screen", CreatedOn = now , IsProcessServer= false },
                new DocumentType() { Name = "Signed Good Cause Article 6A", CreatedOn = now, IsProcessServer= false },
                new DocumentType() { Name = "Notice of Appearance", CreatedOn = now , IsProcessServer= false},
                new DocumentType() { Name = "Stipulation", CreatedOn = now , IsProcessServer = false},
                new DocumentType() { Name = "Judgement and Warrant", CreatedOn = now , IsProcessServer = false},
                new DocumentType() { Name = "Decision/Order", CreatedOn = now , IsProcessServer = false},
                new DocumentType() { Name = "Notice of Eviction", CreatedOn = now , IsProcessServer = false},
                new DocumentType() { Name = "OSC/Motion", CreatedOn = now , IsProcessServer = false},
                new DocumentType() { Name = "Rent Ledger", CreatedOn = now , IsProcessServer = false},
                new DocumentType() { Name = "Affidavit of Service - Demand Notice", CreatedOn = now , IsProcessServer = true},
                new DocumentType() { Name = "Affidavit of Service - Petition/Notice of Petition", CreatedOn = now , IsProcessServer = true},
                new DocumentType() { Name = "Non Military Affidavit", CreatedOn = now , IsProcessServer = true},
            };
        }

        public static IEnumerable<AppearanceMode> GetAppearanceMode()
        {
            var now = DateTime.UtcNow;
            return new List<AppearanceMode>
            {
                new AppearanceMode() { Name = "In Person", CreatedOn = now },
                new AppearanceMode() { Name = "Virtual", CreatedOn = now },
            };
        }
        public static IEnumerable<VirtualPlatform> GetVirtualPlatform()
        {
            var now = DateTime.UtcNow;
            return new List<VirtualPlatform>
            {
                new VirtualPlatform() { Name = "Google Meet", CreatedOn = now },
                new VirtualPlatform() { Name = "MS Teams", CreatedOn = now },
            };
        }
        public static IEnumerable<CourtType> GetCourtTypes()
        {
            var now = DateTime.UtcNow;
            return new List<CourtType>
            {
                new CourtType() { Name = "Nassau Courts", CreatedOn = now },
                new CourtType() { Name = "NYC Courts", CreatedOn = now },
                new CourtType() { Name = "Westchester Courts", CreatedOn = now },
            };
        }
        public static IEnumerable<City> GetCities()
        {
            var now = DateTime.UtcNow;
            return new List<City>
            {
                new City() { Name = "New York", CreatedOn = now },
                new City() { Name = "Kings", CreatedOn = now },
                new City() { Name = "Queens", CreatedOn = now },
                new City() { Name = "Bronx", CreatedOn = now },
                new City() { Name = "Richmond", CreatedOn = now },
            };
        }
        public static IEnumerable<RemainderType> GetRemainderTypes()
        {
            var now = DateTime.UtcNow;
            return new List<RemainderType>
    {
        new RemainderType { Name = "End of predicate notice", CreatedOn = now },
        new RemainderType { Name = "Notice of Petition filing", CreatedOn = now },
        new RemainderType { Name = "Petition filing", CreatedOn = now },
        new RemainderType { Name = "Affidavit of Service", CreatedOn = now },
        new RemainderType { Name = "Warrant eligible", CreatedOn = now },
        new RemainderType { Name = "Opposition Due (motion)", CreatedOn = now },
        new RemainderType { Name = "Reply Due (motion)", CreatedOn = now },
        new RemainderType { Name = "Cross-Motion Deadline", CreatedOn = now },
        new RemainderType { Name = "OSC Opposition Due", CreatedOn = now },
        new RemainderType { Name = "Temporary Stay Expires", CreatedOn = now },
        new RemainderType { Name = "Undertaking / U&O Payment Due", CreatedOn = now },
        new RemainderType { Name = "Adjournment Cut-Off", CreatedOn = now },
        new RemainderType { Name = "Decision Tickler (D+30)", CreatedOn = now },
        new RemainderType { Name = "Decision Tickler (D+60)", CreatedOn = now },
        new RemainderType { Name = "Decision Tickler (D+90)", CreatedOn = now },
        new RemainderType { Name = "Certificate of Service Filing", CreatedOn = now },
        new RemainderType { Name = "Marshal: Day of", CreatedOn = now },
         new RemainderType { Name = "Appeal Notice Deadline", CreatedOn = now },
        new RemainderType { Name = "New filing by opposing counsel", CreatedOn = now }
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

        public static IEnumerable<Unit> GetUnitTypes()
        {
            var now = DateTime.UtcNow;
            return new List<Unit>
            {
                new Unit() { Name = "item", CreatedOn = now },
                new Unit() { Name = "hour", CreatedOn = now },
                new Unit() { Name = "flat", CreatedOn = now },
                new Unit() { Name = "page", CreatedOn = now },

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
                new CaseType() { Name = "Illegal Lockout", CreatedOn = now },
                new CaseType() { Name = "Tenants", CreatedOn = now },
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

        public static IEnumerable<CaseTypePerdiem> GetCaseTypesPerDiem()
        {
            var now = DateTime.UtcNow;
            return new List<CaseTypePerdiem>
            {
                new CaseTypePerdiem() { Name = "Residential Holdover", CreatedOn = now },
                new CaseTypePerdiem() { Name = "Residential Nonpayment", CreatedOn = now },
                new CaseTypePerdiem() { Name = "HPD/Code Enforcement", CreatedOn = now },
                new CaseTypePerdiem() { Name = "Commercial Case", CreatedOn = now },
                new CaseTypePerdiem() { Name = "Illegal Lockout", CreatedOn = now },
                new CaseTypePerdiem() { Name = "Post‑Eviction / Restoration", CreatedOn = now },
                 new CaseTypePerdiem() { Name = "Other", CreatedOn = now },

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

        public static IEnumerable<AppearanceTypePerDiem> GetAppearanceTypesPerDiem()
        {
            var now = DateTime.UtcNow;
            return new List<AppearanceTypePerDiem>
            {
                new AppearanceTypePerDiem() { Name = "First Appearance / Return Date", CreatedOn = now },
                new AppearanceTypePerDiem() { Name = "Motion / OSC Hearing", CreatedOn = now },
                new AppearanceTypePerDiem() { Name = "Trial / Evidentiary Hearing", CreatedOn = now },
                new AppearanceTypePerDiem() { Name = "Post‑Eviction Motion (Restoration, ERAP, etc.)", CreatedOn = now },
                   new AppearanceTypePerDiem() { Name = "HPD Compliance / Inspection Hearing", CreatedOn = now },
                    new AppearanceTypePerDiem() { Name = "Other", CreatedOn = now },

            };
        }
        public static IEnumerable<DocumentTypePerDiem> GetDocumentTypesPerDiem()
        {
            var now = DateTime.UtcNow;
            return new List<DocumentTypePerDiem>
            {
                new DocumentTypePerDiem() { Name = "Petition/Answer", CreatedOn = now },
                new DocumentTypePerDiem() { Name = "Lease / Rent Ledger", CreatedOn = now },
                new DocumentTypePerDiem() { Name = "Prior Orders", CreatedOn = now },
                new DocumentTypePerDiem() { Name = "Inspection Reports", CreatedOn = now },
                   new DocumentTypePerDiem() { Name = "Stipulations", CreatedOn = now },
                    new DocumentTypePerDiem() { Name = "Other", CreatedOn = now },

            };
        }

        public static IEnumerable<ReportingTypePerDiem> GetReportingTypePerDiems()
        {
            var now = DateTime.UtcNow;
            return new List<ReportingTypePerDiem>
            {
                new ReportingTypePerDiem() { Name = "Written Court Report (Outcome, Next Date, Judge’s Notes)", CreatedOn = now },
                new ReportingTypePerDiem() { Name = "Copy of Any Stipulation/Order Signed", CreatedOn = now },
                new ReportingTypePerDiem() { Name = "Updated Case Status in Platform", CreatedOn = now },
                

            };
        }
        public static IEnumerable<RateType> GetRateTypes()
        {
            var now = DateTime.UtcNow;
            return new List<RateType>
            {
                new RateType() { Name = "Flat", CreatedOn = now },
                new RateType() { Name = "Hourly", CreatedOn = now },
               


            };
        }

        public static IEnumerable<PaymentMethod> GetPaymentMethod()
        {
            var now = DateTime.UtcNow;
            return new List<PaymentMethod>
            {
                new PaymentMethod() { Name = "Direct Pay (check/ACH)", CreatedOn = now },
                new PaymentMethod() { Name = "Platform Invoice (EvictionFiler.com)", CreatedOn = now },

            };
        }
        public static IEnumerable<Category> GetCategory()
        {
            var now = DateTime.UtcNow;
            return new List<Category>
            {
                new Category() { Name = "Holdover", CreatedOn = now },
                new Category() { Name = "NonPayment - Predicate", CreatedOn = now },
                new Category() { Name = "Warrant - Marshal", CreatedOn = now },
                new Category() { Name = "Process - Server", CreatedOn = now },
                new Category() { Name = "Appearance - Matrix", CreatedOn = now },
                new Category() { Name = "Filling - Admin", CreatedOn = now },
                new Category() { Name = "Manage Attorney & default hourly Rates", CreatedOn = now },

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

        public static IEnumerable<PartyRepresentPerDiem> GetPartyRepresentPerDiem()
        {
            var now = DateTime.UtcNow;
            return new List<PartyRepresentPerDiem>
            {
                new PartyRepresentPerDiem() { Name = "Petitioner (Landlord/Owner/Managing Agent)", CreatedOn = now },
                new PartyRepresentPerDiem() { Name = "Respondent (Tenant/Occupant)", CreatedOn = now },


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
                new County() { Name = "Richmond", CreatedOn = now },
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

        public static IEnumerable<FilingMethod> GetFilingMethod()
        {
            var now = DateTime.UtcNow;
            return new List<FilingMethod>
            {
                new FilingMethod() { Name = "Electronic", CreatedOn = now },
                new FilingMethod() { Name = "In Person", CreatedOn = now },
            };
        }

        public static IEnumerable<ServiceMethod> GetServiceMethod()
        {
            var now = DateTime.UtcNow;
            return new List<ServiceMethod>
            {
                new ServiceMethod() { Name = "Personal", CreatedOn = now },
                new ServiceMethod() { Name = "Overnight", CreatedOn = now },
                new ServiceMethod() { Name = "Mail", CreatedOn = now },
                new ServiceMethod() { Name = "Posting + Mail", CreatedOn = now },
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
                 new PremiseType() { Name = "Multiple Dwelling", CreatedOn = now },
                  new PremiseType() { Name = "Other", CreatedOn = now },
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
                 new RegulationStatus() { Name = "Exempt", CreatedOn = now },
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
                new FormTypes() { Name = "Demand Notice", CaseTypeName = "HoldOver", HTML = "", CreatedOn = now },
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

        public static IEnumerable<TenancyTypeForBuilding> GetTenancyTypesForBuilding()
        {
            var now = DateTime.UtcNow;
            return new List<TenancyTypeForBuilding>
            {
                new TenancyTypeForBuilding() { Name = "Month-to-Month", CreatedOn = now },
                new TenancyTypeForBuilding() { Name = "Expired Lease", CreatedOn = now },
                new TenancyTypeForBuilding() { Name = "Licensee", CreatedOn = now },
                new TenancyTypeForBuilding() { Name = "Squatter", CreatedOn = now },
           
            };
        }

        public static IEnumerable<ExemptionReason> GetExemptionReason()
        {
            var now = DateTime.UtcNow;
            return new List<ExemptionReason>
            {
                new ExemptionReason() { Name = "Owner occupied ≤ 10 units", CreatedOn = now },
                new ExemptionReason() { Name = "Small landlord", CreatedOn = now },
                new ExemptionReason() { Name = "Regulated unit", CreatedOn = now },
                new ExemptionReason() { Name = "Other statutory exemption", CreatedOn = now },

            };
        }

        public static IEnumerable<ExemptionBasic> GetExemptionBasic()
        {
            var now = DateTime.UtcNow;
            return new List<ExemptionBasic>
            {
                new ExemptionBasic() { Name = "1–2 Family Owner Occupied", CreatedOn = now },
                new ExemptionBasic() { Name = "Post-1974 Construction", CreatedOn = now },
                new ExemptionBasic() { Name = "High Rent Vacancy", CreatedOn = now },
                new ExemptionBasic() { Name = "Other", CreatedOn = now },

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
