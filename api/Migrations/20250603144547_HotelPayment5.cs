using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelPayment5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d88ef37-acca-402f-85f3-4f424b844601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9cff59e-fb10-4106-a3a3-5528472aacb7");

            migrationBuilder.AddColumn<string>(
                name: "booking_date",
                table: "HotelPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2993c48c-182e-4283-a14e-fd0c5ae0ff76", null, "Admin", "ADMIN" },
                    { "e8dd9335-3bb1-44a1-a4c4-d54b93847a93", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2993c48c-182e-4283-a14e-fd0c5ae0ff76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8dd9335-3bb1-44a1-a4c4-d54b93847a93");

            migrationBuilder.DropColumn(
                name: "booking_date",
                table: "HotelPayments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d88ef37-acca-402f-85f3-4f424b844601", null, "User", "USER" },
                    { "d9cff59e-fb10-4106-a3a3-5528472aacb7", null, "Admin", "ADMIN" }
                });
        }
    }
}
