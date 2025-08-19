using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifycasesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentDueEachMonthOrWeek",
                table: "LegalCases");

            migrationBuilder.AddColumn<Guid>(
                name: "RentDueEachMonthOrWeekId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RentDueEachMonthOrWeekId",
                table: "LegalCases",
                column: "RentDueEachMonthOrWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstDateRent_RentDueEachMonthOrWeekId",
                table: "LegalCases",
                column: "RentDueEachMonthOrWeekId",
                principalTable: "MstDateRent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstDateRent_RentDueEachMonthOrWeekId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_RentDueEachMonthOrWeekId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RentDueEachMonthOrWeekId",
                table: "LegalCases");

            migrationBuilder.AddColumn<string>(
                name: "RentDueEachMonthOrWeek",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
