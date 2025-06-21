using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class flightBookingUpdated4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b60f5248-3d43-4db8-b8b1-875e7e49deae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c61e7a-56de-4637-8206-e9e0deca65b8");

            migrationBuilder.AddColumn<string>(
                name: "date_of_arrival",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fbe2977-a05a-4480-a217-578e71186968", null, "User", "USER" },
                    { "c80be25e-7260-4e4b-b4ea-9698749f6378", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fbe2977-a05a-4480-a217-578e71186968");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c80be25e-7260-4e4b-b4ea-9698749f6378");

            migrationBuilder.DropColumn(
                name: "date_of_arrival",
                table: "Flights");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b60f5248-3d43-4db8-b8b1-875e7e49deae", null, "Admin", "ADMIN" },
                    { "f7c61e7a-56de-4637-8206-e9e0deca65b8", null, "User", "USER" }
                });
        }
    }
}
