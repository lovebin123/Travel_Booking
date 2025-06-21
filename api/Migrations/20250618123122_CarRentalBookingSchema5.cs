using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HotelPayments_bookingId",
                table: "HotelPayments");

            migrationBuilder.DropIndex(
                name: "IX_flightPayements_FlightBookingId",
                table: "flightPayements");

            migrationBuilder.DropIndex(
                name: "IX_CarRentalPayments_bookingId",
                table: "CarRentalPayments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b95062-3409-4c8a-a0dd-16fff50bcdab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e283afd-bf06-473f-9f00-3c9c3ce406a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e2345d4-3cfe-4dd1-a81a-123b1e1129cf", null, "User", "USER" },
                    { "e1aede7e-acbf-4475-b3af-3f2bc52646c3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelPayments_bookingId",
                table: "HotelPayments",
                column: "bookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flightPayements_FlightBookingId",
                table: "flightPayements",
                column: "FlightBookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalPayments_bookingId",
                table: "CarRentalPayments",
                column: "bookingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HotelPayments_bookingId",
                table: "HotelPayments");

            migrationBuilder.DropIndex(
                name: "IX_flightPayements_FlightBookingId",
                table: "flightPayements");

            migrationBuilder.DropIndex(
                name: "IX_CarRentalPayments_bookingId",
                table: "CarRentalPayments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e2345d4-3cfe-4dd1-a81a-123b1e1129cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1aede7e-acbf-4475-b3af-3f2bc52646c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19b95062-3409-4c8a-a0dd-16fff50bcdab", null, "Admin", "ADMIN" },
                    { "5e283afd-bf06-473f-9f00-3c9c3ce406a5", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelPayments_bookingId",
                table: "HotelPayments",
                column: "bookingId");

            migrationBuilder.CreateIndex(
                name: "IX_flightPayements_FlightBookingId",
                table: "flightPayements",
                column: "FlightBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalPayments_bookingId",
                table: "CarRentalPayments",
                column: "bookingId");
        }
    }
}
