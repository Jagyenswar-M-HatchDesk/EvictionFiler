using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLegalcaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExplainDescription",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonDescription",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReasonHoldoverId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstReasonHoldover",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstReasonHoldover", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ReasonHoldoverId",
                table: "LegalCases",
                column: "ReasonHoldoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstReasonHoldover_ReasonHoldoverId",
                table: "LegalCases",
                column: "ReasonHoldoverId",
                principalTable: "MstReasonHoldover",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstReasonHoldover_ReasonHoldoverId",
                table: "LegalCases");

            migrationBuilder.DropTable(
                name: "MstReasonHoldover");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ReasonHoldoverId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ExplainDescription",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ReasonDescription",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ReasonHoldoverId",
                table: "LegalCases");
        }
    }
}
