using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DITest.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    line2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postcode = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addressid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Address_addressid",
                        column: x => x.addressid,
                        principalTable: "Address",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK_Delivery_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timeslot",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delivery1id = table.Column<int>(name: "delivery_1id", type: "int", nullable: true),
                    delivery2id = table.Column<int>(name: "delivery_2id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslot", x => x.id);
                    table.ForeignKey(
                        name: "FK_Timeslot_Delivery_delivery_1id",
                        column: x => x.delivery1id,
                        principalTable: "Delivery",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Timeslot_Delivery_delivery_2id",
                        column: x => x.delivery2id,
                        principalTable: "Delivery",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_userid",
                table: "Delivery",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslot_delivery_1id",
                table: "Timeslot",
                column: "delivery_1id");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslot_delivery_2id",
                table: "Timeslot",
                column: "delivery_2id");

            migrationBuilder.CreateIndex(
                name: "IX_User_addressid",
                table: "User",
                column: "addressid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timeslot");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
