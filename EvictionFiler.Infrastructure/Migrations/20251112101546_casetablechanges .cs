using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class casetablechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BilingTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_BilingTypeId",
                table: "LegalCases",
                column: "BilingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstBilingTypes_BilingTypeId",
                table: "LegalCases",
                column: "BilingTypeId",
                principalTable: "MstBilingTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstBilingTypes_BilingTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_BilingTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "BilingTypeId",
                table: "LegalCases");
        }
    }
}
