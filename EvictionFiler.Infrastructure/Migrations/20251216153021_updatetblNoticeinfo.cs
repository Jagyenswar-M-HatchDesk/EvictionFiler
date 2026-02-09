using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetblNoticeinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseNoticeInfo_MstTenancyTypes_DateRentId",
                table: "CaseNoticeInfo");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpirationDate",
                table: "CaseNoticeInfo",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateofLastPayment",
                table: "CaseNoticeInfo",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateNoticeServed",
                table: "CaseNoticeInfo",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseNoticeInfo_TenancyTypeId",
                table: "CaseNoticeInfo",
                column: "TenancyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNoticeInfo_MstTenancyTypes_TenancyTypeId",
                table: "CaseNoticeInfo",
                column: "TenancyTypeId",
                principalTable: "MstTenancyTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseNoticeInfo_MstTenancyTypes_TenancyTypeId",
                table: "CaseNoticeInfo");

            migrationBuilder.DropIndex(
                name: "IX_CaseNoticeInfo_TenancyTypeId",
                table: "CaseNoticeInfo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "CaseNoticeInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateofLastPayment",
                table: "CaseNoticeInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNoticeServed",
                table: "CaseNoticeInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNoticeInfo_MstTenancyTypes_DateRentId",
                table: "CaseNoticeInfo",
                column: "DateRentId",
                principalTable: "MstTenancyTypes",
                principalColumn: "Id");
        }
    }
}
