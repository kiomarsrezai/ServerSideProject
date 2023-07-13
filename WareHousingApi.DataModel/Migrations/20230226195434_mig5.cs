using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductLocationID",
                table: "Inventories_Tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Tbl_ProductLocationID",
                table: "Inventories_Tbl",
                column: "ProductLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Tbl_ProductLocations_Tbl_ProductLocationID",
                table: "Inventories_Tbl",
                column: "ProductLocationID",
                principalTable: "ProductLocations_Tbl",
                principalColumn: "ProductLocationID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Tbl_ProductLocations_Tbl_ProductLocationID",
                table: "Inventories_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_Tbl_ProductLocationID",
                table: "Inventories_Tbl");

            migrationBuilder.DropColumn(
                name: "ProductLocationID",
                table: "Inventories_Tbl");
        }
    }
}
