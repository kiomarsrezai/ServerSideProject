using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices_Tbl",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    InvoiceType = table.Column<byte>(type: "tinyint", nullable: false),
                    InvoiceTotalPrice = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices_Tbl", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Tbl_Customers_Tbl_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers_Tbl",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoices_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoices_Tbl_WareHouses_Tbl_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "WareHouses_Tbl",
                        principalColumn: "WareHouseID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems_Tbl",
                columns: table => new
                {
                    InvoiceItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false),
                    SalesPrice = table.Column<int>(type: "int", nullable: false),
                    CoverPrice = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems_Tbl", x => x.InvoiceItemID);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Tbl_Invoices_Tbl_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices_Tbl",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Tbl_Products_Tbl_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products_Tbl",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_Tbl_InvoiceID",
                table: "InvoiceItems_Tbl",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_Tbl_ProductID",
                table: "InvoiceItems_Tbl",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_Tbl_UserID",
                table: "InvoiceItems_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Tbl_CustomerID",
                table: "Invoices_Tbl",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Tbl_UserID",
                table: "Invoices_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Tbl_WareHouseID",
                table: "Invoices_Tbl",
                column: "WareHouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems_Tbl");

            migrationBuilder.DropTable(
                name: "Invoices_Tbl");
        }
    }
}
