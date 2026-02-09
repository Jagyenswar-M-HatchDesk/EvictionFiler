using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCaseWarranttbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseWarrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarrantRequested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantIssued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantRejected = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReFileDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoticeServed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionEligible = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvictionExecuted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarshalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseWarrants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseWarrants_Marshal_MarshalId",
                        column: x => x.MarshalId,
                        principalTable: "Marshal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseWarrants_MarshalId",
                table: "CaseWarrants",
                column: "MarshalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseWarrants");
        }
    }
}
