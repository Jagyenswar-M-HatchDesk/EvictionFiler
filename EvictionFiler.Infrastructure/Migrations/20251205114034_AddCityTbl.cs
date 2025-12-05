using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCityTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Buildings");

            migrationBuilder.AddColumn<Guid>(
                name: "SubCaseTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Buildings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MstCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSubCaseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MstSubCaseTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_SubCaseTypeId",
                table: "LegalCases",
                column: "SubCaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CityId",
                table: "Buildings",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstCities_CityId",
                table: "Buildings",
                column: "CityId",
                principalTable: "MstCities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstSubCaseTypes_SubCaseTypeId",
                table: "LegalCases",
                column: "SubCaseTypeId",
                principalTable: "MstSubCaseTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstCities_CityId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstSubCaseTypes_SubCaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropTable(
                name: "MstCities");

            migrationBuilder.DropTable(
                name: "MstSubCaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_SubCaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_CityId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "SubCaseTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Buildings");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
