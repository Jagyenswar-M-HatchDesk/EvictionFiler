using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AdditionalOccupants_AdditionalOccupantId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "AdditionalOccupants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_AdditionalOccupantId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "AdditionalOccupantId",
                table: "Tenants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalOccupantId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdditionalOccupants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalOccupants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_AdditionalOccupantId",
                table: "Tenants",
                column: "AdditionalOccupantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AdditionalOccupants_AdditionalOccupantId",
                table: "Tenants",
                column: "AdditionalOccupantId",
                principalTable: "AdditionalOccupants",
                principalColumn: "Id");
        }
    }
}
