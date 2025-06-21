using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updations88 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "480b700f-ece8-4105-a76d-adfd785adf61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f1a8bee-7e2d-4f28-b6b7-3b47c7c3f69e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc36befd-6d33-44a9-b09d-ec42bf7f5c20", null, "Admin", "ADMIN" },
                    { "dae23e80-6158-4e7d-9739-92e342b6e3d3", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc36befd-6d33-44a9-b09d-ec42bf7f5c20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dae23e80-6158-4e7d-9739-92e342b6e3d3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "480b700f-ece8-4105-a76d-adfd785adf61", null, "Admin", "ADMIN" },
                    { "7f1a8bee-7e2d-4f28-b6b7-3b47c7c3f69e", null, "User", "USER" }
                });
        }
    }
}
