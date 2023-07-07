using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInWareHouse_Tbl",
                columns: table => new
                {
                    UserInWareHouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIDInWareHouse = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WareHouseID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInWareHouse_Tbl", x => x.UserInWareHouseID);
                    table.ForeignKey(
                        name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserIDInWareHouse",
                        column: x => x.UserIDInWareHouse,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserInWareHouse_Tbl_WareHouses_Tbl_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "WareHouses_Tbl",
                        principalColumn: "WareHouseID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInWareHouse_Tbl_UserID",
                table: "UserInWareHouse_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInWareHouse_Tbl_UserIDInWareHouse",
                table: "UserInWareHouse_Tbl",
                column: "UserIDInWareHouse");

            migrationBuilder.CreateIndex(
                name: "IX_UserInWareHouse_Tbl_WareHouseID",
                table: "UserInWareHouse_Tbl",
                column: "WareHouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInWareHouse_Tbl");
        }
    }
}
