using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstAppearanceTypes_AppearanceTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstCaseTypesHPD_CaseTypeHPDId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstDefenseTypes_DefenseTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstHarassmentTypes_HarassmentTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstReliefPetitionerTypes_ReliefPetitionerTypeId",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_MstReliefRespondentTypes_ReliefRespondentTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_AppearanceTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CaseTypeHPDId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_DefenseTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_HarassmentTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ReliefPetitionerTypeId",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_ReliefRespondentTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "AppearanceTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CaseTypeHPDId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "DefenseTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "HarassmentTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ReliefPetitionerTypeId",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "ReliefRespondentTypeId",
                table: "LegalCases");

            migrationBuilder.CreateTable(
                name: "AppearanceTypeLegalCase",
                columns: table => new
                {
                    AppearanceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppearanceTypeLegalCase", x => new { x.AppearanceTypeId, x.LegalCasesId });
                    table.ForeignKey(
                        name: "FK_AppearanceTypeLegalCase_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppearanceTypeLegalCase_MstAppearanceTypes_AppearanceTypeId",
                        column: x => x.AppearanceTypeId,
                        principalTable: "MstAppearanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseTypeHPDLegalCase",
                columns: table => new
                {
                    CaseTypeHPDsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypeHPDLegalCase", x => new { x.CaseTypeHPDsId, x.LegalCasesId });
                    table.ForeignKey(
                        name: "FK_CaseTypeHPDLegalCase_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseTypeHPDLegalCase_MstCaseTypesHPD_CaseTypeHPDsId",
                        column: x => x.CaseTypeHPDsId,
                        principalTable: "MstCaseTypesHPD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefenseTypeLegalCase",
                columns: table => new
                {
                    DefenseTypseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenseTypeLegalCase", x => new { x.DefenseTypseId, x.LegalCasesId });
                    table.ForeignKey(
                        name: "FK_DefenseTypeLegalCase_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefenseTypeLegalCase_MstDefenseTypes_DefenseTypseId",
                        column: x => x.DefenseTypseId,
                        principalTable: "MstDefenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HarassmentTypeLegalCase",
                columns: table => new
                {
                    HarassmentTypseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarassmentTypeLegalCase", x => new { x.HarassmentTypseId, x.LegalCasesId });
                    table.ForeignKey(
                        name: "FK_HarassmentTypeLegalCase_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarassmentTypeLegalCase_MstHarassmentTypes_HarassmentTypseId",
                        column: x => x.HarassmentTypseId,
                        principalTable: "MstHarassmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalCaseReliefPetitionerType",
                columns: table => new
                {
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReliefPetitionerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCaseReliefPetitionerType", x => new { x.LegalCasesId, x.ReliefPetitionerTypeId });
                    table.ForeignKey(
                        name: "FK_LegalCaseReliefPetitionerType_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalCaseReliefPetitionerType_MstReliefPetitionerTypes_ReliefPetitionerTypeId",
                        column: x => x.ReliefPetitionerTypeId,
                        principalTable: "MstReliefPetitionerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalCaseReliefRespondentType",
                columns: table => new
                {
                    LegalCasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReliefRespondentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCaseReliefRespondentType", x => new { x.LegalCasesId, x.ReliefRespondentTypeId });
                    table.ForeignKey(
                        name: "FK_LegalCaseReliefRespondentType_LegalCases_LegalCasesId",
                        column: x => x.LegalCasesId,
                        principalTable: "LegalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalCaseReliefRespondentType_MstReliefRespondentTypes_ReliefRespondentTypeId",
                        column: x => x.ReliefRespondentTypeId,
                        principalTable: "MstReliefRespondentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppearanceTypeLegalCase_LegalCasesId",
                table: "AppearanceTypeLegalCase",
                column: "LegalCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypeHPDLegalCase_LegalCasesId",
                table: "CaseTypeHPDLegalCase",
                column: "LegalCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenseTypeLegalCase_LegalCasesId",
                table: "DefenseTypeLegalCase",
                column: "LegalCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_HarassmentTypeLegalCase_LegalCasesId",
                table: "HarassmentTypeLegalCase",
                column: "LegalCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCaseReliefPetitionerType_ReliefPetitionerTypeId",
                table: "LegalCaseReliefPetitionerType",
                column: "ReliefPetitionerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCaseReliefRespondentType_ReliefRespondentTypeId",
                table: "LegalCaseReliefRespondentType",
                column: "ReliefRespondentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppearanceTypeLegalCase");

            migrationBuilder.DropTable(
                name: "CaseTypeHPDLegalCase");

            migrationBuilder.DropTable(
                name: "DefenseTypeLegalCase");

            migrationBuilder.DropTable(
                name: "HarassmentTypeLegalCase");

            migrationBuilder.DropTable(
                name: "LegalCaseReliefPetitionerType");

            migrationBuilder.DropTable(
                name: "LegalCaseReliefRespondentType");

            migrationBuilder.AddColumn<Guid>(
                name: "AppearanceTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CaseTypeHPDId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DefenseTypeId",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HarassmentTypeId",
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

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_AppearanceTypeId",
                table: "LegalCases",
                column: "AppearanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseTypeHPDId",
                table: "LegalCases",
                column: "CaseTypeHPDId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_DefenseTypeId",
                table: "LegalCases",
                column: "DefenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_HarassmentTypeId",
                table: "LegalCases",
                column: "HarassmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ReliefPetitionerTypeId",
                table: "LegalCases",
                column: "ReliefPetitionerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_ReliefRespondentTypeId",
                table: "LegalCases",
                column: "ReliefRespondentTypeId");

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
                name: "FK_LegalCases_MstDefenseTypes_DefenseTypeId",
                table: "LegalCases",
                column: "DefenseTypeId",
                principalTable: "MstDefenseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_MstHarassmentTypes_HarassmentTypeId",
                table: "LegalCases",
                column: "HarassmentTypeId",
                principalTable: "MstHarassmentTypes",
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
    }
}
