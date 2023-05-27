using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreateHotelDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CusID = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CusID);
                });

            migrationBuilder.CreateTable(
                name: "HotelDetails",
                columns: table => new
                {
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDetails", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    RoomStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomPrice = table.Column<double>(type: "float", nullable: false),
                    HotelDetailsHotelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_RoomDetails_HotelDetails_HotelDetailsHotelID",
                        column: x => x.HotelDetailsHotelID,
                        principalTable: "HotelDetails",
                        principalColumn: "HotelID");
                });

            migrationBuilder.CreateTable(
                name: "BookedDetails",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    HotelDetailsHotelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedDetails", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_BookedDetails_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedDetails_HotelDetails_HotelDetailsHotelID",
                        column: x => x.HotelDetailsHotelID,
                        principalTable: "HotelDetails",
                        principalColumn: "HotelID");
                    table.ForeignKey(
                        name: "FK_BookedDetails_RoomDetails_RoomID",
                        column: x => x.RoomID,
                        principalTable: "RoomDetails",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedDetails_CustomerID",
                table: "BookedDetails",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_BookedDetails_HotelDetailsHotelID",
                table: "BookedDetails",
                column: "HotelDetailsHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_BookedDetails_RoomID",
                table: "BookedDetails",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetails_HotelDetailsHotelID",
                table: "RoomDetails",
                column: "HotelDetailsHotelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedDetails");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RoomDetails");

            migrationBuilder.DropTable(
                name: "HotelDetails");
        }
    }
}
