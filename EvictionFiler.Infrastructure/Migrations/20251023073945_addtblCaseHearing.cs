using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtblCaseHearing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourtId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillAmount",
                table: "CaseForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CaseHearings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HearingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LegalCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseHearings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseHearings_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseHearings_LegalCases_LegalCaseId",
                        column: x => x.LegalCaseId,
                        principalTable: "LegalCases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CourtId",
                table: "LegalCases",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_CourtId",
                table: "CaseHearings",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_LegalCaseId",
                table: "CaseHearings",
                column: "LegalCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_Courts_CourtId",
                table: "LegalCases",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_Courts_CourtId",
                table: "LegalCases");

            migrationBuilder.DropTable(
                name: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CourtId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "BillAmount",
                table: "CaseForms");
        }
    }
}
