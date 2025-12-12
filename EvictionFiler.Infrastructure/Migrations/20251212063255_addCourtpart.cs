using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCourtpart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourtTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CourtTypeId",
                table: "LegalCases",
                column: "CourtTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstCourtType_CourtTypeId",
                table: "LegalCases",
                column: "CourtTypeId",
                principalTable: "MstCourtType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstCourtType_CourtTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CourtTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CourtTypeId",
                table: "LegalCases");
        }
    }
}
