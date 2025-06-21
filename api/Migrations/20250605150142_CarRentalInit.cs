using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "822f4ee9-a683-49e9-8cdd-4e1289991f27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b16b247d-9024-457f-92c3-867ab3e1cee1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58dc5648-a245-4919-83bd-68aec7604944", null, "Admin", "ADMIN" },
                    { "a465ea6b-f005-44af-94ac-86b849271eef", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58dc5648-a245-4919-83bd-68aec7604944");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a465ea6b-f005-44af-94ac-86b849271eef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "822f4ee9-a683-49e9-8cdd-4e1289991f27", null, "User", "USER" },
                    { "b16b247d-9024-457f-92c3-867ab3e1cee1", null, "Admin", "ADMIN" }
                });
        }
    }
}
