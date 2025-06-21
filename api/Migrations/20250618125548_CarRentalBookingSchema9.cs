using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ebf576b-444b-4522-a8ce-0f123da41a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1da0799-a591-41ea-8ac9-0aba8d121a63");

            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "CarRentalBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29cb2ab8-c097-4912-a62a-f82aa9c5cd11", null, "User", "USER" },
                    { "e3e05c7a-722d-4994-9e60-9f8fbb65335d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29cb2ab8-c097-4912-a62a-f82aa9c5cd11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3e05c7a-722d-4994-9e60-9f8fbb65335d");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "CarRentalBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ebf576b-444b-4522-a8ce-0f123da41a9b", null, "User", "USER" },
                    { "a1da0799-a591-41ea-8ac9-0aba8d121a63", null, "Admin", "ADMIN" }
                });
        }
    }
}
