using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateroledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f5ab29da-356e-42df-a3ad-d91bbf644550"), new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("56355bf6-e335-428a-b718-00cb79e5273d"), new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("56355bf6-e335-428a-b718-00cb79e5273d"), new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f5ab29da-356e-42df-a3ad-d91bbf644550"), new Guid("84722e9d-806c-4f49-94d7-a55de8d2d76e") });
        }
    }
}
