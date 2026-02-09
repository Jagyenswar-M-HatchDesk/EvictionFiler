using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class casetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefenseTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HarassmentTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_DefenseTypeId",
                table: "LegalCases",
                column: "DefenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_HarassmentTypeId",
                table: "LegalCases",
                column: "HarassmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstDefenseTypes_DefenseTypeId",
                table: "LegalCases",
                column: "DefenseTypeId",
                principalTable: "MstDefenseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstHarassmentTypes_HarassmentTypeId",
                table: "LegalCases",
                column: "HarassmentTypeId",
                principalTable: "MstHarassmentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstDefenseTypes_DefenseTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstHarassmentTypes_HarassmentTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_DefenseTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_HarassmentTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "DefenseTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "HarassmentTypeId",
                table: "LegalCases");
        }
    }
}
