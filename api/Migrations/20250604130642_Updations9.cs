using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updations9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2993c48c-182e-4283-a14e-fd0c5ae0ff76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8dd9335-3bb1-44a1-a4c4-d54b93847a93");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "093e6db1-7e09-491f-bdd5-db5e47a0ebf8", null, "User", "USER" },
                    { "7dc1fa32-0b1e-4886-a6fd-680ea9500a30", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2993c48c-182e-4283-a14e-fd0c5ae0ff76", null, "Admin", "ADMIN" },
                    { "e8dd9335-3bb1-44a1-a4c4-d54b93847a93", null, "User", "USER" }
                });
        }
    }
}
