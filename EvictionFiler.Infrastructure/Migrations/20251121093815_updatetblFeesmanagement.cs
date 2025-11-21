using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetblFeesmanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FeesCatalog_CourtAppearance",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeesCatalog_AttorneyRoster",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeesCatalog",
                schema: "dbo",
                table: "FeesCatalog");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog");

            migrationBuilder.AddColumn<Guid>(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<Guid>(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                schema: "dbo",
                table: "FeesCatalog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<Guid>(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<Guid>(
                name: "LabelId",
                schema: "dbo",
                table: "FeesCatalog",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeesCatalog_CourtAppearance",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance",
                column: "Ids");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeesCatalog_AttorneyRoster",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster",
                column: "Ids");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeesCatalog",
                schema: "dbo",
                table: "FeesCatalog",
                column: "Ids");

            migrationBuilder.CreateIndex(
                name: "IX_FeesCatalog_LabelId",
                schema: "dbo",
                table: "FeesCatalog",
                column: "LabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeesCatalog_MstFormTypes_LabelId",
                schema: "dbo",
                table: "FeesCatalog",
                column: "LabelId",
                principalTable: "MstFormTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeesCatalog_MstFormTypes_LabelId",
                schema: "dbo",
                table: "FeesCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeesCatalog_CourtAppearance",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeesCatalog_AttorneyRoster",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeesCatalog",
                schema: "dbo",
                table: "FeesCatalog");

            migrationBuilder.DropIndex(
                name: "IX_FeesCatalog_LabelId",
                schema: "dbo",
                table: "FeesCatalog");

            migrationBuilder.DropColumn(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance");

            migrationBuilder.DropColumn(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster");

            migrationBuilder.DropColumn(
                name: "Ids",
                schema: "dbo",
                table: "FeesCatalog");

            migrationBuilder.DropColumn(
                name: "LabelId",
                schema: "dbo",
                table: "FeesCatalog");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                schema: "dbo",
                table: "FeesCatalog",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "FeesCatalog",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeesCatalog_CourtAppearance",
                schema: "dbo",
                table: "FeesCatalog_CourtAppearance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeesCatalog_AttorneyRoster",
                schema: "dbo",
                table: "FeesCatalog_AttorneyRoster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeesCatalog",
                schema: "dbo",
                table: "FeesCatalog",
                column: "Id");
        }
    }
}
