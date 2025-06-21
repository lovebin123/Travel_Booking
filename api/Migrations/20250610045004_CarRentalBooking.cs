using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49b26028-02f1-4bca-98f4-a32a0e1b8c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6690d512-ba91-4f0f-9e11-9add03f1b7da");

            migrationBuilder.CreateTable(
                name: "CarRentalBookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingId = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    bookedFromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    bookedTillDate = table.Column<DateOnly>(type: "date", nullable: false),
                    bookedFromTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookedTillTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentalBookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_CarRentalBookings_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentalBookings_CarRentals_bookingId",
                        column: x => x.bookingId,
                        principalTable: "CarRentals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalBookings_user_id",
                table: "CarRentalBookings",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentalBookings");

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
                    { "49b26028-02f1-4bca-98f4-a32a0e1b8c4d", null, "User", "USER" },
                    { "6690d512-ba91-4f0f-9e11-9add03f1b7da", null, "Admin", "ADMIN" }
                });
        }
    }
}
