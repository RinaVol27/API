using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApi_Vol.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courier",
                columns: table => new
                {
                    id_courier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name_courier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courier__3E05CEFE19329956", x => x.id_courier);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    id_manufacturer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manuf_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    house = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    entrance = table.Column<int>(type: "int", nullable: true),
                    num_floor = table.Column<int>(type: "int", nullable: true),
                    apartment = table.Column<int>(type: "int", nullable: true),
                    index_us = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Manufact__0F53B9C356E64E9E", x => x.id_manufacturer);
                });

            migrationBuilder.CreateTable(
                name: "Product_Category",
                columns: table => new
                {
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___4BB73C334359DFAA", x => x.Category);
                });

            migrationBuilder.CreateTable(
                name: "Product_Packaging",
                columns: table => new
                {
                    packaging = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    quality = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___9D09D5A93F97C0EE", x => x.packaging);
                });

            migrationBuilder.CreateTable(
                name: "Site_User",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Site_Use__B607F2480EF92801", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    id_transport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transport_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    number_tr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transpor__A387EDD46BD49627", x => x.id_transport);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id_product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Count_product_on_warehouse = table.Column<int>(type: "int", nullable: false),
                    Count_in_box = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_manufacturer = table.Column<int>(type: "int", nullable: false),
                    expiration_date = table.Column<int>(type: "int", nullable: false),
                    production_date = table.Column<DateTime>(type: "date", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    image_pr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight_pr = table.Column<decimal>(type: "decimal(10,1)", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__BA39E84F564333C8", x => x.id_product);
                    table.ForeignKey(
                        name: "FK__Product__Categor__1BC821DD",
                        column: x => x.Category,
                        principalTable: "Product_Category",
                        principalColumn: "Category");
                    table.ForeignKey(
                        name: "FK__Product__id_manu__1CBC4616",
                        column: x => x.id_manufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "id_manufacturer");
                });

            migrationBuilder.CreateTable(
                name: "User_Card",
                columns: table => new
                {
                    Id_card = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number_card = table.Column<int>(type: "int", nullable: false),
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_Car__549380B9B15099AC", x => x.Id_card);
                    table.ForeignKey(
                        name: "FK__User_Card__is_de__797309D9",
                        column: x => x.Id_user,
                        principalTable: "Site_User",
                        principalColumn: "Id_user");
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    id_delivery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delivery_method = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_courier = table.Column<int>(type: "int", nullable: true),
                    id_transport = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Delivery__D7513687E2B9990D", x => x.id_delivery);
                    table.ForeignKey(
                        name: "FK__Delivery__id_cou__06CD04F7",
                        column: x => x.id_courier,
                        principalTable: "Courier",
                        principalColumn: "id_courier");
                    table.ForeignKey(
                        name: "FK__Delivery__id_tra__07C12930",
                        column: x => x.id_transport,
                        principalTable: "Transport",
                        principalColumn: "id_transport");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Id_card = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__862FEFE083D0629A", x => x.id_payment);
                    table.ForeignKey(
                        name: "FK__Payment__Id_card__7D439ABD",
                        column: x => x.Id_card,
                        principalTable: "User_Card",
                        principalColumn: "Id_card");
                });

            migrationBuilder.CreateTable(
                name: "User_Order",
                columns: table => new
                {
                    id_order = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    assembly_period = table.Column<int>(type: "int", nullable: true),
                    id_payment = table.Column<int>(type: "int", nullable: false),
                    id_delivery = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "date", nullable: false),
                    information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    house = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    entrance = table.Column<int>(type: "int", nullable: true),
                    num_floor = table.Column<int>(type: "int", nullable: true),
                    apartment = table.Column<int>(type: "int", nullable: true),
                    index_us = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_Ord__DD5B8F3F09A590E8", x => x.id_order);
                    table.ForeignKey(
                        name: "FK__User_Orde__id_de__0E6E26BF",
                        column: x => x.id_delivery,
                        principalTable: "Delivery",
                        principalColumn: "id_delivery");
                    table.ForeignKey(
                        name: "FK__User_Orde__id_pa__0D7A0286",
                        column: x => x.id_payment,
                        principalTable: "Payment",
                        principalColumn: "id_payment");
                    table.ForeignKey(
                        name: "FK__User_Orde__Id_us__0C85DE4D",
                        column: x => x.Id_user,
                        principalTable: "Site_User",
                        principalColumn: "Id_user");
                });

            migrationBuilder.CreateTable(
                name: "Order_Contents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_product = table.Column<int>(type: "int", nullable: false),
                    id_order = table.Column<int>(type: "int", nullable: false),
                    count_product = table.Column<int>(type: "int", nullable: false),
                    packaging = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Contents", x => x.id);
                    table.ForeignKey(
                        name: "FK__Order_Con__id_or__208CD6FA",
                        column: x => x.id_order,
                        principalTable: "User_Order",
                        principalColumn: "id_order");
                    table.ForeignKey(
                        name: "FK__Order_Con__id_pr__2180FB33",
                        column: x => x.id_product,
                        principalTable: "Product",
                        principalColumn: "id_product");
                    table.ForeignKey(
                        name: "FK__Order_Con__packa__22751F6C",
                        column: x => x.packaging,
                        principalTable: "Product_Packaging",
                        principalColumn: "packaging");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_id_courier",
                table: "Delivery",
                column: "id_courier");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_id_transport",
                table: "Delivery",
                column: "id_transport");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Contents_id_order",
                table: "Order_Contents",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Contents_id_product",
                table: "Order_Contents",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Contents_packaging",
                table: "Order_Contents",
                column: "packaging");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Id_card",
                table: "Payment",
                column: "Id_card");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category",
                table: "Product",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Product_id_manufacturer",
                table: "Product",
                column: "id_manufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_User_Card_Id_user",
                table: "User_Card",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_User_Order_id_delivery",
                table: "User_Order",
                column: "id_delivery");

            migrationBuilder.CreateIndex(
                name: "IX_User_Order_id_payment",
                table: "User_Order",
                column: "id_payment");

            migrationBuilder.CreateIndex(
                name: "IX_User_Order_Id_user",
                table: "User_Order",
                column: "Id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Contents");

            migrationBuilder.DropTable(
                name: "User_Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Product_Packaging");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Product_Category");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Courier");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "User_Card");

            migrationBuilder.DropTable(
                name: "Site_User");
        }
    }
}
