using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyNotificaton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CaseId",
                table: "TblRemainderCenter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblRemainderCenter_CaseId",
                table: "TblRemainderCenter",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_LegalCases_CaseId",
                table: "TblRemainderCenter",
                column: "CaseId",
                principalTable: "LegalCases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_LegalCases_CaseId",
                table: "TblRemainderCenter");

            migrationBuilder.DropIndex(
                name: "IX_TblRemainderCenter_CaseId",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "TblRemainderCenter");
        }
    }
}
