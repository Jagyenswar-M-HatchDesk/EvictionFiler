using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations.Multi_tenant
{
    /// <inheritdoc />
    public partial class UpdateClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_Clients_ClientId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "isCorporeateOwner",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "PremiseType",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tenants",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "LeaseStatus",
                table: "Tenants",
                newName: "Registration_No");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Tenants",
                newName: "Name_Relation");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Tenants",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ClientRole",
                table: "LegalCases",
                newName: "Firm");

            migrationBuilder.RenameColumn(
                name: "CaseType",
                table: "LegalCases",
                newName: "AttrneyContactInfo");

            migrationBuilder.RenameColumn(
                name: "RegisteredAgent",
                table: "LandLords",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LandLords",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "MaillingAddress",
                table: "LandLords",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Firm",
                table: "LandLords",
                newName: "ContactPersonName");

            migrationBuilder.RenameColumn(
                name: "Attorney",
                table: "LandLords",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Appartments",
                newName: "BuildingCode");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Appartments",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Appartments_ClientId",
                table: "Appartments",
                newName: "IX_Appartments_StateId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DOB",
                table: "Tenants",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Address_1",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_2",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPossession",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPriorCase",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRegulatedTenancy",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtherOccupants",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TenantRecord",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attrney",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseSubTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientRoleId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "LandLords",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<int>(
                name: "BuildingUnits",
                table: "Appartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfRefreeDeed",
                table: "Appartments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "LandlordId",
                table: "Appartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LandlordType",
                table: "Appartments",
                type: "int",
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

            migrationBuilder.CreateTable(
                name: "CaseType",
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
                    table.PrimaryKey("PK_CaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientRole",
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
                    table.PrimaryKey("PK_ClientRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
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
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PremiseType",
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
                    table.PrimaryKey("PK_PremiseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegulationStatus",
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
                    table.PrimaryKey("PK_RegulationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
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
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfOwner",
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
                    table.PrimaryKey("PK_TypeOfOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseSubType",
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
                    table.PrimaryKey("PK_CaseSubType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseSubType_CaseType_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApartmentId",
                table: "Tenants",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseSubTypeId",
                table: "LegalCases",
                column: "CaseSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseTypeId",
                table: "LegalCases",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ClientRoleId",
                table: "LegalCases",
                column: "ClientRoleId");

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
                name: "IX_Appartments_LandlordId",
                table: "Appartments",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_PremiseTypeId",
                table: "Appartments",
                column: "PremiseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_RentRegulationId",
                table: "Appartments",
                column: "RentRegulationId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseSubType_CaseTypeId",
                table: "CaseSubType",
                column: "CaseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_LandLords_LandlordId",
                table: "Appartments",
                column: "LandlordId",
                principalTable: "LandLords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_PremiseType_PremiseTypeId",
                table: "Appartments",
                column: "PremiseTypeId",
                principalTable: "PremiseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_RegulationStatus_RentRegulationId",
                table: "Appartments",
                column: "RentRegulationId",
                principalTable: "RegulationStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_State_StateId",
                table: "Appartments",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_State_StateId",
                table: "Clients",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_State_StateId",
                table: "LandLords",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_TypeOfOwner_TypeOfOwnerId",
                table: "LandLords",
                column: "TypeOfOwnerId",
                principalTable: "TypeOfOwner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_CaseSubType_CaseSubTypeId",
                table: "LegalCases",
                column: "CaseSubTypeId",
                principalTable: "CaseSubType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_CaseType_CaseTypeId",
                table: "LegalCases",
                column: "CaseTypeId",
                principalTable: "CaseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_ClientRole_ClientRoleId",
                table: "LegalCases",
                column: "ClientRoleId",
                principalTable: "ClientRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Appartments_ApartmentId",
                table: "Tenants",
                column: "ApartmentId",
                principalTable: "Appartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Language_LanguageId",
                table: "Tenants",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_State_StateId",
                table: "Tenants",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_LandLords_LandlordId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_PremiseType_PremiseTypeId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_RegulationStatus_RentRegulationId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_State_StateId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_State_StateId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_State_StateId",
                table: "LandLords");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_TypeOfOwner_TypeOfOwnerId",
                table: "LandLords");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_CaseSubType_CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_CaseType_CaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_ClientRole_ClientRoleId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Appartments_ApartmentId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Language_LanguageId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_State_StateId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "CaseSubType");

            migrationBuilder.DropTable(
                name: "ClientRole");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "PremiseType");

            migrationBuilder.DropTable(
                name: "RegulationStatus");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "TypeOfOwner");

            migrationBuilder.DropTable(
                name: "CaseType");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ApartmentId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ClientRoleId",
                table: "LegalCases");

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
                name: "IX_Appartments_LandlordId",
                table: "Appartments");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_PremiseTypeId",
                table: "Appartments");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_RentRegulationId",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "Address_1",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Address_2",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "HasPossession",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "HasPriorCase",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "HasRegulatedTenancy",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OtherOccupants",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantRecord",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Attrney",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ClientRoleId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "LandLords");

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
                name: "BuildingUnits",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "DateOfRefreeDeed",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "LandlordType",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "PremiseTypeId",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "RentRegulationId",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Tenants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Registration_No",
                table: "Tenants",
                newName: "LeaseStatus");

            migrationBuilder.RenameColumn(
                name: "Name_Relation",
                table: "Tenants",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Tenants",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Firm",
                table: "LegalCases",
                newName: "ClientRole");

            migrationBuilder.RenameColumn(
                name: "AttrneyContactInfo",
                table: "LegalCases",
                newName: "CaseType");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "LandLords",
                newName: "RegisteredAgent");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "LandLords",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "LandLords",
                newName: "MaillingAddress");

            migrationBuilder.RenameColumn(
                name: "ContactPersonName",
                table: "LandLords",
                newName: "Firm");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "LandLords",
                newName: "Attorney");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Appartments",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "BuildingCode",
                table: "Appartments",
                newName: "State");

            migrationBuilder.RenameIndex(
                name: "IX_Appartments_StateId",
                table: "Appartments",
                newName: "IX_Appartments_ClientId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "isCorporeateOwner",
                table: "LandLords",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PremiseType",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_Clients_ClientId",
                table: "Appartments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
