using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetbllegalcases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourtPartId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CourtPartId",
                table: "LegalCases",
                column: "CourtPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_CourtPart_CourtPartId",
                table: "LegalCases",
                column: "CourtPartId",
                principalTable: "CourtPart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_CourtPart_CourtPartId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CourtPartId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CourtPartId",
                table: "LegalCases");
        }
    }
}
