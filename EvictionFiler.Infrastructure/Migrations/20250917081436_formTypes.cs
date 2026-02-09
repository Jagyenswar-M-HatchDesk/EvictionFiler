using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class formTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "MstFormTypes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
