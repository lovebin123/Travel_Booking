using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelBookingSchema15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eb98058-4a95-488f-aaef-b377c5973fb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "621dfcda-d170-4cbe-9c2a-d4cf544c893c");

            migrationBuilder.AddColumn<int>(
                name: "isBooked",
                table: "HotelBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "paymentId",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isBooked",
                table: "FlightBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "paymentId",
                table: "FlightBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02f5de2b-8fca-4f33-8e41-5857c5ff1956", null, "User", "USER" },
                    { "22050128-24f4-4ecf-a44a-e59e3b202606", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02f5de2b-8fca-4f33-8e41-5857c5ff1956");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22050128-24f4-4ecf-a44a-e59e3b202606");

            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "FlightBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eb98058-4a95-488f-aaef-b377c5973fb9", null, "Admin", "ADMIN" },
                    { "621dfcda-d170-4cbe-9c2a-d4cf544c893c", null, "User", "USER" }
                });
        }
    }
}
