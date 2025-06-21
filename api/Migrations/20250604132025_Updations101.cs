using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updations101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "093e6db1-7e09-491f-bdd5-db5e47a0ebf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dc1fa32-0b1e-4886-a6fd-680ea9500a30");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "822f4ee9-a683-49e9-8cdd-4e1289991f27", null, "User", "USER" },
                    { "b16b247d-9024-457f-92c3-867ab3e1cee1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "093e6db1-7e09-491f-bdd5-db5e47a0ebf8", null, "User", "USER" },
                    { "7dc1fa32-0b1e-4886-a6fd-680ea9500a30", null, "Admin", "ADMIN" }
                });
        }
    }
}
