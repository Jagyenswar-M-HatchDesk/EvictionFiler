using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientRole",
                table: "LegalCases");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientRoleId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ClientRoleId",
                table: "LegalCases",
                column: "ClientRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_mst_ClienrRoles_ClientRoleId",
                table: "LegalCases",
                column: "ClientRoleId",
                principalTable: "mst_ClienrRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_mst_ClienrRoles_ClientRoleId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ClientRoleId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ClientRoleId",
                table: "LegalCases");

            migrationBuilder.AddColumn<string>(
                name: "ClientRole",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
