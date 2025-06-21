using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelPayment_HotelBookings_bookingId",
                table: "HotelPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelPayment",
                table: "HotelPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "185d71e7-a247-402f-9ecc-44ee230110d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b2fffd-05c5-4492-a61e-010545894374");

            migrationBuilder.RenameTable(
                name: "HotelPayment",
                newName: "HotelPayments");

            migrationBuilder.RenameIndex(
                name: "IX_HotelPayment_bookingId",
                table: "HotelPayments",
                newName: "IX_HotelPayments_bookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelPayments",
                table: "HotelPayments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "062071f5-0972-4ea2-8e57-6601f5079da4", null, "User", "USER" },
                    { "3c9aa3e7-8c1c-4e9d-a8a9-cf0a0701acfc", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPayments_HotelBookings_bookingId",
                table: "HotelPayments",
                column: "bookingId",
                principalTable: "HotelBookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelPayments_HotelBookings_bookingId",
                table: "HotelPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelPayments",
                table: "HotelPayments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "062071f5-0972-4ea2-8e57-6601f5079da4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c9aa3e7-8c1c-4e9d-a8a9-cf0a0701acfc");

            migrationBuilder.RenameTable(
                name: "HotelPayments",
                newName: "HotelPayment");

            migrationBuilder.RenameIndex(
                name: "IX_HotelPayments_bookingId",
                table: "HotelPayment",
                newName: "IX_HotelPayment_bookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelPayment",
                table: "HotelPayment",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "185d71e7-a247-402f-9ecc-44ee230110d5", null, "User", "USER" },
                    { "f4b2fffd-05c5-4492-a61e-010545894374", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPayment_HotelBookings_bookingId",
                table: "HotelPayment",
                column: "bookingId",
                principalTable: "HotelBookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
