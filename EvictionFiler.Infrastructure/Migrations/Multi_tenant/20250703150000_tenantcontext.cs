using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations.Multi_tenant
{
    /// <inheritdoc />
    public partial class tenantcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "LandLords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Appartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_ClientId",
                table: "LandLords",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_ClientId",
                table: "Appartments",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_Clients_ClientId",
                table: "Appartments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

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
                name: "FK_Appartments_Clients_ClientId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords");

            migrationBuilder.DropIndex(
                name: "IX_LandLords_ClientId",
                table: "LandLords");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_ClientId",
                table: "Appartments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Appartments");
        }
    }
}
