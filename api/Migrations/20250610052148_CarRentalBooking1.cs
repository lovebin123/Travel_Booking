using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBooking1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12edf9a9-36e2-4d7f-957f-750074ca0ff6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb7e850-0f7c-4763-b856-5d67a71bf128");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5438d00f-d56f-4669-bdc9-adc78f05130c", null, "User", "USER" },
                    { "70331be1-cf55-415d-9567-cc4c39b3c5f2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings",
                columns: new[] { "bookingId", "user_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5438d00f-d56f-4669-bdc9-adc78f05130c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70331be1-cf55-415d-9567-cc4c39b3c5f2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12edf9a9-36e2-4d7f-957f-750074ca0ff6", null, "User", "USER" },
                    { "3cb7e850-0f7c-4763-b856-5d67a71bf128", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings",
                columns: new[] { "bookingId", "user_id" });
        }
    }
}
