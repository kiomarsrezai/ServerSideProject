using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setting_Tbl");

            migrationBuilder.CreateTable(
                name: "Customers_Tbl",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EconomicCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers_Tbl", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Tbl_WareHouses_Tbl_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "WareHouses_Tbl",
                        principalColumn: "WareHouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Tbl_UserID",
                table: "Customers_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Tbl_WareHouseID",
                table: "Customers_Tbl",
                column: "WareHouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers_Tbl");

            migrationBuilder.CreateTable(
                name: "Setting_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MySetting = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setting_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setting_Tbl_UserID",
                table: "Setting_Tbl",
                column: "UserID");
        }
    }
}
