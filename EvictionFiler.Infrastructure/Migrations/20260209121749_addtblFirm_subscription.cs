using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtblFirm_subscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FirmId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubscriptionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SubscriptionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Firms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firms_SubscriptionTypes_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2bb5c3bf-8dd8-4415-9090-1d428c792533"),
                columns: new[] { "Description", "Name", "NormalizedName" },
                values: new object[] { "Employee of a firm.", "Staff Member", "STAFF MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56355bf6-e335-428a-b718-00cb79e5273d"),
                columns: new[] { "Description", "Name", "NormalizedName" },
                values: new object[] { "Owner of a product.", "Super Admin", "SUPER ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5ab29da-356e-42df-a3ad-d91bbf644550"),
                column: "Description",
                value: "Owner of a firm.");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Description", "IsActive", "IsDeleted", "Name", "NormalizedName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("5bb5c3bf-8dd8-4415-9090-1d428c792533"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Client of a firm.", true, null, "Client", "CLIENT", null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e"),
                columns: new[] { "Email", "FirmId", "FirstName", "NormalizedEmail", "NormalizedUserName", "RoleId", "UserName" },
                values: new object[] { "superadmin@gmail.com", null, "Super Admin", "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", new Guid("56355bf6-e335-428a-b718-00cb79e5273d"), "superadmin@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FirmId",
                table: "AspNetUsers",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_SubscriptionTypeId",
                table: "Firms",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Firms_FirmId",
                table: "AspNetUsers",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Firms_FirmId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "SubscriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FirmId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5bb5c3bf-8dd8-4415-9090-1d428c792533"));

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2bb5c3bf-8dd8-4415-9090-1d428c792533"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Property Manager", "PROPERTY MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56355bf6-e335-428a-b718-00cb79e5273d"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Law Firm", "LAW FIRM" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e"),
                columns: new[] { "Email", "FirstName", "NormalizedEmail", "NormalizedUserName", "RoleId", "UserName" },
                values: new object[] { "admin@gmail.com", "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", new Guid("f5ab29da-356e-42df-a3ad-d91bbf644550"), "admin@gmail.com" });
        }
    }
}
