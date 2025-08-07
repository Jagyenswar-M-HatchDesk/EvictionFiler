using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fieldchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalOccupantId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firm",
                table: "LegalCases",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AttrneyContactInfo",
                table: "LegalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Attrney",
                table: "LegalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ExplainTenancyReceiveDescription",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherPropertiesBuildingId",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "tenantReceive",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdditionalOccupants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_AdditionalOccupants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_AdditionalOccupantId",
                table: "Tenants",
                column: "AdditionalOccupantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AdditionalOccupants_AdditionalOccupantId",
                table: "Tenants",
                column: "AdditionalOccupantId",
                principalTable: "AdditionalOccupants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AdditionalOccupants_AdditionalOccupantId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "AdditionalOccupants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_AdditionalOccupantId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "AdditionalOccupantId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ExplainTenancyReceiveDescription",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OtherPropertiesBuildingId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "tenantReceive",
                table: "LegalCases");

            migrationBuilder.AlterColumn<string>(
                name: "Firm",
                table: "LegalCases",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AttrneyContactInfo",
                table: "LegalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Attrney",
                table: "LegalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
