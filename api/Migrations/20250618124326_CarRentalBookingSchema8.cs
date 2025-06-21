using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema8 : Migration
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
                    { "3ebf576b-444b-4522-a8ce-0f123da41a9b", null, "User", "USER" },
                    { "a1da0799-a591-41ea-8ac9-0aba8d121a63", null, "Admin", "ADMIN" }
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
                keyValue: "3ebf576b-444b-4522-a8ce-0f123da41a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1da0799-a591-41ea-8ac9-0aba8d121a63");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c240e1a0-00d4-43e9-8629-df872b0d1d73", null, "Admin", "ADMIN" },
                    { "fe43280c-8792-4f90-b4af-cba2c5a73be6", null, "User", "USER" }
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
    }
}
