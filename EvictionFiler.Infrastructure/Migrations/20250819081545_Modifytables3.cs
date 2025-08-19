using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modifytables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentDueEachMonthOrWeek",
                table: "Tenants");

            migrationBuilder.AddColumn<Guid>(
                name: "RentDueEachMonthOrWeekId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_RentDueEachMonthOrWeekId",
                table: "Tenants",
                column: "RentDueEachMonthOrWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_MstDateRent_RentDueEachMonthOrWeekId",
                table: "Tenants",
                column: "RentDueEachMonthOrWeekId",
                principalTable: "MstDateRent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_MstDateRent_RentDueEachMonthOrWeekId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_RentDueEachMonthOrWeekId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "RentDueEachMonthOrWeekId",
                table: "Tenants");

            migrationBuilder.AddColumn<string>(
                name: "RentDueEachMonthOrWeek",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
