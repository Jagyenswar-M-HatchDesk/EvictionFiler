using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFormCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MstFormTypes_MstCategories_CategoryId",
                table: "MstFormTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstFormTypes_CategoryId",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MstFormTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "FormCategoryId",
                table: "MstFormTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstFormCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_MstFormCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstFormCategories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MstFormTypes_FormCategoryId",
                table: "MstFormTypes",
                column: "FormCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MstFormCategories_CreatedById",
                table: "MstFormCategories",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_MstFormTypes_MstFormCategories_FormCategoryId",
                table: "MstFormTypes",
                column: "FormCategoryId",
                principalTable: "MstFormCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MstFormTypes_MstFormCategories_FormCategoryId",
                table: "MstFormTypes");

            migrationBuilder.DropTable(
                name: "MstFormCategories");

            migrationBuilder.DropIndex(
                name: "IX_MstFormTypes_FormCategoryId",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "FormCategoryId",
                table: "MstFormTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "MstFormTypes",
                type: "uniqueidentifier",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MstFormTypes_CategoryId",
                table: "MstFormTypes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MstFormTypes_MstCategories_CategoryId",
                table: "MstFormTypes",
                column: "CategoryId",
                principalTable: "MstCategories",
                principalColumn: "Id");
        }
    }
}
