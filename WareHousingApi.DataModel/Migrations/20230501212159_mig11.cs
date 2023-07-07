using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalYearID",
                table: "Invoices_Tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Tbl_FiscalYearID",
                table: "Invoices_Tbl",
                column: "FiscalYearID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Tbl_FiscalYears_Tbl_FiscalYearID",
                table: "Invoices_Tbl",
                column: "FiscalYearID",
                principalTable: "FiscalYears_Tbl",
                principalColumn: "FiscalYearID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Tbl_FiscalYears_Tbl_FiscalYearID",
                table: "Invoices_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_Tbl_FiscalYearID",
                table: "Invoices_Tbl");

            migrationBuilder.DropColumn(
                name: "FiscalYearID",
                table: "Invoices_Tbl");
        }
    }
}
