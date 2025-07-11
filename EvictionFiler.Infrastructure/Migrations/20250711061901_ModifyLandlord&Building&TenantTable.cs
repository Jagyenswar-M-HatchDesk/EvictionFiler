using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLandlordBuildingTenantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tanent",
                table: "Appartments",
                newName: "TypeOfRentRegulation");

            migrationBuilder.AddColumn<bool>(
                name: "HasPossession",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRegulatedTenancy",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Relation",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtherOccupants",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Registration_No",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TenantRecord",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttorneyContactInfo",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfRefreeDeed",
                table: "LandLords",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "LandlordType",
                table: "LandLords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfOwner",
                table: "LandLords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingUnits",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPriorCase",
                table: "Appartments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherProperties",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPossession",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "HasRegulatedTenancy",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Name_Relation",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OtherOccupants",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Registration_No",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantRecord",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "AttorneyContactInfo",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "DateOfRefreeDeed",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "LandlordType",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "TypeOfOwner",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "BuildingUnits",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "HasPriorCase",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "OtherProperties",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "TypeOfRentRegulation",
                table: "Appartments",
                newName: "Tanent");
        }
    }
}
