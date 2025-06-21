using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2794e168-93d9-49ae-bb0f-874640a6897f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8669a864-5b57-4acc-9ffd-2d7224a10fe9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c240e1a0-00d4-43e9-8629-df872b0d1d73", null, "Admin", "ADMIN" },
                    { "fe43280c-8792-4f90-b4af-cba2c5a73be6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c240e1a0-00d4-43e9-8629-df872b0d1d73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe43280c-8792-4f90-b4af-cba2c5a73be6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2794e168-93d9-49ae-bb0f-874640a6897f", null, "User", "USER" },
                    { "8669a864-5b57-4acc-9ffd-2d7224a10fe9", null, "Admin", "ADMIN" }
                });
        }
    }
}
