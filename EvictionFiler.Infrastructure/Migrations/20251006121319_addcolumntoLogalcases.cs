using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolumntoLogalcases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalculatedNoticeLength",
                table: "LegalCases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseProgramId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateNoticeServed",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpirationDate",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GoodCauseApplies",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastRentPaid",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LeaseEnd",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OralAgreeMent",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PredicateNotice",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialService",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOrApartmentNumber",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstCaseProgram",
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
                    table.PrimaryKey("PK_MstCaseProgram", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstCaseProgram");

            migrationBuilder.DropColumn(
                name: "CalculatedNoticeLength",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseProgramId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "DateNoticeServed",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "GoodCauseApplies",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LastRentPaid",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LeaseEnd",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OralAgreeMent",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PredicateNotice",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "SocialService",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "UnitOrApartmentNumber",
                table: "LegalCases");
        }
    }
}
