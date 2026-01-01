using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changestotblforremainder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_MstReminderCategory_RemainderCategoryId",
                table: "TblRemainderCenter");

            migrationBuilder.RenameColumn(
                name: "RemainderCategoryId",
                table: "TblRemainderCenter",
                newName: "ReminderCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TblRemainderCenter_RemainderCategoryId",
                table: "TblRemainderCenter",
                newName: "IX_TblRemainderCenter_ReminderCategoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "TblRemainderCenter",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_MstReminderCategory_ReminderCategoryId",
                table: "TblRemainderCenter",
                column: "ReminderCategoryId",
                principalTable: "MstReminderCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_MstReminderCategory_ReminderCategoryId",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "TblRemainderCenter");

            migrationBuilder.RenameColumn(
                name: "ReminderCategoryId",
                table: "TblRemainderCenter",
                newName: "RemainderCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TblRemainderCenter_ReminderCategoryId",
                table: "TblRemainderCenter",
                newName: "IX_TblRemainderCenter_RemainderCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_MstReminderCategory_RemainderCategoryId",
                table: "TblRemainderCenter",
                column: "RemainderCategoryId",
                principalTable: "MstReminderCategory",
                principalColumn: "Id");
        }
    }
}
