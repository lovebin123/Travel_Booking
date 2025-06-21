using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updationss3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightBookings",
                table: "FlightBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de29825-278c-4bb8-8704-7018e91f4546");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e11056f-3f4b-45fc-b14b-1e3088a9a7c3");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightBookings",
                table: "FlightBookings",
                column: "id");

            migrationBuilder.CreateTable(
                name: "flightPayements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightBookingId = table.Column<int>(type: "int", nullable: false),
                    stripe_payement_intend_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flightPayements", x => x.id);
                    table.ForeignKey(
                        name: "FK_flightPayements_FlightBookings_FlightBookingId",
                        column: x => x.FlightBookingId,
                        principalTable: "FlightBookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31db7054-0723-4c41-8143-4e9dc9de9af9", null, "Admin", "ADMIN" },
                    { "90db9e26-90e4-4fde-a7df-efae87649198", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_user_id",
                table: "FlightBookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_flightPayements_FlightBookingId",
                table: "flightPayements",
                column: "FlightBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flightPayements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightBookings",
                table: "FlightBookings");

            migrationBuilder.DropIndex(
                name: "IX_FlightBookings_user_id",
                table: "FlightBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31db7054-0723-4c41-8143-4e9dc9de9af9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90db9e26-90e4-4fde-a7df-efae87649198");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightBookings",
                table: "FlightBookings",
                columns: new[] { "user_id", "flight_id" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7de29825-278c-4bb8-8704-7018e91f4546", null, "Admin", "ADMIN" },
                    { "9e11056f-3f4b-45fc-b14b-1e3088a9a7c3", null, "User", "USER" }
                });
        }
    }
}
