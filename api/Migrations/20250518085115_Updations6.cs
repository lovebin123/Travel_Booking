using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updations6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "712870aa-490f-47e5-8d50-9387f19e34f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d301f22c-4cf0-4f94-9fad-ddd560bfd330");

            migrationBuilder.AddColumn<string>(
                name: "card",
                table: "flightPayements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11e5986a-5c06-4f03-98a7-b9af48ad2953", null, "Admin", "ADMIN" },
                    { "b9409fba-2e73-4cbb-abd3-efa1bc1658f6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11e5986a-5c06-4f03-98a7-b9af48ad2953");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9409fba-2e73-4cbb-abd3-efa1bc1658f6");

            migrationBuilder.DropColumn(
                name: "card",
                table: "flightPayements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "712870aa-490f-47e5-8d50-9387f19e34f6", null, "Admin", "ADMIN" },
                    { "d301f22c-4cf0-4f94-9fad-ddd560bfd330", null, "User", "USER" }
                });
        }
    }
}
