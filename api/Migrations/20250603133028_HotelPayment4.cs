using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelPayment4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16f8c36d-c8e2-4be5-ba30-191867484996");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5624f47-94cb-4541-9a3e-12b491c1e7c1");

            migrationBuilder.AlterColumn<string>(
                name: "booking_time",
                table: "HotelPayments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d88ef37-acca-402f-85f3-4f424b844601", null, "User", "USER" },
                    { "d9cff59e-fb10-4106-a3a3-5528472aacb7", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d88ef37-acca-402f-85f3-4f424b844601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9cff59e-fb10-4106-a3a3-5528472aacb7");

            migrationBuilder.AlterColumn<DateTime>(
                name: "booking_time",
                table: "HotelPayments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16f8c36d-c8e2-4be5-ba30-191867484996", null, "Admin", "ADMIN" },
                    { "d5624f47-94cb-4541-9a3e-12b491c1e7c1", null, "User", "USER" }
                });
        }
    }
}
