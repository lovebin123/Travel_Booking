using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentalBookings_CarRentals_bookingId",
                table: "CarRentalBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48ee2548-9ff3-4c0b-bb44-e7ba849c5839");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b160bb29-85ed-4839-a359-b9219d7b817a");

            migrationBuilder.AlterColumn<int>(
                name: "bookingId",
                table: "CarRentalBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa21f540-cf78-4e9a-b512-83dc15eca071", null, "Admin", "ADMIN" },
                    { "c864c6b7-0925-4148-a362-e635dadedb3a", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings",
                columns: new[] { "bookingId", "user_id" },
                unique: true,
                filter: "[bookingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentalBookings_CarRentals_bookingId",
                table: "CarRentalBookings",
                column: "bookingId",
                principalTable: "CarRentals",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentalBookings_CarRentals_bookingId",
                table: "CarRentalBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa21f540-cf78-4e9a-b512-83dc15eca071");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c864c6b7-0925-4148-a362-e635dadedb3a");

            migrationBuilder.AlterColumn<int>(
                name: "bookingId",
                table: "CarRentalBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48ee2548-9ff3-4c0b-bb44-e7ba849c5839", null, "Admin", "ADMIN" },
                    { "b160bb29-85ed-4839-a359-b9219d7b817a", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalBookings_bookingId_user_id",
                table: "CarRentalBookings",
                columns: new[] { "bookingId", "user_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentalBookings_CarRentals_bookingId",
                table: "CarRentalBookings",
                column: "bookingId",
                principalTable: "CarRentals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
