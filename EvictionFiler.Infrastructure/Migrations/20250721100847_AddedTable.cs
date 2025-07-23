using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_CaseSubTypes_CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_CaseTypes_CaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropTable(
                name: "CaseSubTypes");

            migrationBuilder.DropTable(
                name: "CaseTypes");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LeaseStatus",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OtherProperties",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "State",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "TypeOfOwner",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PremiseType",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "TypeOfRentRegulation",
                table: "Appartments");

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "LandLords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeOfOwnerId",
                table: "LandLords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PremiseTypeId",
                table: "Appartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RentRegulationId",
                table: "Appartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Appartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mst_CaseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_CaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_ClienrRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_ClienrRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_PremiseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_PremiseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_regulationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_regulationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_State",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_TypeOfOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_TypeOfOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_CaseSubTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_CaseSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mst_CaseSubTypes_mst_CaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "mst_CaseTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_StateId",
                table: "LandLords",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_TypeOfOwnerId",
                table: "LandLords",
                column: "TypeOfOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StateId",
                table: "Clients",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_PremiseTypeId",
                table: "Appartments",
                column: "PremiseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_RentRegulationId",
                table: "Appartments",
                column: "RentRegulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_StateId",
                table: "Appartments",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_mst_CaseSubTypes_CaseTypeId",
                table: "mst_CaseSubTypes",
                column: "CaseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_mst_PremiseTypes_PremiseTypeId",
                table: "Appartments",
                column: "PremiseTypeId",
                principalTable: "mst_PremiseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_mst_State_StateId",
                table: "Appartments",
                column: "StateId",
                principalTable: "mst_State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_mst_regulationStatus_RentRegulationId",
                table: "Appartments",
                column: "RentRegulationId",
                principalTable: "mst_regulationStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_mst_State_StateId",
                table: "Clients",
                column: "StateId",
                principalTable: "mst_State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_mst_State_StateId",
                table: "LandLords",
                column: "StateId",
                principalTable: "mst_State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_mst_TypeOfOwners_TypeOfOwnerId",
                table: "LandLords",
                column: "TypeOfOwnerId",
                principalTable: "mst_TypeOfOwners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_mst_CaseSubTypes_CaseSubTypeId",
                table: "LegalCases",
                column: "CaseSubTypeId",
                principalTable: "mst_CaseSubTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_mst_CaseTypes_CaseTypeId",
                table: "LegalCases",
                column: "CaseTypeId",
                principalTable: "mst_CaseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_mst_Languages_LanguageId",
                table: "Tenants",
                column: "LanguageId",
                principalTable: "mst_Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_mst_State_StateId",
                table: "Tenants",
                column: "StateId",
                principalTable: "mst_State",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_mst_PremiseTypes_PremiseTypeId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_mst_State_StateId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_mst_regulationStatus_RentRegulationId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_mst_State_StateId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_mst_State_StateId",
                table: "LandLords");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_mst_TypeOfOwners_TypeOfOwnerId",
                table: "LandLords");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_mst_CaseSubTypes_CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_mst_CaseTypes_CaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_mst_Languages_LanguageId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_mst_State_StateId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "mst_CaseSubTypes");

            migrationBuilder.DropTable(
                name: "mst_ClienrRoles");

            migrationBuilder.DropTable(
                name: "mst_Languages");

            migrationBuilder.DropTable(
                name: "mst_PremiseTypes");

            migrationBuilder.DropTable(
                name: "mst_regulationStatus");

            migrationBuilder.DropTable(
                name: "mst_State");

            migrationBuilder.DropTable(
                name: "mst_TypeOfOwners");

            migrationBuilder.DropTable(
                name: "mst_CaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_LandLords_StateId",
                table: "LandLords");

            migrationBuilder.DropIndex(
                name: "IX_LandLords_TypeOfOwnerId",
                table: "LandLords");

            migrationBuilder.DropIndex(
                name: "IX_Clients_StateId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_PremiseTypeId",
                table: "Appartments");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_RentRegulationId",
                table: "Appartments");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_StateId",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "TypeOfOwnerId",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PremiseTypeId",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "RentRegulationId",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Appartments");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeaseStatus",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherProperties",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfOwner",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PremiseType",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfRentRegulation",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CaseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseSubTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseSubTypes_CaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseSubTypes_CaseTypeId",
                table: "CaseSubTypes",
                column: "CaseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_CaseSubTypes_CaseSubTypeId",
                table: "LegalCases",
                column: "CaseSubTypeId",
                principalTable: "CaseSubTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_CaseTypes_CaseTypeId",
                table: "LegalCases",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id");
        }
    }
}
