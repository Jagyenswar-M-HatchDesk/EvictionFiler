using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FormTypeId",
                table: "CaseForms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseForms_FormTypeId",
                table: "CaseForms",
                column: "FormTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseForms_MstFormTypes_FormTypeId",
                table: "CaseForms",
                column: "FormTypeId",
                principalTable: "MstFormTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseForms_MstFormTypes_FormTypeId",
                table: "CaseForms");

            migrationBuilder.DropIndex(
                name: "IX_CaseForms_FormTypeId",
                table: "CaseForms");

            migrationBuilder.DropColumn(
                name: "FormTypeId",
                table: "CaseForms");
        }
    }
}
