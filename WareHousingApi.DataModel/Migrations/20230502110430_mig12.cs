using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnInvoiceDateTime",
                table: "Invoices_Tbl",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnInvoiceDateTime",
                table: "Invoices_Tbl");
        }
    }
}
