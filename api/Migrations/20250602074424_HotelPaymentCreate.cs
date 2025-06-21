using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelPaymentCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc36befd-6d33-44a9-b09d-ec42bf7f5c20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dae23e80-6158-4e7d-9739-92e342b6e3d3");

            migrationBuilder.CreateTable(
                name: "HotelPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stripe_payement_intent_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookingId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    card = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelPayment_HotelBookings_bookingId",
                        column: x => x.bookingId,
                        principalTable: "HotelBookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "185d71e7-a247-402f-9ecc-44ee230110d5", null, "User", "USER" },
                    { "f4b2fffd-05c5-4492-a61e-010545894374", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelPayment_bookingId",
                table: "HotelPayment",
                column: "bookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "185d71e7-a247-402f-9ecc-44ee230110d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b2fffd-05c5-4492-a61e-010545894374");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc36befd-6d33-44a9-b09d-ec42bf7f5c20", null, "Admin", "ADMIN" },
                    { "dae23e80-6158-4e7d-9739-92e342b6e3d3", null, "User", "USER" }
                });
        }
    }
}
