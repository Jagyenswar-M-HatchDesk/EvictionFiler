using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tableChangesForPerdiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppearanceTypePerDiemId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseBackground",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Flatdescription",
                table: "LegalCases",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Hourlydescription",
                table: "LegalCases",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartyRepresentPerDiemId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Partynames",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerDiemAttorneyname",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PerDiemDate",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerDiemSignature",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RatetypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReliefActionRequested",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialInstruction",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravelExpense",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstAppearanceTypesPerDiems",
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
                    table.PrimaryKey("PK_MstAppearanceTypesPerDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstCaseTypePerdiems",
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
                    table.PrimaryKey("PK_MstCaseTypePerdiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstDocumentTypePerDiems",
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
                    table.PrimaryKey("PK_MstDocumentTypePerDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstPartyRepresentPerDiems",
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
                    table.PrimaryKey("PK_MstPartyRepresentPerDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstPaymentMethods",
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
                    table.PrimaryKey("PK_MstPaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstRateTypes",
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
                    table.PrimaryKey("PK_MstRateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstReportingTypePerDiems",
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
                    table.PrimaryKey("PK_MstReportingTypePerDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTypePerdiemLegalCase",
                columns: table => new
                {
                    CaseTypePerDiemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypePerdiemLegalCase", x => new { x.CaseTypePerDiemsId, x.LegalCasesId });
                    table.ForeignKey(
                        name: "FK_CaseTypePerdiemLegalCase_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseTypePerdiemLegalCase_MstCaseTypePerdiems_CaseTypePerDiemsId",
                        column: x => x.CaseTypePerDiemsId,
                        principalTable: "MstCaseTypePerdiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypePerDiemLegalCase",
                columns: table => new
                {
                    DocumentIntructionsTypseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypePerDiemLegalCase", x => new { x.DocumentIntructionsTypseId, x.LegalCasesId });
                    table.ForeignKey(
                        name: "FK_DocumentTypePerDiemLegalCase_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentTypePerDiemLegalCase_MstDocumentTypePerDiems_DocumentIntructionsTypseId",
                        column: x => x.DocumentIntructionsTypseId,
                        principalTable: "MstDocumentTypePerDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalCaseReportingTypePerDiem",
                columns: table => new
                {
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportingTypePerDiemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCaseReportingTypePerDiem", x => new { x.LegalCasesId, x.ReportingTypePerDiemsId });
                    table.ForeignKey(
                        name: "FK_LegalCaseReportingTypePerDiem_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalCaseReportingTypePerDiem_MstReportingTypePerDiems_ReportingTypePerDiemsId",
                        column: x => x.ReportingTypePerDiemsId,
                        principalTable: "MstReportingTypePerDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_AppearanceTypePerDiemId",
                table: "LegalCases",
                column: "AppearanceTypePerDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_PartyRepresentPerDiemId",
                table: "LegalCases",
                column: "PartyRepresentPerDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_PaymentMethodId",
                table: "LegalCases",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_RatetypeId",
                table: "LegalCases",
                column: "RatetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypePerdiemLegalCase_LegalCasesId",
                table: "CaseTypePerdiemLegalCase",
                column: "LegalCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypePerDiemLegalCase_LegalCasesId",
                table: "DocumentTypePerDiemLegalCase",
                column: "LegalCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCaseReportingTypePerDiem_ReportingTypePerDiemsId",
                table: "LegalCaseReportingTypePerDiem",
                column: "ReportingTypePerDiemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstAppearanceTypesPerDiems_AppearanceTypePerDiemId",
                table: "LegalCases",
                column: "AppearanceTypePerDiemId",
                principalTable: "MstAppearanceTypesPerDiems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstPartyRepresentPerDiems_PartyRepresentPerDiemId",
                table: "LegalCases",
                column: "PartyRepresentPerDiemId",
                principalTable: "MstPartyRepresentPerDiems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstPaymentMethods_PaymentMethodId",
                table: "LegalCases",
                column: "PaymentMethodId",
                principalTable: "MstPaymentMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstRateTypes_RatetypeId",
                table: "LegalCases",
                column: "RatetypeId",
                principalTable: "MstRateTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstAppearanceTypesPerDiems_AppearanceTypePerDiemId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstPartyRepresentPerDiems_PartyRepresentPerDiemId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstPaymentMethods_PaymentMethodId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstRateTypes_RatetypeId",
                table: "LegalCases");

            migrationBuilder.DropTable(
                name: "CaseTypePerdiemLegalCase");

            migrationBuilder.DropTable(
                name: "DocumentTypePerDiemLegalCase");

            migrationBuilder.DropTable(
                name: "LegalCaseReportingTypePerDiem");

            migrationBuilder.DropTable(
                name: "MstAppearanceTypesPerDiems");

            migrationBuilder.DropTable(
                name: "MstPartyRepresentPerDiems");

            migrationBuilder.DropTable(
                name: "MstPaymentMethods");

            migrationBuilder.DropTable(
                name: "MstRateTypes");

            migrationBuilder.DropTable(
                name: "MstCaseTypePerdiems");

            migrationBuilder.DropTable(
                name: "MstDocumentTypePerDiems");

            migrationBuilder.DropTable(
                name: "MstReportingTypePerDiems");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_AppearanceTypePerDiemId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_PartyRepresentPerDiemId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_PaymentMethodId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_RatetypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AppearanceTypePerDiemId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseBackground",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Flatdescription",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Hourlydescription",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PartyRepresentPerDiemId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Partynames",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PerDiemAttorneyname",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PerDiemDate",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PerDiemSignature",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "RatetypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ReliefActionRequested",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "SpecialInstruction",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "TravelExpense",
                table: "LegalCases");
        }
    }
}
