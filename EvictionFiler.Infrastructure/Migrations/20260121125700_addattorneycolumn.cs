using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addattorneycolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aps_Agl",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OppAttorneyEmail",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OppAttorneyFirm",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OppAttorneyPhone",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OppAttorneyname",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aps_Agl",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OppAttorneyEmail",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OppAttorneyFirm",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OppAttorneyPhone",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OppAttorneyname",
                table: "LegalCases");
        }
    }
}
