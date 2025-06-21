using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class HotelBookingCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83803fc7-6dfe-4965-8d7f-551bbeca19f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8471c78c-0590-4309-80c5-3c552aa40d8a");

            migrationBuilder.CreateTable(
                name: "HotelBookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    check_in_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    check_out_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    no_of_adults = table.Column<int>(type: "int", nullable: false),
                    no_of_children = table.Column<int>(type: "int", nullable: false),
                    no_of_rooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_HotelBookings_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelBookings_hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63f519a3-f284-446a-8a2a-63c481e8e494", null, "User", "USER" },
                    { "edb0126a-afe1-462a-9fab-59427acb577b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_hotel_id_user_id",
                table: "HotelBookings",
                columns: new[] { "hotel_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_user_id",
                table: "HotelBookings",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63f519a3-f284-446a-8a2a-63c481e8e494");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edb0126a-afe1-462a-9fab-59427acb577b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83803fc7-6dfe-4965-8d7f-551bbeca19f6", null, "Admin", "ADMIN" },
                    { "8471c78c-0590-4309-80c5-3c552aa40d8a", null, "User", "USER" }
                });
        }
    }
}
