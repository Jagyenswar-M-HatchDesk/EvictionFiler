using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LegalCaseModifyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MarshalId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_MarshalId",
                table: "LegalCases",
                column: "MarshalId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_Marshal_MarshalId",
                table: "LegalCases",
                column: "MarshalId",
                principalTable: "Marshal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_Marshal_MarshalId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_MarshalId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "MarshalId",
                table: "LegalCases");
        }
    }
}
