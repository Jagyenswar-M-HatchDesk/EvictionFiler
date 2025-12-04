using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemianderTableModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountyName",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "TblRemainderCenter");

            migrationBuilder.AddColumn<Guid>(
                name: "CountyId",
                table: "TblRemainderCenter",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "TblRemainderCenter",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblRemainderCenter_CountyId",
                table: "TblRemainderCenter",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRemainderCenter_TenantId",
                table: "TblRemainderCenter",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_MstCounties_CountyId",
                table: "TblRemainderCenter",
                column: "CountyId",
                principalTable: "MstCounties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_Tenants_TenantId",
                table: "TblRemainderCenter",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_MstCounties_CountyId",
                table: "TblRemainderCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_Tenants_TenantId",
                table: "TblRemainderCenter");

            migrationBuilder.DropIndex(
                name: "IX_TblRemainderCenter_CountyId",
                table: "TblRemainderCenter");

            migrationBuilder.DropIndex(
                name: "IX_TblRemainderCenter_TenantId",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "TblRemainderCenter");

            migrationBuilder.AddColumn<string>(
                name: "CountyName",
                table: "TblRemainderCenter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "TblRemainderCenter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
