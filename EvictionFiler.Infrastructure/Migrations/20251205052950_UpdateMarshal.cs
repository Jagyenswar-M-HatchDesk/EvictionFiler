using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMarshal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Marshal",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Marshal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Marshal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Marshal");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Marshal");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Marshal",
                newName: "Name");
        }
    }
}
