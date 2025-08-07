using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatetenantTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AdditionalOccupants_AdditialOccupantsId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_AdditialOccupantsId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "AdditialOccupantsId",
                table: "Tenants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdditialOccupantsId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_AdditialOccupantsId",
                table: "Tenants",
                column: "AdditialOccupantsId",
                unique: true,
                filter: "[AdditialOccupantsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AdditionalOccupants_AdditialOccupantsId",
                table: "Tenants",
                column: "AdditialOccupantsId",
                principalTable: "AdditionalOccupants",
                principalColumn: "Id");
        }
    }
}
