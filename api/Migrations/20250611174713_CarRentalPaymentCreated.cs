using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalPaymentCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96ed2b49-0fe5-402d-8919-9ab35eee95fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f85f07c-14d5-4a79-9500-2bb092adfbb2");

            migrationBuilder.CreateTable(
                name: "CarRentalPayment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingId = table.Column<int>(type: "int", nullable: false),
                    stripe_payement_intent_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    card = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    booking_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    booking_time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentalPayment", x => x.id);
                    table.ForeignKey(
                        name: "FK_CarRentalPayment_CarRentalBookings_bookingId",
                        column: x => x.bookingId,
                        principalTable: "CarRentalBookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "316fab95-b419-470b-b1ee-d51c3d457364", null, "User", "USER" },
                    { "fc5d54aa-5206-4dda-b200-ace5d3ec81f8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalPayment_bookingId",
                table: "CarRentalPayment",
                column: "bookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentalPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "316fab95-b419-470b-b1ee-d51c3d457364");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc5d54aa-5206-4dda-b200-ace5d3ec81f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96ed2b49-0fe5-402d-8919-9ab35eee95fe", null, "Admin", "ADMIN" },
                    { "9f85f07c-14d5-4a79-9500-2bb092adfbb2", null, "User", "USER" }
                });
        }
    }
}
