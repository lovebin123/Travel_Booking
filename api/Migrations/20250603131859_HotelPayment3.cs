using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelPayment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "048179ac-6888-483a-a8b8-b94c9f4638a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9b59197-b4cb-43b3-ab44-bffd840e5598");

            migrationBuilder.AddColumn<DateTime>(
                name: "booking_time",
                table: "HotelPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16f8c36d-c8e2-4be5-ba30-191867484996", null, "Admin", "ADMIN" },
                    { "d5624f47-94cb-4541-9a3e-12b491c1e7c1", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16f8c36d-c8e2-4be5-ba30-191867484996");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5624f47-94cb-4541-9a3e-12b491c1e7c1");

            migrationBuilder.DropColumn(
                name: "booking_time",
                table: "HotelPayments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "048179ac-6888-483a-a8b8-b94c9f4638a5", null, "User", "USER" },
                    { "c9b59197-b4cb-43b3-ab44-bffd840e5598", null, "Admin", "ADMIN" }
                });
        }
    }
}
