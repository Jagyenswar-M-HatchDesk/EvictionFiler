using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCaseWarranttbl3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LegalCaseId",
                table: "CaseWarrants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseWarrants_LegalCaseId",
                table: "CaseWarrants",
                column: "LegalCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWarrants_LegalCases_LegalCaseId",
                table: "CaseWarrants",
                column: "LegalCaseId",
                principalTable: "LegalCases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseWarrants_LegalCases_LegalCaseId",
                table: "CaseWarrants");

            migrationBuilder.DropIndex(
                name: "IX_CaseWarrants_LegalCaseId",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "LegalCaseId",
                table: "CaseWarrants");
        }
    }
}
