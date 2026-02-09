using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateCaseDoctbl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "CaseDocument",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CaseDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CaseDocument",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "CaseDocument",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CaseDocument",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CaseDocument",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "CaseDocument",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "CaseDocument",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "CaseDocument");
        }
    }
}
