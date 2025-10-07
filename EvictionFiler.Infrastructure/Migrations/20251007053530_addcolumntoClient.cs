using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolumntoClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalOccupants_LegalCases_LegalCaseId",
                table: "AdditionalOccupants");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientTypeId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LegalCaseId",
                table: "AdditionalOccupants",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalOccupants_LegalCases_LegalCaseId",
                table: "AdditionalOccupants",
                column: "LegalCaseId",
                principalTable: "LegalCases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MstClientRoles_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId",
                principalTable: "MstClientRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalOccupants_LegalCases_LegalCaseId",
                table: "AdditionalOccupants");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MstClientRoles_ClientTypeId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "LegalCaseId",
                table: "AdditionalOccupants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalOccupants_LegalCases_LegalCaseId",
                table: "AdditionalOccupants",
                column: "LegalCaseId",
                principalTable: "LegalCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
