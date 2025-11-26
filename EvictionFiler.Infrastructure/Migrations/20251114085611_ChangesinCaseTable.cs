using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesinCaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstAppearanceTypesPerDiems_AppearanceTypePerDiemId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_AppearanceTypePerDiemId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AppearanceTypePerDiemId",
                table: "LegalCases");

            migrationBuilder.CreateTable(
                name: "AppearanceTypePerDiemLegalCase",
                columns: table => new
                {
                    AppearanceTypePerDiemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppearanceTypePerDiemLegalCase", x => new { x.AppearanceTypePerDiemId, x.LegalCasesId });
                    table.ForeignKey(
                        name: "FK_AppearanceTypePerDiemLegalCase_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppearanceTypePerDiemLegalCase_MstAppearanceTypesPerDiems_AppearanceTypePerDiemId",
                        column: x => x.AppearanceTypePerDiemId,
                        principalTable: "MstAppearanceTypesPerDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppearanceTypePerDiemLegalCase_LegalCasesId",
                table: "AppearanceTypePerDiemLegalCase",
                column: "LegalCasesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppearanceTypePerDiemLegalCase");

            migrationBuilder.AddColumn<Guid>(
                name: "AppearanceTypePerDiemId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_AppearanceTypePerDiemId",
                table: "LegalCases",
                column: "AppearanceTypePerDiemId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstAppearanceTypesPerDiems_AppearanceTypePerDiemId",
                table: "LegalCases",
                column: "AppearanceTypePerDiemId",
                principalTable: "MstAppearanceTypesPerDiems",
                principalColumn: "Id");
        }
    }
}
