using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updationss4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31db7054-0723-4c41-8143-4e9dc9de9af9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90db9e26-90e4-4fde-a7df-efae87649198");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2eb59eb-45db-4416-baec-6cd408cee284", null, "Admin", "ADMIN" },
                    { "d8826fdd-4c40-4e48-a65c-3daf1a5ffa71", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2eb59eb-45db-4416-baec-6cd408cee284");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8826fdd-4c40-4e48-a65c-3daf1a5ffa71");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31db7054-0723-4c41-8143-4e9dc9de9af9", null, "Admin", "ADMIN" },
                    { "90db9e26-90e4-4fde-a7df-efae87649198", null, "User", "USER" }
                });
        }
    }
}
