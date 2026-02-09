using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Calanadertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstCaseStatus",
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
                    table.PrimaryKey("PK_MstCaseStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstCounties",
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
                    table.PrimaryKey("PK_MstCounties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstCourtPart",
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
                    table.PrimaryKey("PK_MstCourtPart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calanders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Judge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourtPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CaseStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CaseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Calanders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calanders_MstCaseStatus_CaseStatusId",
                        column: x => x.CaseStatusId,
                        principalTable: "MstCaseStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calanders_MstCaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "MstCaseTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calanders_MstCounties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "MstCounties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calanders_MstCourtPart_CourtPartId",
                        column: x => x.CourtPartId,
                        principalTable: "MstCourtPart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calanders_CaseStatusId",
                table: "Calanders",
                column: "CaseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Calanders_CaseTypeId",
                table: "Calanders",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Calanders_CountyId",
                table: "Calanders",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Calanders_CourtPartId",
                table: "Calanders",
                column: "CourtPartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calanders");

            migrationBuilder.DropTable(
                name: "MstCaseStatus");

            migrationBuilder.DropTable(
                name: "MstCounties");

            migrationBuilder.DropTable(
                name: "MstCourtPart");
        }
    }
}
