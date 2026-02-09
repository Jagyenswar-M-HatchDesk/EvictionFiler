using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "AppearanceDate",
                table: "LegalCases",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AppearanceTime",
                table: "LegalCases",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppearanceTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttrneyEmail",
                table: "LegalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseTypeHPDId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtLocation",
                table: "LegalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtRoom",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Index",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceTo",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagingAgent",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpposingCounsel",
                table: "LegalCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartyRepresentId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReliefPetitionerTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReliefRespondentTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingTypeId",
                table: "Buildings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegistrationStatusId",
                table: "Buildings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstAppearanceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstAppearanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstBilingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstBilingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstBuildingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstBuildingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstCaseTypesHPD",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstCaseTypesHPD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstDefenseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstDefenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstHarassmentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstHarassmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstPartyRepresents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstPartyRepresents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstRegistrationstatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstRegistrationstatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstReliefPetitionerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstReliefPetitionerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstReliefRespondentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstReliefRespondentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_AppearanceTypeId",
                table: "LegalCases",
                column: "AppearanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseTypeHPDId",
                table: "LegalCases",
                column: "CaseTypeHPDId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_PartyRepresentId",
                table: "LegalCases",
                column: "PartyRepresentId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ReliefPetitionerTypeId",
                table: "LegalCases",
                column: "ReliefPetitionerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ReliefRespondentTypeId",
                table: "LegalCases",
                column: "ReliefRespondentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_RegistrationStatusId",
                table: "Buildings",
                column: "RegistrationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstBuildingTypes_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId",
                principalTable: "MstBuildingTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_MstRegistrationstatuses_RegistrationStatusId",
                table: "Buildings",
                column: "RegistrationStatusId",
                principalTable: "MstRegistrationstatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstAppearanceTypes_AppearanceTypeId",
                table: "LegalCases",
                column: "AppearanceTypeId",
                principalTable: "MstAppearanceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstCaseTypesHPD_CaseTypeHPDId",
                table: "LegalCases",
                column: "CaseTypeHPDId",
                principalTable: "MstCaseTypesHPD",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstPartyRepresents_PartyRepresentId",
                table: "LegalCases",
                column: "PartyRepresentId",
                principalTable: "MstPartyRepresents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstReliefPetitionerTypes_ReliefPetitionerTypeId",
                table: "LegalCases",
                column: "ReliefPetitionerTypeId",
                principalTable: "MstReliefPetitionerTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstReliefRespondentTypes_ReliefRespondentTypeId",
                table: "LegalCases",
                column: "ReliefRespondentTypeId",
                principalTable: "MstReliefRespondentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstBuildingTypes_BuildingTypeId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_MstRegistrationstatuses_RegistrationStatusId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstAppearanceTypes_AppearanceTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstCaseTypesHPD_CaseTypeHPDId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstPartyRepresents_PartyRepresentId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstReliefPetitionerTypes_ReliefPetitionerTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstReliefRespondentTypes_ReliefRespondentTypeId",
                table: "LegalCases");

            migrationBuilder.DropTable(
                name: "MstAppearanceTypes");

            migrationBuilder.DropTable(
                name: "MstBilingTypes");

            migrationBuilder.DropTable(
                name: "MstBuildingTypes");

            migrationBuilder.DropTable(
                name: "MstCaseTypesHPD");

            migrationBuilder.DropTable(
                name: "MstDefenseTypes");

            migrationBuilder.DropTable(
                name: "MstHarassmentTypes");

            migrationBuilder.DropTable(
                name: "MstPartyRepresents");

            migrationBuilder.DropTable(
                name: "MstRegistrationstatuses");

            migrationBuilder.DropTable(
                name: "MstReliefPetitionerTypes");

            migrationBuilder.DropTable(
                name: "MstReliefRespondentTypes");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_AppearanceTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CaseTypeHPDId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_PartyRepresentId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ReliefPetitionerTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ReliefRespondentTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_RegistrationStatusId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "AppearanceDate",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AppearanceTime",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AppearanceTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AttrneyEmail",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseTypeHPDId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "County",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CourtLocation",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CourtRoom",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "InvoiceTo",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ManagingAgent",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "OpposingCounsel",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "PartyRepresentId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ReliefPetitionerTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ReliefRespondentTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "RegistrationStatusId",
                table: "Buildings");
        }
    }
}
