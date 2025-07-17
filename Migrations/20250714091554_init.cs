using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4435fb33-5074-43df-90b7-8944c31a233f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b103dfd-0a64-4709-ab5c-84bc11f7c2b3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1024bcfd-569d-4fa0-9a4b-82e79686615b", null, "Admin", "ADMIN" },
                    { "9fab5edd-3c65-4abf-a671-0400c0fa18b1", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1024bcfd-569d-4fa0-9a4b-82e79686615b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fab5edd-3c65-4abf-a671-0400c0fa18b1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4435fb33-5074-43df-90b7-8944c31a233f", null, "User", "USER" },
                    { "8b103dfd-0a64-4709-ab5c-84bc11f7c2b3", null, "Admin", "ADMIN" }
                });
        }
    }
}
