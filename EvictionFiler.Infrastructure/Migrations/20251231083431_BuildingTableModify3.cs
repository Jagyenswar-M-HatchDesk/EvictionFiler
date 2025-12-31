using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BuildingTableModify3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstExemptionReason_ExemptionBasisId",
                table: "Buildings");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ExemptionReasonId",
                table: "Buildings",
                column: "ExemptionReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstExemptionReason_ExemptionReasonId",
                table: "Buildings",
                column: "ExemptionReasonId",
                principalTable: "MstExemptionReason",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstExemptionReason_ExemptionReasonId",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_ExemptionReasonId",
                table: "Buildings");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstExemptionReason_ExemptionBasisId",
                table: "Buildings",
                column: "ExemptionBasisId",
                principalTable: "MstExemptionReason",
                principalColumn: "Id");
        }
    }
}
