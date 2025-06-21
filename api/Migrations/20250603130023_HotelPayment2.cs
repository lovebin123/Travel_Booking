using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelPayment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "062071f5-0972-4ea2-8e57-6601f5079da4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c9aa3e7-8c1c-4e9d-a8a9-cf0a0701acfc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "048179ac-6888-483a-a8b8-b94c9f4638a5", null, "User", "USER" },
                    { "c9b59197-b4cb-43b3-ab44-bffd840e5598", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "048179ac-6888-483a-a8b8-b94c9f4638a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9b59197-b4cb-43b3-ab44-bffd840e5598");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "062071f5-0972-4ea2-8e57-6601f5079da4", null, "User", "USER" },
                    { "3c9aa3e7-8c1c-4e9d-a8a9-cf0a0701acfc", null, "Admin", "ADMIN" }
                });
        }
    }
}
