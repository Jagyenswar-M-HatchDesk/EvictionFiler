using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetblFeesmanagementv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance",
                newName: "Ids");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster",
                newName: "Ids");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog",
                newName: "Ids");
        }
    }
}
