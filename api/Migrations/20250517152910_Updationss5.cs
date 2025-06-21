using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Updationss5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2eb59eb-45db-4416-baec-6cd408cee284");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8826fdd-4c40-4e48-a65c-3daf1a5ffa71");

            migrationBuilder.RenameColumn(
                name: "stripe_payement_intend_id",
                table: "flightPayements",
                newName: "stripe_payement_intent_id");

            migrationBuilder.AddColumn<string>(
                name: "payement_status",
                table: "flightPayements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "712870aa-490f-47e5-8d50-9387f19e34f6", null, "Admin", "ADMIN" },
                    { "d301f22c-4cf0-4f94-9fad-ddd560bfd330", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "712870aa-490f-47e5-8d50-9387f19e34f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d301f22c-4cf0-4f94-9fad-ddd560bfd330");

            migrationBuilder.DropColumn(
                name: "payement_status",
                table: "flightPayements");

            migrationBuilder.RenameColumn(
                name: "stripe_payement_intent_id",
                table: "flightPayements",
                newName: "stripe_payement_intend_id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2eb59eb-45db-4416-baec-6cd408cee284", null, "Admin", "ADMIN" },
                    { "d8826fdd-4c40-4e48-a65c-3daf1a5ffa71", null, "User", "USER" }
                });
        }
    }
}
