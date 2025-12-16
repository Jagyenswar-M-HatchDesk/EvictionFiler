using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtblCaseNoticeinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseNoticeInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateRentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenancyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MonthlyRent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantShare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredicateNotice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPaidAmt = table.Column<int>(type: "int", nullable: true),
                    Totalowed = table.Column<int>(type: "int", nullable: true),
                    CalcNoticeLength = table.Column<int>(type: "int", nullable: true),
                    DateofLastPayment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNoticeServed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GoodCauseExempt = table.Column<bool>(type: "bit", nullable: true),
                    LeasedAttached = table.Column<bool>(type: "bit", nullable: true),
                    LedgerAttached = table.Column<bool>(type: "bit", nullable: true),
                    NoticeProofattached = table.Column<bool>(type: "bit", nullable: true),
                    RegistrationRentHistory = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_CaseNoticeInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseNoticeInfo_MstDateRent_DateRentId",
                        column: x => x.DateRentId,
                        principalTable: "MstDateRent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseNoticeInfo_MstTenancyTypes_DateRentId",
                        column: x => x.DateRentId,
                        principalTable: "MstTenancyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseNoticeInfo_DateRentId",
                table: "CaseNoticeInfo",
                column: "DateRentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseNoticeInfo");
        }
    }
}
