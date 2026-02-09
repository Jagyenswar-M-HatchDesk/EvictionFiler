using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolumntblCaseNoticeinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LegalCaseId",
                table: "CaseNoticeInfo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseNoticeInfo_LegalCaseId",
                table: "CaseNoticeInfo",
                column: "LegalCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNoticeInfo_LegalCases_LegalCaseId",
                table: "CaseNoticeInfo",
                column: "LegalCaseId",
                principalTable: "LegalCases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseNoticeInfo_LegalCases_LegalCaseId",
                table: "CaseNoticeInfo");

            migrationBuilder.DropIndex(
                name: "IX_CaseNoticeInfo_LegalCaseId",
                table: "CaseNoticeInfo");

            migrationBuilder.DropColumn(
                name: "LegalCaseId",
                table: "CaseNoticeInfo");
        }
    }
}
