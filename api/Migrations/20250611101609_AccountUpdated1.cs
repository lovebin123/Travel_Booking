using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AccountUpdated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07976ca1-4406-4879-b40e-f222c8207246");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "425fc9b8-d545-4d97-8e8d-937a439d0038");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96ed2b49-0fe5-402d-8919-9ab35eee95fe", null, "Admin", "ADMIN" },
                    { "9f85f07c-14d5-4a79-9500-2bb092adfbb2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96ed2b49-0fe5-402d-8919-9ab35eee95fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f85f07c-14d5-4a79-9500-2bb092adfbb2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07976ca1-4406-4879-b40e-f222c8207246", null, "User", "USER" },
                    { "425fc9b8-d545-4d97-8e8d-937a439d0038", null, "Admin", "ADMIN" }
                });
        }
    }
}
