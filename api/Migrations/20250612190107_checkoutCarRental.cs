using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class checkoutCarRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentalPayment_CarRentalBookings_bookingId",
                table: "CarRentalPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRentalPayment",
                table: "CarRentalPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "316fab95-b419-470b-b1ee-d51c3d457364");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc5d54aa-5206-4dda-b200-ace5d3ec81f8");

            migrationBuilder.RenameTable(
                name: "CarRentalPayment",
                newName: "CarRentalPayments");

            migrationBuilder.RenameIndex(
                name: "IX_CarRentalPayment_bookingId",
                table: "CarRentalPayments",
                newName: "IX_CarRentalPayments_bookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRentalPayments",
                table: "CarRentalPayments",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "790f2b6d-ec2f-4a51-87be-3cc8b0bcd21d", null, "User", "USER" },
                    { "904268ff-244f-4543-a214-3a708e009aae", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentalPayments_CarRentalBookings_bookingId",
                table: "CarRentalPayments",
                column: "bookingId",
                principalTable: "CarRentalBookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentalPayments_CarRentalBookings_bookingId",
                table: "CarRentalPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRentalPayments",
                table: "CarRentalPayments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "790f2b6d-ec2f-4a51-87be-3cc8b0bcd21d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904268ff-244f-4543-a214-3a708e009aae");

            migrationBuilder.RenameTable(
                name: "CarRentalPayments",
                newName: "CarRentalPayment");

            migrationBuilder.RenameIndex(
                name: "IX_CarRentalPayments_bookingId",
                table: "CarRentalPayment",
                newName: "IX_CarRentalPayment_bookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRentalPayment",
                table: "CarRentalPayment",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "316fab95-b419-470b-b1ee-d51c3d457364", null, "User", "USER" },
                    { "fc5d54aa-5206-4dda-b200-ace5d3ec81f8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentalPayment_CarRentalBookings_bookingId",
                table: "CarRentalPayment",
                column: "bookingId",
                principalTable: "CarRentalBookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
