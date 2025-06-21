using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updations8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlightBookings_flight_id",
                table: "FlightBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a8b6fea-39a7-4923-8f38-d534b7745381");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c8ad96-13c5-4de2-b441-9e78b7c0241d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0fccbe9-58d7-4c11-a601-47e8fbb2be79", null, "Admin", "ADMIN" },
                    { "dad7e303-4aff-4be8-bd11-250509f10076", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_flight_id_user_id",
                table: "FlightBookings",
                columns: new[] { "flight_id", "user_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlightBookings_flight_id_user_id",
                table: "FlightBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fccbe9-58d7-4c11-a601-47e8fbb2be79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad7e303-4aff-4be8-bd11-250509f10076");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a8b6fea-39a7-4923-8f38-d534b7745381", null, "Admin", "ADMIN" },
                    { "a1c8ad96-13c5-4de2-b441-9e78b7c0241d", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_flight_id",
                table: "FlightBookings",
                column: "flight_id");
        }
    }
}
