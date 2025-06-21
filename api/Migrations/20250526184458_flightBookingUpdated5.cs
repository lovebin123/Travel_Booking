using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class flightBookingUpdated5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "22f58d87-3cfa-49b8-b1db-a73a002aa1b5", null, "Admin", "ADMIN" },
                    { "3a656091-da47-49f6-9c42-36802b75c7ee", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22f58d87-3cfa-49b8-b1db-a73a002aa1b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a656091-da47-49f6-9c42-36802b75c7ee");

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
    }
}
