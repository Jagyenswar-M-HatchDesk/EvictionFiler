using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations.Tenants
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateRent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateRent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IsUnitIllegal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsUnitIllegal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandlordType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandlordType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PremiseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReasonHoldover",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonHoldover", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegulationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RenewalStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenewalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenancyType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenancyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseSubType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CaseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSubType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseSubType_CaseType_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LandLords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LandLordCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeOfOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EINorSSN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfRefreeDeed = table.Column<DateOnly>(type: "date", nullable: false),
                    LandlordTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandLords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandLords_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LandLords_LandlordType_LandlordTypeId",
                        column: x => x.LandlordTypeId,
                        principalTable: "LandlordType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LandLords_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LandLords_TypeOfOwner_TypeOfOwnerId",
                        column: x => x.TypeOfOwnerId,
                        principalTable: "TypeOfOwner",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MDRNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BuildingUnits = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PremiseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegulationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PetitionerInterest = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LandlordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_LandLords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "LandLords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buildings_PremiseType_PremiseTypeId",
                        column: x => x.PremiseTypeId,
                        principalTable: "PremiseType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buildings_RegulationStatus_RegulationStatusId",
                        column: x => x.RegulationStatusId,
                        principalTable: "RegulationStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buildings_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Additionaltenants = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenancyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SSN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantRecord = table.Column<bool>(type: "bit", nullable: true),
                    RenewalOffer = table.Column<bool>(type: "bit", nullable: true),
                    HasPossession = table.Column<bool>(type: "bit", nullable: true),
                    HasRegulatedTenancy = table.Column<bool>(type: "bit", nullable: true),
                    OtherOccupants = table.Column<bool>(type: "bit", nullable: true),
                    HasPriorCase = table.Column<bool>(type: "bit", nullable: true),
                    BuildinId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RentDueEachMonthOrWeekId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MonthlyRent = table.Column<double>(type: "float", nullable: true),
                    TenantShare = table.Column<double>(type: "float", nullable: true),
                    SocialServices = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsERAPPaymentReceived = table.Column<bool>(type: "bit", nullable: true),
                    ERAPPaymentReceivedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UnitOrApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnitIllegalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MoveInDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Buildings_BuildinId",
                        column: x => x.BuildinId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_DateRent_RentDueEachMonthOrWeekId",
                        column: x => x.RentDueEachMonthOrWeekId,
                        principalTable: "DateRent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_IsUnitIllegal_IsUnitIllegalId",
                        column: x => x.IsUnitIllegalId,
                        principalTable: "IsUnitIllegal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_TenancyType_TenancyTypeId",
                        column: x => x.TenancyTypeId,
                        principalTable: "TenancyType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdditioanlTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditioanlTenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditioanlTenants_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegalCases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Casecode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandLordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CaseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LegalRepresentative = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CaseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CaseSubTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReasonHoldoverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsUnitIllegalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantRecord = table.Column<bool>(type: "bit", nullable: true),
                    RenewalOffer = table.Column<bool>(type: "bit", nullable: true),
                    HasPossession = table.Column<bool>(type: "bit", nullable: true),
                    OtherOccupants = table.Column<bool>(type: "bit", nullable: true),
                    RentDueEachMonthOrWeekId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MonthlyRent = table.Column<double>(type: "float", nullable: true),
                    TenantShare = table.Column<double>(type: "float", nullable: true),
                    SocialServices = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastMonthWeekRentPaid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalRentOwed = table.Column<double>(type: "float", nullable: true),
                    IsERAPPaymentReceived = table.Column<bool>(type: "bit", nullable: true),
                    ERAPPaymentReceivedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    TenancyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegulationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandlordTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateOfRefreeDeed = table.Column<DateOnly>(type: "date", nullable: false),
                    ReasonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExplainDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attrney = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AttrneyContactInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Firm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OtherPropertiesBuildingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenantReceive = table.Column<bool>(type: "bit", nullable: true),
                    ExplainTenancyReceiveDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WrittenLease = table.Column<bool>(type: "bit", nullable: true),
                    DateTenantMoved = table.Column<DateOnly>(type: "date", nullable: true),
                    OralStart = table.Column<DateOnly>(type: "date", nullable: true),
                    OralEnd = table.Column<DateOnly>(type: "date", nullable: true),
                    RenewalStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalCases_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_CaseSubType_CaseSubTypeId",
                        column: x => x.CaseSubTypeId,
                        principalTable: "CaseSubType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_CaseType_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_ClientRole_ClientRoleId",
                        column: x => x.ClientRoleId,
                        principalTable: "ClientRole",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_DateRent_RentDueEachMonthOrWeekId",
                        column: x => x.RentDueEachMonthOrWeekId,
                        principalTable: "DateRent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_IsUnitIllegal_IsUnitIllegalId",
                        column: x => x.IsUnitIllegalId,
                        principalTable: "IsUnitIllegal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_LandLords_LandLordId",
                        column: x => x.LandLordId,
                        principalTable: "LandLords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_LandlordType_LandlordTypeId",
                        column: x => x.LandlordTypeId,
                        principalTable: "LandlordType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_ReasonHoldover_ReasonHoldoverId",
                        column: x => x.ReasonHoldoverId,
                        principalTable: "ReasonHoldover",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_RegulationStatus_RegulationStatusId",
                        column: x => x.RegulationStatusId,
                        principalTable: "RegulationStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_RenewalStatus_RenewalStatusId",
                        column: x => x.RenewalStatusId,
                        principalTable: "RenewalStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_TenancyType_TenancyTypeId",
                        column: x => x.TenancyTypeId,
                        principalTable: "TenancyType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalOccupants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LegalCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalOccupants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalOccupants_LegalCases_LegalCaseId",
                        column: x => x.LegalCaseId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditioanlTenants_TenantId",
                table: "AdditioanlTenants",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOccupants_LegalCaseId",
                table: "AdditionalOccupants",
                column: "LegalCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_LandlordId",
                table: "Buildings",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_PremiseTypeId",
                table: "Buildings",
                column: "PremiseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_RegulationStatusId",
                table: "Buildings",
                column: "RegulationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_StateId",
                table: "Buildings",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseSubType_CaseTypeId",
                table: "CaseSubType",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StateId",
                table: "Clients",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_ClientId",
                table: "LandLords",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_LandlordTypeId",
                table: "LandLords",
                column: "LandlordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_StateId",
                table: "LandLords",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_TypeOfOwnerId",
                table: "LandLords",
                column: "TypeOfOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_BuildingId",
                table: "LegalCases",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseSubTypeId",
                table: "LegalCases",
                column: "CaseSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseTypeId",
                table: "LegalCases",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ClientId",
                table: "LegalCases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ClientRoleId",
                table: "LegalCases",
                column: "ClientRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_IsUnitIllegalId",
                table: "LegalCases",
                column: "IsUnitIllegalId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_LandLordId",
                table: "LegalCases",
                column: "LandLordId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_LandlordTypeId",
                table: "LegalCases",
                column: "LandlordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ReasonHoldoverId",
                table: "LegalCases",
                column: "ReasonHoldoverId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RegulationStatusId",
                table: "LegalCases",
                column: "RegulationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RenewalStatusId",
                table: "LegalCases",
                column: "RenewalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RentDueEachMonthOrWeekId",
                table: "LegalCases",
                column: "RentDueEachMonthOrWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_TenancyTypeId",
                table: "LegalCases",
                column: "TenancyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_TenantId",
                table: "LegalCases",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_BuildinId",
                table: "Tenants",
                column: "BuildinId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_IsUnitIllegalId",
                table: "Tenants",
                column: "IsUnitIllegalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_RentDueEachMonthOrWeekId",
                table: "Tenants",
                column: "RentDueEachMonthOrWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenancyTypeId",
                table: "Tenants",
                column: "TenancyTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditioanlTenants");

            migrationBuilder.DropTable(
                name: "AdditionalOccupants");

            migrationBuilder.DropTable(
                name: "LegalCases");

            migrationBuilder.DropTable(
                name: "CaseSubType");

            migrationBuilder.DropTable(
                name: "ClientRole");

            migrationBuilder.DropTable(
                name: "ReasonHoldover");

            migrationBuilder.DropTable(
                name: "RenewalStatus");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "CaseType");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "DateRent");

            migrationBuilder.DropTable(
                name: "IsUnitIllegal");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "TenancyType");

            migrationBuilder.DropTable(
                name: "LandLords");

            migrationBuilder.DropTable(
                name: "PremiseType");

            migrationBuilder.DropTable(
                name: "RegulationStatus");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "LandlordType");

            migrationBuilder.DropTable(
                name: "TypeOfOwner");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
