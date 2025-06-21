using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FlightModal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3df3506-c52a-4b6a-b91c-1c2ad5006239");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7c284a-9130-49ff-a098-7bcb3636d977");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a865ad8-35d3-42d6-a06f-009e6334227f", null, "User", "USER" },
                    { "ed70a7e9-80fa-4376-b143-3cfd0ae8c951", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a865ad8-35d3-42d6-a06f-009e6334227f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed70a7e9-80fa-4376-b143-3cfd0ae8c951");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b3df3506-c52a-4b6a-b91c-1c2ad5006239", null, "User", "USER" },
                    { "db7c284a-9130-49ff-a098-7bcb3636d977", null, "Admin", "ADMIN" }
                });
        }
    }
}
