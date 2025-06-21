using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hotelUpdated5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfff6f95-311a-4756-8ee1-515f01119fb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fecbf07b-0b1a-4598-a7da-0a4becf1a6a7");

            migrationBuilder.AddColumn<string>(
                name: "bed_type",
                table: "hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48e662b3-53a0-4a68-9fad-a3c8571ae06e", null, "User", "USER" },
                    { "84b94484-637d-48fe-952c-e878b286eac5", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48e662b3-53a0-4a68-9fad-a3c8571ae06e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b94484-637d-48fe-952c-e878b286eac5");

            migrationBuilder.DropColumn(
                name: "bed_type",
                table: "hotels");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bfff6f95-311a-4756-8ee1-515f01119fb9", null, "Admin", "ADMIN" },
                    { "fecbf07b-0b1a-4598-a7da-0a4becf1a6a7", null, "User", "USER" }
                });
        }
    }
}
