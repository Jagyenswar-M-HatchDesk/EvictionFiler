using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addlegalcaseid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LegalCaseId",
                table: "CaseAppearances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseAppearances_LegalCaseId",
                table: "CaseAppearances",
                column: "LegalCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAppearances_LegalCases_LegalCaseId",
                table: "CaseAppearances",
                column: "LegalCaseId",
                principalTable: "LegalCases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseAppearances_LegalCases_LegalCaseId",
                table: "CaseAppearances");

            migrationBuilder.DropIndex(
                name: "IX_CaseAppearances_LegalCaseId",
                table: "CaseAppearances");

            migrationBuilder.DropColumn(
                name: "LegalCaseId",
                table: "CaseAppearances");
        }
    }
}
