using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTblCourt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountyId",
                table: "Courts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courts_CountyId",
                table: "Courts",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_MstCounties_CountyId",
                table: "Courts",
                column: "CountyId",
                principalTable: "MstCounties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courts_MstCounties_CountyId",
                table: "Courts");

            migrationBuilder.DropIndex(
                name: "IX_Courts_CountyId",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "Courts");
        }
    }
}
