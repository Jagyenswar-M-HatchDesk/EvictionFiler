using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLandlordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "LandLords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_ClientId",
                table: "LandLords",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords");

            migrationBuilder.DropIndex(
                name: "IX_LandLords_ClientId",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "LandLords");
        }
    }
}
