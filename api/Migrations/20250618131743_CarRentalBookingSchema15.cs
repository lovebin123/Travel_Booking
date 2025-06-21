using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dfa96ba-06b6-4c82-a93d-1809d5e55ddd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc721d7-6a60-4153-9c28-7617dd0dbe4c");

            migrationBuilder.AlterColumn<string>(
                name: "paymentId",
                table: "CarRentalBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eb98058-4a95-488f-aaef-b377c5973fb9", null, "Admin", "ADMIN" },
                    { "621dfcda-d170-4cbe-9c2a-d4cf544c893c", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eb98058-4a95-488f-aaef-b377c5973fb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "621dfcda-d170-4cbe-9c2a-d4cf544c893c");

            migrationBuilder.AlterColumn<string>(
                name: "paymentId",
                table: "CarRentalBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7dfa96ba-06b6-4c82-a93d-1809d5e55ddd", null, "User", "USER" },
                    { "efc721d7-6a60-4153-9c28-7617dd0dbe4c", null, "Admin", "ADMIN" }
                });
        }
    }
}
