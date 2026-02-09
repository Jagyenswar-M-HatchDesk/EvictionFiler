using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstCaseTypes",
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
                    table.PrimaryKey("PK_MstCaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstClientRoles",
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
                    table.PrimaryKey("PK_MstClientRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstDateRent",
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
                    table.PrimaryKey("PK_MstDateRent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstIsUnitIllegal",
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
                    table.PrimaryKey("PK_MstIsUnitIllegal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstLandlordTypes",
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
                    table.PrimaryKey("PK_MstLandlordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstLanguages",
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
                    table.PrimaryKey("PK_MstLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstPremiseTypes",
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
                    table.PrimaryKey("PK_MstPremiseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstReasonHoldover",
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
                    table.PrimaryKey("PK_MstReasonHoldover", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstRegulationStatus",
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
                    table.PrimaryKey("PK_MstRegulationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstRenewalStatus",
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
                    table.PrimaryKey("PK_MstRenewalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstStates",
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
                    table.PrimaryKey("PK_MstStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstTenancyTypes",
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
                    table.PrimaryKey("PK_MstTenancyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstTypeOfOwners",
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
                    table.PrimaryKey("PK_MstTypeOfOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDatabases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatabaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatabases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MstCaseSubTypes",
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
                    table.PrimaryKey("PK_MstCaseSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstCaseSubTypes_MstCaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "MstCaseTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MstFormTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CaseTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 500, nullable: true),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MstFormTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstFormTypes_MstCaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "MstCaseTypes",
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
                        name: "FK_Clients_MstStates_StateId",
                        column: x => x.StateId,
                        principalTable: "MstStates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserDatabases_TenantId",
                        column: x => x.TenantId,
                        principalTable: "UserDatabases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_LandLords_MstLandlordTypes_LandlordTypeId",
                        column: x => x.LandlordTypeId,
                        principalTable: "MstLandlordTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LandLords_MstStates_StateId",
                        column: x => x.StateId,
                        principalTable: "MstStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LandLords_MstTypeOfOwners_TypeOfOwnerId",
                        column: x => x.TypeOfOwnerId,
                        principalTable: "MstTypeOfOwners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Buildings_MstPremiseTypes_PremiseTypeId",
                        column: x => x.PremiseTypeId,
                        principalTable: "MstPremiseTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buildings_MstRegulationStatus_RegulationStatusId",
                        column: x => x.RegulationStatusId,
                        principalTable: "MstRegulationStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buildings_MstStates_StateId",
                        column: x => x.StateId,
                        principalTable: "MstStates",
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
                        name: "FK_Tenants_MstDateRent_RentDueEachMonthOrWeekId",
                        column: x => x.RentDueEachMonthOrWeekId,
                        principalTable: "MstDateRent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_MstIsUnitIllegal_IsUnitIllegalId",
                        column: x => x.IsUnitIllegalId,
                        principalTable: "MstIsUnitIllegal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_MstLanguages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "MstLanguages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_MstStates_StateId",
                        column: x => x.StateId,
                        principalTable: "MstStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_MstTenancyTypes_TenancyTypeId",
                        column: x => x.TenancyTypeId,
                        principalTable: "MstTenancyTypes",
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
                        name: "FK_LegalCases_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_LandLords_LandLordId",
                        column: x => x.LandLordId,
                        principalTable: "LandLords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstCaseSubTypes_CaseSubTypeId",
                        column: x => x.CaseSubTypeId,
                        principalTable: "MstCaseSubTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstCaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "MstCaseTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstClientRoles_ClientRoleId",
                        column: x => x.ClientRoleId,
                        principalTable: "MstClientRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstDateRent_RentDueEachMonthOrWeekId",
                        column: x => x.RentDueEachMonthOrWeekId,
                        principalTable: "MstDateRent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstIsUnitIllegal_IsUnitIllegalId",
                        column: x => x.IsUnitIllegalId,
                        principalTable: "MstIsUnitIllegal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstLandlordTypes_LandlordTypeId",
                        column: x => x.LandlordTypeId,
                        principalTable: "MstLandlordTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstReasonHoldover_ReasonHoldoverId",
                        column: x => x.ReasonHoldoverId,
                        principalTable: "MstReasonHoldover",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstRegulationStatus_RegulationStatusId",
                        column: x => x.RegulationStatusId,
                        principalTable: "MstRegulationStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstRenewalStatus_RenewalStatusId",
                        column: x => x.RenewalStatusId,
                        principalTable: "MstRenewalStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalCases_MstTenancyTypes_TenancyTypeId",
                        column: x => x.TenancyTypeId,
                        principalTable: "MstTenancyTypes",
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

            migrationBuilder.CreateTable(
                name: "CaseForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CaseForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseForms_LegalCases_LegalCaseId",
                        column: x => x.LegalCaseId,
                        principalTable: "LegalCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseForms_MstFormTypes_FormTypeId",
                        column: x => x.FormTypeId,
                        principalTable: "MstFormTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "Name", "NormalizedName", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("2bb5c3bf-8dd8-4415-9090-1d428c792533"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, true, null, "Property Manager", "PROPERTY MANAGER", null, null },
                    { new Guid("56355bf6-e335-428a-b718-00cb79e5273d"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, true, null, "Law Firm", "LAW FIRM", null, null },
                    { new Guid("f5ab29da-356e-42df-a3ad-d91bbf644550"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, true, null, "Admin", "ADMIN", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName" },
                values: new object[] { new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e"), 0, "12456e31-62c3-4db3-a8fc-987654321def", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 19, 12, 0, 0, 0, DateTimeKind.Utc), "admin@gmail.com", true, "Admin", true, false, "", false, null, "", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEHXHMy52Ji1wPk8MrXLQrX8XKJekP1rHPXwmwtgFmlmiCdkN7lYlOlLlaOVXJ2SKcw==", null, false, new Guid("f5ab29da-356e-42df-a3ad-d91bbf644550"), "38fef087-d2ad-4e78-9823-123456789abc", null, false, null, null, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f5ab29da-356e-42df-a3ad-d91bbf644550"), new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e") });

            migrationBuilder.CreateIndex(
                name: "IX_AdditioanlTenants_TenantId",
                table: "AdditioanlTenants",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOccupants_LegalCaseId",
                table: "AdditionalOccupants",
                column: "LegalCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_CaseForms_FormTypeId",
                table: "CaseForms",
                column: "FormTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseForms_LegalCaseId",
                table: "CaseForms",
                column: "LegalCaseId");

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
                name: "IX_MstCaseSubTypes_CaseTypeId",
                table: "MstCaseSubTypes",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MstFormTypes_CaseTypeId",
                table: "MstFormTypes",
                column: "CaseTypeId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaseForms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LegalCases");

            migrationBuilder.DropTable(
                name: "MstFormTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserDatabases");

            migrationBuilder.DropTable(
                name: "MstCaseSubTypes");

            migrationBuilder.DropTable(
                name: "MstClientRoles");

            migrationBuilder.DropTable(
                name: "MstReasonHoldover");

            migrationBuilder.DropTable(
                name: "MstRenewalStatus");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "MstCaseTypes");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "MstDateRent");

            migrationBuilder.DropTable(
                name: "MstIsUnitIllegal");

            migrationBuilder.DropTable(
                name: "MstLanguages");

            migrationBuilder.DropTable(
                name: "MstTenancyTypes");

            migrationBuilder.DropTable(
                name: "LandLords");

            migrationBuilder.DropTable(
                name: "MstPremiseTypes");

            migrationBuilder.DropTable(
                name: "MstRegulationStatus");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "MstLandlordTypes");

            migrationBuilder.DropTable(
                name: "MstTypeOfOwners");

            migrationBuilder.DropTable(
                name: "MstStates");
        }
    }
}
