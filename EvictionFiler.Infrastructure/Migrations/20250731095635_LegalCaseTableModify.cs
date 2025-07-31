using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LegalCaseTableModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfRefreeDeed",
                table: "LegalCases",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ERAPPaymentReceivedDate",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPossession",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsERAPPaymentReceived",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IsUnitIllegalId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LandlordTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMonthWeekRentPaid",
                table: "LegalCases",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MonthlyRent",
                table: "LegalCases",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtherOccupants",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegulationStatusId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RenewalOffer",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentDueEachMonthOrWeek",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialServices",
                table: "LegalCases",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenancyTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TenantRecord",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TenantShare",
                table: "LegalCases",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalRentOwed",
                table: "LegalCases",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_IsUnitIllegalId",
                table: "LegalCases",
                column: "IsUnitIllegalId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_LandlordTypeId",
                table: "LegalCases",
                column: "LandlordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RegulationStatusId",
                table: "LegalCases",
                column: "RegulationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_TenancyTypeId",
                table: "LegalCases",
                column: "TenancyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstIsUnitIllegal_IsUnitIllegalId",
                table: "LegalCases",
                column: "IsUnitIllegalId",
                principalTable: "MstIsUnitIllegal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstLandlordTypes_LandlordTypeId",
                table: "LegalCases",
                column: "LandlordTypeId",
                principalTable: "MstLandlordTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstRegulationStatus_RegulationStatusId",
                table: "LegalCases",
                column: "RegulationStatusId",
                principalTable: "MstRegulationStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstTenancyTypes_TenancyTypeId",
                table: "LegalCases",
                column: "TenancyTypeId",
                principalTable: "MstTenancyTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstIsUnitIllegal_IsUnitIllegalId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstLandlordTypes_LandlordTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstRegulationStatus_RegulationStatusId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstTenancyTypes_TenancyTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_IsUnitIllegalId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_LandlordTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_RegulationStatusId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_TenancyTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "DateOfRefreeDeed",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ERAPPaymentReceivedDate",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "HasPossession",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "IsERAPPaymentReceived",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "IsUnitIllegalId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LandlordTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LastMonthWeekRentPaid",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "MonthlyRent",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OtherOccupants",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RegulationStatusId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RenewalOffer",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RentDueEachMonthOrWeek",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "SocialServices",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TenancyTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TenantRecord",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TenantShare",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TotalRentOwed",
                table: "LegalCases");
        }
    }
}
