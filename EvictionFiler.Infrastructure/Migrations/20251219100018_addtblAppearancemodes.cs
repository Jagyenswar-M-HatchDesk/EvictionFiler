using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtblAppearancemodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppearanceModeId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppearanceTypeId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppreanceModeId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VirtualPlatformId",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstAppearanceModes",
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
                    table.PrimaryKey("PK_MstAppearanceModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstVirtualPlatforms",
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
                    table.PrimaryKey("PK_MstVirtualPlatforms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_AppearanceTypeId",
                table: "CaseHearings",
                column: "AppearanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_AppreanceModeId",
                table: "CaseHearings",
                column: "AppreanceModeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_VirtualPlatformId",
                table: "CaseHearings",
                column: "VirtualPlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstAppearanceModes_AppreanceModeId",
                table: "CaseHearings",
                column: "AppreanceModeId",
                principalTable: "MstAppearanceModes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstAppearanceTypes_AppearanceTypeId",
                table: "CaseHearings",
                column: "AppearanceTypeId",
                principalTable: "MstAppearanceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstVirtualPlatforms_VirtualPlatformId",
                table: "CaseHearings",
                column: "VirtualPlatformId",
                principalTable: "MstVirtualPlatforms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstAppearanceModes_AppreanceModeId",
                table: "CaseHearings");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstAppearanceTypes_AppearanceTypeId",
                table: "CaseHearings");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstVirtualPlatforms_VirtualPlatformId",
                table: "CaseHearings");

            migrationBuilder.DropTable(
                name: "MstAppearanceModes");

            migrationBuilder.DropTable(
                name: "MstVirtualPlatforms");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_AppearanceTypeId",
                table: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_AppreanceModeId",
                table: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_VirtualPlatformId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "AppearanceModeId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "AppearanceTypeId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "AppreanceModeId",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "VirtualPlatformId",
                table: "CaseHearings");
        }
    }
}
