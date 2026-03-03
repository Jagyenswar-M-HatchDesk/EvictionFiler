using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtenancyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenancyTypeId",
                table: "MstFormTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MstFormTypes_TenancyTypeId",
                table: "MstFormTypes",
                column: "TenancyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MstFormTypes_MstTenancyTypes_TenancyTypeId",
                table: "MstFormTypes",
                column: "TenancyTypeId",
                principalTable: "MstTenancyTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MstFormTypes_MstTenancyTypes_TenancyTypeId",
                table: "MstFormTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstFormTypes_TenancyTypeId",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "TenancyTypeId",
                table: "MstFormTypes");
        }
    }
}
