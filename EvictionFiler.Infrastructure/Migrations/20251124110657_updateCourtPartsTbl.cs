using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateCourtPartsTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calanders_MstCourtPart_CourtPartId",
                table: "Calanders");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_MstCourtPart_CourtPartId",
                table: "CaseHearings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MstCourtPart",
                table: "MstCourtPart");

            migrationBuilder.DropColumn(
                name: "CallIn",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "Judge",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "Part",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "RoomNo",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "VirtualLink",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MstCourtPart");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MstCourtPart");

            migrationBuilder.RenameTable(
                name: "MstCourtPart",
                newName: "CourtPart");

            migrationBuilder.AddColumn<string>(
                name: "CallIn",
                table: "CourtPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConferenceId",
                table: "CourtPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CourtId",
                table: "CourtPart",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Judge",
                table: "CourtPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Part",
                table: "CourtPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomNo",
                table: "CourtPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tollfree",
                table: "CourtPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VirtualLink",
                table: "CourtPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtPart",
                table: "CourtPart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourtPart_CourtId",
                table: "CourtPart",
                column: "CourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calanders_CourtPart_CourtPartId",
                table: "Calanders",
                column: "CourtPartId",
                principalTable: "CourtPart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_CourtPart_CourtPartId",
                table: "CaseHearings",
                column: "CourtPartId",
                principalTable: "CourtPart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtPart_Courts_CourtId",
                table: "CourtPart",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calanders_CourtPart_CourtPartId",
                table: "Calanders");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_CourtPart_CourtPartId",
                table: "CaseHearings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtPart_Courts_CourtId",
                table: "CourtPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtPart",
                table: "CourtPart");

            migrationBuilder.DropIndex(
                name: "IX_CourtPart_CourtId",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "CallIn",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "Judge",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "Part",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "RoomNo",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "Tollfree",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "VirtualLink",
                table: "CourtPart");

            migrationBuilder.RenameTable(
                name: "CourtPart",
                newName: "MstCourtPart");

            migrationBuilder.AddColumn<string>(
                name: "CallIn",
                table: "Courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConferenceId",
                table: "Courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Judge",
                table: "Courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Part",
                table: "Courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomNo",
                table: "Courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VirtualLink",
                table: "Courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MstCourtPart",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MstCourtPart",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstCourtPart",
                table: "MstCourtPart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calanders_MstCourtPart_CourtPartId",
                table: "Calanders",
                column: "CourtPartId",
                principalTable: "MstCourtPart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_MstCourtPart_CourtPartId",
                table: "CaseHearings",
                column: "CourtPartId",
                principalTable: "MstCourtPart",
                principalColumn: "Id");
        }
    }
}
