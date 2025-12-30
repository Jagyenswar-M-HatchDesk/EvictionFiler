using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablemodifyLegalcase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_TblRemainderCenter_RemainderCenterId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_RemainderCenterId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RemainderCenterId",
                table: "LegalCases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RemainderCenterId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RemainderCenterId",
                table: "LegalCases",
                column: "RemainderCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_TblRemainderCenter_RemainderCenterId",
                table: "LegalCases",
                column: "RemainderCenterId",
                principalTable: "TblRemainderCenter",
                principalColumn: "Id");
        }
    }
}
