using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class intentId1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c5fe835-7d23-4ab0-934d-ac4aa6c655da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63b3d16a-546d-4f22-abc1-0bcb06b44a53");

            migrationBuilder.AddColumn<string>(
                name: "sessionId",
                table: "HotelPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sessionId",
                table: "flightPayements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46cf98e8-cae6-431d-bece-3c66a2f2a89e", null, "User", "USER" },
                    { "a4fdf3cb-f6db-4d31-b6e4-8d94a5fcbd94", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46cf98e8-cae6-431d-bece-3c66a2f2a89e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4fdf3cb-f6db-4d31-b6e4-8d94a5fcbd94");

            migrationBuilder.DropColumn(
                name: "sessionId",
                table: "HotelPayments");

            migrationBuilder.DropColumn(
                name: "sessionId",
                table: "flightPayements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c5fe835-7d23-4ab0-934d-ac4aa6c655da", null, "Admin", "ADMIN" },
                    { "63b3d16a-546d-4f22-abc1-0bcb06b44a53", null, "User", "USER" }
                });
        }
    }
}
