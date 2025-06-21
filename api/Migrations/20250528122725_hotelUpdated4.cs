using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hotelUpdated4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9098d42b-e713-4ce3-ba14-51c451236780");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1f56f08-949d-410c-b194-0a7b0537d6ca");

            migrationBuilder.AddColumn<int>(
                name: "no_of_stars",
                table: "hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bfff6f95-311a-4756-8ee1-515f01119fb9", null, "Admin", "ADMIN" },
                    { "fecbf07b-0b1a-4598-a7da-0a4becf1a6a7", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfff6f95-311a-4756-8ee1-515f01119fb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fecbf07b-0b1a-4598-a7da-0a4becf1a6a7");

            migrationBuilder.DropColumn(
                name: "no_of_stars",
                table: "hotels");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9098d42b-e713-4ce3-ba14-51c451236780", null, "Admin", "ADMIN" },
                    { "b1f56f08-949d-410c-b194-0a7b0537d6ca", null, "User", "USER" }
                });
        }
    }
}
