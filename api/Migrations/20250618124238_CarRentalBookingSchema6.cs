using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e2345d4-3cfe-4dd1-a81a-123b1e1129cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1aede7e-acbf-4475-b3af-3f2bc52646c3");

            migrationBuilder.AddColumn<int>(
                name: "isBooked",
                table: "CarRentalBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2794e168-93d9-49ae-bb0f-874640a6897f", null, "User", "USER" },
                    { "8669a864-5b57-4acc-9ffd-2d7224a10fe9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2794e168-93d9-49ae-bb0f-874640a6897f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8669a864-5b57-4acc-9ffd-2d7224a10fe9");

            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "CarRentalBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e2345d4-3cfe-4dd1-a81a-123b1e1129cf", null, "User", "USER" },
                    { "e1aede7e-acbf-4475-b3af-3f2bc52646c3", null, "Admin", "ADMIN" }
                });
        }
    }
}
