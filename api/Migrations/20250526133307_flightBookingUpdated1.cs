using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class flightBookingUpdated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1039c34-01b7-4a9d-9e21-c45094861827");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c408cce9-455e-4adf-9422-82f1054299db");

            migrationBuilder.AddColumn<int>(
                name: "no_of_adults",
                table: "FlightBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "no_of_children",
                table: "FlightBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d39a35b8-111f-47cc-a15d-a18967f1aa8d", null, "User", "USER" },
                    { "eb81e97a-b87c-49da-ab76-ab482a387543", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d39a35b8-111f-47cc-a15d-a18967f1aa8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb81e97a-b87c-49da-ab76-ab482a387543");

            migrationBuilder.DropColumn(
                name: "no_of_adults",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "no_of_children",
                table: "FlightBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1039c34-01b7-4a9d-9e21-c45094861827", null, "Admin", "ADMIN" },
                    { "c408cce9-455e-4adf-9422-82f1054299db", null, "User", "USER" }
                });
        }
    }
}
