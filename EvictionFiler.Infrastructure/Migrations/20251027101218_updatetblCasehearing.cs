using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetblCasehearing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HearingDate",
                table: "CaseHearings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CaseHearings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CaseHearings",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HearingTime",
                table: "CaseHearings",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndexNo",
                table: "CaseHearings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CaseHearings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CaseHearings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "CaseHearings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "HearingTime",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "IndexNo",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "CaseHearings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HearingDate",
                table: "CaseHearings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
