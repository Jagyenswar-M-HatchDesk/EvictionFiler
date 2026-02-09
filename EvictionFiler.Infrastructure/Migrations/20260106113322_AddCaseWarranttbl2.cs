using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCaseWarranttbl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "CaseWarrants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CaseWarrants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CaseWarrants",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "CaseWarrants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CaseWarrants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CaseWarrants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "CaseWarrants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "CaseWarrants",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "CaseWarrants");
        }
    }
}
