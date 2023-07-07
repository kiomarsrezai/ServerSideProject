using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles_Tbl",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users_Tbl",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MelliCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    UserType = table.Column<byte>(type: "tinyint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Tbl", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_Tbl_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_Tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_Tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_Tbl_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_Tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_Tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Countries_Tbl",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries_Tbl", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYears_Tbl",
                columns: table => new
                {
                    FiscalYearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FiscalYearDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiscalFlag = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYears_Tbl", x => x.FiscalYearID);
                    table.ForeignKey(
                        name: "FK_FiscalYears_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers_Tbl",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers_Tbl", x => x.SupplierID);
                    table.ForeignKey(
                        name: "FK_Suppliers_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WareHouses_Tbl",
                columns: table => new
                {
                    WareHouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses_Tbl", x => x.WareHouseID);
                    table.ForeignKey(
                        name: "FK_WareHouses_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Products_Tbl",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackingType = table.Column<int>(type: "int", nullable: false),
                    CountInPacking = table.Column<int>(type: "int", nullable: false),
                    ProductWeight = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    IsRefregerator = table.Column<byte>(type: "tinyint", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Tbl", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Tbl_Countries_Tbl_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries_Tbl",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_Tbl_Suppliers_Tbl_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers_Tbl",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocations_Tbl",
                columns: table => new
                {
                    ProductLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductLocationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocations_Tbl", x => x.ProductLocationID);
                    table.ForeignKey(
                        name: "FK_ProductLocations_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductLocations_Tbl_WareHouses_Tbl_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "WareHouses_Tbl",
                        principalColumn: "WareHouseID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Inventories_Tbl",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    WareHouseID = table.Column<int>(type: "int", nullable: false),
                    FiscalYearID = table.Column<int>(type: "int", nullable: false),
                    ProductCountMain = table.Column<int>(type: "int", nullable: false),
                    ProductCountWastage = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationType = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories_Tbl", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventories_Tbl_FiscalYears_Tbl_FiscalYearID",
                        column: x => x.FiscalYearID,
                        principalTable: "FiscalYears_Tbl",
                        principalColumn: "FiscalYearID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventories_Tbl_Products_Tbl_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products_Tbl",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventories_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventories_Tbl_WareHouses_Tbl_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "WareHouses_Tbl",
                        principalColumn: "WareHouseID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices_Tbl",
                columns: table => new
                {
                    ProductPriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false),
                    SalesPrice = table.Column<int>(type: "int", nullable: false),
                    CoverPrice = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FiscalYearID = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices_Tbl", x => x.ProductPriceID);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Tbl_FiscalYears_Tbl_FiscalYearID",
                        column: x => x.FiscalYearID,
                        principalTable: "FiscalYears_Tbl",
                        principalColumn: "FiscalYearID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Tbl_Products_Tbl_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products_Tbl",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Tbl_UserID",
                table: "Countries_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_Tbl_UserID",
                table: "FiscalYears_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Tbl_FiscalYearID",
                table: "Inventories_Tbl",
                column: "FiscalYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Tbl_ProductID",
                table: "Inventories_Tbl",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Tbl_UserID",
                table: "Inventories_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Tbl_WareHouseID",
                table: "Inventories_Tbl",
                column: "WareHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_Tbl_UserID",
                table: "ProductLocations_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_Tbl_WareHouseID",
                table: "ProductLocations_Tbl",
                column: "WareHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_Tbl_FiscalYearID",
                table: "ProductPrices_Tbl",
                column: "FiscalYearID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_Tbl_ProductID",
                table: "ProductPrices_Tbl",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_Tbl_UserID",
                table: "ProductPrices_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Tbl_CountryID",
                table: "Products_Tbl",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Tbl_SupplierID",
                table: "Products_Tbl",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Tbl_UserID",
                table: "Products_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles_Tbl",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Tbl_UserID",
                table: "Suppliers_Tbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users_Tbl",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users_Tbl",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouses_Tbl_UserID",
                table: "WareHouses_Tbl",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Inventories_Tbl");

            migrationBuilder.DropTable(
                name: "ProductLocations_Tbl");

            migrationBuilder.DropTable(
                name: "ProductPrices_Tbl");

            migrationBuilder.DropTable(
                name: "Roles_Tbl");

            migrationBuilder.DropTable(
                name: "WareHouses_Tbl");

            migrationBuilder.DropTable(
                name: "FiscalYears_Tbl");

            migrationBuilder.DropTable(
                name: "Products_Tbl");

            migrationBuilder.DropTable(
                name: "Countries_Tbl");

            migrationBuilder.DropTable(
                name: "Suppliers_Tbl");

            migrationBuilder.DropTable(
                name: "Users_Tbl");
        }
    }
}
