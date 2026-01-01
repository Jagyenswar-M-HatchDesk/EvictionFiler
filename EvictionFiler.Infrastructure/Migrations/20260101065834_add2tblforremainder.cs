using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add2tblforremainder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RemainderCategoryId",
                table: "TblRemainderCenter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReminderEscalateId",
                table: "TblRemainderCenter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderName",
                table: "TblRemainderCenter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MstReminderCategory",
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
                    table.PrimaryKey("PK_MstReminderCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstReminderEscalates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MstReminderEscalates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblRemainderCenter_RemainderCategoryId",
                table: "TblRemainderCenter",
                column: "RemainderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRemainderCenter_ReminderEscalateId",
                table: "TblRemainderCenter",
                column: "ReminderEscalateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_MstReminderCategory_RemainderCategoryId",
                table: "TblRemainderCenter",
                column: "RemainderCategoryId",
                principalTable: "MstReminderCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_MstReminderEscalates_ReminderEscalateId",
                table: "TblRemainderCenter",
                column: "ReminderEscalateId",
                principalTable: "MstReminderEscalates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_MstReminderCategory_RemainderCategoryId",
                table: "TblRemainderCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_MstReminderEscalates_ReminderEscalateId",
                table: "TblRemainderCenter");

            migrationBuilder.DropTable(
                name: "MstReminderCategory");

            migrationBuilder.DropTable(
                name: "MstReminderEscalates");

            migrationBuilder.DropIndex(
                name: "IX_TblRemainderCenter_RemainderCategoryId",
                table: "TblRemainderCenter");

            migrationBuilder.DropIndex(
                name: "IX_TblRemainderCenter_ReminderEscalateId",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "RemainderCategoryId",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "ReminderEscalateId",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "ReminderName",
                table: "TblRemainderCenter");
        }
    }
}
