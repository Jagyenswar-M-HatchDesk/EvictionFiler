using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfRefreeDeed",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "LandlordType",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "isCorporeateOwner",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "HasPriorCase",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "OtherProperties",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tenants",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Tenants",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "RegisteredAgent",
                table: "LandLords",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LandLords",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "MaillingAddress",
                table: "LandLords",
                newName: "OtherProperties");

            migrationBuilder.RenameColumn(
                name: "Firm",
                table: "LandLords",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AttorneyContactInfo",
                table: "LandLords",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Attorney",
                table: "LandLords",
                newName: "City");

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
                name: "HasPriorCase",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Tenants",
                type: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<int>(
                name: "BuildingUnits",
                table: "Appartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfRefreeDeed",
                table: "Appartments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "LandlordType",
                table: "Appartments",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_1",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Address_2",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "HasPriorCase",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "DateOfRefreeDeed",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "LandlordType",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Tenants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Tenants",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "LandLords",
                newName: "RegisteredAgent");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "LandLords",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OtherProperties",
                table: "LandLords",
                newName: "MaillingAddress");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "LandLords",
                newName: "Firm");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "LandLords",
                newName: "AttorneyContactInfo");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "LandLords",
                newName: "Attorney");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

            migrationBuilder.AddColumn<bool>(
                name: "isCorporeateOwner",
                table: "LandLords",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuildingUnits",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
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
    }
}
