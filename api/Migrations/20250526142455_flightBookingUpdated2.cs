using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class flightBookingUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d39a35b8-111f-47cc-a15d-a18967f1aa8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb81e97a-b87c-49da-ab76-ab482a387543");

            migrationBuilder.AlterColumn<string>(
                name: "no_of_children",
                table: "FlightBookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "no_of_adults",
                table: "FlightBookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0fb250a-dad6-4666-9877-f002a514103e", null, "User", "USER" },
                    { "c49f8967-9ce8-45b8-acc7-ef2183fcfbea", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fb250a-dad6-4666-9877-f002a514103e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c49f8967-9ce8-45b8-acc7-ef2183fcfbea");

            migrationBuilder.AlterColumn<int>(
                name: "no_of_children",
                table: "FlightBookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "no_of_adults",
                table: "FlightBookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d39a35b8-111f-47cc-a15d-a18967f1aa8d", null, "User", "USER" },
                    { "eb81e97a-b87c-49da-ab76-ab482a387543", null, "Admin", "ADMIN" }
                });
        }
    }
}
