using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class legalCaseTablemodify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExemptionBasisId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExemptionReasonId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GoodCause",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OwnerOccupied",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryResidence",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentRegulationDescription",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenancyTypeForBuildingId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ExemptionBasisId",
                table: "LegalCases",
                column: "ExemptionBasisId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ExemptionReasonId",
                table: "LegalCases",
                column: "ExemptionReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_TenancyTypeForBuildingId",
                table: "LegalCases",
                column: "TenancyTypeForBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstExemptionBasic_ExemptionBasisId",
                table: "LegalCases",
                column: "ExemptionBasisId",
                principalTable: "MstExemptionBasic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstExemptionReason_ExemptionReasonId",
                table: "LegalCases",
                column: "ExemptionReasonId",
                principalTable: "MstExemptionReason",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstTenancyTypesForBuilding_TenancyTypeForBuildingId",
                table: "LegalCases",
                column: "TenancyTypeForBuildingId",
                principalTable: "MstTenancyTypesForBuilding",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstExemptionBasic_ExemptionBasisId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstExemptionReason_ExemptionReasonId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstTenancyTypesForBuilding_TenancyTypeForBuildingId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ExemptionBasisId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ExemptionReasonId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_TenancyTypeForBuildingId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ExemptionBasisId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ExemptionReasonId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "GoodCause",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OwnerOccupied",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PrimaryResidence",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RentRegulationDescription",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TenancyTypeForBuildingId",
                table: "LegalCases");
        }
    }
}
