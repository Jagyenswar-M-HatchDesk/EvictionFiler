using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyApartmentTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApartmentId",
                table: "Tenants",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Appartments_ApartmentId",
                table: "Tenants",
                column: "ApartmentId",
                principalTable: "Appartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Appartments_ApartmentId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ApartmentId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Tenants");
        }
    }
}
