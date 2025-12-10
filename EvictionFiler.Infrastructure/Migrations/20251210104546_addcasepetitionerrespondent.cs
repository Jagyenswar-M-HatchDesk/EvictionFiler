using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcasepetitionerrespondent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseAdditionalPetitioners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LegalcaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CaseAdditionalPetitioners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseAdditionalPetitioners_LegalCases_LegalcaseId",
                        column: x => x.LegalcaseId,
                        principalTable: "LegalCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseAdditionalPetitioners_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CaseAdditionalResondents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandlordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LegalcaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CaseAdditionalResondents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseAdditionalResondents_LandLords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "LandLords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseAdditionalResondents_LegalCases_LegalcaseId",
                        column: x => x.LegalcaseId,
                        principalTable: "LegalCases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseAdditionalPetitioners_LegalcaseId",
                table: "CaseAdditionalPetitioners",
                column: "LegalcaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAdditionalPetitioners_TenantId",
                table: "CaseAdditionalPetitioners",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAdditionalResondents_LandlordId",
                table: "CaseAdditionalResondents",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAdditionalResondents_LegalcaseId",
                table: "CaseAdditionalResondents",
                column: "LegalcaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseAdditionalPetitioners");

            migrationBuilder.DropTable(
                name: "CaseAdditionalResondents");
        }
    }
}
