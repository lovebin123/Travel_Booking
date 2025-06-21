using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updations11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fccbe9-58d7-4c11-a601-47e8fbb2be79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad7e303-4aff-4be8-bd11-250509f10076");

            migrationBuilder.AddColumn<int>(
                name: "no_of_seats",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1039c34-01b7-4a9d-9e21-c45094861827", null, "Admin", "ADMIN" },
                    { "c408cce9-455e-4adf-9422-82f1054299db", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1039c34-01b7-4a9d-9e21-c45094861827");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c408cce9-455e-4adf-9422-82f1054299db");

            migrationBuilder.DropColumn(
                name: "no_of_seats",
                table: "Flights");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0fccbe9-58d7-4c11-a601-47e8fbb2be79", null, "Admin", "ADMIN" },
                    { "dad7e303-4aff-4be8-bd11-250509f10076", null, "User", "USER" }
                });
        }
    }
}
