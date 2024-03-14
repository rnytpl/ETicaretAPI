using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("37385c93-2835-4059-9a44-09f881a48753"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7327), "Aslan", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7327) },
                    { new Guid("b4f8fa92-fd1a-404e-b91a-9a1bee8c23fb"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7325), "Faruk", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7326) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedTime", "Name", "Price", "Stock", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("0f573d19-f500-4484-aaea-9b17dd2e603f"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7151), "Product 5", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7151) },
                    { new Guid("0f76ed9c-16bb-4589-82fb-8cba14f54cc3"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7198), "Product 19", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7199) },
                    { new Guid("265683a3-aa38-4566-8672-a04026ad722a"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7192), "Product 16", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7193) },
                    { new Guid("32980ca4-1b8f-43d2-91d8-ecdc13345f27"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7169), "Product 6", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7169) },
                    { new Guid("412a41d6-1d65-43dd-a8a7-57817b860d67"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7181), "Product 12", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7182) },
                    { new Guid("4dfccbee-cabf-420e-98bd-c37793b9113c"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7171), "Product 7", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7172) },
                    { new Guid("54b880e0-584d-448e-b004-6cf245d31f44"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7200), "Product 5", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7201) },
                    { new Guid("55892398-5bca-4e10-81bf-eb2f756d034e"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7183), "Product 13", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7184) },
                    { new Guid("621351df-3c01-43ac-b6cd-301edf40325b"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7190), "Product 15", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7191) },
                    { new Guid("6646519c-01f5-434f-ad87-719e8d1e566a"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7139), "Product 1", 500f, 100, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7141) },
                    { new Guid("6735926e-a024-44e4-892a-3fc8b186639f"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7175), "Product 9", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7176) },
                    { new Guid("6e61ce0b-4cf3-4851-a81f-be772c3efec8"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7144), "Product 2", 600f, 200, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7145) },
                    { new Guid("7eeba2e4-e66f-4075-991f-c607d9f0b780"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7147), "Product 3", 700f, 300, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7147) },
                    { new Guid("8dba5805-e09d-4c21-bb6f-5d612256f557"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7202), "Product 5", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7203) },
                    { new Guid("a8092878-6f14-4514-96a0-6201a6a1661a"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7194), "Product 17", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7195) },
                    { new Guid("a8fe1daa-2697-4956-8761-62dde0b29865"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7179), "Product 11", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7180) },
                    { new Guid("ae9b44fa-4584-4797-86bf-5672c116cdc7"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7188), "Product 14", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7189) },
                    { new Guid("b13fb4d5-2dc6-4407-87b1-7caee3b385ab"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7149), "Product 4", 800f, 400, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7149) },
                    { new Guid("b1f2ad85-4c3f-4112-abd2-573ad34ce58a"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7177), "Product 10", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7178) },
                    { new Guid("c321c1d8-6de4-4baa-823e-0fe37f467080"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7207), "Product 5", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7207) },
                    { new Guid("cc55152b-6f4b-4284-adac-9e0e1ab37a1c"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7209), "Product 5", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7209) },
                    { new Guid("eec2add7-75ac-4d17-ae34-b668645459be"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7196), "Product 18", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7197) },
                    { new Guid("fc823166-4091-4ecd-9bf2-75f4005d7318"), new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7173), "Product 8", 900f, 500, new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7174) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedTime", "CustomerId", "Description", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("317f7226-e8b4-42e5-8397-5c9421b0a3aa"), "Kartal", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7384), new Guid("37385c93-2835-4059-9a44-09f881a48753"), "Customer 37385c93-2835-4059-9a44-09f881a48753", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7384) },
                    { new Guid("7a6457d8-e475-45f4-9ced-bb8d009f4a5d"), "Eraykent", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7375), new Guid("b4f8fa92-fd1a-404e-b91a-9a1bee8c23fb"), "Customer b4f8fa92-fd1a-404e-b91a-9a1bee8c23fb", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7375) },
                    { new Guid("c399b3c5-e7ae-4e81-b560-b3e67966efd0"), "Maltepe", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7379), new Guid("b4f8fa92-fd1a-404e-b91a-9a1bee8c23fb"), "Customer b4f8fa92-fd1a-404e-b91a-9a1bee8c23fb", new DateTime(2024, 3, 10, 15, 42, 9, 640, DateTimeKind.Utc).AddTicks(7380) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
