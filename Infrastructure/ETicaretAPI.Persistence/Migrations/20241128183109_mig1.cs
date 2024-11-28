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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("02d7fddb-6374-4641-9195-656b79c7dc62"), new DateTime(2024, 11, 28, 18, 32, 28, 951, DateTimeKind.Utc).AddTicks(6243), "A brief description of the product, highlighting its key features and benefits.", "Product 81", 81f, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("02f988a2-6948-4006-8b80-12382aa1aebf"), new DateTime(2024, 11, 28, 18, 32, 47, 951, DateTimeKind.Utc).AddTicks(6277), "A brief description of the product, highlighting its key features and benefits.", "Product 100", 100f, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("03591216-88b1-4bee-8e6d-89ab0be85852"), new DateTime(2024, 11, 28, 18, 31, 11, 951, DateTimeKind.Utc).AddTicks(6011), "A brief description of the product, highlighting its key features and benefits.", "Product 4", 4f, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("03a2f7be-79ac-44b0-be8b-9ae6af74e9d1"), new DateTime(2024, 11, 28, 18, 32, 5, 951, DateTimeKind.Utc).AddTicks(6177), "A brief description of the product, highlighting its key features and benefits.", "Product 58", 58f, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("049cf196-23a7-41ea-ac75-744d775a4757"), new DateTime(2024, 11, 28, 18, 34, 1, 951, DateTimeKind.Utc).AddTicks(6436), "A brief description of the product, highlighting its key features and benefits.", "Product 174", 174f, 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("04bf9628-99e3-4bfc-b246-469fbdf74a8f"), new DateTime(2024, 11, 28, 18, 35, 46, 951, DateTimeKind.Utc).AddTicks(6673), "A brief description of the product, highlighting its key features and benefits.", "Product 279", 279f, 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0578b0c7-3f00-4bd2-8f70-062609fbe638"), new DateTime(2024, 11, 28, 18, 31, 25, 951, DateTimeKind.Utc).AddTicks(6103), "A brief description of the product, highlighting its key features and benefits.", "Product 18", 18f, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("063581e8-3528-46e8-bd35-91e611d19619"), new DateTime(2024, 11, 28, 18, 31, 26, 951, DateTimeKind.Utc).AddTicks(6104), "A brief description of the product, highlighting its key features and benefits.", "Product 19", 19f, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("07f31acf-60bf-48ab-9fd5-46eb88f5e152"), new DateTime(2024, 11, 28, 18, 31, 41, 951, DateTimeKind.Utc).AddTicks(6132), "A brief description of the product, highlighting its key features and benefits.", "Product 34", 34f, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("082d36ed-60ab-46a5-8289-c10df7c7cee2"), new DateTime(2024, 11, 28, 18, 31, 31, 951, DateTimeKind.Utc).AddTicks(6114), "A brief description of the product, highlighting its key features and benefits.", "Product 24", 24f, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("09128599-64a7-462a-a71a-9730d80b2af5"), new DateTime(2024, 11, 28, 18, 35, 38, 951, DateTimeKind.Utc).AddTicks(6658), "A brief description of the product, highlighting its key features and benefits.", "Product 271", 271f, 271, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0a5b9852-613e-4ed4-a0bf-a2cde078e6ac"), new DateTime(2024, 11, 28, 18, 35, 28, 951, DateTimeKind.Utc).AddTicks(6639), "A brief description of the product, highlighting its key features and benefits.", "Product 261", 261f, 261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c388516-203d-4970-9f7b-b8c0895bc760"), new DateTime(2024, 11, 28, 18, 31, 54, 951, DateTimeKind.Utc).AddTicks(6157), "A brief description of the product, highlighting its key features and benefits.", "Product 47", 47f, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0dbd5bf8-5fa6-4094-8060-099304fe5fe4"), new DateTime(2024, 11, 28, 18, 31, 44, 951, DateTimeKind.Utc).AddTicks(6137), "A brief description of the product, highlighting its key features and benefits.", "Product 37", 37f, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e09928b-6169-45c3-9a97-9f04eb311599"), new DateTime(2024, 11, 28, 18, 34, 18, 951, DateTimeKind.Utc).AddTicks(6489), "A brief description of the product, highlighting its key features and benefits.", "Product 191", 191f, 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0eb1a807-eb52-4291-8e9a-5fd9604b08a5"), new DateTime(2024, 11, 28, 18, 35, 16, 951, DateTimeKind.Utc).AddTicks(6618), "A brief description of the product, highlighting its key features and benefits.", "Product 249", 249f, 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ed86aac-b6b8-411e-8f93-4d9015f05cda"), new DateTime(2024, 11, 28, 18, 33, 12, 951, DateTimeKind.Utc).AddTicks(6345), "A brief description of the product, highlighting its key features and benefits.", "Product 125", 125f, 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10b821b1-c669-42ca-94b3-379c32151a91"), new DateTime(2024, 11, 28, 18, 33, 27, 951, DateTimeKind.Utc).AddTicks(6373), "A brief description of the product, highlighting its key features and benefits.", "Product 140", 140f, 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1400822a-4546-434a-b356-4863eb642fad"), new DateTime(2024, 11, 28, 18, 32, 13, 951, DateTimeKind.Utc).AddTicks(6216), "A brief description of the product, highlighting its key features and benefits.", "Product 66", 66f, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("151b2a0d-370d-4cba-8d26-194a7865ae72"), new DateTime(2024, 11, 28, 18, 35, 6, 951, DateTimeKind.Utc).AddTicks(6600), "A brief description of the product, highlighting its key features and benefits.", "Product 239", 239f, 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("151d898d-38df-4ded-ba54-f4fcf5a409b8"), new DateTime(2024, 11, 28, 18, 32, 1, 951, DateTimeKind.Utc).AddTicks(6170), "A brief description of the product, highlighting its key features and benefits.", "Product 54", 54f, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15c9bc57-adb5-4bd0-a507-743d7723e037"), new DateTime(2024, 11, 28, 18, 34, 54, 951, DateTimeKind.Utc).AddTicks(6554), "A brief description of the product, highlighting its key features and benefits.", "Product 227", 227f, 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("160f3e06-8459-4f8a-a5ea-378062d8eaaf"), new DateTime(2024, 11, 28, 18, 33, 43, 951, DateTimeKind.Utc).AddTicks(6402), "A brief description of the product, highlighting its key features and benefits.", "Product 156", 156f, 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("166eda06-d293-4bfa-8188-e2550502993d"), new DateTime(2024, 11, 28, 18, 31, 28, 951, DateTimeKind.Utc).AddTicks(6107), "A brief description of the product, highlighting its key features and benefits.", "Product 21", 21f, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("179b8b4e-e4ad-4b53-9c8f-2642ee35867f"), new DateTime(2024, 11, 28, 18, 33, 7, 951, DateTimeKind.Utc).AddTicks(6315), "A brief description of the product, highlighting its key features and benefits.", "Product 120", 120f, 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("180223b2-7f0b-42f4-93d1-b09d497d3a0a"), new DateTime(2024, 11, 28, 18, 33, 13, 951, DateTimeKind.Utc).AddTicks(6348), "A brief description of the product, highlighting its key features and benefits.", "Product 126", 126f, 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1c7263f4-fa4f-4e6c-b631-fa8323f9a854"), new DateTime(2024, 11, 28, 18, 32, 26, 951, DateTimeKind.Utc).AddTicks(6240), "A brief description of the product, highlighting its key features and benefits.", "Product 79", 79f, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1cae1fc7-3ef5-4ac5-8955-eb720bf554cf"), new DateTime(2024, 11, 28, 18, 34, 52, 951, DateTimeKind.Utc).AddTicks(6551), "A brief description of the product, highlighting its key features and benefits.", "Product 225", 225f, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e61b46e-d6a4-4919-ad2a-ed7e91e3ed59"), new DateTime(2024, 11, 28, 18, 31, 16, 951, DateTimeKind.Utc).AddTicks(6084), "A brief description of the product, highlighting its key features and benefits.", "Product 9", 9f, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20f81183-099b-449a-bb0a-287d7ab72089"), new DateTime(2024, 11, 28, 18, 33, 21, 951, DateTimeKind.Utc).AddTicks(6363), "A brief description of the product, highlighting its key features and benefits.", "Product 134", 134f, 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("210c1e75-8786-42b1-b801-53cbce479222"), new DateTime(2024, 11, 28, 18, 33, 45, 951, DateTimeKind.Utc).AddTicks(6407), "A brief description of the product, highlighting its key features and benefits.", "Product 158", 158f, 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("214a6465-081c-44b2-9342-ed98bf5f837c"), new DateTime(2024, 11, 28, 18, 35, 27, 951, DateTimeKind.Utc).AddTicks(6637), "A brief description of the product, highlighting its key features and benefits.", "Product 260", 260f, 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21ca9e2d-c857-4b6f-97a9-610122ecd9cf"), new DateTime(2024, 11, 28, 18, 33, 6, 951, DateTimeKind.Utc).AddTicks(6314), "A brief description of the product, highlighting its key features and benefits.", "Product 119", 119f, 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("228f9369-b6f5-4f03-b94e-87b518c0a76b"), new DateTime(2024, 11, 28, 18, 32, 20, 951, DateTimeKind.Utc).AddTicks(6229), "A brief description of the product, highlighting its key features and benefits.", "Product 73", 73f, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("235ce52e-f39d-4d5c-ac35-9759028bc895"), new DateTime(2024, 11, 28, 18, 34, 58, 951, DateTimeKind.Utc).AddTicks(6562), "A brief description of the product, highlighting its key features and benefits.", "Product 231", 231f, 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27e8339d-c8e7-45b0-9e13-47a041e4dec6"), new DateTime(2024, 11, 28, 18, 34, 36, 951, DateTimeKind.Utc).AddTicks(6521), "A brief description of the product, highlighting its key features and benefits.", "Product 209", 209f, 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("288b18d3-6414-466d-9048-190f555d4b90"), new DateTime(2024, 11, 28, 18, 34, 37, 951, DateTimeKind.Utc).AddTicks(6523), "A brief description of the product, highlighting its key features and benefits.", "Product 210", 210f, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a24af81-04c4-47e6-afae-9b965a11d6de"), new DateTime(2024, 11, 28, 18, 33, 18, 951, DateTimeKind.Utc).AddTicks(6357), "A brief description of the product, highlighting its key features and benefits.", "Product 131", 131f, 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2c693cc7-6427-4149-bb08-211fde8194d1"), new DateTime(2024, 11, 28, 18, 34, 25, 951, DateTimeKind.Utc).AddTicks(6502), "A brief description of the product, highlighting its key features and benefits.", "Product 198", 198f, 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d8b130e-c18d-4389-aaf4-877bc2cf677a"), new DateTime(2024, 11, 28, 18, 33, 49, 951, DateTimeKind.Utc).AddTicks(6414), "A brief description of the product, highlighting its key features and benefits.", "Product 162", 162f, 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d97f1bf-32d3-439e-ba58-5b5520660321"), new DateTime(2024, 11, 28, 18, 31, 52, 951, DateTimeKind.Utc).AddTicks(6151), "A brief description of the product, highlighting its key features and benefits.", "Product 45", 45f, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e350826-0658-4483-93d9-e2cf499b8d2d"), new DateTime(2024, 11, 28, 18, 36, 7, 951, DateTimeKind.Utc).AddTicks(6733), "A brief description of the product, highlighting its key features and benefits.", "Product 300", 300f, 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e4e1744-4bd9-4c09-9692-e2f5a001f962"), new DateTime(2024, 11, 28, 18, 32, 37, 951, DateTimeKind.Utc).AddTicks(6260), "A brief description of the product, highlighting its key features and benefits.", "Product 90", 90f, 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f871d95-1420-4484-8518-b53780ceb9b2"), new DateTime(2024, 11, 28, 18, 35, 44, 951, DateTimeKind.Utc).AddTicks(6668), "A brief description of the product, highlighting its key features and benefits.", "Product 277", 277f, 277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ff1919a-3a8b-419b-969c-67b1e1676071"), new DateTime(2024, 11, 28, 18, 31, 46, 951, DateTimeKind.Utc).AddTicks(6142), "A brief description of the product, highlighting its key features and benefits.", "Product 39", 39f, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("302bf217-1069-4fde-bbbd-d3fd7ba2e258"), new DateTime(2024, 11, 28, 18, 33, 17, 951, DateTimeKind.Utc).AddTicks(6355), "A brief description of the product, highlighting its key features and benefits.", "Product 130", 130f, 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3264279d-ce2d-4f8e-8a09-7229bd1d68d1"), new DateTime(2024, 11, 28, 18, 35, 40, 951, DateTimeKind.Utc).AddTicks(6662), "A brief description of the product, highlighting its key features and benefits.", "Product 273", 273f, 273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3391a6f9-3e1e-415d-aba8-0cd9f2d3b6aa"), new DateTime(2024, 11, 28, 18, 34, 27, 951, DateTimeKind.Utc).AddTicks(6505), "A brief description of the product, highlighting its key features and benefits.", "Product 200", 200f, 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33c31f93-4a85-4525-95bd-5f0b4e15d981"), new DateTime(2024, 11, 28, 18, 31, 45, 951, DateTimeKind.Utc).AddTicks(6140), "A brief description of the product, highlighting its key features and benefits.", "Product 38", 38f, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("340d5686-c94b-40c8-bbe1-0f4d0f0992da"), new DateTime(2024, 11, 28, 18, 33, 50, 951, DateTimeKind.Utc).AddTicks(6415), "A brief description of the product, highlighting its key features and benefits.", "Product 163", 163f, 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("341200ca-7e0f-4d95-93f8-c0d8ac17daad"), new DateTime(2024, 11, 28, 18, 33, 56, 951, DateTimeKind.Utc).AddTicks(6427), "A brief description of the product, highlighting its key features and benefits.", "Product 169", 169f, 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34a05e00-17b3-41d9-b6af-7ecb305fab91"), new DateTime(2024, 11, 28, 18, 33, 52, 951, DateTimeKind.Utc).AddTicks(6419), "A brief description of the product, highlighting its key features and benefits.", "Product 165", 165f, 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34dfd410-4070-486b-b178-19bd09b50a94"), new DateTime(2024, 11, 28, 18, 34, 48, 951, DateTimeKind.Utc).AddTicks(6542), "A brief description of the product, highlighting its key features and benefits.", "Product 221", 221f, 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3537ec7f-fa48-45fe-b098-302ae56affd1"), new DateTime(2024, 11, 28, 18, 33, 29, 951, DateTimeKind.Utc).AddTicks(6378), "A brief description of the product, highlighting its key features and benefits.", "Product 142", 142f, 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("37102459-be93-4b6b-ae95-a12f0c148159"), new DateTime(2024, 11, 28, 18, 31, 30, 951, DateTimeKind.Utc).AddTicks(6112), "A brief description of the product, highlighting its key features and benefits.", "Product 23", 23f, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("37f15ffb-4f63-46f3-9ee7-49e0455ebbd9"), new DateTime(2024, 11, 28, 18, 35, 24, 951, DateTimeKind.Utc).AddTicks(6632), "A brief description of the product, highlighting its key features and benefits.", "Product 257", 257f, 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3893956e-4301-4d2b-8577-3b8c9ea86e8f"), new DateTime(2024, 11, 28, 18, 34, 13, 951, DateTimeKind.Utc).AddTicks(6479), "A brief description of the product, highlighting its key features and benefits.", "Product 186", 186f, 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39808bab-003c-4c35-83a8-fd6dcab7005a"), new DateTime(2024, 11, 28, 18, 31, 29, 951, DateTimeKind.Utc).AddTicks(6111), "A brief description of the product, highlighting its key features and benefits.", "Product 22", 22f, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("399362cf-edf0-4ec1-ad4f-854777f339d3"), new DateTime(2024, 11, 28, 18, 35, 55, 951, DateTimeKind.Utc).AddTicks(6689), "A brief description of the product, highlighting its key features and benefits.", "Product 288", 288f, 288, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a7631ef-5dd3-42b4-a5e1-b9cb069f7f90"), new DateTime(2024, 11, 28, 18, 32, 53, 951, DateTimeKind.Utc).AddTicks(6289), "A brief description of the product, highlighting its key features and benefits.", "Product 106", 106f, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cc0caa3-a50a-41ba-ae07-4e3506bcb026"), new DateTime(2024, 11, 28, 18, 34, 15, 951, DateTimeKind.Utc).AddTicks(6482), "A brief description of the product, highlighting its key features and benefits.", "Product 188", 188f, 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e2b4a22-69ed-42de-a80a-c37e7099d4a8"), new DateTime(2024, 11, 28, 18, 31, 12, 951, DateTimeKind.Utc).AddTicks(6013), "A brief description of the product, highlighting its key features and benefits.", "Product 5", 5f, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e5b8e0e-6a29-446b-8f74-7a17c43cab7f"), new DateTime(2024, 11, 28, 18, 35, 50, 951, DateTimeKind.Utc).AddTicks(6679), "A brief description of the product, highlighting its key features and benefits.", "Product 283", 283f, 283, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f6d645d-391b-439a-b806-a0c643c6b41e"), new DateTime(2024, 11, 28, 18, 33, 48, 951, DateTimeKind.Utc).AddTicks(6412), "A brief description of the product, highlighting its key features and benefits.", "Product 161", 161f, 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40424b00-99fb-4e3c-8cab-fe3bc339ee31"), new DateTime(2024, 11, 28, 18, 35, 33, 951, DateTimeKind.Utc).AddTicks(6649), "A brief description of the product, highlighting its key features and benefits.", "Product 266", 266f, 266, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("435b54be-b890-4da6-b355-6197596e6dfd"), new DateTime(2024, 11, 28, 18, 35, 32, 951, DateTimeKind.Utc).AddTicks(6647), "A brief description of the product, highlighting its key features and benefits.", "Product 265", 265f, 265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("444012d3-3667-4e6f-b312-3ea6fe2e42dd"), new DateTime(2024, 11, 28, 18, 33, 24, 951, DateTimeKind.Utc).AddTicks(6368), "A brief description of the product, highlighting its key features and benefits.", "Product 137", 137f, 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("445ca74a-36fc-4e73-a0bd-d655b99e209f"), new DateTime(2024, 11, 28, 18, 33, 14, 951, DateTimeKind.Utc).AddTicks(6350), "A brief description of the product, highlighting its key features and benefits.", "Product 127", 127f, 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44d37459-b53d-4b8d-b6e5-d40cc2fca6d0"), new DateTime(2024, 11, 28, 18, 35, 56, 951, DateTimeKind.Utc).AddTicks(6691), "A brief description of the product, highlighting its key features and benefits.", "Product 289", 289f, 289, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4518500c-19fd-499e-a096-ef43bac9173b"), new DateTime(2024, 11, 28, 18, 33, 5, 951, DateTimeKind.Utc).AddTicks(6312), "A brief description of the product, highlighting its key features and benefits.", "Product 118", 118f, 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45a6ae71-31ad-47bc-9048-dcbea38b4860"), new DateTime(2024, 11, 28, 18, 33, 58, 951, DateTimeKind.Utc).AddTicks(6430), "A brief description of the product, highlighting its key features and benefits.", "Product 171", 171f, 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4638ef4d-4a74-4c0a-b48f-160d207cf02c"), new DateTime(2024, 11, 28, 18, 31, 9, 951, DateTimeKind.Utc).AddTicks(6008), "A brief description of the product, highlighting its key features and benefits.", "Product 2", 2f, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47878e1a-da2e-46f4-b9f4-d2f8f952633d"), new DateTime(2024, 11, 28, 18, 32, 33, 951, DateTimeKind.Utc).AddTicks(6253), "A brief description of the product, highlighting its key features and benefits.", "Product 86", 86f, 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("493a6d41-1110-4792-aeab-4515729a8f36"), new DateTime(2024, 11, 28, 18, 35, 13, 951, DateTimeKind.Utc).AddTicks(6613), "A brief description of the product, highlighting its key features and benefits.", "Product 246", 246f, 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49bd9af8-224a-4ff5-bab9-892be31563b0"), new DateTime(2024, 11, 28, 18, 31, 59, 951, DateTimeKind.Utc).AddTicks(6165), "A brief description of the product, highlighting its key features and benefits.", "Product 52", 52f, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49f2f8e6-cc0e-44e1-8416-20ba9e0edda3"), new DateTime(2024, 11, 28, 18, 32, 32, 951, DateTimeKind.Utc).AddTicks(6250), "A brief description of the product, highlighting its key features and benefits.", "Product 85", 85f, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49f9eeec-9cc4-40a0-a498-37f91f8db150"), new DateTime(2024, 11, 28, 18, 32, 6, 951, DateTimeKind.Utc).AddTicks(6178), "A brief description of the product, highlighting its key features and benefits.", "Product 59", 59f, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b617fb1-ed78-4df7-88d0-8d566aaa71bb"), new DateTime(2024, 11, 28, 18, 35, 51, 951, DateTimeKind.Utc).AddTicks(6681), "A brief description of the product, highlighting its key features and benefits.", "Product 284", 284f, 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c3fcb94-b138-4a63-89a5-697369845d3b"), new DateTime(2024, 11, 28, 18, 33, 55, 951, DateTimeKind.Utc).AddTicks(6425), "A brief description of the product, highlighting its key features and benefits.", "Product 168", 168f, 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c7fc6a4-287c-4365-952c-8aa146673a75"), new DateTime(2024, 11, 28, 18, 34, 53, 951, DateTimeKind.Utc).AddTicks(6552), "A brief description of the product, highlighting its key features and benefits.", "Product 226", 226f, 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4cbd80fb-60f2-47d4-9287-78937bf04f2e"), new DateTime(2024, 11, 28, 18, 31, 42, 951, DateTimeKind.Utc).AddTicks(6133), "A brief description of the product, highlighting its key features and benefits.", "Product 35", 35f, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e4b01a9-4add-46ee-9730-4aa90673f1e9"), new DateTime(2024, 11, 28, 18, 35, 59, 951, DateTimeKind.Utc).AddTicks(6719), "A brief description of the product, highlighting its key features and benefits.", "Product 292", 292f, 292, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("500ff80f-63ec-4323-bda1-e7707531fa61"), new DateTime(2024, 11, 28, 18, 34, 22, 951, DateTimeKind.Utc).AddTicks(6495), "A brief description of the product, highlighting its key features and benefits.", "Product 195", 195f, 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50283974-82f9-4b65-bb19-0b11031eac8f"), new DateTime(2024, 11, 28, 18, 34, 47, 951, DateTimeKind.Utc).AddTicks(6541), "A brief description of the product, highlighting its key features and benefits.", "Product 220", 220f, 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("515f0275-3c1e-4c8a-b73e-065c47d35e85"), new DateTime(2024, 11, 28, 18, 35, 47, 951, DateTimeKind.Utc).AddTicks(6675), "A brief description of the product, highlighting its key features and benefits.", "Product 280", 280f, 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("523e587a-562e-4de9-aa00-94365143651e"), new DateTime(2024, 11, 28, 18, 35, 21, 951, DateTimeKind.Utc).AddTicks(6627), "A brief description of the product, highlighting its key features and benefits.", "Product 254", 254f, 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5294f6b9-4c7b-491b-b32e-1431e5c85021"), new DateTime(2024, 11, 28, 18, 32, 36, 951, DateTimeKind.Utc).AddTicks(6258), "A brief description of the product, highlighting its key features and benefits.", "Product 89", 89f, 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5337c77f-fadf-49e1-87e5-215ec4769a8b"), new DateTime(2024, 11, 28, 18, 34, 44, 951, DateTimeKind.Utc).AddTicks(6536), "A brief description of the product, highlighting its key features and benefits.", "Product 217", 217f, 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55871557-8c53-450b-91e8-efedf39d4fe6"), new DateTime(2024, 11, 28, 18, 33, 38, 951, DateTimeKind.Utc).AddTicks(6394), "A brief description of the product, highlighting its key features and benefits.", "Product 151", 151f, 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56093c5d-ba7d-4aad-8af6-788dbc7f53d7"), new DateTime(2024, 11, 28, 18, 33, 0, 951, DateTimeKind.Utc).AddTicks(6302), "A brief description of the product, highlighting its key features and benefits.", "Product 113", 113f, 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("560c370e-7cdb-4166-bec0-3e7b2f3df82b"), new DateTime(2024, 11, 28, 18, 32, 22, 951, DateTimeKind.Utc).AddTicks(6232), "A brief description of the product, highlighting its key features and benefits.", "Product 75", 75f, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("568be794-5c90-4de9-92e9-e36ed4f02bad"), new DateTime(2024, 11, 28, 18, 32, 52, 951, DateTimeKind.Utc).AddTicks(6287), "A brief description of the product, highlighting its key features and benefits.", "Product 105", 105f, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("582d487b-0b94-4815-bb97-050de7a329c7"), new DateTime(2024, 11, 28, 18, 32, 24, 951, DateTimeKind.Utc).AddTicks(6235), "A brief description of the product, highlighting its key features and benefits.", "Product 77", 77f, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("58eab10e-9fd7-49d5-ac58-b9290ede1642"), new DateTime(2024, 11, 28, 18, 35, 31, 951, DateTimeKind.Utc).AddTicks(6645), "A brief description of the product, highlighting its key features and benefits.", "Product 264", 264f, 264, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59f01927-adb1-4039-84db-0b1041381f8e"), new DateTime(2024, 11, 28, 18, 34, 9, 951, DateTimeKind.Utc).AddTicks(6473), "A brief description of the product, highlighting its key features and benefits.", "Product 182", 182f, 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5a33e70e-3274-48c4-9bda-743db2a1634d"), new DateTime(2024, 11, 28, 18, 35, 43, 951, DateTimeKind.Utc).AddTicks(6666), "A brief description of the product, highlighting its key features and benefits.", "Product 276", 276f, 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5a80a6ff-faab-42aa-b9e8-b9fd25f86933"), new DateTime(2024, 11, 28, 18, 34, 51, 951, DateTimeKind.Utc).AddTicks(6549), "A brief description of the product, highlighting its key features and benefits.", "Product 224", 224f, 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5a9634cf-1f07-4748-a34c-e3585ca9c82a"), new DateTime(2024, 11, 28, 18, 33, 22, 951, DateTimeKind.Utc).AddTicks(6365), "A brief description of the product, highlighting its key features and benefits.", "Product 135", 135f, 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b4ede07-583e-44e1-bf40-b1e977021ff9"), new DateTime(2024, 11, 28, 18, 34, 16, 951, DateTimeKind.Utc).AddTicks(6484), "A brief description of the product, highlighting its key features and benefits.", "Product 189", 189f, 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b74326a-fa46-4e2b-ab8d-97276622c184"), new DateTime(2024, 11, 28, 18, 34, 20, 951, DateTimeKind.Utc).AddTicks(6492), "A brief description of the product, highlighting its key features and benefits.", "Product 193", 193f, 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d7c61c9-81ae-4b2c-832f-36d39e6b93ad"), new DateTime(2024, 11, 28, 18, 32, 40, 951, DateTimeKind.Utc).AddTicks(6264), "A brief description of the product, highlighting its key features and benefits.", "Product 93", 93f, 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ecd6a8a-4f33-4265-84d4-83a66b4f7c93"), new DateTime(2024, 11, 28, 18, 32, 50, 951, DateTimeKind.Utc).AddTicks(6284), "A brief description of the product, highlighting its key features and benefits.", "Product 103", 103f, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5fac6f7e-30d8-4681-b690-7cb98c7394ef"), new DateTime(2024, 11, 28, 18, 31, 50, 951, DateTimeKind.Utc).AddTicks(6148), "A brief description of the product, highlighting its key features and benefits.", "Product 43", 43f, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("604f269f-7962-4eef-93dc-1575ca54f69c"), new DateTime(2024, 11, 28, 18, 31, 40, 951, DateTimeKind.Utc).AddTicks(6130), "A brief description of the product, highlighting its key features and benefits.", "Product 33", 33f, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61a4eff2-8d8a-435d-9f1d-14bdb790c8fb"), new DateTime(2024, 11, 28, 18, 31, 19, 951, DateTimeKind.Utc).AddTicks(6090), "A brief description of the product, highlighting its key features and benefits.", "Product 12", 12f, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61f163a6-f615-43e1-9b69-743c9768acdb"), new DateTime(2024, 11, 28, 18, 33, 32, 951, DateTimeKind.Utc).AddTicks(6383), "A brief description of the product, highlighting its key features and benefits.", "Product 145", 145f, 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63fc8bef-9b4f-4621-904c-d028b8341f3a"), new DateTime(2024, 11, 28, 18, 34, 46, 951, DateTimeKind.Utc).AddTicks(6539), "A brief description of the product, highlighting its key features and benefits.", "Product 219", 219f, 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6438e945-0a90-4329-9172-956db3265728"), new DateTime(2024, 11, 28, 18, 34, 59, 951, DateTimeKind.Utc).AddTicks(6564), "A brief description of the product, highlighting its key features and benefits.", "Product 232", 232f, 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64727a08-f7b8-446c-8748-2bf076448b3a"), new DateTime(2024, 11, 28, 18, 34, 34, 951, DateTimeKind.Utc).AddTicks(6518), "A brief description of the product, highlighting its key features and benefits.", "Product 207", 207f, 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64c08082-7009-4f1e-a024-1a0785dc5ab8"), new DateTime(2024, 11, 28, 18, 31, 22, 951, DateTimeKind.Utc).AddTicks(6098), "A brief description of the product, highlighting its key features and benefits.", "Product 15", 15f, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64f764e6-3f53-4047-934e-d4777f0a03cc"), new DateTime(2024, 11, 28, 18, 34, 45, 951, DateTimeKind.Utc).AddTicks(6537), "A brief description of the product, highlighting its key features and benefits.", "Product 218", 218f, 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("661a83a5-e761-423e-bcb4-84cb02cad8f0"), new DateTime(2024, 11, 28, 18, 31, 21, 951, DateTimeKind.Utc).AddTicks(6096), "A brief description of the product, highlighting its key features and benefits.", "Product 14", 14f, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69bafcb6-5fa8-4284-954a-a2cc7751f177"), new DateTime(2024, 11, 28, 18, 34, 2, 951, DateTimeKind.Utc).AddTicks(6438), "A brief description of the product, highlighting its key features and benefits.", "Product 175", 175f, 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a62d58e-f31e-452c-b88c-6d2ed7b159d8"), new DateTime(2024, 11, 28, 18, 35, 39, 951, DateTimeKind.Utc).AddTicks(6660), "A brief description of the product, highlighting its key features and benefits.", "Product 272", 272f, 272, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b7fe497-4a7e-4123-9405-60056d647acd"), new DateTime(2024, 11, 28, 18, 35, 18, 951, DateTimeKind.Utc).AddTicks(6621), "A brief description of the product, highlighting its key features and benefits.", "Product 251", 251f, 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ba21985-11c4-4b3c-becd-a865cc643b4c"), new DateTime(2024, 11, 28, 18, 34, 57, 951, DateTimeKind.Utc).AddTicks(6560), "A brief description of the product, highlighting its key features and benefits.", "Product 230", 230f, 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d0c4138-ed29-49a4-853d-786430eede97"), new DateTime(2024, 11, 28, 18, 35, 29, 951, DateTimeKind.Utc).AddTicks(6642), "A brief description of the product, highlighting its key features and benefits.", "Product 262", 262f, 262, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d96ea0e-23eb-4c99-a16f-a96e3b285ca2"), new DateTime(2024, 11, 28, 18, 31, 48, 951, DateTimeKind.Utc).AddTicks(6145), "A brief description of the product, highlighting its key features and benefits.", "Product 41", 41f, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("709c4836-fb35-42af-9cba-6924a4f6a072"), new DateTime(2024, 11, 28, 18, 34, 50, 951, DateTimeKind.Utc).AddTicks(6547), "A brief description of the product, highlighting its key features and benefits.", "Product 223", 223f, 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("721930d7-8e31-4798-b5f1-83f42ec7c70f"), new DateTime(2024, 11, 28, 18, 33, 39, 951, DateTimeKind.Utc).AddTicks(6396), "A brief description of the product, highlighting its key features and benefits.", "Product 152", 152f, 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("726fef1e-6d93-4f17-8689-1e3e94d17d4f"), new DateTime(2024, 11, 28, 18, 35, 8, 951, DateTimeKind.Utc).AddTicks(6603), "A brief description of the product, highlighting its key features and benefits.", "Product 241", 241f, 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("72ecbfd4-7582-445d-9e95-4b167f9ed41a"), new DateTime(2024, 11, 28, 18, 33, 20, 951, DateTimeKind.Utc).AddTicks(6360), "A brief description of the product, highlighting its key features and benefits.", "Product 133", 133f, 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74a8ab12-d43b-4c14-8ecc-cc11a73bb8a6"), new DateTime(2024, 11, 28, 18, 31, 58, 951, DateTimeKind.Utc).AddTicks(6164), "A brief description of the product, highlighting its key features and benefits.", "Product 51", 51f, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74dc60cc-b8b1-4b6d-8218-cd9177e105d2"), new DateTime(2024, 11, 28, 18, 33, 28, 951, DateTimeKind.Utc).AddTicks(6375), "A brief description of the product, highlighting its key features and benefits.", "Product 141", 141f, 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76fb30e5-39dc-4c46-80e6-9b7cdb18aed4"), new DateTime(2024, 11, 28, 18, 35, 45, 951, DateTimeKind.Utc).AddTicks(6671), "A brief description of the product, highlighting its key features and benefits.", "Product 278", 278f, 278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("788ac459-ba9a-4f5e-bf6c-a07169f314ee"), new DateTime(2024, 11, 28, 18, 32, 58, 951, DateTimeKind.Utc).AddTicks(6299), "A brief description of the product, highlighting its key features and benefits.", "Product 111", 111f, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("78ebb405-21e7-406d-b471-77a8d913f927"), new DateTime(2024, 11, 28, 18, 35, 49, 951, DateTimeKind.Utc).AddTicks(6678), "A brief description of the product, highlighting its key features and benefits.", "Product 282", 282f, 282, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79ea2233-2fa4-4186-bca1-fd2d931dd1bf"), new DateTime(2024, 11, 28, 18, 33, 33, 951, DateTimeKind.Utc).AddTicks(6384), "A brief description of the product, highlighting its key features and benefits.", "Product 146", 146f, 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ada58b7-45ef-46ed-a9dc-cfb92113cc64"), new DateTime(2024, 11, 28, 18, 33, 34, 951, DateTimeKind.Utc).AddTicks(6386), "A brief description of the product, highlighting its key features and benefits.", "Product 147", 147f, 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c4c748f-1efd-4fb1-a17f-7d3f6bf9d688"), new DateTime(2024, 11, 28, 18, 31, 24, 951, DateTimeKind.Utc).AddTicks(6101), "A brief description of the product, highlighting its key features and benefits.", "Product 17", 17f, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ce9ee84-9915-4eb2-98c4-eee78f364c5d"), new DateTime(2024, 11, 28, 18, 32, 4, 951, DateTimeKind.Utc).AddTicks(6175), "A brief description of the product, highlighting its key features and benefits.", "Product 57", 57f, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e34cae0-ccd1-46a9-9fa1-ded1269899aa"), new DateTime(2024, 11, 28, 18, 34, 17, 951, DateTimeKind.Utc).AddTicks(6487), "A brief description of the product, highlighting its key features and benefits.", "Product 190", 190f, 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e5fc414-c3f4-44a0-941b-c1efcf51ff54"), new DateTime(2024, 11, 28, 18, 32, 29, 951, DateTimeKind.Utc).AddTicks(6245), "A brief description of the product, highlighting its key features and benefits.", "Product 82", 82f, 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7edef19b-a2bc-4ea9-b2e6-3c2494d9b534"), new DateTime(2024, 11, 28, 18, 33, 8, 951, DateTimeKind.Utc).AddTicks(6338), "A brief description of the product, highlighting its key features and benefits.", "Product 121", 121f, 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("814a6113-a4d3-44bd-9c13-1584facc1e1e"), new DateTime(2024, 11, 28, 18, 31, 14, 951, DateTimeKind.Utc).AddTicks(6081), "A brief description of the product, highlighting its key features and benefits.", "Product 7", 7f, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("81564e9d-29ef-4824-9b91-c62e357355d2"), new DateTime(2024, 11, 28, 18, 36, 2, 951, DateTimeKind.Utc).AddTicks(6725), "A brief description of the product, highlighting its key features and benefits.", "Product 295", 295f, 295, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("817e0e00-5f27-4ea5-bf5a-ce17a8252548"), new DateTime(2024, 11, 28, 18, 35, 23, 951, DateTimeKind.Utc).AddTicks(6631), "A brief description of the product, highlighting its key features and benefits.", "Product 256", 256f, 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("822f0566-b583-471b-9dcf-155166481522"), new DateTime(2024, 11, 28, 18, 35, 3, 951, DateTimeKind.Utc).AddTicks(6593), "A brief description of the product, highlighting its key features and benefits.", "Product 236", 236f, 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("846e6eb2-0b86-46c7-8bbd-9d62e801fe63"), new DateTime(2024, 11, 28, 18, 32, 41, 951, DateTimeKind.Utc).AddTicks(6268), "A brief description of the product, highlighting its key features and benefits.", "Product 94", 94f, 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8641c439-4c49-4576-b552-d08cd6ee4027"), new DateTime(2024, 11, 28, 18, 32, 59, 951, DateTimeKind.Utc).AddTicks(6300), "A brief description of the product, highlighting its key features and benefits.", "Product 112", 112f, 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("879c931a-499b-4f0d-914d-985efedc4960"), new DateTime(2024, 11, 28, 18, 33, 19, 951, DateTimeKind.Utc).AddTicks(6358), "A brief description of the product, highlighting its key features and benefits.", "Product 132", 132f, 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8950ce26-ff00-4558-984b-7d43152d7474"), new DateTime(2024, 11, 28, 18, 36, 5, 951, DateTimeKind.Utc).AddTicks(6730), "A brief description of the product, highlighting its key features and benefits.", "Product 298", 298f, 298, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89b93485-9c64-4089-ae36-663efb0da3c5"), new DateTime(2024, 11, 28, 18, 31, 37, 951, DateTimeKind.Utc).AddTicks(6125), "A brief description of the product, highlighting its key features and benefits.", "Product 30", 30f, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a884856-45f2-4a01-bea9-dce1236f85ea"), new DateTime(2024, 11, 28, 18, 31, 38, 951, DateTimeKind.Utc).AddTicks(6127), "A brief description of the product, highlighting its key features and benefits.", "Product 31", 31f, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b0e1cd1-6082-410e-8072-0dd1e3e9b2ff"), new DateTime(2024, 11, 28, 18, 31, 47, 951, DateTimeKind.Utc).AddTicks(6143), "A brief description of the product, highlighting its key features and benefits.", "Product 40", 40f, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b31d350-3648-4aff-b20f-c72801c01d63"), new DateTime(2024, 11, 28, 18, 34, 14, 951, DateTimeKind.Utc).AddTicks(6481), "A brief description of the product, highlighting its key features and benefits.", "Product 187", 187f, 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c6be089-9b8e-43ba-b3e7-dd1f2fc80178"), new DateTime(2024, 11, 28, 18, 31, 13, 951, DateTimeKind.Utc).AddTicks(6030), "A brief description of the product, highlighting its key features and benefits.", "Product 6", 6f, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8dfc8f3d-57f0-45c3-b336-67c2b582163b"), new DateTime(2024, 11, 28, 18, 31, 20, 951, DateTimeKind.Utc).AddTicks(6092), "A brief description of the product, highlighting its key features and benefits.", "Product 13", 13f, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9016ad0c-1a9a-46f9-a9ac-d96ab04fcaf6"), new DateTime(2024, 11, 28, 18, 33, 15, 951, DateTimeKind.Utc).AddTicks(6352), "A brief description of the product, highlighting its key features and benefits.", "Product 128", 128f, 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91a10197-9881-45a8-8fbd-4d0f34e4ea26"), new DateTime(2024, 11, 28, 18, 32, 55, 951, DateTimeKind.Utc).AddTicks(6292), "A brief description of the product, highlighting its key features and benefits.", "Product 108", 108f, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94b1cbe6-4ad3-4117-9a02-f1d277f3dd14"), new DateTime(2024, 11, 28, 18, 32, 49, 951, DateTimeKind.Utc).AddTicks(6282), "A brief description of the product, highlighting its key features and benefits.", "Product 102", 102f, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("958fe0e2-6c84-474b-b04d-58f6e6567ebd"), new DateTime(2024, 11, 28, 18, 35, 11, 951, DateTimeKind.Utc).AddTicks(6608), "A brief description of the product, highlighting its key features and benefits.", "Product 244", 244f, 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95d34862-0966-4a7a-9738-e6cf130738c4"), new DateTime(2024, 11, 28, 18, 33, 54, 951, DateTimeKind.Utc).AddTicks(6423), "A brief description of the product, highlighting its key features and benefits.", "Product 167", 167f, 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("961225d4-335f-4a19-b374-be160079204b"), new DateTime(2024, 11, 28, 18, 34, 55, 951, DateTimeKind.Utc).AddTicks(6555), "A brief description of the product, highlighting its key features and benefits.", "Product 228", 228f, 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9628753e-d3c7-41d0-b1c5-ce1110c65c48"), new DateTime(2024, 11, 28, 18, 33, 36, 951, DateTimeKind.Utc).AddTicks(6389), "A brief description of the product, highlighting its key features and benefits.", "Product 149", 149f, 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97419708-6388-44f7-a318-8ab31dd1e932"), new DateTime(2024, 11, 28, 18, 34, 5, 951, DateTimeKind.Utc).AddTicks(6464), "A brief description of the product, highlighting its key features and benefits.", "Product 178", 178f, 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97efa66a-6e9a-4aad-bee6-b5860c56a6fc"), new DateTime(2024, 11, 28, 18, 32, 16, 951, DateTimeKind.Utc).AddTicks(6221), "A brief description of the product, highlighting its key features and benefits.", "Product 69", 69f, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98ca1f50-4f84-43a7-a4ae-93a15a69af88"), new DateTime(2024, 11, 28, 18, 31, 10, 951, DateTimeKind.Utc).AddTicks(6009), "A brief description of the product, highlighting its key features and benefits.", "Product 3", 3f, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("991aa429-d227-4ed5-a0ea-914e86435bf1"), new DateTime(2024, 11, 28, 18, 34, 7, 951, DateTimeKind.Utc).AddTicks(6468), "A brief description of the product, highlighting its key features and benefits.", "Product 180", 180f, 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a651769-31b9-4b65-a9c6-2a750089ceb4"), new DateTime(2024, 11, 28, 18, 35, 52, 951, DateTimeKind.Utc).AddTicks(6683), "A brief description of the product, highlighting its key features and benefits.", "Product 285", 285f, 285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a86ce82-3bc7-46f5-9af0-f808d7bd82d8"), new DateTime(2024, 11, 28, 18, 31, 34, 951, DateTimeKind.Utc).AddTicks(6119), "A brief description of the product, highlighting its key features and benefits.", "Product 27", 27f, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b555d07-999b-49db-8557-bb651194a11f"), new DateTime(2024, 11, 28, 18, 31, 33, 951, DateTimeKind.Utc).AddTicks(6117), "A brief description of the product, highlighting its key features and benefits.", "Product 26", 26f, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b55b11a-816b-403a-9d0b-da9dbd65d3f1"), new DateTime(2024, 11, 28, 18, 35, 14, 951, DateTimeKind.Utc).AddTicks(6614), "A brief description of the product, highlighting its key features and benefits.", "Product 247", 247f, 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ca9c126-49f4-46a1-8259-b720ae3bf725"), new DateTime(2024, 11, 28, 18, 32, 21, 951, DateTimeKind.Utc).AddTicks(6230), "A brief description of the product, highlighting its key features and benefits.", "Product 74", 74f, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d50b08e-5f9f-44ff-86a9-261457d03cd1"), new DateTime(2024, 11, 28, 18, 31, 35, 951, DateTimeKind.Utc).AddTicks(6120), "A brief description of the product, highlighting its key features and benefits.", "Product 28", 28f, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d9620b1-4074-4e2d-a37d-daec31403ed2"), new DateTime(2024, 11, 28, 18, 32, 18, 951, DateTimeKind.Utc).AddTicks(6226), "A brief description of the product, highlighting its key features and benefits.", "Product 71", 71f, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f26e9f0-3606-409d-a2c3-9c1d3583e8ae"), new DateTime(2024, 11, 28, 18, 32, 44, 951, DateTimeKind.Utc).AddTicks(6272), "A brief description of the product, highlighting its key features and benefits.", "Product 97", 97f, 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a058df36-8e79-42de-8cd3-8622eaea3768"), new DateTime(2024, 11, 28, 18, 32, 23, 951, DateTimeKind.Utc).AddTicks(6234), "A brief description of the product, highlighting its key features and benefits.", "Product 76", 76f, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a05b23ae-835b-48e9-8a78-44e857c423fa"), new DateTime(2024, 11, 28, 18, 32, 39, 951, DateTimeKind.Utc).AddTicks(6263), "A brief description of the product, highlighting its key features and benefits.", "Product 92", 92f, 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a091cdcb-5ab3-4172-b03e-5204368a978b"), new DateTime(2024, 11, 28, 18, 32, 14, 951, DateTimeKind.Utc).AddTicks(6218), "A brief description of the product, highlighting its key features and benefits.", "Product 67", 67f, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2692004-abbf-4c5b-87e5-bb4dbb73f2ec"), new DateTime(2024, 11, 28, 18, 34, 31, 951, DateTimeKind.Utc).AddTicks(6511), "A brief description of the product, highlighting its key features and benefits.", "Product 204", 204f, 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3db0e71-0a6c-4ddd-b31d-ef627a239977"), new DateTime(2024, 11, 28, 18, 34, 0, 951, DateTimeKind.Utc).AddTicks(6433), "A brief description of the product, highlighting its key features and benefits.", "Product 173", 173f, 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a473aa1b-1535-4351-b072-3b4a3946e4e3"), new DateTime(2024, 11, 28, 18, 32, 31, 951, DateTimeKind.Utc).AddTicks(6248), "A brief description of the product, highlighting its key features and benefits.", "Product 84", 84f, 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a49ff2e2-5c73-46c8-9719-47d7ee9591e0"), new DateTime(2024, 11, 28, 18, 35, 22, 951, DateTimeKind.Utc).AddTicks(6629), "A brief description of the product, highlighting its key features and benefits.", "Product 255", 255f, 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4b3aaa0-3349-44f3-91f6-294d731880b9"), new DateTime(2024, 11, 28, 18, 34, 40, 951, DateTimeKind.Utc).AddTicks(6528), "A brief description of the product, highlighting its key features and benefits.", "Product 213", 213f, 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a66ba3bb-bbd2-4c3b-ab61-2f22e276eead"), new DateTime(2024, 11, 28, 18, 32, 9, 951, DateTimeKind.Utc).AddTicks(6185), "A brief description of the product, highlighting its key features and benefits.", "Product 62", 62f, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8f61fba-b421-4a33-b334-12d5e6681acd"), new DateTime(2024, 11, 28, 18, 36, 1, 951, DateTimeKind.Utc).AddTicks(6724), "A brief description of the product, highlighting its key features and benefits.", "Product 294", 294f, 294, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aab45ba3-9f6a-4b5c-9329-92907ebfeada"), new DateTime(2024, 11, 28, 18, 32, 10, 951, DateTimeKind.Utc).AddTicks(6186), "A brief description of the product, highlighting its key features and benefits.", "Product 63", 63f, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aafd506c-ef9b-40a4-aafa-6f4d54c88466"), new DateTime(2024, 11, 28, 18, 32, 30, 951, DateTimeKind.Utc).AddTicks(6247), "A brief description of the product, highlighting its key features and benefits.", "Product 83", 83f, 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab6a00f4-39a8-434f-84f4-56e054121a98"), new DateTime(2024, 11, 28, 18, 35, 34, 951, DateTimeKind.Utc).AddTicks(6650), "A brief description of the product, highlighting its key features and benefits.", "Product 267", 267f, 267, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad382f07-401b-4bd2-89fa-ff60afff46b8"), new DateTime(2024, 11, 28, 18, 33, 47, 951, DateTimeKind.Utc).AddTicks(6410), "A brief description of the product, highlighting its key features and benefits.", "Product 160", 160f, 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ada828de-3530-47c9-b3c6-efd1ac74812c"), new DateTime(2024, 11, 28, 18, 31, 17, 951, DateTimeKind.Utc).AddTicks(6087), "A brief description of the product, highlighting its key features and benefits.", "Product 10", 10f, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae061ed3-784b-4fad-b8e2-8c95a929ae9b"), new DateTime(2024, 11, 28, 18, 35, 1, 951, DateTimeKind.Utc).AddTicks(6589), "A brief description of the product, highlighting its key features and benefits.", "Product 234", 234f, 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae59ce89-c4c9-4166-8df5-0ce2a19a5750"), new DateTime(2024, 11, 28, 18, 35, 0, 951, DateTimeKind.Utc).AddTicks(6565), "A brief description of the product, highlighting its key features and benefits.", "Product 233", 233f, 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af3939b6-ecd3-48bc-8b45-7d6c9ccf0b9c"), new DateTime(2024, 11, 28, 18, 34, 32, 951, DateTimeKind.Utc).AddTicks(6513), "A brief description of the product, highlighting its key features and benefits.", "Product 205", 205f, 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("afbd83a2-f4c8-4569-bdb6-659e76b715e1"), new DateTime(2024, 11, 28, 18, 32, 38, 951, DateTimeKind.Utc).AddTicks(6261), "A brief description of the product, highlighting its key features and benefits.", "Product 91", 91f, 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0b7ede0-617b-45b8-9514-259e8d380cf9"), new DateTime(2024, 11, 28, 18, 32, 19, 951, DateTimeKind.Utc).AddTicks(6227), "A brief description of the product, highlighting its key features and benefits.", "Product 72", 72f, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1f732f5-b748-49a8-84bf-731728d4e101"), new DateTime(2024, 11, 28, 18, 31, 23, 951, DateTimeKind.Utc).AddTicks(6100), "A brief description of the product, highlighting its key features and benefits.", "Product 16", 16f, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b246ef43-98fe-4bbe-a3d7-84a85e2619c6"), new DateTime(2024, 11, 28, 18, 35, 35, 951, DateTimeKind.Utc).AddTicks(6652), "A brief description of the product, highlighting its key features and benefits.", "Product 268", 268f, 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2906595-3162-4f21-a02b-6bd36ca829bb"), new DateTime(2024, 11, 28, 18, 31, 43, 951, DateTimeKind.Utc).AddTicks(6135), "A brief description of the product, highlighting its key features and benefits.", "Product 36", 36f, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2cc4f69-537a-4e46-befa-fbfa87930a65"), new DateTime(2024, 11, 28, 18, 32, 17, 951, DateTimeKind.Utc).AddTicks(6224), "A brief description of the product, highlighting its key features and benefits.", "Product 70", 70f, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2d95841-c33b-4c93-bc61-34c5eb1920e3"), new DateTime(2024, 11, 28, 18, 32, 45, 951, DateTimeKind.Utc).AddTicks(6274), "A brief description of the product, highlighting its key features and benefits.", "Product 98", 98f, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3832ebc-6b80-4c40-a11e-9b2bf66835d1"), new DateTime(2024, 11, 28, 18, 33, 30, 951, DateTimeKind.Utc).AddTicks(6380), "A brief description of the product, highlighting its key features and benefits.", "Product 143", 143f, 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3efe659-c0ce-45d0-bf9a-4ce7a9d9b080"), new DateTime(2024, 11, 28, 18, 32, 25, 951, DateTimeKind.Utc).AddTicks(6239), "A brief description of the product, highlighting its key features and benefits.", "Product 78", 78f, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b40ab17b-22ec-42a2-be9d-3f58420d4421"), new DateTime(2024, 11, 28, 18, 35, 9, 951, DateTimeKind.Utc).AddTicks(6604), "A brief description of the product, highlighting its key features and benefits.", "Product 242", 242f, 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5418426-ef84-45fa-a2ed-3dd6dbfec402"), new DateTime(2024, 11, 28, 18, 32, 43, 951, DateTimeKind.Utc).AddTicks(6271), "A brief description of the product, highlighting its key features and benefits.", "Product 96", 96f, 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5aa27c6-4d31-4be4-b6e3-9f528be25e89"), new DateTime(2024, 11, 28, 18, 32, 54, 951, DateTimeKind.Utc).AddTicks(6291), "A brief description of the product, highlighting its key features and benefits.", "Product 107", 107f, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6371233-51ec-4818-bedb-eca7051fac95"), new DateTime(2024, 11, 28, 18, 32, 3, 951, DateTimeKind.Utc).AddTicks(6173), "A brief description of the product, highlighting its key features and benefits.", "Product 56", 56f, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6980a26-ce5c-4bcf-8391-a6deda01b700"), new DateTime(2024, 11, 28, 18, 34, 56, 951, DateTimeKind.Utc).AddTicks(6557), "A brief description of the product, highlighting its key features and benefits.", "Product 229", 229f, 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6edf3a9-52a8-4398-aa9f-7263b3f11cf9"), new DateTime(2024, 11, 28, 18, 33, 10, 951, DateTimeKind.Utc).AddTicks(6342), "A brief description of the product, highlighting its key features and benefits.", "Product 123", 123f, 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7e1b966-9026-4218-95d2-afd877e2a616"), new DateTime(2024, 11, 28, 18, 33, 42, 951, DateTimeKind.Utc).AddTicks(6401), "A brief description of the product, highlighting its key features and benefits.", "Product 155", 155f, 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b81d5777-4e8a-4c75-acb4-2e74fed70ccf"), new DateTime(2024, 11, 28, 18, 31, 55, 951, DateTimeKind.Utc).AddTicks(6159), "A brief description of the product, highlighting its key features and benefits.", "Product 48", 48f, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9408795-27c9-4320-869a-1b6f826749b1"), new DateTime(2024, 11, 28, 18, 35, 19, 951, DateTimeKind.Utc).AddTicks(6622), "A brief description of the product, highlighting its key features and benefits.", "Product 252", 252f, 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb9958a5-77f1-405a-bb8a-6f320852861d"), new DateTime(2024, 11, 28, 18, 33, 59, 951, DateTimeKind.Utc).AddTicks(6432), "A brief description of the product, highlighting its key features and benefits.", "Product 172", 172f, 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bd5566f1-b042-443e-8217-9f34660b7788"), new DateTime(2024, 11, 28, 18, 33, 26, 951, DateTimeKind.Utc).AddTicks(6371), "A brief description of the product, highlighting its key features and benefits.", "Product 139", 139f, 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bdbb815e-8acb-4041-b6f5-9fc24f833850"), new DateTime(2024, 11, 28, 18, 35, 17, 951, DateTimeKind.Utc).AddTicks(6619), "A brief description of the product, highlighting its key features and benefits.", "Product 250", 250f, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf040ab8-e4c1-4336-be00-7ca9e15ca89c"), new DateTime(2024, 11, 28, 18, 34, 33, 951, DateTimeKind.Utc).AddTicks(6516), "A brief description of the product, highlighting its key features and benefits.", "Product 206", 206f, 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf1e1a7f-ffe3-4b15-b439-980f1e4f5345"), new DateTime(2024, 11, 28, 18, 33, 16, 951, DateTimeKind.Utc).AddTicks(6353), "A brief description of the product, highlighting its key features and benefits.", "Product 129", 129f, 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c0f7ef7e-275b-4c81-9f63-731478428906"), new DateTime(2024, 11, 28, 18, 35, 4, 951, DateTimeKind.Utc).AddTicks(6595), "A brief description of the product, highlighting its key features and benefits.", "Product 237", 237f, 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2799eba-5717-488c-a17c-01912deb2be9"), new DateTime(2024, 11, 28, 18, 33, 31, 951, DateTimeKind.Utc).AddTicks(6381), "A brief description of the product, highlighting its key features and benefits.", "Product 144", 144f, 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c30c6501-c7ef-4dd7-b81f-4e67a77a12a1"), new DateTime(2024, 11, 28, 18, 35, 5, 951, DateTimeKind.Utc).AddTicks(6598), "A brief description of the product, highlighting its key features and benefits.", "Product 238", 238f, 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4f90cda-f79e-4f8d-9e9f-a4b58440828f"), new DateTime(2024, 11, 28, 18, 35, 2, 951, DateTimeKind.Utc).AddTicks(6591), "A brief description of the product, highlighting its key features and benefits.", "Product 235", 235f, 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6522cde-59d0-4bdb-955b-ad85c0760122"), new DateTime(2024, 11, 28, 18, 32, 27, 951, DateTimeKind.Utc).AddTicks(6242), "A brief description of the product, highlighting its key features and benefits.", "Product 80", 80f, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6646453-d832-49e6-ae9e-01f8a5390477"), new DateTime(2024, 11, 28, 18, 31, 57, 951, DateTimeKind.Utc).AddTicks(6162), "A brief description of the product, highlighting its key features and benefits.", "Product 50", 50f, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6964baa-77ff-4417-a617-e910764425d7"), new DateTime(2024, 11, 28, 18, 35, 20, 951, DateTimeKind.Utc).AddTicks(6624), "A brief description of the product, highlighting its key features and benefits.", "Product 253", 253f, 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7815bec-0026-4520-bf4c-24a33670ff18"), new DateTime(2024, 11, 28, 18, 35, 36, 951, DateTimeKind.Utc).AddTicks(6653), "A brief description of the product, highlighting its key features and benefits.", "Product 269", 269f, 269, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7ac5c4f-6978-4a35-9538-aa66ddf414e2"), new DateTime(2024, 11, 28, 18, 31, 32, 951, DateTimeKind.Utc).AddTicks(6116), "A brief description of the product, highlighting its key features and benefits.", "Product 25", 25f, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9a74bab-0845-4fbc-8efa-a2dd858666b1"), new DateTime(2024, 11, 28, 18, 35, 10, 951, DateTimeKind.Utc).AddTicks(6606), "A brief description of the product, highlighting its key features and benefits.", "Product 243", 243f, 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cbc02f32-fb0a-4bb1-b63e-72dd90742bdc"), new DateTime(2024, 11, 28, 18, 31, 36, 951, DateTimeKind.Utc).AddTicks(6122), "A brief description of the product, highlighting its key features and benefits.", "Product 29", 29f, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cbfa4188-5bf1-4302-b6d7-fc78898db236"), new DateTime(2024, 11, 28, 18, 34, 41, 951, DateTimeKind.Utc).AddTicks(6531), "A brief description of the product, highlighting its key features and benefits.", "Product 214", 214f, 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc49db66-9516-4e9e-a77a-d3c5a8b7fd05"), new DateTime(2024, 11, 28, 18, 31, 18, 951, DateTimeKind.Utc).AddTicks(6089), "A brief description of the product, highlighting its key features and benefits.", "Product 11", 11f, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc81b522-8b7d-415f-99b2-5cb8dc4aed0f"), new DateTime(2024, 11, 28, 18, 32, 8, 951, DateTimeKind.Utc).AddTicks(6181), "A brief description of the product, highlighting its key features and benefits.", "Product 61", 61f, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ccb34ac4-ffc3-41b2-b08c-1300999505e0"), new DateTime(2024, 11, 28, 18, 31, 27, 951, DateTimeKind.Utc).AddTicks(6106), "A brief description of the product, highlighting its key features and benefits.", "Product 20", 20f, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd3a4898-4fc6-4593-858d-4b1fb650344c"), new DateTime(2024, 11, 28, 18, 34, 23, 951, DateTimeKind.Utc).AddTicks(6497), "A brief description of the product, highlighting its key features and benefits.", "Product 196", 196f, 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd60533b-f7dc-4bf3-86bc-e9adf1fd35b8"), new DateTime(2024, 11, 28, 18, 34, 3, 951, DateTimeKind.Utc).AddTicks(6440), "A brief description of the product, highlighting its key features and benefits.", "Product 176", 176f, 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce21521b-ccf2-4d03-a3fd-bd653b07fc9a"), new DateTime(2024, 11, 28, 18, 33, 11, 951, DateTimeKind.Utc).AddTicks(6343), "A brief description of the product, highlighting its key features and benefits.", "Product 124", 124f, 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cf18fc53-8493-42c4-9dec-b11b48c0405e"), new DateTime(2024, 11, 28, 18, 33, 40, 951, DateTimeKind.Utc).AddTicks(6397), "A brief description of the product, highlighting its key features and benefits.", "Product 153", 153f, 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d06ed6eb-db25-465b-b095-95780e1985f6"), new DateTime(2024, 11, 28, 18, 33, 37, 951, DateTimeKind.Utc).AddTicks(6393), "A brief description of the product, highlighting its key features and benefits.", "Product 150", 150f, 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0b1e482-0118-41e3-a648-2d6b78789e9b"), new DateTime(2024, 11, 28, 18, 32, 46, 951, DateTimeKind.Utc).AddTicks(6276), "A brief description of the product, highlighting its key features and benefits.", "Product 99", 99f, 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0f39f86-0483-465e-99e2-c50a0cb9bb2b"), new DateTime(2024, 11, 28, 18, 33, 41, 951, DateTimeKind.Utc).AddTicks(6399), "A brief description of the product, highlighting its key features and benefits.", "Product 154", 154f, 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d108df14-bdf1-425c-9202-9d2e06dfce86"), new DateTime(2024, 11, 28, 18, 32, 11, 951, DateTimeKind.Utc).AddTicks(6213), "A brief description of the product, highlighting its key features and benefits.", "Product 64", 64f, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d110a3a7-e3ca-4f12-8f75-017db8b0c03d"), new DateTime(2024, 11, 28, 18, 34, 10, 951, DateTimeKind.Utc).AddTicks(6474), "A brief description of the product, highlighting its key features and benefits.", "Product 183", 183f, 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d29662e6-d188-4f9e-8354-55b051281291"), new DateTime(2024, 11, 28, 18, 35, 53, 951, DateTimeKind.Utc).AddTicks(6686), "A brief description of the product, highlighting its key features and benefits.", "Product 286", 286f, 286, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3004cb1-391d-4ec6-9c3d-bc13a3e32964"), new DateTime(2024, 11, 28, 18, 36, 3, 951, DateTimeKind.Utc).AddTicks(6727), "A brief description of the product, highlighting its key features and benefits.", "Product 296", 296f, 296, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d36f4f37-5c52-4a6f-8693-96baa9521216"), new DateTime(2024, 11, 28, 18, 32, 0, 951, DateTimeKind.Utc).AddTicks(6167), "A brief description of the product, highlighting its key features and benefits.", "Product 53", 53f, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3b4b020-0a30-46f0-ab20-d9b7b4cb418b"), new DateTime(2024, 11, 28, 18, 35, 48, 951, DateTimeKind.Utc).AddTicks(6676), "A brief description of the product, highlighting its key features and benefits.", "Product 281", 281f, 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d50de2a8-26cf-407d-ad33-d61c0ff0a58f"), new DateTime(2024, 11, 28, 18, 33, 23, 951, DateTimeKind.Utc).AddTicks(6366), "A brief description of the product, highlighting its key features and benefits.", "Product 136", 136f, 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5368c31-5216-497c-981b-fa95bdfbf106"), new DateTime(2024, 11, 28, 18, 32, 56, 951, DateTimeKind.Utc).AddTicks(6294), "A brief description of the product, highlighting its key features and benefits.", "Product 109", 109f, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d561f69c-040f-4d7a-a80b-554835f32577"), new DateTime(2024, 11, 28, 18, 34, 21, 951, DateTimeKind.Utc).AddTicks(6494), "A brief description of the product, highlighting its key features and benefits.", "Product 194", 194f, 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5a7ae7e-b3b7-492e-8511-f13e7cc515b5"), new DateTime(2024, 11, 28, 18, 34, 8, 951, DateTimeKind.Utc).AddTicks(6469), "A brief description of the product, highlighting its key features and benefits.", "Product 181", 181f, 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6ac042e-34a4-4adf-bf5b-fc81b34479a8"), new DateTime(2024, 11, 28, 18, 34, 29, 951, DateTimeKind.Utc).AddTicks(6508), "A brief description of the product, highlighting its key features and benefits.", "Product 202", 202f, 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d716c30c-cf90-4077-8c90-f23ffee1a33f"), new DateTime(2024, 11, 28, 18, 34, 28, 951, DateTimeKind.Utc).AddTicks(6507), "A brief description of the product, highlighting its key features and benefits.", "Product 201", 201f, 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d729cb4d-a7ad-41ad-94ed-c4440fb145b9"), new DateTime(2024, 11, 28, 18, 34, 26, 951, DateTimeKind.Utc).AddTicks(6503), "A brief description of the product, highlighting its key features and benefits.", "Product 199", 199f, 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d97644b5-fcdf-4c13-aa39-2eec62cdc8e1"), new DateTime(2024, 11, 28, 18, 33, 51, 951, DateTimeKind.Utc).AddTicks(6417), "A brief description of the product, highlighting its key features and benefits.", "Product 164", 164f, 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9960cc6-54e1-4fc7-95cc-1e87d4437868"), new DateTime(2024, 11, 28, 18, 33, 57, 951, DateTimeKind.Utc).AddTicks(6428), "A brief description of the product, highlighting its key features and benefits.", "Product 170", 170f, 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9ae4d76-393a-44e7-b3d2-7a6eadd9309b"), new DateTime(2024, 11, 28, 18, 31, 53, 951, DateTimeKind.Utc).AddTicks(6156), "A brief description of the product, highlighting its key features and benefits.", "Product 46", 46f, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9c7bc0d-c0a8-4c6f-8c52-ac18b853414b"), new DateTime(2024, 11, 28, 18, 36, 0, 951, DateTimeKind.Utc).AddTicks(6720), "A brief description of the product, highlighting its key features and benefits.", "Product 293", 293f, 293, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da2eac17-b587-4f71-985d-ed681d0cf085"), new DateTime(2024, 11, 28, 18, 34, 6, 951, DateTimeKind.Utc).AddTicks(6466), "A brief description of the product, highlighting its key features and benefits.", "Product 179", 179f, 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da4cac21-68f2-4310-9eec-b106bb324fcf"), new DateTime(2024, 11, 28, 18, 32, 34, 951, DateTimeKind.Utc).AddTicks(6255), "A brief description of the product, highlighting its key features and benefits.", "Product 87", 87f, 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da878cd9-b7b7-44a0-aeae-232b03290b49"), new DateTime(2024, 11, 28, 18, 33, 1, 951, DateTimeKind.Utc).AddTicks(6304), "A brief description of the product, highlighting its key features and benefits.", "Product 114", 114f, 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db99b225-b41a-4553-8905-2ef535204b8d"), new DateTime(2024, 11, 28, 18, 32, 7, 951, DateTimeKind.Utc).AddTicks(6180), "A brief description of the product, highlighting its key features and benefits.", "Product 60", 60f, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcb351e1-8762-44d5-8a3a-1d41889b9e77"), new DateTime(2024, 11, 28, 18, 35, 57, 951, DateTimeKind.Utc).AddTicks(6692), "A brief description of the product, highlighting its key features and benefits.", "Product 290", 290f, 290, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd70c803-41ab-4f87-bc3c-8ea8af23929c"), new DateTime(2024, 11, 28, 18, 36, 6, 951, DateTimeKind.Utc).AddTicks(6732), "A brief description of the product, highlighting its key features and benefits.", "Product 299", 299f, 299, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de55ba1d-400d-4b2f-aa9c-9b700b2536c4"), new DateTime(2024, 11, 28, 18, 32, 57, 951, DateTimeKind.Utc).AddTicks(6297), "A brief description of the product, highlighting its key features and benefits.", "Product 110", 110f, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ded8d258-f0a8-4ea4-99dd-25d946da7ebf"), new DateTime(2024, 11, 28, 18, 32, 2, 951, DateTimeKind.Utc).AddTicks(6172), "A brief description of the product, highlighting its key features and benefits.", "Product 55", 55f, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("df7de91d-4efb-49d3-b4e7-7557c0cb0afb"), new DateTime(2024, 11, 28, 18, 35, 30, 951, DateTimeKind.Utc).AddTicks(6644), "A brief description of the product, highlighting its key features and benefits.", "Product 263", 263f, 263, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e074686a-b9f5-4179-933f-378b024f8c98"), new DateTime(2024, 11, 28, 18, 31, 8, 951, DateTimeKind.Utc).AddTicks(6000), "A brief description of the product, highlighting its key features and benefits.", "Product 1", 1f, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e07cbdee-6e80-4e84-83f2-a65aba936251"), new DateTime(2024, 11, 28, 18, 31, 49, 951, DateTimeKind.Utc).AddTicks(6146), "A brief description of the product, highlighting its key features and benefits.", "Product 42", 42f, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0ae0d1f-04b4-4a02-9ed2-6f9b40a0dfd3"), new DateTime(2024, 11, 28, 18, 35, 15, 951, DateTimeKind.Utc).AddTicks(6616), "A brief description of the product, highlighting its key features and benefits.", "Product 248", 248f, 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2b3a56b-0bae-4853-bf52-3e950f8b3bcf"), new DateTime(2024, 11, 28, 18, 34, 39, 951, DateTimeKind.Utc).AddTicks(6526), "A brief description of the product, highlighting its key features and benefits.", "Product 212", 212f, 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e46c2573-52f0-4137-841b-63f33cffb18e"), new DateTime(2024, 11, 28, 18, 35, 25, 951, DateTimeKind.Utc).AddTicks(6634), "A brief description of the product, highlighting its key features and benefits.", "Product 258", 258f, 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e48b2b72-05a1-4901-be20-819779c64d41"), new DateTime(2024, 11, 28, 18, 34, 43, 951, DateTimeKind.Utc).AddTicks(6534), "A brief description of the product, highlighting its key features and benefits.", "Product 216", 216f, 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e506407a-a0e8-41d9-9929-e931dbf7959a"), new DateTime(2024, 11, 28, 18, 34, 42, 951, DateTimeKind.Utc).AddTicks(6533), "A brief description of the product, highlighting its key features and benefits.", "Product 215", 215f, 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6074a5b-6274-456d-b98c-7a6f57202c64"), new DateTime(2024, 11, 28, 18, 32, 48, 951, DateTimeKind.Utc).AddTicks(6279), "A brief description of the product, highlighting its key features and benefits.", "Product 101", 101f, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6091cd1-ba9a-4c54-8e21-61fd62d0185e"), new DateTime(2024, 11, 28, 18, 34, 49, 951, DateTimeKind.Utc).AddTicks(6546), "A brief description of the product, highlighting its key features and benefits.", "Product 222", 222f, 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e64a11d6-f03d-4158-810e-5425856b38f6"), new DateTime(2024, 11, 28, 18, 35, 26, 951, DateTimeKind.Utc).AddTicks(6636), "A brief description of the product, highlighting its key features and benefits.", "Product 259", 259f, 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e746b80c-7150-44bb-8a75-591f651386dc"), new DateTime(2024, 11, 28, 18, 36, 4, 951, DateTimeKind.Utc).AddTicks(6728), "A brief description of the product, highlighting its key features and benefits.", "Product 297", 297f, 297, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7a7a16d-4b0e-4529-8cba-181f45b357ca"), new DateTime(2024, 11, 28, 18, 33, 53, 951, DateTimeKind.Utc).AddTicks(6422), "A brief description of the product, highlighting its key features and benefits.", "Product 166", 166f, 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7aedb62-e7ec-41a7-a4d7-04a9aca3699f"), new DateTime(2024, 11, 28, 18, 35, 42, 951, DateTimeKind.Utc).AddTicks(6665), "A brief description of the product, highlighting its key features and benefits.", "Product 275", 275f, 275, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eab091dd-6517-4c14-bd97-d348dfc45157"), new DateTime(2024, 11, 28, 18, 34, 38, 951, DateTimeKind.Utc).AddTicks(6524), "A brief description of the product, highlighting its key features and benefits.", "Product 211", 211f, 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb7482a5-bdde-4402-992e-3db1d7a0456a"), new DateTime(2024, 11, 28, 18, 31, 51, 951, DateTimeKind.Utc).AddTicks(6150), "A brief description of the product, highlighting its key features and benefits.", "Product 44", 44f, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb9f0ac9-2478-43c7-a085-8372c877101e"), new DateTime(2024, 11, 28, 18, 34, 19, 951, DateTimeKind.Utc).AddTicks(6490), "A brief description of the product, highlighting its key features and benefits.", "Product 192", 192f, 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec14102a-63f0-4f7c-a670-85bd10abb265"), new DateTime(2024, 11, 28, 18, 33, 3, 951, DateTimeKind.Utc).AddTicks(6307), "A brief description of the product, highlighting its key features and benefits.", "Product 116", 116f, 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec3c3b44-2bd4-4c41-8ef9-4dd646e3d470"), new DateTime(2024, 11, 28, 18, 34, 11, 951, DateTimeKind.Utc).AddTicks(6476), "A brief description of the product, highlighting its key features and benefits.", "Product 184", 184f, 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ecc41519-218e-4baa-9416-94d843e7ff7b"), new DateTime(2024, 11, 28, 18, 32, 15, 951, DateTimeKind.Utc).AddTicks(6219), "A brief description of the product, highlighting its key features and benefits.", "Product 68", 68f, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee81d20f-7101-4556-b02c-4ea5f6a3f757"), new DateTime(2024, 11, 28, 18, 33, 9, 951, DateTimeKind.Utc).AddTicks(6340), "A brief description of the product, highlighting its key features and benefits.", "Product 122", 122f, 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("efacc4e2-30e7-420d-beed-a031143a4eb5"), new DateTime(2024, 11, 28, 18, 35, 37, 951, DateTimeKind.Utc).AddTicks(6657), "A brief description of the product, highlighting its key features and benefits.", "Product 270", 270f, 270, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("efd9c800-61fe-4da3-8a8a-e17cabe5a229"), new DateTime(2024, 11, 28, 18, 35, 41, 951, DateTimeKind.Utc).AddTicks(6663), "A brief description of the product, highlighting its key features and benefits.", "Product 274", 274f, 274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f0dac29c-0ebe-4560-ac02-dc4f58ce8d4b"), new DateTime(2024, 11, 28, 18, 35, 54, 951, DateTimeKind.Utc).AddTicks(6688), "A brief description of the product, highlighting its key features and benefits.", "Product 287", 287f, 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f27c16d5-982f-49e3-8fed-d7310d35ac24"), new DateTime(2024, 11, 28, 18, 34, 4, 951, DateTimeKind.Utc).AddTicks(6441), "A brief description of the product, highlighting its key features and benefits.", "Product 177", 177f, 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f34da0e0-e1e1-45fd-9aec-58acb590737f"), new DateTime(2024, 11, 28, 18, 31, 15, 951, DateTimeKind.Utc).AddTicks(6083), "A brief description of the product, highlighting its key features and benefits.", "Product 8", 8f, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f35b7e99-46f0-4000-8b86-5f40dd9ae2da"), new DateTime(2024, 11, 28, 18, 32, 12, 951, DateTimeKind.Utc).AddTicks(6214), "A brief description of the product, highlighting its key features and benefits.", "Product 65", 65f, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f40cc14b-581f-44bd-8a6a-ad5c373b30d3"), new DateTime(2024, 11, 28, 18, 34, 35, 951, DateTimeKind.Utc).AddTicks(6520), "A brief description of the product, highlighting its key features and benefits.", "Product 208", 208f, 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f434abcd-7374-42e8-82bc-fd3d8d9f64e6"), new DateTime(2024, 11, 28, 18, 31, 39, 951, DateTimeKind.Utc).AddTicks(6129), "A brief description of the product, highlighting its key features and benefits.", "Product 32", 32f, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f78a8b99-d479-4b07-89a8-d99e7aec53fe"), new DateTime(2024, 11, 28, 18, 35, 7, 951, DateTimeKind.Utc).AddTicks(6601), "A brief description of the product, highlighting its key features and benefits.", "Product 240", 240f, 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8d48f70-ad2e-4949-9896-eba6228f9654"), new DateTime(2024, 11, 28, 18, 33, 44, 951, DateTimeKind.Utc).AddTicks(6404), "A brief description of the product, highlighting its key features and benefits.", "Product 157", 157f, 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa0f656e-099a-49f0-ad6e-9bfbfcf9d7ee"), new DateTime(2024, 11, 28, 18, 33, 4, 951, DateTimeKind.Utc).AddTicks(6309), "A brief description of the product, highlighting its key features and benefits.", "Product 117", 117f, 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa455576-e9fc-4e60-ae15-9ebe008e7435"), new DateTime(2024, 11, 28, 18, 34, 12, 951, DateTimeKind.Utc).AddTicks(6477), "A brief description of the product, highlighting its key features and benefits.", "Product 185", 185f, 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fac525e5-04d2-46d1-820d-50d4cfa10339"), new DateTime(2024, 11, 28, 18, 35, 12, 951, DateTimeKind.Utc).AddTicks(6609), "A brief description of the product, highlighting its key features and benefits.", "Product 245", 245f, 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fadbcdf0-9dd2-4edf-8b4b-a60f293b32dc"), new DateTime(2024, 11, 28, 18, 34, 30, 951, DateTimeKind.Utc).AddTicks(6510), "A brief description of the product, highlighting its key features and benefits.", "Product 203", 203f, 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb3ee0bc-405c-4a21-8bf4-b9893d3a698e"), new DateTime(2024, 11, 28, 18, 32, 51, 951, DateTimeKind.Utc).AddTicks(6286), "A brief description of the product, highlighting its key features and benefits.", "Product 104", 104f, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb6821f2-c6ec-432c-bdd2-e9491bb79649"), new DateTime(2024, 11, 28, 18, 33, 46, 951, DateTimeKind.Utc).AddTicks(6409), "A brief description of the product, highlighting its key features and benefits.", "Product 159", 159f, 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fba3edf4-6591-43a7-bf42-5b4acd56eb6e"), new DateTime(2024, 11, 28, 18, 32, 35, 951, DateTimeKind.Utc).AddTicks(6256), "A brief description of the product, highlighting its key features and benefits.", "Product 88", 88f, 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fbd4d102-3e9e-425b-a2fb-08900afd598d"), new DateTime(2024, 11, 28, 18, 34, 24, 951, DateTimeKind.Utc).AddTicks(6498), "A brief description of the product, highlighting its key features and benefits.", "Product 197", 197f, 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fbfe539a-2760-4a28-9700-7855fdc11d92"), new DateTime(2024, 11, 28, 18, 32, 42, 951, DateTimeKind.Utc).AddTicks(6269), "A brief description of the product, highlighting its key features and benefits.", "Product 95", 95f, 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc7d1d0b-170a-4d29-bbb1-cbc99459f7e9"), new DateTime(2024, 11, 28, 18, 35, 58, 951, DateTimeKind.Utc).AddTicks(6717), "A brief description of the product, highlighting its key features and benefits.", "Product 291", 291f, 291, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fececf66-b5f2-4017-b9ee-89ed81187de5"), new DateTime(2024, 11, 28, 18, 31, 56, 951, DateTimeKind.Utc).AddTicks(6160), "A brief description of the product, highlighting its key features and benefits.", "Product 49", 49f, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff0f81a3-9e3c-4190-a294-eb0dc74db60a"), new DateTime(2024, 11, 28, 18, 33, 35, 951, DateTimeKind.Utc).AddTicks(6388), "A brief description of the product, highlighting its key features and benefits.", "Product 148", 148f, 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff1b07c8-fd7e-48ed-ade6-0474cf81723a"), new DateTime(2024, 11, 28, 18, 33, 2, 951, DateTimeKind.Utc).AddTicks(6305), "A brief description of the product, highlighting its key features and benefits.", "Product 115", 115f, 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff38e1f2-1944-4b55-b850-7f9c3724e700"), new DateTime(2024, 11, 28, 18, 33, 25, 951, DateTimeKind.Utc).AddTicks(6370), "A brief description of the product, highlighting its key features and benefits.", "Product 138", 138f, 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductProductImageFile");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
