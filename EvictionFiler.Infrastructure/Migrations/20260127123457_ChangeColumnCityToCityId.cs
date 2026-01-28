using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnCityToCityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "LandLords");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "LandLords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_CityId",
                table: "LandLords",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_MstCities_CityId",
                table: "LandLords",
                column: "CityId",
                principalTable: "MstCities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_MstCities_CityId",
                table: "LandLords");

            migrationBuilder.DropIndex(
                name: "IX_LandLords_CityId",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LandLords");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "LandLords",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
