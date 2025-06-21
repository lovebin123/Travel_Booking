using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class flightBookingUpdated3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fb250a-dad6-4666-9877-f002a514103e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c49f8967-9ce8-45b8-acc7-ef2183fcfbea");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "FlightBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b60f5248-3d43-4db8-b8b1-875e7e49deae", null, "Admin", "ADMIN" },
                    { "f7c61e7a-56de-4637-8206-e9e0deca65b8", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b60f5248-3d43-4db8-b8b1-875e7e49deae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c61e7a-56de-4637-8206-e9e0deca65b8");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "FlightBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0fb250a-dad6-4666-9877-f002a514103e", null, "User", "USER" },
                    { "c49f8967-9ce8-45b8-acc7-ef2183fcfbea", null, "Admin", "ADMIN" }
                });
        }
    }
}
