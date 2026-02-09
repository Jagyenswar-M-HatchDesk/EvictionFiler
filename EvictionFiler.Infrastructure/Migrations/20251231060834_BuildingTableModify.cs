using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BuildingTableModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExemptionBasisId",
                table: "Buildings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExemptionReasonId",
                table: "Buildings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GoodCause",
                table: "Buildings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OwnerOccupied",
                table: "Buildings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryResidence",
                table: "Buildings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentRegulationDescription",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenancyTypeForBuildingId",
                table: "Buildings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstExemptionBasic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_MstExemptionBasic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstExemptionReason",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_MstExemptionReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstTenancyTypesForBuilding",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_MstTenancyTypesForBuilding", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ExemptionBasisId",
                table: "Buildings",
                column: "ExemptionBasisId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_TenancyTypeForBuildingId",
                table: "Buildings",
                column: "TenancyTypeForBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstExemptionBasic_ExemptionBasisId",
                table: "Buildings",
                column: "ExemptionBasisId",
                principalTable: "MstExemptionBasic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstExemptionReason_ExemptionBasisId",
                table: "Buildings",
                column: "ExemptionBasisId",
                principalTable: "MstExemptionReason",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstTenancyTypesForBuilding_TenancyTypeForBuildingId",
                table: "Buildings",
                column: "TenancyTypeForBuildingId",
                principalTable: "MstTenancyTypesForBuilding",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstExemptionBasic_ExemptionBasisId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstExemptionReason_ExemptionBasisId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstTenancyTypesForBuilding_TenancyTypeForBuildingId",
                table: "Buildings");

            migrationBuilder.DropTable(
                name: "MstExemptionBasic");

            migrationBuilder.DropTable(
                name: "MstExemptionReason");

            migrationBuilder.DropTable(
                name: "MstTenancyTypesForBuilding");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_ExemptionBasisId",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_TenancyTypeForBuildingId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ExemptionBasisId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ExemptionReasonId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "GoodCause",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "OwnerOccupied",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "PrimaryResidence",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "RentRegulationDescription",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "TenancyTypeForBuildingId",
                table: "Buildings");
        }
    }
}
