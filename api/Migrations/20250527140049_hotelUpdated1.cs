using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hotelUpdated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19e3487a-3a2f-4838-a819-a4a893dc1355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bd88d97-be93-4f3c-9cd1-77b6eae8d8bb");

            migrationBuilder.AddColumn<string>(
                name: "bedroom_type",
                table: "hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9098d42b-e713-4ce3-ba14-51c451236780", null, "Admin", "ADMIN" },
                    { "b1f56f08-949d-410c-b194-0a7b0537d6ca", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9098d42b-e713-4ce3-ba14-51c451236780");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1f56f08-949d-410c-b194-0a7b0537d6ca");

            migrationBuilder.DropColumn(
                name: "bedroom_type",
                table: "hotels");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19e3487a-3a2f-4838-a819-a4a893dc1355", null, "User", "USER" },
                    { "9bd88d97-be93-4f3c-9cd1-77b6eae8d8bb", null, "Admin", "ADMIN" }
                });
        }
    }
}
