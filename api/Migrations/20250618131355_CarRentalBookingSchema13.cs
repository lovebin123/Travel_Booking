using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalBookingSchema13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e2fdf64-09a9-4460-af2f-a15bba38d8bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3743499-f099-4c90-bacf-80169476e151");

            migrationBuilder.AlterColumn<string>(
                name: "paymentId",
                table: "CarRentalBookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7dfa96ba-06b6-4c82-a93d-1809d5e55ddd", null, "User", "USER" },
                    { "efc721d7-6a60-4153-9c28-7617dd0dbe4c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dfa96ba-06b6-4c82-a93d-1809d5e55ddd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc721d7-6a60-4153-9c28-7617dd0dbe4c");

            migrationBuilder.AlterColumn<int>(
                name: "paymentId",
                table: "CarRentalBookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e2fdf64-09a9-4460-af2f-a15bba38d8bd", null, "Admin", "ADMIN" },
                    { "a3743499-f099-4c90-bacf-80169476e151", null, "User", "USER" }
                });
        }
    }
}
