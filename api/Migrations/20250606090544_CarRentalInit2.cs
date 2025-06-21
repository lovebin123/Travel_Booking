using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalInit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4beef6d2-e2ec-43f4-8653-8a2edea79edb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7431b4ab-b67a-41d5-84a8-171cb2af3a39");

            migrationBuilder.AddColumn<DateOnly>(
                name: "AvailableFromDate",
                table: "CarRentals",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "AvailableFromTime",
                table: "CarRentals",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<DateOnly>(
                name: "AvailableUntilDate",
                table: "CarRentals",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "AvailableUntilTime",
                table: "CarRentals",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "is_available",
                table: "CarRentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70f493d0-54cc-449f-aba2-5f3bd05a786f", null, "User", "USER" },
                    { "80f9560b-909c-42f1-8a8c-0c143a2ca085", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70f493d0-54cc-449f-aba2-5f3bd05a786f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f9560b-909c-42f1-8a8c-0c143a2ca085");

            migrationBuilder.DropColumn(
                name: "AvailableFromDate",
                table: "CarRentals");

            migrationBuilder.DropColumn(
                name: "AvailableFromTime",
                table: "CarRentals");

            migrationBuilder.DropColumn(
                name: "AvailableUntilDate",
                table: "CarRentals");

            migrationBuilder.DropColumn(
                name: "AvailableUntilTime",
                table: "CarRentals");

            migrationBuilder.DropColumn(
                name: "is_available",
                table: "CarRentals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4beef6d2-e2ec-43f4-8653-8a2edea79edb", null, "User", "USER" },
                    { "7431b4ab-b67a-41d5-84a8-171cb2af3a39", null, "Admin", "ADMIN" }
                });
        }
    }
}
