using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentals20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70f493d0-54cc-449f-aba2-5f3bd05a786f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f9560b-909c-42f1-8a8c-0c143a2ca085");

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "CarRentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c5fe835-7d23-4ab0-934d-ac4aa6c655da", null, "Admin", "ADMIN" },
                    { "63b3d16a-546d-4f22-abc1-0bcb06b44a53", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c5fe835-7d23-4ab0-934d-ac4aa6c655da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63b3d16a-546d-4f22-abc1-0bcb06b44a53");

            migrationBuilder.DropColumn(
                name: "location",
                table: "CarRentals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70f493d0-54cc-449f-aba2-5f3bd05a786f", null, "User", "USER" },
                    { "80f9560b-909c-42f1-8a8c-0c143a2ca085", null, "Admin", "ADMIN" }
                });
        }
    }
}
