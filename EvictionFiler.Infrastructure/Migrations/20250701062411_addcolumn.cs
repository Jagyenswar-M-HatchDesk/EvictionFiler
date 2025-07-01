using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Appartments",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Appartments",
                newName: "PremiseType");

            migrationBuilder.RenameColumn(
                name: "Extention",
                table: "Appartments",
                newName: "PetitionerInterest");

            migrationBuilder.RenameColumn(
                name: "CellPhone",
                table: "Appartments",
                newName: "MDR_Number");

            migrationBuilder.AddColumn<string>(
                name: "TenantCode",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllUnitsRehistered",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AptNo",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Borough",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseType",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Casecode",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommercialUnits",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ExemptUnit",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HPDViolation",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HeatorHotWater",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MDRNo",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Monthsunpaid",
                table: "LegalCases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OthersGrounds",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneorEmail",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RentIncreases",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RentStablized",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentalUnits",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SeekinEviction",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearBuilt",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZIP",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandLordCode",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_1",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_2",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentCode",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_TenantId",
                table: "LegalCases",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_Tenants_TenantId",
                table: "LegalCases",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_Tenants_TenantId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_TenantId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TenantCode",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AllUnitsRehistered",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AptNo",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Borough",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseType",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Casecode",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CommercialUnits",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ExemptUnit",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "HPDViolation",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "HeatorHotWater",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "MDRNo",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Monthsunpaid",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OthersGrounds",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PhoneorEmail",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RentIncreases",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RentStablized",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ResidentalUnits",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "SeekinEviction",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "YearBuilt",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LandLordCode",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "Address_1",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "Address_2",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "ApartmentCode",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Appartments",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "PremiseType",
                table: "Appartments",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PetitionerInterest",
                table: "Appartments",
                newName: "Extention");

            migrationBuilder.RenameColumn(
                name: "MDR_Number",
                table: "Appartments",
                newName: "CellPhone");
        }
    }
}
