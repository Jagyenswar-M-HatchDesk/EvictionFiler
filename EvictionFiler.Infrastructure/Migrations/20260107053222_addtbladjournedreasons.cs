using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtbladjournedreasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstAdjournedReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MstAdjournedReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseAppearances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourtTodayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdjournDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdjournTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    AdjournReasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MotionDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OppositionDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReplyDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JurisdictionWaived = table.Column<bool>(type: "bit", nullable: false),
                    MilitaryAffidavit = table.Column<bool>(type: "bit", nullable: false),
                    WarrantIssued = table.Column<bool>(type: "bit", nullable: false),
                    WarrantDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StayUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReminderDeadlines = table.Column<bool>(type: "bit", nullable: false),
                    ReminderPayments = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_CaseAppearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseAppearances_MstAdjournedReasons_AdjournReasonId",
                        column: x => x.AdjournReasonId,
                        principalTable: "MstAdjournedReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseAppearances_MstCourtTodayType_CourtTodayId",
                        column: x => x.CourtTodayId,
                        principalTable: "MstCourtTodayType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseAppearances_AdjournReasonId",
                table: "CaseAppearances",
                column: "AdjournReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAppearances_CourtTodayId",
                table: "CaseAppearances",
                column: "CourtTodayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseAppearances");

            migrationBuilder.DropTable(
                name: "MstAdjournedReasons");
        }
    }
}
