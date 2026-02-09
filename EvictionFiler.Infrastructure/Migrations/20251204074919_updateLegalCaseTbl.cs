using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateLegalCaseTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalComments",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffidavitofService",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assistance",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CourtDraftNop",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeemedService",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expiry",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FilingMethodId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GoodCauseExempt",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LastPayment",
                table: "LegalCases",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastPaymentDate",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LeaseStart",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NextBussinessday",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NoticeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NoticeproofAttached",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PlannedServiceDate",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PreferedFilingDate",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RegistrationRentAttached",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceMethodId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "leasedAttached",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ledgerAttached",
                table: "LegalCases",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_FilingMethodId",
                table: "LegalCases",
                column: "FilingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_NoticeId",
                table: "LegalCases",
                column: "NoticeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ServiceMethodId",
                table: "LegalCases",
                column: "ServiceMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstFilingMethod_FilingMethodId",
                table: "LegalCases",
                column: "FilingMethodId",
                principalTable: "MstFilingMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstFormTypes_NoticeId",
                table: "LegalCases",
                column: "NoticeId",
                principalTable: "MstFormTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstServiceMethod_ServiceMethodId",
                table: "LegalCases",
                column: "ServiceMethodId",
                principalTable: "MstServiceMethod",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstFilingMethod_FilingMethodId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstFormTypes_NoticeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstServiceMethod_ServiceMethodId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_FilingMethodId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_NoticeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ServiceMethodId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AdditionalComments",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AffidavitofService",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Assistance",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CourtDraftNop",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "DeemedService",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Expiry",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "FilingMethodId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "GoodCauseExempt",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LastPayment",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LastPaymentDate",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "LeaseStart",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "NextBussinessday",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "NoticeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "NoticeproofAttached",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PlannedServiceDate",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PreferedFilingDate",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RegistrationRentAttached",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ServiceMethodId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "leasedAttached",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ledgerAttached",
                table: "LegalCases");
        }
    }
}
