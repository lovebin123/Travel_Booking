using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updations7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11e5986a-5c06-4f03-98a7-b9af48ad2953");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9409fba-2e73-4cbb-abd3-efa1bc1658f6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a8b6fea-39a7-4923-8f38-d534b7745381", null, "Admin", "ADMIN" },
                    { "a1c8ad96-13c5-4de2-b441-9e78b7c0241d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a8b6fea-39a7-4923-8f38-d534b7745381");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c8ad96-13c5-4de2-b441-9e78b7c0241d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11e5986a-5c06-4f03-98a7-b9af48ad2953", null, "Admin", "ADMIN" },
                    { "b9409fba-2e73-4cbb-abd3-efa1bc1658f6", null, "User", "USER" }
                });
        }
    }
}
