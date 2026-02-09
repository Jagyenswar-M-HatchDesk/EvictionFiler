using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TblUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MstFormTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rate",
                table: "MstFormTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "MstFormTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MstUnits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MstFormTypes_UnitId",
                table: "MstFormTypes",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_MstFormTypes_MstUnits_UnitId",
                table: "MstFormTypes",
                column: "UnitId",
                principalTable: "MstUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MstFormTypes_MstUnits_UnitId",
                table: "MstFormTypes");

            migrationBuilder.DropTable(
                name: "MstUnits");

            migrationBuilder.DropIndex(
                name: "IX_MstFormTypes_UnitId",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "MstFormTypes");
        }
    }
}
