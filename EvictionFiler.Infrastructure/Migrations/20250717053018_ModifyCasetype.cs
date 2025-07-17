using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCasetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypes_CaseSubTypes_CaseSubTypeId",
                table: "CaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_CaseTypes_CaseSubTypeId",
                table: "CaseTypes");

            migrationBuilder.DropColumn(
                name: "CaseSubTypeId",
                table: "CaseTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "CaseSubTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseTypeId",
                table: "CaseSubTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseSubTypeId",
                table: "LegalCases",
                column: "CaseSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseSubTypes_CaseTypeId",
                table: "CaseSubTypes",
                column: "CaseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseSubTypes_CaseTypes_CaseTypeId",
                table: "CaseSubTypes",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_CaseSubTypes_CaseSubTypeId",
                table: "LegalCases",
                column: "CaseSubTypeId",
                principalTable: "CaseSubTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseSubTypes_CaseTypes_CaseTypeId",
                table: "CaseSubTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_CaseSubTypes_CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_CaseSubTypes_CaseTypeId",
                table: "CaseSubTypes");

            migrationBuilder.DropColumn(
                name: "CaseSubTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseTypeId",
                table: "CaseSubTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "CaseSubTypeId",
                table: "CaseTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_CaseSubTypeId",
                table: "CaseTypes",
                column: "CaseSubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypes_CaseSubTypes_CaseSubTypeId",
                table: "CaseTypes",
                column: "CaseSubTypeId",
                principalTable: "CaseSubTypes",
                principalColumn: "Id");
        }
    }
}
