using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ETicaretAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NameSurname = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductImageFile",
                columns: table => new
                {
                    ProductImageFilesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductImageFile", x => new { x.ProductImageFilesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_Files_ProductImageFilesId",
                        column: x => x.ProductImageFilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BasketId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    OrderCode = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Baskets_Id",
                        column: x => x.Id,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("003b5592-78ae-4dbe-aa9e-258a1228921a"), new DateTime(2024, 12, 6, 17, 58, 6, 752, DateTimeKind.Utc).AddTicks(5556), "A brief description of the product, highlighting its key features and benefits.", "Product 272", 272f, 272, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00fa100f-6a1c-4621-a4de-d892d54f0529"), new DateTime(2024, 12, 6, 17, 54, 32, 752, DateTimeKind.Utc).AddTicks(5040), "A brief description of the product, highlighting its key features and benefits.", "Product 58", 58f, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("024fac67-9fd5-48d7-b853-f4558adb094f"), new DateTime(2024, 12, 6, 17, 54, 25, 752, DateTimeKind.Utc).AddTicks(5027), "A brief description of the product, highlighting its key features and benefits.", "Product 51", 51f, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("037d79bb-9e16-4a67-a8d6-b2ee1c622eea"), new DateTime(2024, 12, 6, 17, 57, 5, 752, DateTimeKind.Utc).AddTicks(5419), "A brief description of the product, highlighting its key features and benefits.", "Product 211", 211f, 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("03dd034a-c48d-4b68-8708-a625a81d8992"), new DateTime(2024, 12, 6, 17, 58, 0, 752, DateTimeKind.Utc).AddTicks(5520), "A brief description of the product, highlighting its key features and benefits.", "Product 266", 266f, 266, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("03f2930c-a98c-4d90-9035-9b07833d2c81"), new DateTime(2024, 12, 6, 17, 54, 19, 752, DateTimeKind.Utc).AddTicks(5015), "A brief description of the product, highlighting its key features and benefits.", "Product 45", 45f, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("04220fd0-1629-4720-bddf-ac4fdc502ea7"), new DateTime(2024, 12, 6, 17, 54, 50, 752, DateTimeKind.Utc).AddTicks(5072), "A brief description of the product, highlighting its key features and benefits.", "Product 76", 76f, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("04312a11-beb8-4c87-9817-9806e529e196"), new DateTime(2024, 12, 6, 17, 55, 1, 752, DateTimeKind.Utc).AddTicks(5093), "A brief description of the product, highlighting its key features and benefits.", "Product 87", 87f, 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("05d78535-a13f-4b39-837a-66f1096f8de7"), new DateTime(2024, 12, 6, 17, 54, 5, 752, DateTimeKind.Utc).AddTicks(4969), "A brief description of the product, highlighting its key features and benefits.", "Product 31", 31f, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("069215c3-641a-4d0c-8394-1981be93dd7d"), new DateTime(2024, 12, 6, 17, 57, 43, 752, DateTimeKind.Utc).AddTicks(5489), "A brief description of the product, highlighting its key features and benefits.", "Product 249", 249f, 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("06c30251-75f2-4ad6-87b8-842b0a4459e0"), new DateTime(2024, 12, 6, 17, 57, 40, 752, DateTimeKind.Utc).AddTicks(5484), "A brief description of the product, highlighting its key features and benefits.", "Product 246", 246f, 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("06dce404-8399-4a58-abab-42079a126a82"), new DateTime(2024, 12, 6, 17, 58, 20, 752, DateTimeKind.Utc).AddTicks(5582), "A brief description of the product, highlighting its key features and benefits.", "Product 286", 286f, 286, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("073400fe-acc1-462a-baaf-06396b6aacd7"), new DateTime(2024, 12, 6, 17, 57, 24, 752, DateTimeKind.Utc).AddTicks(5455), "A brief description of the product, highlighting its key features and benefits.", "Product 230", 230f, 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0859a4ff-2602-4d0f-8237-d9ac5162737e"), new DateTime(2024, 12, 6, 17, 55, 23, 752, DateTimeKind.Utc).AddTicks(5171), "A brief description of the product, highlighting its key features and benefits.", "Product 109", 109f, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("08bd05ee-aa56-42a8-adc0-0a4ac44714bf"), new DateTime(2024, 12, 6, 17, 57, 1, 752, DateTimeKind.Utc).AddTicks(5388), "A brief description of the product, highlighting its key features and benefits.", "Product 207", 207f, 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("093dd07f-4f6f-46b3-aefb-7d89f888e1d1"), new DateTime(2024, 12, 6, 17, 57, 2, 752, DateTimeKind.Utc).AddTicks(5389), "A brief description of the product, highlighting its key features and benefits.", "Product 208", 208f, 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0a390757-b56f-431d-94e3-91882307b8e4"), new DateTime(2024, 12, 6, 17, 54, 8, 752, DateTimeKind.Utc).AddTicks(4974), "A brief description of the product, highlighting its key features and benefits.", "Product 34", 34f, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0a6d0319-e588-4a4b-acac-6cf23206ebb9"), new DateTime(2024, 12, 6, 17, 55, 13, 752, DateTimeKind.Utc).AddTicks(5153), "A brief description of the product, highlighting its key features and benefits.", "Product 99", 99f, 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b9c5d04-45ca-4d8c-b14e-7584e88322fe"), new DateTime(2024, 12, 6, 17, 54, 43, 752, DateTimeKind.Utc).AddTicks(5059), "A brief description of the product, highlighting its key features and benefits.", "Product 69", 69f, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c93843c-9ed3-4e62-a892-8b62f5a8e864"), new DateTime(2024, 12, 6, 17, 53, 50, 752, DateTimeKind.Utc).AddTicks(4942), "A brief description of the product, highlighting its key features and benefits.", "Product 16", 16f, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c9a9338-ee6d-4fe9-a447-a051367bf616"), new DateTime(2024, 12, 6, 17, 58, 27, 752, DateTimeKind.Utc).AddTicks(5594), "A brief description of the product, highlighting its key features and benefits.", "Product 293", 293f, 293, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0caab144-2609-410d-8076-ccf6824f50fd"), new DateTime(2024, 12, 6, 17, 53, 43, 752, DateTimeKind.Utc).AddTicks(4926), "A brief description of the product, highlighting its key features and benefits.", "Product 9", 9f, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0cde1687-16c0-458e-9b72-f9ac8f3b034e"), new DateTime(2024, 12, 6, 17, 56, 11, 752, DateTimeKind.Utc).AddTicks(5296), "A brief description of the product, highlighting its key features and benefits.", "Product 157", 157f, 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d167cb8-d68f-417e-95cf-8638a047c025"), new DateTime(2024, 12, 6, 17, 54, 9, 752, DateTimeKind.Utc).AddTicks(4976), "A brief description of the product, highlighting its key features and benefits.", "Product 35", 35f, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0dfb22f5-1f30-48fd-a008-62e2f80eb92e"), new DateTime(2024, 12, 6, 17, 57, 14, 752, DateTimeKind.Utc).AddTicks(5436), "A brief description of the product, highlighting its key features and benefits.", "Product 220", 220f, 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ee94554-89f3-4012-9b79-5376c0f2ede1"), new DateTime(2024, 12, 6, 17, 56, 24, 752, DateTimeKind.Utc).AddTicks(5320), "A brief description of the product, highlighting its key features and benefits.", "Product 170", 170f, 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f125e49-eae7-4f88-bcee-4440c4fccd00"), new DateTime(2024, 12, 6, 17, 57, 58, 752, DateTimeKind.Utc).AddTicks(5517), "A brief description of the product, highlighting its key features and benefits.", "Product 264", 264f, 264, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f7f95d0-8df5-47b2-ab75-a41a8ec1dccd"), new DateTime(2024, 12, 6, 17, 58, 18, 752, DateTimeKind.Utc).AddTicks(5577), "A brief description of the product, highlighting its key features and benefits.", "Product 284", 284f, 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("118d1a36-1b61-47bd-a687-c26664eef127"), new DateTime(2024, 12, 6, 17, 56, 3, 752, DateTimeKind.Utc).AddTicks(5243), "A brief description of the product, highlighting its key features and benefits.", "Product 149", 149f, 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12b46091-cc4a-4ee3-86c7-3c8f7bb2eb3b"), new DateTime(2024, 12, 6, 17, 54, 27, 752, DateTimeKind.Utc).AddTicks(5030), "A brief description of the product, highlighting its key features and benefits.", "Product 53", 53f, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13176b06-079e-4a9c-99cd-ed40c7355b7e"), new DateTime(2024, 12, 6, 17, 55, 42, 752, DateTimeKind.Utc).AddTicks(5206), "A brief description of the product, highlighting its key features and benefits.", "Product 128", 128f, 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1341441d-dd7c-4261-9935-b2c59b77a973"), new DateTime(2024, 12, 6, 17, 53, 53, 752, DateTimeKind.Utc).AddTicks(4947), "A brief description of the product, highlighting its key features and benefits.", "Product 19", 19f, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16a91a90-1efa-43bc-84c3-de7eda2b5f5d"), new DateTime(2024, 12, 6, 17, 55, 47, 752, DateTimeKind.Utc).AddTicks(5214), "A brief description of the product, highlighting its key features and benefits.", "Product 133", 133f, 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16bf85c0-f326-4984-9fe5-b19502a077fa"), new DateTime(2024, 12, 6, 17, 55, 4, 752, DateTimeKind.Utc).AddTicks(5097), "A brief description of the product, highlighting its key features and benefits.", "Product 90", 90f, 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("170e9de4-907a-4376-91e1-d4073b3bff8a"), new DateTime(2024, 12, 6, 17, 54, 10, 752, DateTimeKind.Utc).AddTicks(4978), "A brief description of the product, highlighting its key features and benefits.", "Product 36", 36f, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("181bf7ab-6091-43f8-a2b6-e7988793ecd1"), new DateTime(2024, 12, 6, 17, 55, 12, 752, DateTimeKind.Utc).AddTicks(5151), "A brief description of the product, highlighting its key features and benefits.", "Product 98", 98f, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("188e6752-9134-454a-b589-3b586713dc6f"), new DateTime(2024, 12, 6, 17, 55, 46, 752, DateTimeKind.Utc).AddTicks(5213), "A brief description of the product, highlighting its key features and benefits.", "Product 132", 132f, 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19bc8fdb-1242-410d-aca8-211abcc0254c"), new DateTime(2024, 12, 6, 17, 55, 43, 752, DateTimeKind.Utc).AddTicks(5208), "A brief description of the product, highlighting its key features and benefits.", "Product 129", 129f, 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1a0ed4a6-8b08-4a2f-9fda-ddfc8a1ac416"), new DateTime(2024, 12, 6, 17, 55, 45, 752, DateTimeKind.Utc).AddTicks(5211), "A brief description of the product, highlighting its key features and benefits.", "Product 131", 131f, 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b181d17-e1ae-43eb-9e9b-57f9b1ebdcca"), new DateTime(2024, 12, 6, 17, 57, 37, 752, DateTimeKind.Utc).AddTicks(5478), "A brief description of the product, highlighting its key features and benefits.", "Product 243", 243f, 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b31870a-70e4-4eb7-8e08-dcb03bd0b810"), new DateTime(2024, 12, 6, 17, 53, 52, 752, DateTimeKind.Utc).AddTicks(4945), "A brief description of the product, highlighting its key features and benefits.", "Product 18", 18f, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1c77deca-b575-4b54-a960-1c8e49369b32"), new DateTime(2024, 12, 6, 17, 54, 24, 752, DateTimeKind.Utc).AddTicks(5025), "A brief description of the product, highlighting its key features and benefits.", "Product 50", 50f, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1cfb1915-efc7-45bd-8a78-02c5985f167d"), new DateTime(2024, 12, 6, 17, 56, 38, 752, DateTimeKind.Utc).AddTicks(5346), "A brief description of the product, highlighting its key features and benefits.", "Product 184", 184f, 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e88f08e-20c0-4fda-a69a-2badd6b68a32"), new DateTime(2024, 12, 6, 17, 54, 55, 752, DateTimeKind.Utc).AddTicks(5081), "A brief description of the product, highlighting its key features and benefits.", "Product 81", 81f, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ea2b5d1-e130-4385-93f6-3094afe792a5"), new DateTime(2024, 12, 6, 17, 55, 53, 752, DateTimeKind.Utc).AddTicks(5226), "A brief description of the product, highlighting its key features and benefits.", "Product 139", 139f, 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f1f7917-cae0-44ec-a24f-0c94c51e49ff"), new DateTime(2024, 12, 6, 17, 57, 49, 752, DateTimeKind.Utc).AddTicks(5501), "A brief description of the product, highlighting its key features and benefits.", "Product 255", 255f, 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f889427-6174-49d7-a732-8d07492ff0b8"), new DateTime(2024, 12, 6, 17, 58, 32, 752, DateTimeKind.Utc).AddTicks(5604), "A brief description of the product, highlighting its key features and benefits.", "Product 298", 298f, 298, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20102f29-1f1a-4bb3-bc07-d3d1ab263b40"), new DateTime(2024, 12, 6, 17, 55, 18, 752, DateTimeKind.Utc).AddTicks(5163), "A brief description of the product, highlighting its key features and benefits.", "Product 104", 104f, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20a2ada8-2dfb-4407-80fd-079d196a7a0a"), new DateTime(2024, 12, 6, 17, 56, 7, 752, DateTimeKind.Utc).AddTicks(5251), "A brief description of the product, highlighting its key features and benefits.", "Product 153", 153f, 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("215dd295-35ec-4486-9d27-9f4f7c502c87"), new DateTime(2024, 12, 6, 17, 54, 2, 752, DateTimeKind.Utc).AddTicks(4963), "A brief description of the product, highlighting its key features and benefits.", "Product 28", 28f, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("217972e7-03ff-4da8-b3e1-34bd0c08e322"), new DateTime(2024, 12, 6, 17, 54, 57, 752, DateTimeKind.Utc).AddTicks(5085), "A brief description of the product, highlighting its key features and benefits.", "Product 83", 83f, 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21c604dd-9b4d-41a0-b0e3-ff8ca330e834"), new DateTime(2024, 12, 6, 17, 57, 22, 752, DateTimeKind.Utc).AddTicks(5450), "A brief description of the product, highlighting its key features and benefits.", "Product 228", 228f, 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2320c615-350a-43a0-9bbc-a8c5b5a0d2b0"), new DateTime(2024, 12, 6, 17, 54, 30, 752, DateTimeKind.Utc).AddTicks(5036), "A brief description of the product, highlighting its key features and benefits.", "Product 56", 56f, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("23bb2f5b-833e-4ca0-957a-cb3d90733bd9"), new DateTime(2024, 12, 6, 17, 56, 34, 752, DateTimeKind.Utc).AddTicks(5338), "A brief description of the product, highlighting its key features and benefits.", "Product 180", 180f, 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("25ba2f07-f0f2-4e7b-bb87-747cbb5c50c0"), new DateTime(2024, 12, 6, 17, 54, 17, 752, DateTimeKind.Utc).AddTicks(5011), "A brief description of the product, highlighting its key features and benefits.", "Product 43", 43f, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26369069-265f-4b77-93a7-86c6760ac39b"), new DateTime(2024, 12, 6, 17, 53, 59, 752, DateTimeKind.Utc).AddTicks(4958), "A brief description of the product, highlighting its key features and benefits.", "Product 25", 25f, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26389e91-2876-4397-843f-68f4ac1bf88f"), new DateTime(2024, 12, 6, 17, 56, 14, 752, DateTimeKind.Utc).AddTicks(5302), "A brief description of the product, highlighting its key features and benefits.", "Product 160", 160f, 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26a46dc9-9f22-4016-a4e2-2cf5be4cc094"), new DateTime(2024, 12, 6, 17, 57, 46, 752, DateTimeKind.Utc).AddTicks(5494), "A brief description of the product, highlighting its key features and benefits.", "Product 252", 252f, 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26f6b66f-12fc-4def-8c86-b4d3fb952db3"), new DateTime(2024, 12, 6, 17, 58, 28, 752, DateTimeKind.Utc).AddTicks(5597), "A brief description of the product, highlighting its key features and benefits.", "Product 294", 294f, 294, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("274d563d-54c1-4b00-b4d5-d6f77cc81516"), new DateTime(2024, 12, 6, 17, 58, 7, 752, DateTimeKind.Utc).AddTicks(5558), "A brief description of the product, highlighting its key features and benefits.", "Product 273", 273f, 273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27ae275b-98b0-494b-b07a-ee6b664b9ad7"), new DateTime(2024, 12, 6, 17, 55, 6, 752, DateTimeKind.Utc).AddTicks(5101), "A brief description of the product, highlighting its key features and benefits.", "Product 92", 92f, 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("280e09fb-5143-4b10-b27a-dc357aa8723f"), new DateTime(2024, 12, 6, 17, 57, 15, 752, DateTimeKind.Utc).AddTicks(5437), "A brief description of the product, highlighting its key features and benefits.", "Product 221", 221f, 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("28a272fc-af01-4ef6-8eb7-8ef7b8465e77"), new DateTime(2024, 12, 6, 17, 57, 13, 752, DateTimeKind.Utc).AddTicks(5434), "A brief description of the product, highlighting its key features and benefits.", "Product 219", 219f, 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("28c2791c-29c9-479c-a85b-10590444d98f"), new DateTime(2024, 12, 6, 17, 54, 11, 752, DateTimeKind.Utc).AddTicks(4979), "A brief description of the product, highlighting its key features and benefits.", "Product 37", 37f, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("292fcaae-e5e0-457a-8fdb-ee1f8824c82e"), new DateTime(2024, 12, 6, 17, 55, 29, 752, DateTimeKind.Utc).AddTicks(5182), "A brief description of the product, highlighting its key features and benefits.", "Product 115", 115f, 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a096b28-22d5-48c4-a2a8-a52e25c23012"), new DateTime(2024, 12, 6, 17, 56, 53, 752, DateTimeKind.Utc).AddTicks(5373), "A brief description of the product, highlighting its key features and benefits.", "Product 199", 199f, 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a2bcdc8-6645-4bca-8d7e-628e72fe6b23"), new DateTime(2024, 12, 6, 17, 56, 13, 752, DateTimeKind.Utc).AddTicks(5301), "A brief description of the product, highlighting its key features and benefits.", "Product 159", 159f, 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a34d734-5aa2-40b7-827f-caaa78539718"), new DateTime(2024, 12, 6, 17, 57, 12, 752, DateTimeKind.Utc).AddTicks(5432), "A brief description of the product, highlighting its key features and benefits.", "Product 218", 218f, 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b859682-1ee7-4c83-b307-5b73c365e71b"), new DateTime(2024, 12, 6, 17, 57, 28, 752, DateTimeKind.Utc).AddTicks(5462), "A brief description of the product, highlighting its key features and benefits.", "Product 234", 234f, 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2df15b79-426a-4c18-bc56-f528048116bb"), new DateTime(2024, 12, 6, 17, 53, 55, 752, DateTimeKind.Utc).AddTicks(4950), "A brief description of the product, highlighting its key features and benefits.", "Product 21", 21f, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f5c2e3d-9d58-4c48-846e-7b5acd2e3a91"), new DateTime(2024, 12, 6, 17, 57, 45, 752, DateTimeKind.Utc).AddTicks(5493), "A brief description of the product, highlighting its key features and benefits.", "Product 251", 251f, 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30ba7e03-7b73-497f-9308-ef7c3fad9e3f"), new DateTime(2024, 12, 6, 17, 56, 30, 752, DateTimeKind.Utc).AddTicks(5331), "A brief description of the product, highlighting its key features and benefits.", "Product 176", 176f, 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3146c545-cf49-48a0-b1d5-d76c98ec66e5"), new DateTime(2024, 12, 6, 17, 57, 18, 752, DateTimeKind.Utc).AddTicks(5444), "A brief description of the product, highlighting its key features and benefits.", "Product 224", 224f, 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("32492719-0b19-43d2-bd79-4f9d38ca8631"), new DateTime(2024, 12, 6, 17, 54, 3, 752, DateTimeKind.Utc).AddTicks(4964), "A brief description of the product, highlighting its key features and benefits.", "Product 29", 29f, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33a90c8c-5e90-49e1-aba5-6e4ea3e8aa82"), new DateTime(2024, 12, 6, 17, 56, 20, 752, DateTimeKind.Utc).AddTicks(5314), "A brief description of the product, highlighting its key features and benefits.", "Product 166", 166f, 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3487590c-fbec-4c4f-bcee-0b6ab18fbcfa"), new DateTime(2024, 12, 6, 17, 56, 16, 752, DateTimeKind.Utc).AddTicks(5305), "A brief description of the product, highlighting its key features and benefits.", "Product 162", 162f, 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34b68c98-9437-4b22-82c4-4a19fbe527da"), new DateTime(2024, 12, 6, 17, 57, 54, 752, DateTimeKind.Utc).AddTicks(5509), "A brief description of the product, highlighting its key features and benefits.", "Product 260", 260f, 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("351f8cf1-0291-48bf-b674-8c33baa9f42b"), new DateTime(2024, 12, 6, 17, 57, 34, 752, DateTimeKind.Utc).AddTicks(5473), "A brief description of the product, highlighting its key features and benefits.", "Product 240", 240f, 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("369a0910-7982-42d2-873c-83aeedbacaa6"), new DateTime(2024, 12, 6, 17, 55, 33, 752, DateTimeKind.Utc).AddTicks(5190), "A brief description of the product, highlighting its key features and benefits.", "Product 119", 119f, 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("385f280e-c55f-471c-bdce-af57a0d6f1d1"), new DateTime(2024, 12, 6, 17, 55, 15, 752, DateTimeKind.Utc).AddTicks(5156), "A brief description of the product, highlighting its key features and benefits.", "Product 101", 101f, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3910d31d-128a-4472-a97e-2c03b3a9beb3"), new DateTime(2024, 12, 6, 17, 54, 41, 752, DateTimeKind.Utc).AddTicks(5056), "A brief description of the product, highlighting its key features and benefits.", "Product 67", 67f, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3910dc66-69cc-4ce0-a424-4f63b3cfa116"), new DateTime(2024, 12, 6, 17, 58, 13, 752, DateTimeKind.Utc).AddTicks(5569), "A brief description of the product, highlighting its key features and benefits.", "Product 279", 279f, 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39b81ada-bffd-4caf-a3f7-44e22ad809a4"), new DateTime(2024, 12, 6, 17, 57, 21, 752, DateTimeKind.Utc).AddTicks(5449), "A brief description of the product, highlighting its key features and benefits.", "Product 227", 227f, 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b6f5cb2-7aee-4bb2-985c-7fbea295d5e5"), new DateTime(2024, 12, 6, 17, 56, 56, 752, DateTimeKind.Utc).AddTicks(5378), "A brief description of the product, highlighting its key features and benefits.", "Product 202", 202f, 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cc7fda3-b6a8-421d-b27e-8f0bf2ec806d"), new DateTime(2024, 12, 6, 17, 58, 9, 752, DateTimeKind.Utc).AddTicks(5561), "A brief description of the product, highlighting its key features and benefits.", "Product 275", 275f, 275, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e18bdb2-d9a6-4276-a5fd-e43010941d4a"), new DateTime(2024, 12, 6, 17, 54, 16, 752, DateTimeKind.Utc).AddTicks(5009), "A brief description of the product, highlighting its key features and benefits.", "Product 42", 42f, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e706efd-943b-4cf8-8df1-31c4773782ec"), new DateTime(2024, 12, 6, 17, 55, 10, 752, DateTimeKind.Utc).AddTicks(5109), "A brief description of the product, highlighting its key features and benefits.", "Product 96", 96f, 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f0c652e-d9c0-4578-b5c4-4cf108f198c8"), new DateTime(2024, 12, 6, 17, 57, 56, 752, DateTimeKind.Utc).AddTicks(5514), "A brief description of the product, highlighting its key features and benefits.", "Product 262", 262f, 262, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4006d689-48e2-45a1-a3ef-39b72093c37f"), new DateTime(2024, 12, 6, 17, 53, 38, 752, DateTimeKind.Utc).AddTicks(4906), "A brief description of the product, highlighting its key features and benefits.", "Product 4", 4f, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("400c5608-280d-427e-9e33-92dec0e5dc5e"), new DateTime(2024, 12, 6, 17, 56, 18, 752, DateTimeKind.Utc).AddTicks(5309), "A brief description of the product, highlighting its key features and benefits.", "Product 164", 164f, 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4112c2ce-e054-4e9d-85db-4064dacd2b12"), new DateTime(2024, 12, 6, 17, 55, 2, 752, DateTimeKind.Utc).AddTicks(5094), "A brief description of the product, highlighting its key features and benefits.", "Product 88", 88f, 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("417f466b-8d26-4123-9bf4-6c656bd29b82"), new DateTime(2024, 12, 6, 17, 54, 48, 752, DateTimeKind.Utc).AddTicks(5068), "A brief description of the product, highlighting its key features and benefits.", "Product 74", 74f, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41b220e2-b389-4b11-b3c1-137eeab45275"), new DateTime(2024, 12, 6, 17, 56, 17, 752, DateTimeKind.Utc).AddTicks(5307), "A brief description of the product, highlighting its key features and benefits.", "Product 163", 163f, 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("422f7f27-ecd6-417e-9381-c462bc90be8b"), new DateTime(2024, 12, 6, 17, 56, 54, 752, DateTimeKind.Utc).AddTicks(5375), "A brief description of the product, highlighting its key features and benefits.", "Product 200", 200f, 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("425b396d-c5e2-4c94-b6b3-8f5e3a0b599e"), new DateTime(2024, 12, 6, 17, 57, 29, 752, DateTimeKind.Utc).AddTicks(5463), "A brief description of the product, highlighting its key features and benefits.", "Product 235", 235f, 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("429a3812-bf4c-44e0-a3be-56d1cbe17c7d"), new DateTime(2024, 12, 6, 17, 53, 39, 752, DateTimeKind.Utc).AddTicks(4908), "A brief description of the product, highlighting its key features and benefits.", "Product 5", 5f, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42f35bab-8a77-463c-a451-0e11e827adf7"), new DateTime(2024, 12, 6, 17, 57, 59, 752, DateTimeKind.Utc).AddTicks(5519), "A brief description of the product, highlighting its key features and benefits.", "Product 265", 265f, 265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42f4f0a5-5f45-44d4-9a8a-066eb5f21b29"), new DateTime(2024, 12, 6, 17, 53, 41, 752, DateTimeKind.Utc).AddTicks(4923), "A brief description of the product, highlighting its key features and benefits.", "Product 7", 7f, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43834f0a-0b67-4847-bfce-243ebbf34c68"), new DateTime(2024, 12, 6, 17, 56, 19, 752, DateTimeKind.Utc).AddTicks(5310), "A brief description of the product, highlighting its key features and benefits.", "Product 165", 165f, 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43b34d99-1cea-4e9a-abaa-2183417516aa"), new DateTime(2024, 12, 6, 17, 53, 44, 752, DateTimeKind.Utc).AddTicks(4929), "A brief description of the product, highlighting its key features and benefits.", "Product 10", 10f, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43cb8e24-222d-4ca7-bdc8-26d73a2c85a8"), new DateTime(2024, 12, 6, 17, 58, 29, 752, DateTimeKind.Utc).AddTicks(5599), "A brief description of the product, highlighting its key features and benefits.", "Product 295", 295f, 295, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4476be83-9256-47d9-a3be-089e2659ab3a"), new DateTime(2024, 12, 6, 17, 57, 33, 752, DateTimeKind.Utc).AddTicks(5471), "A brief description of the product, highlighting its key features and benefits.", "Product 239", 239f, 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45615b07-88e1-4b80-8dba-77828bf7c05a"), new DateTime(2024, 12, 6, 17, 54, 22, 752, DateTimeKind.Utc).AddTicks(5022), "A brief description of the product, highlighting its key features and benefits.", "Product 48", 48f, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45b37ef0-0179-4ad5-a88e-2ccb9458359c"), new DateTime(2024, 12, 6, 17, 55, 21, 752, DateTimeKind.Utc).AddTicks(5167), "A brief description of the product, highlighting its key features and benefits.", "Product 107", 107f, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4615fdaa-aa95-4f05-ba86-b118e8c86093"), new DateTime(2024, 12, 6, 17, 58, 11, 752, DateTimeKind.Utc).AddTicks(5564), "A brief description of the product, highlighting its key features and benefits.", "Product 277", 277f, 277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47439d1d-1f67-4d92-a463-79fe542699cd"), new DateTime(2024, 12, 6, 17, 58, 21, 752, DateTimeKind.Utc).AddTicks(5584), "A brief description of the product, highlighting its key features and benefits.", "Product 287", 287f, 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47545e2a-7ecd-4b3b-95cb-feaeaadc02d5"), new DateTime(2024, 12, 6, 17, 56, 26, 752, DateTimeKind.Utc).AddTicks(5323), "A brief description of the product, highlighting its key features and benefits.", "Product 172", 172f, 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4847c196-9e38-4fa2-8bdc-1e0c85b93ac9"), new DateTime(2024, 12, 6, 17, 56, 9, 752, DateTimeKind.Utc).AddTicks(5292), "A brief description of the product, highlighting its key features and benefits.", "Product 155", 155f, 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a758591-4d57-4a02-922a-8621cb7913cc"), new DateTime(2024, 12, 6, 17, 57, 17, 752, DateTimeKind.Utc).AddTicks(5442), "A brief description of the product, highlighting its key features and benefits.", "Product 223", 223f, 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a7a0860-8014-45a1-a18e-23de8627f58f"), new DateTime(2024, 12, 6, 17, 54, 26, 752, DateTimeKind.Utc).AddTicks(5028), "A brief description of the product, highlighting its key features and benefits.", "Product 52", 52f, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b018d1b-282d-42da-ac10-a4a297a4db22"), new DateTime(2024, 12, 6, 17, 55, 50, 752, DateTimeKind.Utc).AddTicks(5221), "A brief description of the product, highlighting its key features and benefits.", "Product 136", 136f, 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b8dafaf-9ff7-4c8a-a55f-ccd9a904a003"), new DateTime(2024, 12, 6, 17, 56, 22, 752, DateTimeKind.Utc).AddTicks(5317), "A brief description of the product, highlighting its key features and benefits.", "Product 168", 168f, 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4cb6f234-3320-4856-b6d1-129415a1778a"), new DateTime(2024, 12, 6, 17, 55, 9, 752, DateTimeKind.Utc).AddTicks(5107), "A brief description of the product, highlighting its key features and benefits.", "Product 95", 95f, 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4dc23270-c150-497a-b1db-9f1561f0a1da"), new DateTime(2024, 12, 6, 17, 58, 12, 752, DateTimeKind.Utc).AddTicks(5568), "A brief description of the product, highlighting its key features and benefits.", "Product 278", 278f, 278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ee0c79d-340b-4a9b-b93b-d3ec285b7862"), new DateTime(2024, 12, 6, 17, 56, 29, 752, DateTimeKind.Utc).AddTicks(5330), "A brief description of the product, highlighting its key features and benefits.", "Product 175", 175f, 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51af9dd2-f25b-4c9c-8669-64db96310f58"), new DateTime(2024, 12, 6, 17, 57, 10, 752, DateTimeKind.Utc).AddTicks(5429), "A brief description of the product, highlighting its key features and benefits.", "Product 216", 216f, 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51d73ac5-8220-4967-b1f7-911101a759df"), new DateTime(2024, 12, 6, 17, 54, 56, 752, DateTimeKind.Utc).AddTicks(5083), "A brief description of the product, highlighting its key features and benefits.", "Product 82", 82f, 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("521f59e6-97cf-4ef6-88b5-2062a15eb3f9"), new DateTime(2024, 12, 6, 17, 54, 34, 752, DateTimeKind.Utc).AddTicks(5043), "A brief description of the product, highlighting its key features and benefits.", "Product 60", 60f, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5255d3b6-3d27-45c1-852c-fa795809d8d3"), new DateTime(2024, 12, 6, 17, 55, 7, 752, DateTimeKind.Utc).AddTicks(5102), "A brief description of the product, highlighting its key features and benefits.", "Product 93", 93f, 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("532cbfd6-6e16-4c68-9dd2-498b240108db"), new DateTime(2024, 12, 6, 17, 53, 46, 752, DateTimeKind.Utc).AddTicks(4933), "A brief description of the product, highlighting its key features and benefits.", "Product 12", 12f, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("543d5c23-d35a-4bf2-aa38-4714e5827ac6"), new DateTime(2024, 12, 6, 17, 56, 1, 752, DateTimeKind.Utc).AddTicks(5240), "A brief description of the product, highlighting its key features and benefits.", "Product 147", 147f, 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54da77da-afd1-4d2f-9d87-94c3d09c2de9"), new DateTime(2024, 12, 6, 17, 56, 55, 752, DateTimeKind.Utc).AddTicks(5377), "A brief description of the product, highlighting its key features and benefits.", "Product 201", 201f, 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55a18b73-655e-4df3-9e82-9534f61f2ed8"), new DateTime(2024, 12, 6, 17, 57, 32, 752, DateTimeKind.Utc).AddTicks(5470), "A brief description of the product, highlighting its key features and benefits.", "Product 238", 238f, 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("570b8a2f-5f63-4973-9ba2-3bac71443c77"), new DateTime(2024, 12, 6, 17, 55, 34, 752, DateTimeKind.Utc).AddTicks(5192), "A brief description of the product, highlighting its key features and benefits.", "Product 120", 120f, 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("577a36f5-d13d-47c5-b486-6478f2b4b31e"), new DateTime(2024, 12, 6, 17, 54, 46, 752, DateTimeKind.Utc).AddTicks(5065), "A brief description of the product, highlighting its key features and benefits.", "Product 72", 72f, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5868c57a-98c3-4389-b146-837c5e36a645"), new DateTime(2024, 12, 6, 17, 54, 0, 752, DateTimeKind.Utc).AddTicks(4960), "A brief description of the product, highlighting its key features and benefits.", "Product 26", 26f, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5aa6f29a-4ffb-4bbe-bb10-c2a3d5f967f7"), new DateTime(2024, 12, 6, 17, 55, 31, 752, DateTimeKind.Utc).AddTicks(5185), "A brief description of the product, highlighting its key features and benefits.", "Product 117", 117f, 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5baf9e84-8eae-444a-82b7-44e8639c7fcb"), new DateTime(2024, 12, 6, 17, 53, 42, 752, DateTimeKind.Utc).AddTicks(4925), "A brief description of the product, highlighting its key features and benefits.", "Product 8", 8f, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d9060cb-3b4a-4812-91e8-f6d2b920ad79"), new DateTime(2024, 12, 6, 17, 56, 21, 752, DateTimeKind.Utc).AddTicks(5315), "A brief description of the product, highlighting its key features and benefits.", "Product 167", 167f, 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5dfe6665-55cc-40e5-ab33-2f129d8a0ced"), new DateTime(2024, 12, 6, 17, 56, 23, 752, DateTimeKind.Utc).AddTicks(5318), "A brief description of the product, highlighting its key features and benefits.", "Product 169", 169f, 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ec6294a-ae3b-403c-a702-bd490d52ee2b"), new DateTime(2024, 12, 6, 17, 53, 49, 752, DateTimeKind.Utc).AddTicks(4940), "A brief description of the product, highlighting its key features and benefits.", "Product 15", 15f, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ee30341-449d-493d-a492-27417769e6d8"), new DateTime(2024, 12, 6, 17, 56, 28, 752, DateTimeKind.Utc).AddTicks(5328), "A brief description of the product, highlighting its key features and benefits.", "Product 174", 174f, 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f2223ff-09a8-4acb-b86b-613ca235062c"), new DateTime(2024, 12, 6, 17, 57, 16, 752, DateTimeKind.Utc).AddTicks(5440), "A brief description of the product, highlighting its key features and benefits.", "Product 222", 222f, 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5fc91278-0c83-4f85-b18b-d1c336d3e85b"), new DateTime(2024, 12, 6, 17, 54, 54, 752, DateTimeKind.Utc).AddTicks(5080), "A brief description of the product, highlighting its key features and benefits.", "Product 80", 80f, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("624e9de3-f5c0-45ac-94e6-5dd52081d5ea"), new DateTime(2024, 12, 6, 17, 55, 51, 752, DateTimeKind.Utc).AddTicks(5222), "A brief description of the product, highlighting its key features and benefits.", "Product 137", 137f, 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("62f165d5-e7d0-4798-ac9c-24f45d0d6f20"), new DateTime(2024, 12, 6, 17, 55, 30, 752, DateTimeKind.Utc).AddTicks(5184), "A brief description of the product, highlighting its key features and benefits.", "Product 116", 116f, 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63cf1a0e-dde2-49a4-b0f3-d19d7ef8f2e9"), new DateTime(2024, 12, 6, 17, 53, 48, 752, DateTimeKind.Utc).AddTicks(4938), "A brief description of the product, highlighting its key features and benefits.", "Product 14", 14f, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("646f8e72-f9a9-4dfb-a0c7-4778ede1f425"), new DateTime(2024, 12, 6, 17, 57, 53, 752, DateTimeKind.Utc).AddTicks(5507), "A brief description of the product, highlighting its key features and benefits.", "Product 259", 259f, 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67d21efb-b4f8-4192-b55a-cff070f0a095"), new DateTime(2024, 12, 6, 17, 54, 6, 752, DateTimeKind.Utc).AddTicks(4971), "A brief description of the product, highlighting its key features and benefits.", "Product 32", 32f, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("688340f0-3a44-490a-b60b-e94be4cd3b62"), new DateTime(2024, 12, 6, 17, 57, 27, 752, DateTimeKind.Utc).AddTicks(5460), "A brief description of the product, highlighting its key features and benefits.", "Product 233", 233f, 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a52a9a3-247c-4daa-acec-56cca62e8e97"), new DateTime(2024, 12, 6, 17, 55, 55, 752, DateTimeKind.Utc).AddTicks(5229), "A brief description of the product, highlighting its key features and benefits.", "Product 141", 141f, 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b7658ce-d156-46ff-816e-22793b883446"), new DateTime(2024, 12, 6, 17, 57, 52, 752, DateTimeKind.Utc).AddTicks(5506), "A brief description of the product, highlighting its key features and benefits.", "Product 258", 258f, 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6bbdbec6-1d60-4cf1-b850-806dbb3776f7"), new DateTime(2024, 12, 6, 17, 53, 35, 752, DateTimeKind.Utc).AddTicks(4898), "A brief description of the product, highlighting its key features and benefits.", "Product 1", 1f, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c1a85e5-e6f9-4aa2-8b06-3eb6f1b8d466"), new DateTime(2024, 12, 6, 17, 54, 13, 752, DateTimeKind.Utc).AddTicks(4986), "A brief description of the product, highlighting its key features and benefits.", "Product 39", 39f, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6dbd953d-3576-4567-8b60-732189630b0b"), new DateTime(2024, 12, 6, 17, 54, 28, 752, DateTimeKind.Utc).AddTicks(5033), "A brief description of the product, highlighting its key features and benefits.", "Product 54", 54f, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6edf211a-8f99-4727-aa89-b6e9724a65b1"), new DateTime(2024, 12, 6, 17, 54, 45, 752, DateTimeKind.Utc).AddTicks(5064), "A brief description of the product, highlighting its key features and benefits.", "Product 71", 71f, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f589cbc-e376-4866-9be6-b191fb88ad2a"), new DateTime(2024, 12, 6, 17, 57, 25, 752, DateTimeKind.Utc).AddTicks(5457), "A brief description of the product, highlighting its key features and benefits.", "Product 231", 231f, 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("701350aa-41e5-4593-956c-2df3606c0e1d"), new DateTime(2024, 12, 6, 17, 57, 39, 752, DateTimeKind.Utc).AddTicks(5481), "A brief description of the product, highlighting its key features and benefits.", "Product 245", 245f, 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70ce954c-0c3e-4967-958c-abecbefffc94"), new DateTime(2024, 12, 6, 17, 55, 32, 752, DateTimeKind.Utc).AddTicks(5188), "A brief description of the product, highlighting its key features and benefits.", "Product 118", 118f, 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("710f12ec-5d45-49ef-8f96-520a44ac28f9"), new DateTime(2024, 12, 6, 17, 57, 35, 752, DateTimeKind.Utc).AddTicks(5475), "A brief description of the product, highlighting its key features and benefits.", "Product 241", 241f, 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("717e8d9e-9251-4729-928b-62d952466bcd"), new DateTime(2024, 12, 6, 17, 57, 6, 752, DateTimeKind.Utc).AddTicks(5421), "A brief description of the product, highlighting its key features and benefits.", "Product 212", 212f, 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("729f00e5-06dc-450a-a23b-6624efbfe7b6"), new DateTime(2024, 12, 6, 17, 53, 40, 752, DateTimeKind.Utc).AddTicks(4921), "A brief description of the product, highlighting its key features and benefits.", "Product 6", 6f, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73f47cf8-7c6b-47f2-b15c-de3f5cb02bc5"), new DateTime(2024, 12, 6, 17, 54, 51, 752, DateTimeKind.Utc).AddTicks(5073), "A brief description of the product, highlighting its key features and benefits.", "Product 77", 77f, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76d7b96a-5275-46cb-a07f-3c796a3abc1e"), new DateTime(2024, 12, 6, 17, 57, 23, 752, DateTimeKind.Utc).AddTicks(5452), "A brief description of the product, highlighting its key features and benefits.", "Product 229", 229f, 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ac8fe37-ef65-4fea-b676-ff799a33d161"), new DateTime(2024, 12, 6, 17, 53, 54, 752, DateTimeKind.Utc).AddTicks(4948), "A brief description of the product, highlighting its key features and benefits.", "Product 20", 20f, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b763f0a-7322-47d6-b1e3-e79ce973333c"), new DateTime(2024, 12, 6, 17, 57, 20, 752, DateTimeKind.Utc).AddTicks(5447), "A brief description of the product, highlighting its key features and benefits.", "Product 226", 226f, 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bac55e2-8cad-4c18-84a9-c2c7cb3b1f4c"), new DateTime(2024, 12, 6, 17, 54, 52, 752, DateTimeKind.Utc).AddTicks(5076), "A brief description of the product, highlighting its key features and benefits.", "Product 78", 78f, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("805b4cb8-28c6-4b30-a156-11590b3c492d"), new DateTime(2024, 12, 6, 17, 56, 33, 752, DateTimeKind.Utc).AddTicks(5336), "A brief description of the product, highlighting its key features and benefits.", "Product 179", 179f, 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80859da7-a841-4705-bce2-e18c87e2d904"), new DateTime(2024, 12, 6, 17, 56, 6, 752, DateTimeKind.Utc).AddTicks(5250), "A brief description of the product, highlighting its key features and benefits.", "Product 152", 152f, 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80fa7627-917d-4a18-b28d-adcee85d7e36"), new DateTime(2024, 12, 6, 17, 54, 39, 752, DateTimeKind.Utc).AddTicks(5052), "A brief description of the product, highlighting its key features and benefits.", "Product 65", 65f, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83d27ef1-4604-45ae-b2e4-8f619eb73c94"), new DateTime(2024, 12, 6, 17, 55, 26, 752, DateTimeKind.Utc).AddTicks(5177), "A brief description of the product, highlighting its key features and benefits.", "Product 112", 112f, 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("841187f0-121d-476a-a5da-4d3c192e9c66"), new DateTime(2024, 12, 6, 17, 56, 46, 752, DateTimeKind.Utc).AddTicks(5360), "A brief description of the product, highlighting its key features and benefits.", "Product 192", 192f, 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8433c95f-9867-4a35-895b-fe93abaef848"), new DateTime(2024, 12, 6, 17, 54, 42, 752, DateTimeKind.Utc).AddTicks(5057), "A brief description of the product, highlighting its key features and benefits.", "Product 68", 68f, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("84348cfd-931d-420b-a5aa-e95499a1836e"), new DateTime(2024, 12, 6, 17, 58, 26, 752, DateTimeKind.Utc).AddTicks(5592), "A brief description of the product, highlighting its key features and benefits.", "Product 292", 292f, 292, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85f42138-6589-43ee-9dba-d7d0539fc864"), new DateTime(2024, 12, 6, 17, 55, 48, 752, DateTimeKind.Utc).AddTicks(5217), "A brief description of the product, highlighting its key features and benefits.", "Product 134", 134f, 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8674657d-cc9d-4ecd-8563-37f5d99f2749"), new DateTime(2024, 12, 6, 17, 56, 40, 752, DateTimeKind.Utc).AddTicks(5349), "A brief description of the product, highlighting its key features and benefits.", "Product 186", 186f, 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("873e7043-fe49-45a1-83ed-5a5299e52024"), new DateTime(2024, 12, 6, 17, 58, 34, 752, DateTimeKind.Utc).AddTicks(5607), "A brief description of the product, highlighting its key features and benefits.", "Product 300", 300f, 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("882ec2e1-ca61-4afc-8eee-077a5009769b"), new DateTime(2024, 12, 6, 17, 55, 56, 752, DateTimeKind.Utc).AddTicks(5232), "A brief description of the product, highlighting its key features and benefits.", "Product 142", 142f, 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89c4472d-1504-4710-aced-7d1e88baa287"), new DateTime(2024, 12, 6, 17, 54, 37, 752, DateTimeKind.Utc).AddTicks(5049), "A brief description of the product, highlighting its key features and benefits.", "Product 63", 63f, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89f240b7-3ca8-4a62-b408-21ff779a1fa7"), new DateTime(2024, 12, 6, 17, 56, 36, 752, DateTimeKind.Utc).AddTicks(5343), "A brief description of the product, highlighting its key features and benefits.", "Product 182", 182f, 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b942ea2-b1df-447e-96d6-beb1e465d1b3"), new DateTime(2024, 12, 6, 17, 58, 5, 752, DateTimeKind.Utc).AddTicks(5555), "A brief description of the product, highlighting its key features and benefits.", "Product 271", 271f, 271, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8cb011c4-25c5-4da4-8930-f871ba24d246"), new DateTime(2024, 12, 6, 17, 57, 55, 752, DateTimeKind.Utc).AddTicks(5510), "A brief description of the product, highlighting its key features and benefits.", "Product 261", 261f, 261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d0341e7-548a-46d6-882e-fab6b22f3bd0"), new DateTime(2024, 12, 6, 17, 57, 36, 752, DateTimeKind.Utc).AddTicks(5476), "A brief description of the product, highlighting its key features and benefits.", "Product 242", 242f, 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ea608a4-2ac9-4c35-befc-411ff73e613b"), new DateTime(2024, 12, 6, 17, 56, 2, 752, DateTimeKind.Utc).AddTicks(5242), "A brief description of the product, highlighting its key features and benefits.", "Product 148", 148f, 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ed1bfca-73b1-4f18-9113-4cc9abb8a4db"), new DateTime(2024, 12, 6, 17, 56, 15, 752, DateTimeKind.Utc).AddTicks(5304), "A brief description of the product, highlighting its key features and benefits.", "Product 161", 161f, 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f33c317-252b-4c6f-a379-ac3f2103f040"), new DateTime(2024, 12, 6, 17, 56, 52, 752, DateTimeKind.Utc).AddTicks(5372), "A brief description of the product, highlighting its key features and benefits.", "Product 198", 198f, 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8fac44ac-3332-4c63-859d-dbe4d2db5be5"), new DateTime(2024, 12, 6, 17, 56, 5, 752, DateTimeKind.Utc).AddTicks(5248), "A brief description of the product, highlighting its key features and benefits.", "Product 151", 151f, 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("90134f69-f7bf-4edb-9040-3cff9de3bec1"), new DateTime(2024, 12, 6, 17, 56, 59, 752, DateTimeKind.Utc).AddTicks(5383), "A brief description of the product, highlighting its key features and benefits.", "Product 205", 205f, 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("908ebe81-aae6-4647-a304-9ee302dcc9d2"), new DateTime(2024, 12, 6, 17, 57, 30, 752, DateTimeKind.Utc).AddTicks(5465), "A brief description of the product, highlighting its key features and benefits.", "Product 236", 236f, 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91453e70-342f-4a2f-a958-4fecb2a88a6d"), new DateTime(2024, 12, 6, 17, 58, 23, 752, DateTimeKind.Utc).AddTicks(5587), "A brief description of the product, highlighting its key features and benefits.", "Product 289", 289f, 289, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91baf564-14f7-4c69-891f-96b2b76c3a84"), new DateTime(2024, 12, 6, 17, 56, 27, 752, DateTimeKind.Utc).AddTicks(5325), "A brief description of the product, highlighting its key features and benefits.", "Product 173", 173f, 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91f5f699-fb2b-49ad-b995-a19d5f117461"), new DateTime(2024, 12, 6, 17, 58, 3, 752, DateTimeKind.Utc).AddTicks(5550), "A brief description of the product, highlighting its key features and benefits.", "Product 269", 269f, 269, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("92011647-09bc-4909-9a57-021012384e60"), new DateTime(2024, 12, 6, 17, 58, 2, 752, DateTimeKind.Utc).AddTicks(5548), "A brief description of the product, highlighting its key features and benefits.", "Product 268", 268f, 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9227c1bc-b2ae-4fc9-8148-8f875b59b274"), new DateTime(2024, 12, 6, 17, 54, 21, 752, DateTimeKind.Utc).AddTicks(5020), "A brief description of the product, highlighting its key features and benefits.", "Product 47", 47f, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("92f14550-d4cd-4e54-92e7-52265765901a"), new DateTime(2024, 12, 6, 17, 58, 8, 752, DateTimeKind.Utc).AddTicks(5559), "A brief description of the product, highlighting its key features and benefits.", "Product 274", 274f, 274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94dfe24e-ac36-4009-aa1e-a8f2a599d520"), new DateTime(2024, 12, 6, 17, 55, 14, 752, DateTimeKind.Utc).AddTicks(5154), "A brief description of the product, highlighting its key features and benefits.", "Product 100", 100f, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("953a91d3-327e-4e9c-98d6-6bd894c16f42"), new DateTime(2024, 12, 6, 17, 54, 1, 752, DateTimeKind.Utc).AddTicks(4961), "A brief description of the product, highlighting its key features and benefits.", "Product 27", 27f, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9551f69f-f453-401e-addd-5854ea506878"), new DateTime(2024, 12, 6, 17, 57, 44, 752, DateTimeKind.Utc).AddTicks(5491), "A brief description of the product, highlighting its key features and benefits.", "Product 250", 250f, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("959a4772-c63d-4237-ad2e-e24ea55b7f25"), new DateTime(2024, 12, 6, 17, 56, 57, 752, DateTimeKind.Utc).AddTicks(5380), "A brief description of the product, highlighting its key features and benefits.", "Product 203", 203f, 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("974ab1b3-95aa-48eb-85c0-3deb6c5ffefc"), new DateTime(2024, 12, 6, 17, 54, 44, 752, DateTimeKind.Utc).AddTicks(5062), "A brief description of the product, highlighting its key features and benefits.", "Product 70", 70f, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("980b6eb0-8c6c-436e-aae5-a213609f9f0c"), new DateTime(2024, 12, 6, 17, 55, 40, 752, DateTimeKind.Utc).AddTicks(5203), "A brief description of the product, highlighting its key features and benefits.", "Product 126", 126f, 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a386205-f4e9-4bdf-baca-39791e40d90e"), new DateTime(2024, 12, 6, 17, 58, 31, 752, DateTimeKind.Utc).AddTicks(5602), "A brief description of the product, highlighting its key features and benefits.", "Product 297", 297f, 297, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a8c08da-5d11-4217-9b7a-3c7a3bfee12c"), new DateTime(2024, 12, 6, 17, 56, 43, 752, DateTimeKind.Utc).AddTicks(5354), "A brief description of the product, highlighting its key features and benefits.", "Product 189", 189f, 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b623d96-c9ea-4286-9471-7159f4e61f12"), new DateTime(2024, 12, 6, 17, 56, 42, 752, DateTimeKind.Utc).AddTicks(5352), "A brief description of the product, highlighting its key features and benefits.", "Product 188", 188f, 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9bfd5284-2973-4be3-aff5-472c1fda0164"), new DateTime(2024, 12, 6, 17, 58, 10, 752, DateTimeKind.Utc).AddTicks(5563), "A brief description of the product, highlighting its key features and benefits.", "Product 276", 276f, 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c1d1a6a-13fa-459b-b743-5681d1fa1498"), new DateTime(2024, 12, 6, 17, 54, 47, 752, DateTimeKind.Utc).AddTicks(5067), "A brief description of the product, highlighting its key features and benefits.", "Product 73", 73f, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c8a48fd-c769-4969-8c31-3d56461de9c1"), new DateTime(2024, 12, 6, 17, 54, 58, 752, DateTimeKind.Utc).AddTicks(5086), "A brief description of the product, highlighting its key features and benefits.", "Product 84", 84f, 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9db2a465-b4b0-462c-9fab-8d7c4a976021"), new DateTime(2024, 12, 6, 17, 56, 41, 752, DateTimeKind.Utc).AddTicks(5351), "A brief description of the product, highlighting its key features and benefits.", "Product 187", 187f, 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ee373a9-b778-409f-8087-56cb426e833c"), new DateTime(2024, 12, 6, 17, 54, 14, 752, DateTimeKind.Utc).AddTicks(4987), "A brief description of the product, highlighting its key features and benefits.", "Product 40", 40f, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a0e76eb2-fd7d-46d5-987b-6cba4f0dcc01"), new DateTime(2024, 12, 6, 17, 57, 11, 752, DateTimeKind.Utc).AddTicks(5431), "A brief description of the product, highlighting its key features and benefits.", "Product 217", 217f, 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a17de991-a6dd-48ca-9f34-856da8072853"), new DateTime(2024, 12, 6, 17, 55, 11, 752, DateTimeKind.Utc).AddTicks(5110), "A brief description of the product, highlighting its key features and benefits.", "Product 97", 97f, 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1977831-7ce6-43d0-96f3-6242b95e6e1b"), new DateTime(2024, 12, 6, 17, 55, 59, 752, DateTimeKind.Utc).AddTicks(5237), "A brief description of the product, highlighting its key features and benefits.", "Product 145", 145f, 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a26378bb-5a70-4c2c-b792-cc292363e8f2"), new DateTime(2024, 12, 6, 17, 58, 14, 752, DateTimeKind.Utc).AddTicks(5571), "A brief description of the product, highlighting its key features and benefits.", "Product 280", 280f, 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a309c8fa-b85c-46cf-a1c6-4c4f66f70386"), new DateTime(2024, 12, 6, 17, 56, 0, 752, DateTimeKind.Utc).AddTicks(5239), "A brief description of the product, highlighting its key features and benefits.", "Product 146", 146f, 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a32ea384-65c8-437e-9b17-dfaa80652dc8"), new DateTime(2024, 12, 6, 17, 55, 3, 752, DateTimeKind.Utc).AddTicks(5096), "A brief description of the product, highlighting its key features and benefits.", "Product 89", 89f, 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a35553b2-3029-467d-ab5d-32865d8cd632"), new DateTime(2024, 12, 6, 17, 55, 41, 752, DateTimeKind.Utc).AddTicks(5205), "A brief description of the product, highlighting its key features and benefits.", "Product 127", 127f, 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3717177-6207-4649-9c58-f37eec732c1a"), new DateTime(2024, 12, 6, 17, 57, 50, 752, DateTimeKind.Utc).AddTicks(5502), "A brief description of the product, highlighting its key features and benefits.", "Product 256", 256f, 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a41db110-25e7-4491-bc3f-15e01f496c10"), new DateTime(2024, 12, 6, 17, 58, 17, 752, DateTimeKind.Utc).AddTicks(5576), "A brief description of the product, highlighting its key features and benefits.", "Product 283", 283f, 283, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a535fe3e-db48-4f43-baed-70b4a703f625"), new DateTime(2024, 12, 6, 17, 55, 57, 752, DateTimeKind.Utc).AddTicks(5234), "A brief description of the product, highlighting its key features and benefits.", "Product 143", 143f, 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5cd3766-679d-4fc3-babc-a629b2120da8"), new DateTime(2024, 12, 6, 17, 55, 27, 752, DateTimeKind.Utc).AddTicks(5179), "A brief description of the product, highlighting its key features and benefits.", "Product 113", 113f, 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6c18730-f231-4f9c-864b-60a650a1b835"), new DateTime(2024, 12, 6, 17, 55, 49, 752, DateTimeKind.Utc).AddTicks(5219), "A brief description of the product, highlighting its key features and benefits.", "Product 135", 135f, 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8233abe-3dc4-4775-9198-8ca55e8095f6"), new DateTime(2024, 12, 6, 17, 53, 45, 752, DateTimeKind.Utc).AddTicks(4931), "A brief description of the product, highlighting its key features and benefits.", "Product 11", 11f, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8c1ca59-9aa0-48e3-8cb6-6d0ad9ed75b1"), new DateTime(2024, 12, 6, 17, 55, 8, 752, DateTimeKind.Utc).AddTicks(5105), "A brief description of the product, highlighting its key features and benefits.", "Product 94", 94f, 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9785e4b-1c1c-45f1-beb8-4b70e8a76c09"), new DateTime(2024, 12, 6, 17, 58, 22, 752, DateTimeKind.Utc).AddTicks(5585), "A brief description of the product, highlighting its key features and benefits.", "Product 288", 288f, 288, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a97cce92-b2b8-45be-a0e1-ab11918ddf58"), new DateTime(2024, 12, 6, 17, 55, 20, 752, DateTimeKind.Utc).AddTicks(5166), "A brief description of the product, highlighting its key features and benefits.", "Product 106", 106f, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a993202e-2890-4b5a-bd59-86be39bd9aea"), new DateTime(2024, 12, 6, 17, 54, 20, 752, DateTimeKind.Utc).AddTicks(5018), "A brief description of the product, highlighting its key features and benefits.", "Product 46", 46f, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa490b6b-8ba8-4818-89b8-1bef3177ef01"), new DateTime(2024, 12, 6, 17, 56, 32, 752, DateTimeKind.Utc).AddTicks(5335), "A brief description of the product, highlighting its key features and benefits.", "Product 178", 178f, 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aaafbc39-a343-4bd2-a18b-d7a09cb899b8"), new DateTime(2024, 12, 6, 17, 55, 24, 752, DateTimeKind.Utc).AddTicks(5174), "A brief description of the product, highlighting its key features and benefits.", "Product 110", 110f, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab2ae9f6-f9f9-446a-b0a5-f7c7332f8a39"), new DateTime(2024, 12, 6, 17, 57, 9, 752, DateTimeKind.Utc).AddTicks(5428), "A brief description of the product, highlighting its key features and benefits.", "Product 215", 215f, 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab8f6832-9d58-4154-b8d5-5365c460ca07"), new DateTime(2024, 12, 6, 17, 55, 44, 752, DateTimeKind.Utc).AddTicks(5209), "A brief description of the product, highlighting its key features and benefits.", "Product 130", 130f, 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad5b6a3f-7488-4896-9bff-1e25f294e8b3"), new DateTime(2024, 12, 6, 17, 54, 49, 752, DateTimeKind.Utc).AddTicks(5070), "A brief description of the product, highlighting its key features and benefits.", "Product 75", 75f, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae462d60-ac36-402e-b4bb-61e346d8af99"), new DateTime(2024, 12, 6, 17, 53, 47, 752, DateTimeKind.Utc).AddTicks(4934), "A brief description of the product, highlighting its key features and benefits.", "Product 13", 13f, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b05e348b-f109-4d1f-8dba-4b897a753079"), new DateTime(2024, 12, 6, 17, 55, 54, 752, DateTimeKind.Utc).AddTicks(5227), "A brief description of the product, highlighting its key features and benefits.", "Product 140", 140f, 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2fc5313-82d3-4152-9d9c-32fe1c7415e0"), new DateTime(2024, 12, 6, 17, 58, 25, 752, DateTimeKind.Utc).AddTicks(5590), "A brief description of the product, highlighting its key features and benefits.", "Product 291", 291f, 291, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b54086de-1377-428a-b38d-32f4c2d41c71"), new DateTime(2024, 12, 6, 17, 58, 15, 752, DateTimeKind.Utc).AddTicks(5572), "A brief description of the product, highlighting its key features and benefits.", "Product 281", 281f, 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b55f1825-77a6-41af-a686-a889824120db"), new DateTime(2024, 12, 6, 17, 53, 37, 752, DateTimeKind.Utc).AddTicks(4904), "A brief description of the product, highlighting its key features and benefits.", "Product 3", 3f, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b684d432-eae0-4c2b-8f9c-a43031b4fd02"), new DateTime(2024, 12, 6, 17, 57, 7, 752, DateTimeKind.Utc).AddTicks(5423), "A brief description of the product, highlighting its key features and benefits.", "Product 213", 213f, 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b76bd2ea-8d1b-4116-9dcf-db373ee843e2"), new DateTime(2024, 12, 6, 17, 55, 35, 752, DateTimeKind.Utc).AddTicks(5193), "A brief description of the product, highlighting its key features and benefits.", "Product 121", 121f, 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7a07a9b-ea0c-4980-be27-b1b6187e44fa"), new DateTime(2024, 12, 6, 17, 58, 19, 752, DateTimeKind.Utc).AddTicks(5579), "A brief description of the product, highlighting its key features and benefits.", "Product 285", 285f, 285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ba4bc2e2-7aae-45b1-8766-51b42db9ef52"), new DateTime(2024, 12, 6, 17, 54, 4, 752, DateTimeKind.Utc).AddTicks(4968), "A brief description of the product, highlighting its key features and benefits.", "Product 30", 30f, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bac64ce2-77aa-405c-bfaf-4553365b27eb"), new DateTime(2024, 12, 6, 17, 54, 36, 752, DateTimeKind.Utc).AddTicks(5048), "A brief description of the product, highlighting its key features and benefits.", "Product 62", 62f, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb68c06f-46e6-4677-b8f1-3dfed7bf15e4"), new DateTime(2024, 12, 6, 17, 57, 0, 752, DateTimeKind.Utc).AddTicks(5386), "A brief description of the product, highlighting its key features and benefits.", "Product 206", 206f, 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc19de89-c066-4271-b71b-0cf13e0dfc10"), new DateTime(2024, 12, 6, 17, 56, 47, 752, DateTimeKind.Utc).AddTicks(5362), "A brief description of the product, highlighting its key features and benefits.", "Product 193", 193f, 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc1fa9cf-7f76-4a20-b859-24cda385a581"), new DateTime(2024, 12, 6, 17, 54, 29, 752, DateTimeKind.Utc).AddTicks(5035), "A brief description of the product, highlighting its key features and benefits.", "Product 55", 55f, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bcbd0d30-7bd3-4763-9846-3cf277948c5d"), new DateTime(2024, 12, 6, 17, 55, 17, 752, DateTimeKind.Utc).AddTicks(5161), "A brief description of the product, highlighting its key features and benefits.", "Product 103", 103f, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bdf55eeb-55c8-4e60-bbc4-e3e2b0903532"), new DateTime(2024, 12, 6, 17, 53, 36, 752, DateTimeKind.Utc).AddTicks(4903), "A brief description of the product, highlighting its key features and benefits.", "Product 2", 2f, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be2f7995-9bab-4ef9-8099-6bf0159132af"), new DateTime(2024, 12, 6, 17, 55, 16, 752, DateTimeKind.Utc).AddTicks(5159), "A brief description of the product, highlighting its key features and benefits.", "Product 102", 102f, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be354a46-deef-4f4c-8e94-3661f57e1216"), new DateTime(2024, 12, 6, 17, 54, 35, 752, DateTimeKind.Utc).AddTicks(5044), "A brief description of the product, highlighting its key features and benefits.", "Product 61", 61f, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bea020c4-a79d-4225-9406-767ec0bb2b9d"), new DateTime(2024, 12, 6, 17, 55, 0, 752, DateTimeKind.Utc).AddTicks(5091), "A brief description of the product, highlighting its key features and benefits.", "Product 86", 86f, 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf341310-d153-45f5-93ee-3e5968380ca2"), new DateTime(2024, 12, 6, 17, 56, 4, 752, DateTimeKind.Utc).AddTicks(5247), "A brief description of the product, highlighting its key features and benefits.", "Product 150", 150f, 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf5ac678-8761-4a22-a055-b154fe8f633d"), new DateTime(2024, 12, 6, 17, 56, 39, 752, DateTimeKind.Utc).AddTicks(5347), "A brief description of the product, highlighting its key features and benefits.", "Product 185", 185f, 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c0dedec1-e249-475c-a4c9-bafbd5a79451"), new DateTime(2024, 12, 6, 17, 55, 22, 752, DateTimeKind.Utc).AddTicks(5169), "A brief description of the product, highlighting its key features and benefits.", "Product 108", 108f, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1112a75-761f-4fcd-95bf-733b4d1c26b0"), new DateTime(2024, 12, 6, 17, 57, 26, 752, DateTimeKind.Utc).AddTicks(5458), "A brief description of the product, highlighting its key features and benefits.", "Product 232", 232f, 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c36f36a5-4254-4436-bf0d-e49417a42c96"), new DateTime(2024, 12, 6, 17, 58, 30, 752, DateTimeKind.Utc).AddTicks(5601), "A brief description of the product, highlighting its key features and benefits.", "Product 296", 296f, 296, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c3ef2731-4c2b-4a01-926f-8f515168c361"), new DateTime(2024, 12, 6, 17, 56, 37, 752, DateTimeKind.Utc).AddTicks(5344), "A brief description of the product, highlighting its key features and benefits.", "Product 183", 183f, 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c3f1726b-3880-4dba-b633-c0c6ca83b304"), new DateTime(2024, 12, 6, 17, 53, 58, 752, DateTimeKind.Utc).AddTicks(4956), "A brief description of the product, highlighting its key features and benefits.", "Product 24", 24f, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c493d7c6-1224-4c22-bfbb-7680f78240cf"), new DateTime(2024, 12, 6, 17, 56, 50, 752, DateTimeKind.Utc).AddTicks(5367), "A brief description of the product, highlighting its key features and benefits.", "Product 196", 196f, 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4d936cd-f24b-4381-8c42-0142681e501d"), new DateTime(2024, 12, 6, 17, 57, 8, 752, DateTimeKind.Utc).AddTicks(5426), "A brief description of the product, highlighting its key features and benefits.", "Product 214", 214f, 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4fa2e5d-cdb7-4992-9c7e-cb46ebabdf6e"), new DateTime(2024, 12, 6, 17, 55, 58, 752, DateTimeKind.Utc).AddTicks(5235), "A brief description of the product, highlighting its key features and benefits.", "Product 144", 144f, 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c60d8b38-5077-43e1-9819-8494326f7dc9"), new DateTime(2024, 12, 6, 17, 57, 57, 752, DateTimeKind.Utc).AddTicks(5515), "A brief description of the product, highlighting its key features and benefits.", "Product 263", 263f, 263, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c831266f-6d60-4a95-b6d7-108d93ad3ed2"), new DateTime(2024, 12, 6, 17, 56, 12, 752, DateTimeKind.Utc).AddTicks(5299), "A brief description of the product, highlighting its key features and benefits.", "Product 158", 158f, 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9bb65c0-d708-4e28-8be4-4105fc55ac02"), new DateTime(2024, 12, 6, 17, 57, 31, 752, DateTimeKind.Utc).AddTicks(5467), "A brief description of the product, highlighting its key features and benefits.", "Product 237", 237f, 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca6d2257-f755-4dcb-b3c9-93b111c649f3"), new DateTime(2024, 12, 6, 17, 54, 12, 752, DateTimeKind.Utc).AddTicks(4984), "A brief description of the product, highlighting its key features and benefits.", "Product 38", 38f, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca79f7ba-abde-4cfa-90e8-47ef7286fb44"), new DateTime(2024, 12, 6, 17, 53, 57, 752, DateTimeKind.Utc).AddTicks(4955), "A brief description of the product, highlighting its key features and benefits.", "Product 23", 23f, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cae59d49-1b0f-40d9-911b-6448735fe1ff"), new DateTime(2024, 12, 6, 17, 57, 4, 752, DateTimeKind.Utc).AddTicks(5393), "A brief description of the product, highlighting its key features and benefits.", "Product 210", 210f, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc2712d9-99fe-44e0-bc89-d9a1d169e200"), new DateTime(2024, 12, 6, 17, 57, 47, 752, DateTimeKind.Utc).AddTicks(5496), "A brief description of the product, highlighting its key features and benefits.", "Product 253", 253f, 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc354f07-2903-47aa-a814-a4050838e2d0"), new DateTime(2024, 12, 6, 17, 57, 48, 752, DateTimeKind.Utc).AddTicks(5499), "A brief description of the product, highlighting its key features and benefits.", "Product 254", 254f, 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd10d78a-6936-49a0-88bf-17c2aa4e615d"), new DateTime(2024, 12, 6, 17, 54, 53, 752, DateTimeKind.Utc).AddTicks(5078), "A brief description of the product, highlighting its key features and benefits.", "Product 79", 79f, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cde127b8-6e1b-4b0f-8592-5c9048422c5e"), new DateTime(2024, 12, 6, 17, 54, 33, 752, DateTimeKind.Utc).AddTicks(5041), "A brief description of the product, highlighting its key features and benefits.", "Product 59", 59f, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d02f7fb8-0c6f-4012-9c4b-38c71fc0db27"), new DateTime(2024, 12, 6, 17, 54, 23, 752, DateTimeKind.Utc).AddTicks(5023), "A brief description of the product, highlighting its key features and benefits.", "Product 49", 49f, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d10c63e4-01b2-44cc-8e85-d43c8bf0b70b"), new DateTime(2024, 12, 6, 17, 57, 3, 752, DateTimeKind.Utc).AddTicks(5391), "A brief description of the product, highlighting its key features and benefits.", "Product 209", 209f, 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d165cb63-095d-42e9-bb5a-d7536e6a2b4e"), new DateTime(2024, 12, 6, 17, 55, 38, 752, DateTimeKind.Utc).AddTicks(5198), "A brief description of the product, highlighting its key features and benefits.", "Product 124", 124f, 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2486869-4964-4a5b-91b9-a9827ab1ea99"), new DateTime(2024, 12, 6, 17, 58, 1, 752, DateTimeKind.Utc).AddTicks(5522), "A brief description of the product, highlighting its key features and benefits.", "Product 267", 267f, 267, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d324b675-e839-40e9-9ef6-08f73375a825"), new DateTime(2024, 12, 6, 17, 58, 4, 752, DateTimeKind.Utc).AddTicks(5553), "A brief description of the product, highlighting its key features and benefits.", "Product 270", 270f, 270, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d36c3c25-3949-46ac-a0ab-7cefb07c4e8b"), new DateTime(2024, 12, 6, 17, 55, 25, 752, DateTimeKind.Utc).AddTicks(5175), "A brief description of the product, highlighting its key features and benefits.", "Product 111", 111f, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d36f8075-9023-4697-aceb-8f3dd7294203"), new DateTime(2024, 12, 6, 17, 56, 49, 752, DateTimeKind.Utc).AddTicks(5365), "A brief description of the product, highlighting its key features and benefits.", "Product 195", 195f, 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4634301-b787-41b8-90f5-199ced7b063c"), new DateTime(2024, 12, 6, 17, 55, 19, 752, DateTimeKind.Utc).AddTicks(5164), "A brief description of the product, highlighting its key features and benefits.", "Product 105", 105f, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5f294bd-ebbe-4d3f-bb3c-e5ac8537a161"), new DateTime(2024, 12, 6, 17, 56, 25, 752, DateTimeKind.Utc).AddTicks(5322), "A brief description of the product, highlighting its key features and benefits.", "Product 171", 171f, 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8e53c25-0b2b-4f24-b266-d80f01af6900"), new DateTime(2024, 12, 6, 17, 56, 35, 752, DateTimeKind.Utc).AddTicks(5339), "A brief description of the product, highlighting its key features and benefits.", "Product 181", 181f, 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9ef26d2-71d4-4590-9818-711a36d3876c"), new DateTime(2024, 12, 6, 17, 56, 44, 752, DateTimeKind.Utc).AddTicks(5357), "A brief description of the product, highlighting its key features and benefits.", "Product 190", 190f, 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da637cf4-3cf6-477c-98f2-b8bf42f86ff3"), new DateTime(2024, 12, 6, 17, 55, 52, 752, DateTimeKind.Utc).AddTicks(5224), "A brief description of the product, highlighting its key features and benefits.", "Product 138", 138f, 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dae70b6d-a458-4bde-916c-5d87048f03d3"), new DateTime(2024, 12, 6, 17, 56, 31, 752, DateTimeKind.Utc).AddTicks(5333), "A brief description of the product, highlighting its key features and benefits.", "Product 177", 177f, 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db526fab-7ed5-40b6-9d18-d749feb651dd"), new DateTime(2024, 12, 6, 17, 58, 16, 752, DateTimeKind.Utc).AddTicks(5574), "A brief description of the product, highlighting its key features and benefits.", "Product 282", 282f, 282, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db635281-69d9-4271-b7ec-d848a2c1f71b"), new DateTime(2024, 12, 6, 17, 57, 42, 752, DateTimeKind.Utc).AddTicks(5488), "A brief description of the product, highlighting its key features and benefits.", "Product 248", 248f, 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db740233-6d3f-4d36-816e-c43125969bff"), new DateTime(2024, 12, 6, 17, 55, 36, 752, DateTimeKind.Utc).AddTicks(5195), "A brief description of the product, highlighting its key features and benefits.", "Product 122", 122f, 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd19c454-6465-48aa-bfc8-b9d18d95acfc"), new DateTime(2024, 12, 6, 17, 55, 39, 752, DateTimeKind.Utc).AddTicks(5200), "A brief description of the product, highlighting its key features and benefits.", "Product 125", 125f, 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de7544ac-b76c-453d-9c1c-0f5768904539"), new DateTime(2024, 12, 6, 17, 55, 28, 752, DateTimeKind.Utc).AddTicks(5180), "A brief description of the product, highlighting its key features and benefits.", "Product 114", 114f, 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dea61a4f-70c6-4c58-8eea-9072d8fc73ea"), new DateTime(2024, 12, 6, 17, 57, 41, 752, DateTimeKind.Utc).AddTicks(5486), "A brief description of the product, highlighting its key features and benefits.", "Product 247", 247f, 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0c5bf15-13de-4a0d-a121-5be0a572503a"), new DateTime(2024, 12, 6, 17, 58, 24, 752, DateTimeKind.Utc).AddTicks(5589), "A brief description of the product, highlighting its key features and benefits.", "Product 290", 290f, 290, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1a65f43-8c74-48b7-8e1d-2215ea4c082b"), new DateTime(2024, 12, 6, 17, 57, 51, 752, DateTimeKind.Utc).AddTicks(5504), "A brief description of the product, highlighting its key features and benefits.", "Product 257", 257f, 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4fafa24-5769-42cc-96ce-0b8597c2e46e"), new DateTime(2024, 12, 6, 17, 55, 37, 752, DateTimeKind.Utc).AddTicks(5196), "A brief description of the product, highlighting its key features and benefits.", "Product 123", 123f, 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5b24113-e31e-4cf4-b874-b6e9496a884c"), new DateTime(2024, 12, 6, 17, 54, 59, 752, DateTimeKind.Utc).AddTicks(5088), "A brief description of the product, highlighting its key features and benefits.", "Product 85", 85f, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e73fad1d-6d54-4ccb-9abb-9b571cd871a5"), new DateTime(2024, 12, 6, 17, 58, 33, 752, DateTimeKind.Utc).AddTicks(5606), "A brief description of the product, highlighting its key features and benefits.", "Product 299", 299f, 299, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e78b3492-890b-40bb-8794-e2617b55c59f"), new DateTime(2024, 12, 6, 17, 54, 15, 752, DateTimeKind.Utc).AddTicks(4989), "A brief description of the product, highlighting its key features and benefits.", "Product 41", 41f, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7fc2c00-9e17-4e91-85f3-b339c2148067"), new DateTime(2024, 12, 6, 17, 56, 51, 752, DateTimeKind.Utc).AddTicks(5368), "A brief description of the product, highlighting its key features and benefits.", "Product 197", 197f, 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e90ba93f-a60b-48bc-accc-8dfe5f94deec"), new DateTime(2024, 12, 6, 17, 55, 5, 752, DateTimeKind.Utc).AddTicks(5099), "A brief description of the product, highlighting its key features and benefits.", "Product 91", 91f, 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ece5ec80-aa7f-4be5-a4df-5c7abfa2ddae"), new DateTime(2024, 12, 6, 17, 54, 18, 752, DateTimeKind.Utc).AddTicks(5013), "A brief description of the product, highlighting its key features and benefits.", "Product 44", 44f, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ecfa5559-a50a-4475-bb76-1b78d1e6014f"), new DateTime(2024, 12, 6, 17, 54, 31, 752, DateTimeKind.Utc).AddTicks(5038), "A brief description of the product, highlighting its key features and benefits.", "Product 57", 57f, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee3c6215-d536-49c3-83cc-8e8ecbc287c5"), new DateTime(2024, 12, 6, 17, 53, 51, 752, DateTimeKind.Utc).AddTicks(4943), "A brief description of the product, highlighting its key features and benefits.", "Product 17", 17f, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef58a141-4a73-4f76-8af7-b1d5d2c98e38"), new DateTime(2024, 12, 6, 17, 56, 8, 752, DateTimeKind.Utc).AddTicks(5253), "A brief description of the product, highlighting its key features and benefits.", "Product 154", 154f, 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef65640d-7523-4750-a15a-c7b218072b41"), new DateTime(2024, 12, 6, 17, 57, 38, 752, DateTimeKind.Utc).AddTicks(5480), "A brief description of the product, highlighting its key features and benefits.", "Product 244", 244f, 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f28874c7-83ae-4466-922e-7dc6804045e3"), new DateTime(2024, 12, 6, 17, 56, 58, 752, DateTimeKind.Utc).AddTicks(5381), "A brief description of the product, highlighting its key features and benefits.", "Product 204", 204f, 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f70fa9df-4650-4727-8f27-7e67abfce02e"), new DateTime(2024, 12, 6, 17, 57, 19, 752, DateTimeKind.Utc).AddTicks(5445), "A brief description of the product, highlighting its key features and benefits.", "Product 225", 225f, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f84830d8-193d-47ec-81de-058305476b0e"), new DateTime(2024, 12, 6, 17, 54, 38, 752, DateTimeKind.Utc).AddTicks(5051), "A brief description of the product, highlighting its key features and benefits.", "Product 64", 64f, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f98cafb8-a16f-4e83-b03c-c812aa91b44f"), new DateTime(2024, 12, 6, 17, 56, 45, 752, DateTimeKind.Utc).AddTicks(5359), "A brief description of the product, highlighting its key features and benefits.", "Product 191", 191f, 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9e0e18f-8d23-4fd5-8c03-677214248148"), new DateTime(2024, 12, 6, 17, 54, 7, 752, DateTimeKind.Utc).AddTicks(4973), "A brief description of the product, highlighting its key features and benefits.", "Product 33", 33f, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fac1b36b-ee2a-4b69-a882-4dd1e11fecb8"), new DateTime(2024, 12, 6, 17, 56, 10, 752, DateTimeKind.Utc).AddTicks(5294), "A brief description of the product, highlighting its key features and benefits.", "Product 156", 156f, 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb3158d1-3ddb-46b0-a18f-80ad9316fe42"), new DateTime(2024, 12, 6, 17, 54, 40, 752, DateTimeKind.Utc).AddTicks(5054), "A brief description of the product, highlighting its key features and benefits.", "Product 66", 66f, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fcd19aef-e312-4be1-9850-db1b109767bd"), new DateTime(2024, 12, 6, 17, 56, 48, 752, DateTimeKind.Utc).AddTicks(5364), "A brief description of the product, highlighting its key features and benefits.", "Product 194", 194f, 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffbf4746-0f20-499d-81e0-5ba9e99fe4ec"), new DateTime(2024, 12, 6, 17, 53, 56, 752, DateTimeKind.Utc).AddTicks(4953), "A brief description of the product, highlighting its key features and benefits.", "Product 22", 22f, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedOrders_OrderId",
                table: "CompletedOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders",
                column: "OrderCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductImageFile_ProductsId",
                table: "ProductProductImageFile",
                column: "ProductsId");
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
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "CompletedOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductProductImageFile");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
