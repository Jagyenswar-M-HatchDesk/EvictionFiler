using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifylegalcase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourtLocation",
                table: "LegalCases");

            migrationBuilder.AddColumn<Guid>(
                name: "CourtLocationId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CourtLocationId",
                table: "LegalCases",
                column: "CourtLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_Courts_CourtLocationId",
                table: "LegalCases",
                column: "CourtLocationId",
                principalTable: "Courts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_Courts_CourtLocationId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CourtLocationId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CourtLocationId",
                table: "LegalCases");

            migrationBuilder.AddColumn<string>(
                name: "CourtLocation",
                table: "LegalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
