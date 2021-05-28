using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PPDL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    customerLocale = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    locationCity = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    locationState = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.locationID);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    managerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    managerName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.managerID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    productPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "int", nullable: false),
                    orderQuantity = table.Column<int>(type: "int", nullable: false),
                    orderNumber = table.Column<int>(type: "int", nullable: false),
                    orderTotal = table.Column<double>(type: "float", nullable: false),
                    orderLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderID);
                    table.ForeignKey(
                        name: "FK__Orders__orderNum__3A6CA48E",
                        column: x => x.orderNumber,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    inventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inventoryNumber = table.Column<int>(type: "int", nullable: false),
                    inventoryQuantity = table.Column<int>(type: "int", nullable: false),
                    inventoryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.inventoryID);
                    table.ForeignKey(
                        name: "FK__Inventory__inven__4119A21D",
                        column: x => x.inventoryNumber,
                        principalTable: "Products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Inventory__inven__420DC656",
                        column: x => x.inventoryCode,
                        principalTable: "Location",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    lineItemID = table.Column<int>(type: "int", nullable: false),
                    lineProductID = table.Column<int>(type: "int", nullable: false),
                    lineOrderID = table.Column<int>(type: "int", nullable: false),
                    lineQuantityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.lineItemID);
                    table.ForeignKey(
                        name: "FK__LineItems__lineO__3E3D3572",
                        column: x => x.lineOrderID,
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LineItems__lineP__3D491139",
                        column: x => x.lineProductID,
                        principalTable: "Products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_inventoryCode",
                table: "Inventory",
                column: "inventoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_inventoryNumber",
                table: "Inventory",
                column: "inventoryNumber");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_lineOrderID",
                table: "LineItems",
                column: "lineOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_lineProductID",
                table: "LineItems",
                column: "lineProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderNumber",
                table: "Orders",
                column: "orderNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
