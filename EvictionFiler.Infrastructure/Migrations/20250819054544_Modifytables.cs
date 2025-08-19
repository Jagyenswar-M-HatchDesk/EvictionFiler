using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modifytables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borough",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LastMonthWeekRentPaid",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Registration_No",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TotalRentOwed",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "Name_Relation",
                table: "Tenants",
                newName: "Additionaltenants");

            migrationBuilder.AddColumn<DateOnly>(
                name: "MoveInDate",
                table: "Tenants",
                type: "date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstDateRent",
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
                    table.PrimaryKey("PK_MstDateRent", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstDateRent");

            migrationBuilder.DropColumn(
                name: "MoveInDate",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "Additionaltenants",
                table: "Tenants",
                newName: "Name_Relation");

            migrationBuilder.AddColumn<string>(
                name: "Borough",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMonthWeekRentPaid",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Registration_No",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalRentOwed",
                table: "Tenants",
                type: "float",
                nullable: true);
        }
    }
}
