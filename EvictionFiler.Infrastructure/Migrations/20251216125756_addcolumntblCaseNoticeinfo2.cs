using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolumntblCaseNoticeinfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantShare",
                table: "CaseNoticeInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonthlyRent",
                table: "CaseNoticeInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormtypeId",
                table: "CaseNoticeInfo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseNoticeInfo_FormtypeId",
                table: "CaseNoticeInfo",
                column: "FormtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNoticeInfo_MstFormTypes_FormtypeId",
                table: "CaseNoticeInfo",
                column: "FormtypeId",
                principalTable: "MstFormTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseNoticeInfo_MstFormTypes_FormtypeId",
                table: "CaseNoticeInfo");

            migrationBuilder.DropIndex(
                name: "IX_CaseNoticeInfo_FormtypeId",
                table: "CaseNoticeInfo");

            migrationBuilder.DropColumn(
                name: "FormtypeId",
                table: "CaseNoticeInfo");

            migrationBuilder.AlterColumn<string>(
                name: "TenantShare",
                table: "CaseNoticeInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MonthlyRent",
                table: "CaseNoticeInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
