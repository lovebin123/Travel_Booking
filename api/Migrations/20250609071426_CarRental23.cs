using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRental23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46cf98e8-cae6-431d-bece-3c66a2f2a89e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4fdf3cb-f6db-4d31-b6e4-8d94a5fcbd94");

            migrationBuilder.AlterColumn<string>(
                name: "AvailableUntilTime",
                table: "CarRentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "AvailableFromTime",
                table: "CarRentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49b26028-02f1-4bca-98f4-a32a0e1b8c4d", null, "User", "USER" },
                    { "6690d512-ba91-4f0f-9e11-9add03f1b7da", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49b26028-02f1-4bca-98f4-a32a0e1b8c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6690d512-ba91-4f0f-9e11-9add03f1b7da");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "AvailableUntilTime",
                table: "CarRentals",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "AvailableFromTime",
                table: "CarRentals",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46cf98e8-cae6-431d-bece-3c66a2f2a89e", null, "User", "USER" },
                    { "a4fdf3cb-f6db-4d31-b6e4-8d94a5fcbd94", null, "Admin", "ADMIN" }
                });
        }
    }
}
