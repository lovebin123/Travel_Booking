using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ianjanv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "790f2b6d-ec2f-4a51-87be-3cc8b0bcd21d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904268ff-244f-4543-a214-3a708e009aae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b3df3506-c52a-4b6a-b91c-1c2ad5006239", null, "User", "USER" },
                    { "db7c284a-9130-49ff-a098-7bcb3636d977", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3df3506-c52a-4b6a-b91c-1c2ad5006239");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7c284a-9130-49ff-a098-7bcb3636d977");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "790f2b6d-ec2f-4a51-87be-3cc8b0bcd21d", null, "User", "USER" },
                    { "904268ff-244f-4543-a214-3a708e009aae", null, "Admin", "ADMIN" }
                });
        }
    }
}
