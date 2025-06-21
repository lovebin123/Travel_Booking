using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FlightUpdation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48e662b3-53a0-4a68-9fad-a3c8571ae06e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b94484-637d-48fe-952c-e878b286eac5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83803fc7-6dfe-4965-8d7f-551bbeca19f6", null, "Admin", "ADMIN" },
                    { "8471c78c-0590-4309-80c5-3c552aa40d8a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83803fc7-6dfe-4965-8d7f-551bbeca19f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8471c78c-0590-4309-80c5-3c552aa40d8a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48e662b3-53a0-4a68-9fad-a3c8571ae06e", null, "User", "USER" },
                    { "84b94484-637d-48fe-952c-e878b286eac5", null, "Admin", "ADMIN" }
                });
        }
    }
}
