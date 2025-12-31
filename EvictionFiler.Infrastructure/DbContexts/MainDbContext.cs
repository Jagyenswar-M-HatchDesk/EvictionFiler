using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.DbContexts
{
    public class MainDbContext : IdentityDbContext<User, Role, Guid>
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Calander> Calanders { get; set; }
        public DbSet<UserDatabase> UserDatabases { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LandLord> LandLords { get; set; }
        public DbSet<CaseType> MstCaseTypes { get; set; }
        public DbSet<BuildingType> MstBuildingTypes { get; set; }
        public DbSet<CaseTypeHPD> MstCaseTypesHPD { get; set; }
        public DbSet<PartyRepresent> MstPartyRepresents { get; set; }
        public DbSet<PartyRepresentPerDiem> MstPartyRepresentPerDiems { get; set; }
        public DbSet<DocumentTypePerDiem> MstDocumentTypePerDiems { get; set; }
        public DbSet<ReportingTypePerDiem> MstReportingTypePerDiems { get; set; }
        public DbSet<RateType> MstRateTypes { get; set; }
        public DbSet<PaymentMethod> MstPaymentMethods { get; set; }
        public DbSet<AppearanceMode> MstAppearanceModes { get; set; }
        public DbSet<VirtualPlatform> MstVirtualPlatforms { get; set; }
        public DbSet<CourtPart> CourtPart { get; set; }
        public DbSet<CaseStatus> MstCaseStatus { get; set; }
        public DbSet<Registrationstatus> MstRegistrationstatuses { get; set; }

        public DbSet<HarassmentType> MstHarassmentTypes { get; set; }
        public DbSet<AppearanceType> MstAppearanceTypes { get; set; }
        public DbSet<AppearanceTypePerDiem> MstAppearanceTypesPerDiems { get; set; }
        public DbSet<AppearanceTypeforHearing> MstAppearanceTypesForHearing { get; set; }
        public DbSet<ReliefPetitionerType> MstReliefPetitionerTypes { get; set; }
        public DbSet<ReliefRespondentType> MstReliefRespondentTypes { get; set; }
        public DbSet<RemainderType> MstRemainderTypes { get; set; }
        public DbSet<RemainderCenter> TblRemainderCenter { get; set; }
        public DbSet<BilingType> MstBilingTypes { get; set; }
        public DbSet<DefenseType> MstDefenseTypes { get; set; }
        public DbSet<County> MstCounties { get; set; }
        public DbSet<Category> MstCategories { get; set; }
        public DbSet<LandlordType> MstLandlordTypes { get; set; }
        public DbSet<CaseSubType> MstCaseSubTypes { get; set; }

        public DbSet<CaseTypePerdiem> MstCaseTypePerdiems { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<LegalCase> LegalCases { get; set; }
        public DbSet<AdditionalOccupants> AdditionalOccupants { get; set; }
        public DbSet<AdditioanlTenants> AdditioanlTenants { get; set; }
        public DbSet<TypeOfOwner> MstTypeOfOwners { get; set; }
        public DbSet<ClientRole> MstClientRoles { get; set; }
        public DbSet<RenewalStatus> MstRenewalStatus { get; set; }
        public DbSet<FormTypes> MstFormTypes { get; set; }
        public DbSet<DateRent> MstDateRent { get; set; }
        public DbSet<CaseForms> CaseForms { get; set; }
        public DbSet<Language> MstLanguages { get; set; }
        public DbSet<PremiseType> MstPremiseTypes { get; set; }
        public DbSet<TenancyType> MstTenancyTypes { get; set; }
        public DbSet<ReasonHoldover> MstReasonHoldover { get; set; }
        public DbSet<IsUnitIllegal> MstIsUnitIllegal { get; set; }
        public DbSet<RegulationStatus> MstRegulationStatus { get; set; }
        public DbSet<State> MstStates { get; set; }
        public DbSet<CaseProgram> MstCaseProgram { get; set; }
        public DbSet<Courts> Courts { get; set; }
        public DbSet<CaseAdditionalTenants> CaseAdditionalTenants { get; set; }

        public DbSet<FeesCatalog> FeesCatalogs { get; set; }
        public DbSet<FeesCatalogCourtAppearance> FeesCatalogCourtAppearances { get; set; }
        public DbSet<FeesCatalogAttorneyRoster> FeesCatalogAttorneyRosters { get; set; }
        public DbSet<CaseHearing> CaseHearings { get; set; }
        public DbSet<Unit> MstUnits { get; set; }
        public DbSet<CaseDocument> CaseDocument { get; set; }
        public DbSet<FilingMethod> MstFilingMethod { get; set; }
        public DbSet<ServiceMethod> MstServiceMethod { get; set; }
        public DbSet<ArrearLedger> ArrearLedgers { get; set; }

        public DbSet<Marshal> Marshal { get; set; }
        public DbSet<SubCaseType> MstSubCaseTypes { get; set; }
        public DbSet<City> MstCities { get; set; }
        public DbSet<CourtType> MstCourtType { get; set; }
        public DbSet<TenancyTypeForBuilding> MstTenancyTypesForBuilding { get; set; }
        public DbSet<ExemptionBasic> MstExemptionBasic { get; set; }
        public DbSet<ExemptionReason> MstExemptionReason { get; set; }
        public DbSet<CaseAdditionalPetitioner> CaseAdditionalPetitioners { get; set; }
        public DbSet<CaseAdditionalRespondent> CaseAdditionalResondents { get; set; }
        public DbSet<CaseNoticeInfo> CaseNoticeInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeesCatalog>()
    .ToTable("FeesCatalog", schema: "dbo");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.Parse("f5ab29da-356e-42df-a3ad-d91bbf644550"), Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = Guid.Parse("56355bf6-e335-428a-b718-00cb79e5273d"), Name = "Law Firm", NormalizedName = "LAW FIRM" },
                new Role { Id = Guid.Parse("2bb5c3bf-8dd8-4415-9090-1d428c792533"), Name = "Property Manager", NormalizedName = "PROPERTY MANAGER" }

            );

            //var password = new PasswordHasher<object>().HashPassword(null, "Abcd@1234");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("84722e9d-806c-4f49-94d7-a55de8d2d76e"),
                    FirstName = "Admin",
                    CreatedOn = new DateTime(2024, 6, 19, 12, 0, 0, DateTimeKind.Utc),
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    IsActive = true,
                    RoleId = Guid.Parse("f5ab29da-356e-42df-a3ad-d91bbf644550"),
                    EmailConfirmed = true,
                    SecurityStamp = "38fef087-d2ad-4e78-9823-123456789abc",
                    ConcurrencyStamp = "12456e31-62c3-4db3-a8fc-987654321def",
                    PasswordHash = "AQAAAAIAAYagAAAAEHXHMy52Ji1wPk8MrXLQrX8XKJekP1rHPXwmwtgFmlmiCdkN7lYlOlLlaOVXJ2SKcw=="
                }
            );


            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("84722e9d-806c-4f49-94d7-a55de8d2d76e"),
                    RoleId = Guid.Parse("f5ab29da-356e-42df-a3ad-d91bbf644550")
                }
            );
        }
    }
}
