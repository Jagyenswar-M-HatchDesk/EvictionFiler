using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class casehearingTbalemodifyagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstAppearanceTypes_AppearanceTypeId",
                table: "CaseHearings");

            migrationBuilder.RenameColumn(
                name: "AppearanceTypeId",
                table: "CaseHearings",
                newName: "AppearanceTypeForHearingId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseHearings_AppearanceTypeId",
                table: "CaseHearings",
                newName: "IX_CaseHearings_AppearanceTypeForHearingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstAppearanceTypesForHearing_AppearanceTypeForHearingId",
                table: "CaseHearings",
                column: "AppearanceTypeForHearingId",
                principalTable: "MstAppearanceTypesForHearing",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstAppearanceTypesForHearing_AppearanceTypeForHearingId",
                table: "CaseHearings");

            migrationBuilder.RenameColumn(
                name: "AppearanceTypeForHearingId",
                table: "CaseHearings",
                newName: "AppearanceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseHearings_AppearanceTypeForHearingId",
                table: "CaseHearings",
                newName: "IX_CaseHearings_AppearanceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstAppearanceTypes_AppearanceTypeId",
                table: "CaseHearings",
                column: "AppearanceTypeId",
                principalTable: "MstAppearanceTypes",
                principalColumn: "Id");
        }
    }
}
