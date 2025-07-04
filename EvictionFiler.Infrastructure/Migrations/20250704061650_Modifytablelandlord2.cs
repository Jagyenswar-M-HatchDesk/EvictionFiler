using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modifytablelandlord2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_Clients_ClientId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Appartments",
                newName: "LandlordId");

            migrationBuilder.RenameIndex(
                name: "IX_Appartments_ClientId",
                table: "Appartments",
                newName: "IX_Appartments_LandlordId");

            migrationBuilder.AddColumn<string>(
                name: "Tanent",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_LandLords_LandlordId",
                table: "Appartments",
                column: "LandlordId",
                principalTable: "LandLords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_LandLords_LandlordId",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "Tanent",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "LandlordId",
                table: "Appartments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appartments_LandlordId",
                table: "Appartments",
                newName: "IX_Appartments_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_Clients_ClientId",
                table: "Appartments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_Clients_ClientId",
                table: "LandLords",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
