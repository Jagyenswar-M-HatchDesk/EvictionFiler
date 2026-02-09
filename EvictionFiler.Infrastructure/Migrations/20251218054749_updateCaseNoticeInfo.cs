using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateCaseNoticeInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assistance",
                table: "CaseNoticeInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LeaseEnd",
                table: "CaseNoticeInfo",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LeaseStart",
                table: "CaseNoticeInfo",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WrittenLease",
                table: "CaseNoticeInfo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseNoticeId",
                table: "ArrearLedgers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArrearLedgers_CaseNoticeId",
                table: "ArrearLedgers",
                column: "CaseNoticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArrearLedgers_CaseNoticeInfo_CaseNoticeId",
                table: "ArrearLedgers",
                column: "CaseNoticeId",
                principalTable: "CaseNoticeInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArrearLedgers_CaseNoticeInfo_CaseNoticeId",
                table: "ArrearLedgers");

            migrationBuilder.DropIndex(
                name: "IX_ArrearLedgers_CaseNoticeId",
                table: "ArrearLedgers");

            migrationBuilder.DropColumn(
                name: "Assistance",
                table: "CaseNoticeInfo");

            migrationBuilder.DropColumn(
                name: "LeaseEnd",
                table: "CaseNoticeInfo");

            migrationBuilder.DropColumn(
                name: "LeaseStart",
                table: "CaseNoticeInfo");

            migrationBuilder.DropColumn(
                name: "WrittenLease",
                table: "CaseNoticeInfo");

            migrationBuilder.DropColumn(
                name: "CaseNoticeId",
                table: "ArrearLedgers");
        }
    }
}
