using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDbAddTablesRequestBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Tbl_Users_Tbl_UserID",
                table: "Countries_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tbl_Users_Tbl_UserID",
                table: "Customers_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_FiscalYears_Tbl_Users_Tbl_UserID",
                table: "FiscalYears_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Tbl_Users_Tbl_UserID",
                table: "Inventories_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Tbl_Users_Tbl_UserID",
                table: "InvoiceItems_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Tbl_Users_Tbl_UserID",
                table: "Invoices_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocations_Tbl_Users_Tbl_UserID",
                table: "ProductLocations_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_Tbl_Users_Tbl_UserID",
                table: "ProductPrices_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tbl_Users_Tbl_UserID",
                table: "Products_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Tbl_Users_Tbl_UserID",
                table: "Suppliers_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserID",
                table: "UserInWareHouse_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserIDInWareHouse",
                table: "UserInWareHouse_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouses_Tbl_Users_Tbl_UserID",
                table: "WareHouses_Tbl");

            migrationBuilder.AlterColumn<string>(
                name: "WareHouseTel",
                table: "WareHouses_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WareHouseName",
                table: "WareHouses_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WareHouseAddress",
                table: "WareHouses_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "WareHouses_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalCode",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MelliCode",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Family",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserIDInWareHouse",
                table: "UserInWareHouse_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserInWareHouse_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Suppliers_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Suppliers_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierTel",
                table: "Suppliers_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierName",
                table: "Suppliers_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Products_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Products_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Products_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ProductPrices_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ProductLocations_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductLocationAddress",
                table: "ProductLocations_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Invoices_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNo",
                table: "Invoices_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "InvoiceItems_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Inventories_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Inventories_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "FiscalYears_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FiscalYearDescription",
                table: "FiscalYears_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Customers_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EconomicCode",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerTel",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerFullName",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerAddress",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Countries_Tbl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries_Tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Tbl_Users_Tbl_UserID",
                table: "Countries_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tbl_Users_Tbl_UserID",
                table: "Customers_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_FiscalYears_Tbl_Users_Tbl_UserID",
                table: "FiscalYears_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Tbl_Users_Tbl_UserID",
                table: "Inventories_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Tbl_Users_Tbl_UserID",
                table: "InvoiceItems_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Tbl_Users_Tbl_UserID",
                table: "Invoices_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocations_Tbl_Users_Tbl_UserID",
                table: "ProductLocations_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_Tbl_Users_Tbl_UserID",
                table: "ProductPrices_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tbl_Users_Tbl_UserID",
                table: "Products_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Tbl_Users_Tbl_UserID",
                table: "Suppliers_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserID",
                table: "UserInWareHouse_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserIDInWareHouse",
                table: "UserInWareHouse_Tbl",
                column: "UserIDInWareHouse",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouses_Tbl_Users_Tbl_UserID",
                table: "WareHouses_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Tbl_Users_Tbl_UserID",
                table: "Countries_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tbl_Users_Tbl_UserID",
                table: "Customers_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_FiscalYears_Tbl_Users_Tbl_UserID",
                table: "FiscalYears_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Tbl_Users_Tbl_UserID",
                table: "Inventories_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Tbl_Users_Tbl_UserID",
                table: "InvoiceItems_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Tbl_Users_Tbl_UserID",
                table: "Invoices_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocations_Tbl_Users_Tbl_UserID",
                table: "ProductLocations_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_Tbl_Users_Tbl_UserID",
                table: "ProductPrices_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tbl_Users_Tbl_UserID",
                table: "Products_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Tbl_Users_Tbl_UserID",
                table: "Suppliers_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserID",
                table: "UserInWareHouse_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserIDInWareHouse",
                table: "UserInWareHouse_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouses_Tbl_Users_Tbl_UserID",
                table: "WareHouses_Tbl");

            migrationBuilder.AlterColumn<string>(
                name: "WareHouseTel",
                table: "WareHouses_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WareHouseName",
                table: "WareHouses_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WareHouseAddress",
                table: "WareHouses_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "WareHouses_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonalCode",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MelliCode",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Family",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserIDInWareHouse",
                table: "UserInWareHouse_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserInWareHouse_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Suppliers_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Suppliers_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupplierTel",
                table: "Suppliers_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupplierName",
                table: "Suppliers_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Products_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Products_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Products_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ProductPrices_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ProductLocations_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductLocationAddress",
                table: "ProductLocations_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Invoices_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNo",
                table: "Invoices_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "InvoiceItems_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Inventories_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Inventories_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "FiscalYears_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FiscalYearDescription",
                table: "FiscalYears_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Customers_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EconomicCode",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerTel",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerFullName",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerAddress",
                table: "Customers_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Countries_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Tbl_Users_Tbl_UserID",
                table: "Countries_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tbl_Users_Tbl_UserID",
                table: "Customers_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FiscalYears_Tbl_Users_Tbl_UserID",
                table: "FiscalYears_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Tbl_Users_Tbl_UserID",
                table: "Inventories_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Tbl_Users_Tbl_UserID",
                table: "InvoiceItems_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Tbl_Users_Tbl_UserID",
                table: "Invoices_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocations_Tbl_Users_Tbl_UserID",
                table: "ProductLocations_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_Tbl_Users_Tbl_UserID",
                table: "ProductPrices_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tbl_Users_Tbl_UserID",
                table: "Products_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Tbl_Users_Tbl_UserID",
                table: "Suppliers_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserID",
                table: "UserInWareHouse_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInWareHouse_Tbl_Users_Tbl_UserIDInWareHouse",
                table: "UserInWareHouse_Tbl",
                column: "UserIDInWareHouse",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouses_Tbl_Users_Tbl_UserID",
                table: "WareHouses_Tbl",
                column: "UserID",
                principalTable: "Users_Tbl",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
