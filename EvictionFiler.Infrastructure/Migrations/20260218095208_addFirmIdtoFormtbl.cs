using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFirmIdtoFormtbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FirmId",
                table: "MstFormTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MstFormTypes_FirmId",
                table: "MstFormTypes",
                column: "FirmId");

            migrationBuilder.AddForeignKey(
                name: "FK_MstFormTypes_Firms_FirmId",
                table: "MstFormTypes",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MstFormTypes_Firms_FirmId",
                table: "MstFormTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstFormTypes_FirmId",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "MstFormTypes");
        }
    }
}
