using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtblDoctype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeId",
                table: "CaseDocument",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstDocumentType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MstDocumentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocument_DocumentTypeId",
                table: "CaseDocument",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDocument_MstDocumentType_DocumentTypeId",
                table: "CaseDocument",
                column: "DocumentTypeId",
                principalTable: "MstDocumentType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseDocument_MstDocumentType_DocumentTypeId",
                table: "CaseDocument");

            migrationBuilder.DropTable(
                name: "MstDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_CaseDocument_DocumentTypeId",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "CaseDocument");
        }
    }
}
