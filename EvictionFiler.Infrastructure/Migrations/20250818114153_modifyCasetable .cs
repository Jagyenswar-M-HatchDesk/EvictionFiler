using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyCasetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateTenantMoved",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "OralEnd",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "OralStart",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RenewalStatusId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WrittenLease",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstRenewalStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstRenewalStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RenewalStatusId",
                table: "LegalCases",
                column: "RenewalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstRenewalStatus_RenewalStatusId",
                table: "LegalCases",
                column: "RenewalStatusId",
                principalTable: "MstRenewalStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstRenewalStatus_RenewalStatusId",
                table: "LegalCases");

            migrationBuilder.DropTable(
                name: "MstRenewalStatus");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_RenewalStatusId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "DateTenantMoved",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OralEnd",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OralStart",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RenewalStatusId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "WrittenLease",
                table: "LegalCases");
        }
    }
}
