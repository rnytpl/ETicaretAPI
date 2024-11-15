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
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
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
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("03be7b27-56e7-405e-b97d-75e13d7b0ab3"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8079), "A brief description of the product, highlighting its key features and benefits.", "Product 281", 281f, 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("03cc7f16-8627-4eda-93f3-9e5adc7772bb"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7931), "A brief description of the product, highlighting its key features and benefits.", "Product 225", 225f, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("03d1a2d1-7285-4eee-a733-44aaf3d55bef"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7606), "A brief description of the product, highlighting its key features and benefits.", "Product 117", 117f, 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("04f51d94-4286-49b0-9286-bb961d50aa34"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8043), "A brief description of the product, highlighting its key features and benefits.", "Product 261", 261f, 261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("056c8410-39c0-4efc-898d-8bd6c7b6b956"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7575), "A brief description of the product, highlighting its key features and benefits.", "Product 99", 99f, 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("07280ded-fcd9-43bf-a86c-67aef7304fb7"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8054), "A brief description of the product, highlighting its key features and benefits.", "Product 267", 267f, 267, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("07887d82-2fbb-4ced-a3e4-793274018cc5"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8040), "A brief description of the product, highlighting its key features and benefits.", "Product 259", 259f, 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("085efdb9-f777-4d23-8403-976b7902f01f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8068), "A brief description of the product, highlighting its key features and benefits.", "Product 275", 275f, 275, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0869c6e4-deaf-4646-852e-4fc7d76c46ae"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7566), "A brief description of the product, highlighting its key features and benefits.", "Product 94", 94f, 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("08d22839-466d-42d4-96c2-05afb4ef45b7"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8103), "A brief description of the product, highlighting its key features and benefits.", "Product 296", 296f, 296, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0acfe31a-a00c-4e1f-9241-f83ce3aa7016"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7792), "A brief description of the product, highlighting its key features and benefits.", "Product 184", 184f, 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0caf5274-c88c-41ed-87e9-fb100c3f9fe1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7485), "A brief description of the product, highlighting its key features and benefits.", "Product 79", 79f, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e1ed51b-1bb3-422d-b7d0-69e61fb6fbdd"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7783), "A brief description of the product, highlighting its key features and benefits.", "Product 180", 180f, 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e540c24-b6cb-4ce4-8125-74fc6ecfa9fa"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7583), "A brief description of the product, highlighting its key features and benefits.", "Product 104", 104f, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f1c55f1-dde5-4ff6-a2be-c121f6e2c3b8"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8069), "A brief description of the product, highlighting its key features and benefits.", "Product 276", 276f, 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f4c2966-764b-4f17-a302-b968453aefa6"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7805), "A brief description of the product, highlighting its key features and benefits.", "Product 189", 189f, 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f7df532-9be7-49f4-8cbe-e8b3ef6e3ae7"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8009), "A brief description of the product, highlighting its key features and benefits.", "Product 244", 244f, 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11b63475-0801-4477-9646-c80946c79595"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7317), "A brief description of the product, highlighting its key features and benefits.", "Product 4", 4f, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11d04f8c-272b-462c-bd6a-3e2feb19ec10"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8037), "A brief description of the product, highlighting its key features and benefits.", "Product 257", 257f, 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13723910-321f-4416-a99c-63148b3cfb91"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7435), "A brief description of the product, highlighting its key features and benefits.", "Product 50", 50f, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13f2a9eb-b897-4f16-b355-ca207e06673d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7756), "A brief description of the product, highlighting its key features and benefits.", "Product 169", 169f, 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13ff00ca-46bb-47aa-ad2b-4f9fe9961786"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7722), "A brief description of the product, highlighting its key features and benefits.", "Product 157", 157f, 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("144043a2-d52d-417e-a0a7-5a607bbd23d6"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7314), "A brief description of the product, highlighting its key features and benefits.", "Product 2", 2f, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("17b7878b-7472-4fb9-bade-9bf9fe4c748a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7484), "A brief description of the product, highlighting its key features and benefits.", "Product 78", 78f, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b7bdd14-4a8e-4c4e-951f-4b43cabf5bb0"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7406), "A brief description of the product, highlighting its key features and benefits.", "Product 33", 33f, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1c29c085-9ca3-4cf5-9a7e-1a1453abcc6e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7628), "A brief description of the product, highlighting its key features and benefits.", "Product 129", 129f, 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1dc4e6e3-d24a-40e2-bf0a-adbb5f9dfae6"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8060), "A brief description of the product, highlighting its key features and benefits.", "Product 271", 271f, 271, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e2be758-a2ec-4535-821d-b2198c676999"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7396), "A brief description of the product, highlighting its key features and benefits.", "Product 28", 28f, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e7e5c58-d7df-4bc5-80af-8223238eb2f3"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7434), "A brief description of the product, highlighting its key features and benefits.", "Product 49", 49f, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1eafaa9f-e0ad-4aec-a9e4-7864fa809f8e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8132), "A brief description of the product, highlighting its key features and benefits.", "Product 299", 299f, 299, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1eed606e-8cb4-48b5-bb57-70d532b6fb34"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7398), "A brief description of the product, highlighting its key features and benefits.", "Product 29", 29f, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1fa6d43e-96e5-4af9-a516-13a1487a40c1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7737), "A brief description of the product, highlighting its key features and benefits.", "Product 162", 162f, 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1faaa97e-219d-4389-bddb-f6758139acb4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7785), "A brief description of the product, highlighting its key features and benefits.", "Product 181", 181f, 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2044db05-33e3-4361-bd93-a3f0ff008e3e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7487), "A brief description of the product, highlighting its key features and benefits.", "Product 80", 80f, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("206bbd5e-0e97-4e35-821b-2d95a781ef0e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7348), "A brief description of the product, highlighting its key features and benefits.", "Product 21", 21f, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2071ff1a-1db6-4762-92be-c56c1e2c192b"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7623), "A brief description of the product, highlighting its key features and benefits.", "Product 127", 127f, 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2088e8ee-fcd4-4b55-b472-9aae6318d181"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7445), "A brief description of the product, highlighting its key features and benefits.", "Product 56", 56f, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("210afffb-6c1a-4e5e-9657-bfb7607d2fab"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8052), "A brief description of the product, highlighting its key features and benefits.", "Product 266", 266f, 266, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("215b680a-787d-4397-840f-406e6538ec34"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7580), "A brief description of the product, highlighting its key features and benefits.", "Product 102", 102f, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("225edf74-bb47-4dca-a539-4e1ad8343190"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7772), "A brief description of the product, highlighting its key features and benefits.", "Product 176", 176f, 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("24e709e0-664f-4ad0-8b7e-2a2682d591f1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7547), "A brief description of the product, highlighting its key features and benefits.", "Product 83", 83f, 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("25ccbedf-a91a-4091-b808-9938280830fd"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7614), "A brief description of the product, highlighting its key features and benefits.", "Product 121", 121f, 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26cc2a98-38bf-4d97-8d03-16b3182490e4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7591), "A brief description of the product, highlighting its key features and benefits.", "Product 108", 108f, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27211666-863f-4120-aede-f6b752784ae6"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8100), "A brief description of the product, highlighting its key features and benefits.", "Product 294", 294f, 294, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27d81bca-ac88-4a1d-b8c2-5e60d65c118d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7976), "A brief description of the product, highlighting its key features and benefits.", "Product 242", 242f, 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("285ccca5-9cdb-4b17-9911-393a74e95733"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7462), "A brief description of the product, highlighting its key features and benefits.", "Product 65", 65f, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("29ee5acd-1c3f-4dae-86eb-140dd24b9ef5"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7609), "A brief description of the product, highlighting its key features and benefits.", "Product 119", 119f, 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("29f79426-3d94-4167-9f9e-20fe7bd986c5"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7705), "A brief description of the product, highlighting its key features and benefits.", "Product 150", 150f, 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a862650-303e-4f4c-bb8c-3a41ddc8b636"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7630), "A brief description of the product, highlighting its key features and benefits.", "Product 130", 130f, 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b49d015-e167-4acb-a75c-3f57cca227fa"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7763), "A brief description of the product, highlighting its key features and benefits.", "Product 172", 172f, 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d23de41-4ac2-4019-bcda-121994db4a28"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8011), "A brief description of the product, highlighting its key features and benefits.", "Product 245", 245f, 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d615b6a-e2b2-463e-9e00-96f8e77d9c6e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8074), "A brief description of the product, highlighting its key features and benefits.", "Product 279", 279f, 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e97a6ff-19c0-4e5e-8a86-632bbe708c6e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7440), "A brief description of the product, highlighting its key features and benefits.", "Product 53", 53f, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f037419-8cb3-47f1-bf2c-7979f4b95b34"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7696), "A brief description of the product, highlighting its key features and benefits.", "Product 146", 146f, 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f2185c2-9284-4a03-8942-2e5f63fd39bd"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7873), "A brief description of the product, highlighting its key features and benefits.", "Product 204", 204f, 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f305beb-898d-4b92-9648-724777e4b166"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7960), "A brief description of the product, highlighting its key features and benefits.", "Product 236", 236f, 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f55e4fd-205b-4615-882f-41baac529a3c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7742), "A brief description of the product, highlighting its key features and benefits.", "Product 164", 164f, 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("300aca05-268f-413c-96e2-d8c975c8fd1c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8072), "A brief description of the product, highlighting its key features and benefits.", "Product 278", 278f, 278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30407481-c7f6-468b-ba0d-0c52bbdf5ed4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7616), "A brief description of the product, highlighting its key features and benefits.", "Product 122", 122f, 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3130c5fd-2b6d-4081-964a-eccb7d789952"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7428), "A brief description of the product, highlighting its key features and benefits.", "Product 46", 46f, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36ee3723-57e5-46ab-8925-c3ca0554bb72"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7359), "A brief description of the product, highlighting its key features and benefits.", "Product 27", 27f, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3737460a-3c6a-4e9c-a212-d4df4b47f56c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7904), "A brief description of the product, highlighting its key features and benefits.", "Product 216", 216f, 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("390fddc7-e14e-4cc3-b646-25aee2ef8afb"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7608), "A brief description of the product, highlighting its key features and benefits.", "Product 118", 118f, 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39966b89-848e-4f2e-b4b8-5ace132dce44"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7667), "A brief description of the product, highlighting its key features and benefits.", "Product 136", 136f, 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39dcd452-7fde-41a5-b6b3-2129b24cf3b9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7337), "A brief description of the product, highlighting its key features and benefits.", "Product 15", 15f, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3bea2003-5aa5-40a0-a927-cc5018331b9e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7457), "A brief description of the product, highlighting its key features and benefits.", "Product 63", 63f, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e2bae5d-26be-42ce-bcef-8bc12cee7789"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7415), "A brief description of the product, highlighting its key features and benefits.", "Product 39", 39f, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e788c89-4936-48d8-9319-39818ed32555"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7718), "A brief description of the product, highlighting its key features and benefits.", "Product 155", 155f, 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f4eff2a-4309-4fb2-8b0b-b5a83c16e7db"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7803), "A brief description of the product, highlighting its key features and benefits.", "Product 188", 188f, 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f8757a6-99b4-409a-bcf1-7bb789f86043"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7924), "A brief description of the product, highlighting its key features and benefits.", "Product 223", 223f, 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4218f5ac-4b22-465e-97c1-f330977ebc93"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7334), "A brief description of the product, highlighting its key features and benefits.", "Product 13", 13f, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43396c05-8538-474d-a30e-3d683fa57d1e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7734), "A brief description of the product, highlighting its key features and benefits.", "Product 161", 161f, 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("445cd154-9072-48be-a98e-b74fa488d066"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7796), "A brief description of the product, highlighting its key features and benefits.", "Product 185", 185f, 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44c0ee35-0792-4ab1-901b-ed5065b813b4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7431), "A brief description of the product, highlighting its key features and benefits.", "Product 48", 48f, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("455e14e8-1f5a-4ef8-955d-5cf752da9207"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7564), "A brief description of the product, highlighting its key features and benefits.", "Product 93", 93f, 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("461bdd63-fc87-4184-aa26-b617ea594dd9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8065), "A brief description of the product, highlighting its key features and benefits.", "Product 273", 273f, 273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("46948ca1-3d95-48d8-a1a2-befa77f10762"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8015), "A brief description of the product, highlighting its key features and benefits.", "Product 247", 247f, 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47afdf47-6469-4a91-bd59-bbc507f50c14"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7681), "A brief description of the product, highlighting its key features and benefits.", "Product 141", 141f, 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("484f8985-31bf-4e74-a610-25379ba231d9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7561), "A brief description of the product, highlighting its key features and benefits.", "Product 91", 91f, 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4853ec78-4967-44c9-aaf5-703186abe730"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7349), "A brief description of the product, highlighting its key features and benefits.", "Product 22", 22f, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4919d5b7-0820-40e9-9647-33bb07b50f01"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7860), "A brief description of the product, highlighting its key features and benefits.", "Product 199", 199f, 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a7e6337-c7a4-47b9-ae23-0fcaf0a7db19"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7962), "A brief description of the product, highlighting its key features and benefits.", "Product 237", 237f, 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4aa474d2-64a6-4ad5-b241-6c869fb2d441"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7911), "A brief description of the product, highlighting its key features and benefits.", "Product 218", 218f, 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4bcbdcd8-bd08-440a-965a-14cbc2119c3c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7410), "A brief description of the product, highlighting its key features and benefits.", "Product 36", 36f, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d368e15-eae7-4f98-b56e-94c6d060b868"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8066), "A brief description of the product, highlighting its key features and benefits.", "Product 274", 274f, 274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e4f033d-d4df-4e99-bcc0-7c663176487a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7574), "A brief description of the product, highlighting its key features and benefits.", "Product 98", 98f, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e52ed4c-7c25-4e20-ab6b-a73b1a9eae32"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7916), "A brief description of the product, highlighting its key features and benefits.", "Product 220", 220f, 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5040d39f-0d4e-47c4-84c6-03d47678c915"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7577), "A brief description of the product, highlighting its key features and benefits.", "Product 100", 100f, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51569cad-2c41-43b3-96b9-25cb902dbaeb"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7698), "A brief description of the product, highlighting its key features and benefits.", "Product 147", 147f, 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5415b41a-0450-4825-b73e-b87ea70c441f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7562), "A brief description of the product, highlighting its key features and benefits.", "Product 92", 92f, 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54492c31-619d-4288-af82-832d166b222e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7310), "A brief description of the product, highlighting its key features and benefits.", "Product 1", 1f, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54960c85-5c5c-48c8-822b-1fe90e90b262"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7921), "A brief description of the product, highlighting its key features and benefits.", "Product 222", 222f, 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54bd73fb-04fa-455a-9af1-47f8fea59d7d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7600), "A brief description of the product, highlighting its key features and benefits.", "Product 113", 113f, 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("551ae0cf-bd0e-475d-a8b3-83190c7d3f3a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7456), "A brief description of the product, highlighting its key features and benefits.", "Product 62", 62f, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("553db280-45d5-44f7-93d5-de945279b745"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7677), "A brief description of the product, highlighting its key features and benefits.", "Product 139", 139f, 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55fcb327-b65e-4930-968b-026d8d2c5eef"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7437), "A brief description of the product, highlighting its key features and benefits.", "Product 51", 51f, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("561edab9-a1d3-4813-aec4-ccff98960eb0"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7413), "A brief description of the product, highlighting its key features and benefits.", "Product 38", 38f, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56d8ddd1-e054-4525-a597-2f51813020d4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7749), "A brief description of the product, highlighting its key features and benefits.", "Product 167", 167f, 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5723d4ad-e5ba-417c-8416-d18297c77ede"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8133), "A brief description of the product, highlighting its key features and benefits.", "Product 300", 300f, 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57a18664-51b4-49f2-a190-c1263ffa153c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7603), "A brief description of the product, highlighting its key features and benefits.", "Product 115", 115f, 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59c87866-3a48-4a9e-a5c5-4fe271346a15"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7892), "A brief description of the product, highlighting its key features and benefits.", "Product 211", 211f, 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c06629e-4892-4e14-a046-ef179a351d27"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7589), "A brief description of the product, highlighting its key features and benefits.", "Product 107", 107f, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c5b0f3d-88c2-4058-a28f-909d5ac66014"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7800), "A brief description of the product, highlighting its key features and benefits.", "Product 187", 187f, 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d49c093-1ee5-4436-a1d7-7fdb51fc9dec"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7481), "A brief description of the product, highlighting its key features and benefits.", "Product 76", 76f, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5df4e01a-5767-4de9-8c33-8648903d5b05"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7767), "A brief description of the product, highlighting its key features and benefits.", "Product 174", 174f, 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5effe0b3-2a0b-4f54-8288-16ca10e735a7"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7352), "A brief description of the product, highlighting its key features and benefits.", "Product 24", 24f, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f5d3df8-876d-4c48-ac2e-3c44796e30f1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7871), "A brief description of the product, highlighting its key features and benefits.", "Product 203", 203f, 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61a82ec3-6c02-40d1-98a2-c52a49119050"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7625), "A brief description of the product, highlighting its key features and benefits.", "Product 128", 128f, 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("626a40c0-9372-412b-89bd-398f69c84b6d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7854), "A brief description of the product, highlighting its key features and benefits.", "Product 197", 197f, 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("62a5c608-062f-41a4-96a2-4ca44b2c490d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7707), "A brief description of the product, highlighting its key features and benefits.", "Product 151", 151f, 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63977730-1ca2-4dd8-b4fa-d9b332c575ba"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7895), "A brief description of the product, highlighting its key features and benefits.", "Product 212", 212f, 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("650cb0e0-0ee3-4675-ab01-fff64e861873"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7611), "A brief description of the product, highlighting its key features and benefits.", "Product 120", 120f, 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("650f15a8-d295-4ffb-9eaf-47a83bebf58a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7582), "A brief description of the product, highlighting its key features and benefits.", "Product 103", 103f, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("65453a68-6995-4798-a465-1d547eb98cc4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7751), "A brief description of the product, highlighting its key features and benefits.", "Product 168", 168f, 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("65c62a2d-62b6-40e5-8527-dcbdef2c63b3"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7449), "A brief description of the product, highlighting its key features and benefits.", "Product 58", 58f, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6602b922-5ed8-44f1-b0c7-32094dadb446"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7345), "A brief description of the product, highlighting its key features and benefits.", "Product 19", 19f, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("66937669-ebbc-437b-9df6-3b98b98169da"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8031), "A brief description of the product, highlighting its key features and benefits.", "Product 254", 254f, 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67b787b9-a90c-4b7e-9044-2f12890dfb4e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7880), "A brief description of the product, highlighting its key features and benefits.", "Product 207", 207f, 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a01bcc6-7a6d-49a2-bec5-0a36a6c081c1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7426), "A brief description of the product, highlighting its key features and benefits.", "Product 45", 45f, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b97b8ff-59b9-4317-a14b-95f4a8563a45"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7558), "A brief description of the product, highlighting its key features and benefits.", "Product 89", 89f, 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6be6f88b-c02c-4e50-95ed-68dba59fd255"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7490), "A brief description of the product, highlighting its key features and benefits.", "Product 81", 81f, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6bee43f3-87b9-41fd-8fb4-8f43b5c8d6e0"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8095), "A brief description of the product, highlighting its key features and benefits.", "Product 291", 291f, 291, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c956380-5551-49a6-9675-8da077475f7c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7789), "A brief description of the product, highlighting its key features and benefits.", "Product 183", 183f, 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d64f518-2842-4d14-b4cd-52184ae99711"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7555), "A brief description of the product, highlighting its key features and benefits.", "Product 88", 88f, 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6eacc51b-867f-4da0-96d0-3ad64d797099"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7448), "A brief description of the product, highlighting its key features and benefits.", "Product 57", 57f, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ebee923-00d9-4c96-a0be-3bd5003aeece"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7592), "A brief description of the product, highlighting its key features and benefits.", "Product 109", 109f, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70bde2bf-62a9-4bcd-ae4c-f7d0bec44b28"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7868), "A brief description of the product, highlighting its key features and benefits.", "Product 202", 202f, 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70edbfe1-6ac6-4b40-9899-ec1210ca9be0"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7594), "A brief description of the product, highlighting its key features and benefits.", "Product 110", 110f, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("716c1fda-eb8e-4449-b651-d4074b8d33a5"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7323), "A brief description of the product, highlighting its key features and benefits.", "Product 8", 8f, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7310001a-d7d8-44e3-8098-f2f2dc3a6162"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8092), "A brief description of the product, highlighting its key features and benefits.", "Product 289", 289f, 289, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75bf4858-6d1e-41fa-8f91-635c4d5898f2"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7850), "A brief description of the product, highlighting its key features and benefits.", "Product 195", 195f, 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7797d914-f785-4030-a8d5-93bdf2670c23"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7417), "A brief description of the product, highlighting its key features and benefits.", "Product 40", 40f, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79e09130-3035-4db3-80f4-e684719d6957"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7720), "A brief description of the product, highlighting its key features and benefits.", "Product 156", 156f, 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b433c84-ccaf-4949-8f43-85a94266d17f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8106), "A brief description of the product, highlighting its key features and benefits.", "Product 297", 297f, 297, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c30defb-c3db-4dd7-871d-6e4ed8dbe331"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7688), "A brief description of the product, highlighting its key features and benefits.", "Product 144", 144f, 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7dc828e3-b95c-4e0f-8aeb-568ca7c70750"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7617), "A brief description of the product, highlighting its key features and benefits.", "Product 123", 123f, 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e253b43-9405-4ce7-8345-a478535d37ac"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7875), "A brief description of the product, highlighting its key features and benefits.", "Product 205", 205f, 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ef0444a-3699-4115-9932-d3c048c7a397"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8051), "A brief description of the product, highlighting its key features and benefits.", "Product 265", 265f, 265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7f4bb283-08ef-494e-a302-31b7eb33b8a1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7633), "A brief description of the product, highlighting its key features and benefits.", "Product 132", 132f, 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7f54cfa3-7141-4691-bfca-7500cf110b87"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8080), "A brief description of the product, highlighting its key features and benefits.", "Product 282", 282f, 282, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80bdb7d4-8dbe-40d9-925d-c76e9b020463"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7329), "A brief description of the product, highlighting its key features and benefits.", "Product 10", 10f, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("811e8166-942b-48e2-89ae-881bc1551b54"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7351), "A brief description of the product, highlighting its key features and benefits.", "Product 23", 23f, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8185b669-7acc-4700-a90d-00fe6c26919f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7938), "A brief description of the product, highlighting its key features and benefits.", "Product 228", 228f, 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83107190-61ac-4889-a766-551f5e9e9aa3"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8062), "A brief description of the product, highlighting its key features and benefits.", "Product 272", 272f, 272, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8641f75c-1256-4201-ad7d-d1dc340fc3fc"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7634), "A brief description of the product, highlighting its key features and benefits.", "Product 133", 133f, 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("867afb5a-c898-41de-89af-c171cc23afac"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7967), "A brief description of the product, highlighting its key features and benefits.", "Product 239", 239f, 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86b3cc96-661a-4436-9917-db4a3b7b818b"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7552), "A brief description of the product, highlighting its key features and benefits.", "Product 86", 86f, 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("87c89173-fc21-4764-8833-bad9e6a3ba6b"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7478), "A brief description of the product, highlighting its key features and benefits.", "Product 74", 74f, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("882d3d90-e9ce-400b-8028-08010bbc5b74"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8086), "A brief description of the product, highlighting its key features and benefits.", "Product 286", 286f, 286, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8847df9e-3c06-4f2a-8b31-0b7e4ef967e0"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7914), "A brief description of the product, highlighting its key features and benefits.", "Product 219", 219f, 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("885aff44-e44e-4eb2-bf1e-b092f67170a4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8013), "A brief description of the product, highlighting its key features and benefits.", "Product 246", 246f, 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c1ee33b-a3b5-45ac-9fbf-84efd029f253"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7473), "A brief description of the product, highlighting its key features and benefits.", "Product 72", 72f, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8cd246b1-1486-4c20-9b56-118cd7936052"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7946), "A brief description of the product, highlighting its key features and benefits.", "Product 231", 231f, 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8db6f98b-7160-43f5-beff-19088c819747"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7320), "A brief description of the product, highlighting its key features and benefits.", "Product 6", 6f, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8de3d314-2f7d-4c35-aa52-fd4694837037"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7787), "A brief description of the product, highlighting its key features and benefits.", "Product 182", 182f, 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8fe5aac6-5023-42c4-a70a-42eb0be15444"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8029), "A brief description of the product, highlighting its key features and benefits.", "Product 253", 253f, 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91a43617-4626-41d6-b78c-b5e51d04c37d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7439), "A brief description of the product, highlighting its key features and benefits.", "Product 52", 52f, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("937edb07-272c-4ce3-94e7-364c2434e1b3"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7326), "A brief description of the product, highlighting its key features and benefits.", "Product 9", 9f, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9465d402-177c-43c2-84e5-4354922de315"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7725), "A brief description of the product, highlighting its key features and benefits.", "Product 158", 158f, 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94a8bc18-d0a2-4c5f-b304-40e24bb9f916"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7545), "A brief description of the product, highlighting its key features and benefits.", "Product 82", 82f, 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9514f666-0083-475e-b998-7571d8323147"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7866), "A brief description of the product, highlighting its key features and benefits.", "Product 201", 201f, 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95f6379b-02c5-4b46-8552-e31f1f089186"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7883), "A brief description of the product, highlighting its key features and benefits.", "Product 208", 208f, 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("96e9b766-ed2b-42c0-a42e-8d01757957ff"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7459), "A brief description of the product, highlighting its key features and benefits.", "Product 64", 64f, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("96f5d810-c929-419c-86e3-7c4a94992bc9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8032), "A brief description of the product, highlighting its key features and benefits.", "Product 255", 255f, 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("96f94b8e-90c7-4f83-bb40-1b0d97d56f4f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7744), "A brief description of the product, highlighting its key features and benefits.", "Product 165", 165f, 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97f557cb-93d6-4e59-9f45-23aa4d807d0f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7958), "A brief description of the product, highlighting its key features and benefits.", "Product 235", 235f, 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98559c2f-6fc7-455a-ba52-d1d06ba8e707"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7482), "A brief description of the product, highlighting its key features and benefits.", "Product 77", 77f, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98c91543-1fab-4eeb-b231-21be86961fe2"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8039), "A brief description of the product, highlighting its key features and benefits.", "Product 258", 258f, 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99ec5078-ee0c-468d-b813-55ac6fbc4663"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7597), "A brief description of the product, highlighting its key features and benefits.", "Product 112", 112f, 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9be8a6f8-c830-4d36-acf7-bf9a19a91f07"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8034), "A brief description of the product, highlighting its key features and benefits.", "Product 256", 256f, 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d23cc90-4f8e-45dc-b5f5-08f8fb80a04a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7443), "A brief description of the product, highlighting its key features and benefits.", "Product 55", 55f, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d9f288d-ddd2-4aff-8640-47f37b53f107"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8042), "A brief description of the product, highlighting its key features and benefits.", "Product 260", 260f, 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9e8b0fe7-535d-4246-b697-227cf32e76a6"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7899), "A brief description of the product, highlighting its key features and benefits.", "Product 214", 214f, 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f01b293-ede4-4685-aa0f-90da2ce038db"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7442), "A brief description of the product, highlighting its key features and benefits.", "Product 54", 54f, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f6b19b5-6505-446e-8414-b351e85c6582"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8028), "A brief description of the product, highlighting its key features and benefits.", "Product 252", 252f, 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a05d4263-c779-4aa6-9578-211398bc0eb3"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7402), "A brief description of the product, highlighting its key features and benefits.", "Product 32", 32f, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a0e42f05-8d6b-41fa-9b65-9a78f5cc75bf"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7933), "A brief description of the product, highlighting its key features and benefits.", "Product 226", 226f, 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a108ed09-d2ad-49d9-9293-92421496e003"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7553), "A brief description of the product, highlighting its key features and benefits.", "Product 87", 87f, 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1bb8c55-a40c-45c6-bcf9-4a3fe0c73adc"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7778), "A brief description of the product, highlighting its key features and benefits.", "Product 178", 178f, 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a22e73a4-8911-4072-bdc1-2714a9dd98c7"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7588), "A brief description of the product, highlighting its key features and benefits.", "Product 106", 106f, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a44203ca-cef5-4491-b8dd-6ec29c6c8b85"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7909), "A brief description of the product, highlighting its key features and benefits.", "Product 217", 217f, 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4e71078-f28c-4962-9cf8-7cbfea014414"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7684), "A brief description of the product, highlighting its key features and benefits.", "Product 142", 142f, 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8695cb0-1a8c-4ae4-a4ad-d331fd4ea22b"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7727), "A brief description of the product, highlighting its key features and benefits.", "Product 159", 159f, 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9877776-0d53-43e9-8929-8ca0d1208a16"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7423), "A brief description of the product, highlighting its key features and benefits.", "Product 43", 43f, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa063d15-45dc-45c0-8275-d6804b76374c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7471), "A brief description of the product, highlighting its key features and benefits.", "Product 71", 71f, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aaaf3a7a-6d25-4c11-b95e-c21211134aad"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7878), "A brief description of the product, highlighting its key features and benefits.", "Product 206", 206f, 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab321a5f-4814-48f4-8f09-a1319b5b7092"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7424), "A brief description of the product, highlighting its key features and benefits.", "Product 44", 44f, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab7e3a41-a618-4662-b28d-e2d8e2cbc0df"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7636), "A brief description of the product, highlighting its key features and benefits.", "Product 134", 134f, 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aba7f9bc-c400-4354-8d56-c7d5441e3fee"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8058), "A brief description of the product, highlighting its key features and benefits.", "Product 270", 270f, 270, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad227d71-cf23-46e0-8f07-e31855c4057a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7979), "A brief description of the product, highlighting its key features and benefits.", "Product 243", 243f, 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad8dab28-11d7-4ccd-ada0-db0de6893c95"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7468), "A brief description of the product, highlighting its key features and benefits.", "Product 69", 69f, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ade5fc6d-9e46-4a81-bdb6-d0942847f341"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7412), "A brief description of the product, highlighting its key features and benefits.", "Product 37", 37f, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af5d9beb-a460-43d4-afc9-3514754b1cfd"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7857), "A brief description of the product, highlighting its key features and benefits.", "Product 198", 198f, 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("afd28899-23c0-4932-8d7b-67f4e4176015"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7399), "A brief description of the product, highlighting its key features and benefits.", "Product 30", 30f, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1aed93b-a915-4591-96ed-8dd568a19d84"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7965), "A brief description of the product, highlighting its key features and benefits.", "Product 238", 238f, 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b239f9cb-42f9-4d41-b0e8-f8dbdb3849ef"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7637), "A brief description of the product, highlighting its key features and benefits.", "Product 135", 135f, 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b31fec00-e633-4a41-86c8-ad2ea16fb633"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8089), "A brief description of the product, highlighting its key features and benefits.", "Product 288", 288f, 288, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b36e7ac2-1991-4573-8ffd-56e7e3075848"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7944), "A brief description of the product, highlighting its key features and benefits.", "Product 230", 230f, 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3afad89-9067-4084-afe5-dff5c4af556f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7974), "A brief description of the product, highlighting its key features and benefits.", "Product 241", 241f, 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3e52a2f-b763-421a-b82f-94fd99878139"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7470), "A brief description of the product, highlighting its key features and benefits.", "Product 70", 70f, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4efd66a-85ad-4a49-8cdd-6bd075cd00b9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7714), "A brief description of the product, highlighting its key features and benefits.", "Product 153", 153f, 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b517d839-8d2d-424d-90b9-72a0cb6ddc53"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7401), "A brief description of the product, highlighting its key features and benefits.", "Product 31", 31f, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5e12802-270a-4c42-bc3e-64ffaaf97613"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7595), "A brief description of the product, highlighting its key features and benefits.", "Product 111", 111f, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7421db9-0202-4fa6-a021-112a6ba63b8d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7578), "A brief description of the product, highlighting its key features and benefits.", "Product 101", 101f, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b83e369a-804e-42ac-9b4b-ea9e673341a2"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7897), "A brief description of the product, highlighting its key features and benefits.", "Product 213", 213f, 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ba19c183-9458-4c7f-88d9-a5873399e357"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7622), "A brief description of the product, highlighting its key features and benefits.", "Product 126", 126f, 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bab45cdb-b5a2-49fb-9b7d-aa5746e11ccd"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7845), "A brief description of the product, highlighting its key features and benefits.", "Product 193", 193f, 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb789b67-7005-4828-967a-ff3449cb3773"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7758), "A brief description of the product, highlighting its key features and benefits.", "Product 170", 170f, 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bde04654-6016-4aa3-87d4-09f16119d271"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7338), "A brief description of the product, highlighting its key features and benefits.", "Product 16", 16f, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be1f732f-8a0f-4053-a5f3-55e8847a193c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7321), "A brief description of the product, highlighting its key features and benefits.", "Product 7", 7f, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bfa22996-5b2a-4a66-aec4-a79b249be4ee"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7467), "A brief description of the product, highlighting its key features and benefits.", "Product 68", 68f, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c01a032c-9e28-48d7-bd8f-2a04ca293f1d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7586), "A brief description of the product, highlighting its key features and benefits.", "Product 105", 105f, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c18d63f8-21cd-4355-9488-d96e1591ec56"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8017), "A brief description of the product, highlighting its key features and benefits.", "Product 248", 248f, 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4fe56e7-8c45-4fa6-ae4b-0b53d1f93949"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7760), "A brief description of the product, highlighting its key features and benefits.", "Product 171", 171f, 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6404149-83a5-4294-8322-f3a7b6337094"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7335), "A brief description of the product, highlighting its key features and benefits.", "Product 14", 14f, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6b2e2de-1c6b-40b8-8b85-e4f8aacd0729"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7953), "A brief description of the product, highlighting its key features and benefits.", "Product 233", 233f, 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c74c1ab5-ae9b-4486-a309-bf7f1b015515"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8055), "A brief description of the product, highlighting its key features and benefits.", "Product 268", 268f, 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c844711d-f217-4525-b066-8f8def290154"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7769), "A brief description of the product, highlighting its key features and benefits.", "Product 175", 175f, 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c868da54-50e3-48ab-894e-1f456511236e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7454), "A brief description of the product, highlighting its key features and benefits.", "Product 61", 61f, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8baf2fa-a991-4648-8d97-352ae9134eed"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7420), "A brief description of the product, highlighting its key features and benefits.", "Product 41", 41f, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9ffc819-d1f4-48f0-9a5f-f515b0f5cc8f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7567), "A brief description of the product, highlighting its key features and benefits.", "Product 95", 95f, 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb9e1a91-2807-455c-a1cc-891a9c341c11"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7332), "A brief description of the product, highlighting its key features and benefits.", "Product 12", 12f, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cdbdf9cb-18d1-40ce-ad1d-9dc9134c0702"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7852), "A brief description of the product, highlighting its key features and benefits.", "Product 196", 196f, 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d025e4d0-6d3a-4210-b43a-2f86057dad9e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8045), "A brief description of the product, highlighting its key features and benefits.", "Product 262", 262f, 262, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0296082-b1f2-411e-b519-818644d684f7"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7572), "A brief description of the product, highlighting its key features and benefits.", "Product 97", 97f, 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d029e58f-0667-4ee0-9877-11fba0b577cf"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7331), "A brief description of the product, highlighting its key features and benefits.", "Product 11", 11f, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d047c3b4-f0ec-4fc9-8693-448e008dd639"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7709), "A brief description of the product, highlighting its key features and benefits.", "Product 152", 152f, 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d055bf9f-1561-4e5b-88df-cd8294892453"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7559), "A brief description of the product, highlighting its key features and benefits.", "Product 90", 90f, 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d15f2074-aca9-41f5-8bde-7d5179f59c5d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8083), "A brief description of the product, highlighting its key features and benefits.", "Product 284", 284f, 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2070cf0-6b9c-48c2-a413-da56510d1745"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7716), "A brief description of the product, highlighting its key features and benefits.", "Product 154", 154f, 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2357980-2187-4067-a462-4ed0d11d9628"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8071), "A brief description of the product, highlighting its key features and benefits.", "Product 277", 277f, 277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2781938-6b4e-40db-958c-9d038089642a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7346), "A brief description of the product, highlighting its key features and benefits.", "Product 20", 20f, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2a15eea-1ed4-47c4-a5a9-b76888f72a60"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7605), "A brief description of the product, highlighting its key features and benefits.", "Product 116", 116f, 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2e0c034-3c71-43f0-aeda-f83ec65b4e28"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7970), "A brief description of the product, highlighting its key features and benefits.", "Product 240", 240f, 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3cc69a8-1094-4ff1-ac7e-1ed38c4b49d1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8097), "A brief description of the product, highlighting its key features and benefits.", "Product 292", 292f, 292, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3e4cd72-6a1a-4578-b6a8-58e8da4d148c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8099), "A brief description of the product, highlighting its key features and benefits.", "Product 293", 293f, 293, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d45be847-509e-4655-8499-acaf28b438bb"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8046), "A brief description of the product, highlighting its key features and benefits.", "Product 263", 263f, 263, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5798089-d5e2-41e3-9197-21495bbb82b9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7631), "A brief description of the product, highlighting its key features and benefits.", "Product 131", 131f, 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5c8f5de-13a8-4ed2-918f-178d14791398"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7700), "A brief description of the product, highlighting its key features and benefits.", "Product 148", 148f, 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e31ca8-8bd5-4bf4-8df7-64d78bae4b6b"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7550), "A brief description of the product, highlighting its key features and benefits.", "Product 85", 85f, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d68e3c20-e62b-4985-9971-920f5c5d0157"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8026), "A brief description of the product, highlighting its key features and benefits.", "Product 251", 251f, 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6ef3d4a-f074-42f1-b0a3-807fad22bc12"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7926), "A brief description of the product, highlighting its key features and benefits.", "Product 224", 224f, 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7901055-9e0f-47b5-9ff7-5f4c32d2af47"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8023), "A brief description of the product, highlighting its key features and benefits.", "Product 249", 249f, 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d79d1d56-8971-4eca-88d1-0afc0415d51e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7421), "A brief description of the product, highlighting its key features and benefits.", "Product 42", 42f, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d79de484-b12d-4746-b0a0-153569583b11"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7355), "A brief description of the product, highlighting its key features and benefits.", "Product 25", 25f, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d972c587-7509-41e7-ae45-26f37da6ac39"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7730), "A brief description of the product, highlighting its key features and benefits.", "Product 160", 160f, 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d997d42c-f741-4812-ac25-ebc7103fbd8b"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7318), "A brief description of the product, highlighting its key features and benefits.", "Product 5", 5f, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9aae037-30dd-4dc4-b3c6-f807ae26a66f"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7672), "A brief description of the product, highlighting its key features and benefits.", "Product 137", 137f, 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9d9ddc7-0e19-4a38-9b43-90f96e17e9af"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7464), "A brief description of the product, highlighting its key features and benefits.", "Product 66", 66f, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da32ad32-81f2-444f-8a61-489f18a6ae92"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8088), "A brief description of the product, highlighting its key features and benefits.", "Product 287", 287f, 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("daf2411d-3e62-40a8-819e-de8bcb4ef13c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8085), "A brief description of the product, highlighting its key features and benefits.", "Product 285", 285f, 285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db2ea6fd-5d2f-4041-a52e-058a7286fcfd"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7429), "A brief description of the product, highlighting its key features and benefits.", "Product 47", 47f, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db85b53e-bae2-4f79-9662-ed7a75ea50e4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7941), "A brief description of the product, highlighting its key features and benefits.", "Product 229", 229f, 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dbd9f2bd-df99-4ec1-a036-c0b78f338519"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7453), "A brief description of the product, highlighting its key features and benefits.", "Product 60", 60f, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd5e2709-fda5-4f95-89fd-3c8084754488"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7548), "A brief description of the product, highlighting its key features and benefits.", "Product 84", 84f, 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ded1fe59-a047-4a89-b0cd-5a2c89995ff9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7747), "A brief description of the product, highlighting its key features and benefits.", "Product 166", 166f, 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("df5338c3-8b6a-4aca-9987-cdc355fe1cbe"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7765), "A brief description of the product, highlighting its key features and benefits.", "Product 173", 173f, 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e150a8ee-b509-474a-9f41-3ae71658c6fd"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8025), "A brief description of the product, highlighting its key features and benefits.", "Product 250", 250f, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1d56ab2-987e-4f24-b2ad-6488d1615fb0"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7674), "A brief description of the product, highlighting its key features and benefits.", "Product 138", 138f, 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e26e7404-69f9-4190-9888-291b950b21ec"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7602), "A brief description of the product, highlighting its key features and benefits.", "Product 114", 114f, 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2b03b8e-65ff-40e2-9281-ac6ca25657ab"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7357), "A brief description of the product, highlighting its key features and benefits.", "Product 26", 26f, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e319b691-cc84-4dc0-a5e8-1a552f46cdd1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7835), "A brief description of the product, highlighting its key features and benefits.", "Product 190", 190f, 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e43ffcc3-99a4-45b1-afff-2599a15414af"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7798), "A brief description of the product, highlighting its key features and benefits.", "Product 186", 186f, 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e64159fa-a1d8-4a40-b9e2-5e1b404d5d4d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7890), "A brief description of the product, highlighting its key features and benefits.", "Product 210", 210f, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6604263-5837-44a8-90b0-f686f2652623"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8094), "A brief description of the product, highlighting its key features and benefits.", "Product 290", 290f, 290, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6c70b61-0fde-4b96-8459-da1baaeb1ba8"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7936), "A brief description of the product, highlighting its key features and benefits.", "Product 227", 227f, 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7533ad8-37fe-4b06-aff1-50c2b2199f4c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7948), "A brief description of the product, highlighting its key features and benefits.", "Product 232", 232f, 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9e21ba1-bf04-4fce-a6ea-888715c7f0b1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7693), "A brief description of the product, highlighting its key features and benefits.", "Product 145", 145f, 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eae605fc-7bd9-4da0-914c-e47b391cba8d"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7955), "A brief description of the product, highlighting its key features and benefits.", "Product 234", 234f, 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec8da7f1-60ad-40e1-b63f-5298e6e9bfd4"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7569), "A brief description of the product, highlighting its key features and benefits.", "Product 96", 96f, 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec90bb7d-a73e-49c3-8e03-79a19ef4b8d2"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7343), "A brief description of the product, highlighting its key features and benefits.", "Product 18", 18f, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef17ec80-d4de-4bc2-a6f4-75cf8ffa3c29"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7476), "A brief description of the product, highlighting its key features and benefits.", "Product 73", 73f, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f0c040ae-b5a5-4996-833c-9a43bef32ade"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7702), "A brief description of the product, highlighting its key features and benefits.", "Product 149", 149f, 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f0cab2d3-cbf2-47d4-8ae0-186bef33884e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7919), "A brief description of the product, highlighting its key features and benefits.", "Product 221", 221f, 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f16aa624-e7e8-42a8-a6dd-a63599c229c9"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7451), "A brief description of the product, highlighting its key features and benefits.", "Product 59", 59f, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1be4a36-e8ec-449f-bfca-dce82f09d49e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8075), "A brief description of the product, highlighting its key features and benefits.", "Product 280", 280f, 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f29287d9-52e7-4ace-8d1d-9b2b4f3044fc"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7479), "A brief description of the product, highlighting its key features and benefits.", "Product 75", 75f, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f297a332-18f7-4206-a571-a33002e7d0ee"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7776), "A brief description of the product, highlighting its key features and benefits.", "Product 177", 177f, 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f31d9374-d6ee-4bb3-a78a-4bf921588eaf"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8048), "A brief description of the product, highlighting its key features and benefits.", "Product 264", 264f, 264, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f332b8c7-be69-4f02-b4e1-22db8ae9dc18"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7902), "A brief description of the product, highlighting its key features and benefits.", "Product 215", 215f, 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3345f2b-4572-4114-b14b-01207a7c05da"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8102), "A brief description of the product, highlighting its key features and benefits.", "Product 295", 295f, 295, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3469ccf-2df5-4379-a010-09cc1fb63a77"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7407), "A brief description of the product, highlighting its key features and benefits.", "Product 34", 34f, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3ce8ebc-7e35-45c7-843d-1667848cfb99"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8082), "A brief description of the product, highlighting its key features and benefits.", "Product 283", 283f, 283, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3cf9169-2e0d-4a65-86f6-b4e572633607"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7679), "A brief description of the product, highlighting its key features and benefits.", "Product 140", 140f, 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f447de6d-be02-414d-a282-2368cff7aa6c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7342), "A brief description of the product, highlighting its key features and benefits.", "Product 17", 17f, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f53fc8d7-978c-4c9e-a92b-5b7b605fb15c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7837), "A brief description of the product, highlighting its key features and benefits.", "Product 191", 191f, 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6b524e1-5eaa-4a22-a6b0-c5924be58143"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7620), "A brief description of the product, highlighting its key features and benefits.", "Product 125", 125f, 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f7097b98-614e-4470-a310-0944a44096c5"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7315), "A brief description of the product, highlighting its key features and benefits.", "Product 3", 3f, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f7567b47-82fb-44c8-a16e-14dba083b845"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7686), "A brief description of the product, highlighting its key features and benefits.", "Product 143", 143f, 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9c61312-c724-4d48-960f-a28af58a6339"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7409), "A brief description of the product, highlighting its key features and benefits.", "Product 35", 35f, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa640071-018d-436f-b41f-17e21e048b5a"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7780), "A brief description of the product, highlighting its key features and benefits.", "Product 179", 179f, 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("face70fc-5b1e-4e07-8df4-a74232b85243"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7739), "A brief description of the product, highlighting its key features and benefits.", "Product 163", 163f, 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb07db00-9258-49fb-8520-a6d59ef5cf63"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7887), "A brief description of the product, highlighting its key features and benefits.", "Product 209", 209f, 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb9445a2-26a9-464a-944f-9359fe9788c0"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7862), "A brief description of the product, highlighting its key features and benefits.", "Product 200", 200f, 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc7537b4-0498-4c31-a929-40b5b59d3369"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7840), "A brief description of the product, highlighting its key features and benefits.", "Product 192", 192f, 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fd5b614d-859c-4b3b-8af8-fe7ff40dfa22"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8057), "A brief description of the product, highlighting its key features and benefits.", "Product 269", 269f, 269, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("feaaf4a6-82e8-4674-a860-47ee657bf3ff"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7465), "A brief description of the product, highlighting its key features and benefits.", "Product 67", 67f, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff3d8185-5736-43ae-930b-5ba0f7f46a2e"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7619), "A brief description of the product, highlighting its key features and benefits.", "Product 124", 124f, 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff428dc9-669a-4017-a8c5-323e9329c9d1"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(8130), "A brief description of the product, highlighting its key features and benefits.", "Product 298", 298f, 298, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffe45bb8-ed48-49ba-8693-0155bc16814c"), new DateTime(2024, 11, 8, 19, 9, 54, 793, DateTimeKind.Utc).AddTicks(7847), "A brief description of the product, highlighting its key features and benefits.", "Product 194", 194f, 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

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
                name: "OrderProduct");

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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
