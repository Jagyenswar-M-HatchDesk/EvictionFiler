using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetblCasehearing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BillAmount",
                table: "LegalCases",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseStatusId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseTypeId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountyId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourtPartId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Judge",
                table: "CaseHearings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomNo",
                table: "CaseHearings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_CaseStatusId",
                table: "CaseHearings",
                column: "CaseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_CaseTypeId",
                table: "CaseHearings",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_CountyId",
                table: "CaseHearings",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_CourtPartId",
                table: "CaseHearings",
                column: "CourtPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstCaseStatus_CaseStatusId",
                table: "CaseHearings",
                column: "CaseStatusId",
                principalTable: "MstCaseStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstCaseTypes_CaseTypeId",
                table: "CaseHearings",
                column: "CaseTypeId",
                principalTable: "MstCaseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstCounties_CountyId",
                table: "CaseHearings",
                column: "CountyId",
                principalTable: "MstCounties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstCourtPart_CourtPartId",
                table: "CaseHearings",
                column: "CourtPartId",
                principalTable: "MstCourtPart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstCaseStatus_CaseStatusId",
                table: "CaseHearings");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstCaseTypes_CaseTypeId",
                table: "CaseHearings");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstCounties_CountyId",
                table: "CaseHearings");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstCourtPart_CourtPartId",
                table: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_CaseStatusId",
                table: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_CaseTypeId",
                table: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_CountyId",
                table: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_CourtPartId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "BillAmount",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseStatusId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "CaseTypeId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "CourtPartId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "Judge",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "RoomNo",
                table: "CaseHearings");
        }
    }
}
