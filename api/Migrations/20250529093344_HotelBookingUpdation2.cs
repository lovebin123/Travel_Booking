using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelBookingUpdation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63f519a3-f284-446a-8a2a-63c481e8e494");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edb0126a-afe1-462a-9fab-59427acb577b");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "HotelBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "480b700f-ece8-4105-a76d-adfd785adf61", null, "Admin", "ADMIN" },
                    { "7f1a8bee-7e2d-4f28-b6b7-3b47c7c3f69e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "480b700f-ece8-4105-a76d-adfd785adf61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f1a8bee-7e2d-4f28-b6b7-3b47c7c3f69e");

            migrationBuilder.DropColumn(
                name: "price",
                table: "HotelBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63f519a3-f284-446a-8a2a-63c481e8e494", null, "User", "USER" },
                    { "edb0126a-afe1-462a-9fab-59427acb577b", null, "Admin", "ADMIN" }
                });
        }
    }
}
