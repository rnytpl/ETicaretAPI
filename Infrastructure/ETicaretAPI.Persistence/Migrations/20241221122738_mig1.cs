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
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
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
                name: "Endpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionType = table.Column<string>(type: "text", nullable: false),
                    HttpType = table.Column<string>(type: "text", nullable: false),
                    Definition = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoints_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
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
                name: "AppRoleEndpoint",
                columns: table => new
                {
                    EndpointsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleEndpoint", x => new { x.EndpointsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_AppRoleEndpoint_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoleEndpoint_Endpoints_EndpointsId",
                        column: x => x.EndpointsId,
                        principalTable: "Endpoints",
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
                    { new Guid("06f98894-732c-4cb5-80e2-cc3b037805e1"), new DateTime(2024, 12, 21, 12, 27, 39, 45, DateTimeKind.Utc).AddTicks(9059), "A brief description of the product, highlighting its key features and benefits.", "Product 2", 2f, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("080f49d2-9e1b-4c5b-92b1-6e68c8797064"), new DateTime(2024, 12, 21, 12, 27, 46, 45, DateTimeKind.Utc).AddTicks(9084), "A brief description of the product, highlighting its key features and benefits.", "Product 9", 9f, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d1f3e7b-6291-44a6-ba65-8a6f7e558bd2"), new DateTime(2024, 12, 21, 12, 28, 23, 45, DateTimeKind.Utc).AddTicks(9232), "A brief description of the product, highlighting its key features and benefits.", "Product 46", 46f, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ee80f3e-d965-4a92-a164-6295e649ebe7"), new DateTime(2024, 12, 21, 12, 28, 6, 45, DateTimeKind.Utc).AddTicks(9133), "A brief description of the product, highlighting its key features and benefits.", "Product 29", 29f, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0fb40992-b702-499d-9a15-ef5d02063d1d"), new DateTime(2024, 12, 21, 12, 27, 52, 45, DateTimeKind.Utc).AddTicks(9102), "A brief description of the product, highlighting its key features and benefits.", "Product 15", 15f, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("111eebb3-74ba-4e92-81be-22a1af290d44"), new DateTime(2024, 12, 21, 12, 28, 18, 45, DateTimeKind.Utc).AddTicks(9224), "A brief description of the product, highlighting its key features and benefits.", "Product 41", 41f, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("14d90990-0d72-4068-a736-7512b655634f"), new DateTime(2024, 12, 21, 12, 28, 26, 45, DateTimeKind.Utc).AddTicks(9239), "A brief description of the product, highlighting its key features and benefits.", "Product 49", 49f, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1639b235-82e7-4410-92f1-5f4be2278994"), new DateTime(2024, 12, 21, 12, 28, 1, 45, DateTimeKind.Utc).AddTicks(9122), "A brief description of the product, highlighting its key features and benefits.", "Product 24", 24f, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27d257cc-326e-4072-94e1-899b8662c1ed"), new DateTime(2024, 12, 21, 12, 27, 54, 45, DateTimeKind.Utc).AddTicks(9106), "A brief description of the product, highlighting its key features and benefits.", "Product 17", 17f, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31e4946e-06ca-4978-858c-e497de0c5501"), new DateTime(2024, 12, 21, 12, 28, 22, 45, DateTimeKind.Utc).AddTicks(9230), "A brief description of the product, highlighting its key features and benefits.", "Product 45", 45f, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("37d831a7-8318-4c87-b133-4b3133a9cbae"), new DateTime(2024, 12, 21, 12, 28, 0, 45, DateTimeKind.Utc).AddTicks(9120), "A brief description of the product, highlighting its key features and benefits.", "Product 23", 23f, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("446a1ec5-baa9-40b3-8992-181d05138639"), new DateTime(2024, 12, 21, 12, 27, 55, 45, DateTimeKind.Utc).AddTicks(9108), "A brief description of the product, highlighting its key features and benefits.", "Product 18", 18f, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4981fc6c-9295-4af2-a0ea-d2d23352d25b"), new DateTime(2024, 12, 21, 12, 27, 57, 45, DateTimeKind.Utc).AddTicks(9112), "A brief description of the product, highlighting its key features and benefits.", "Product 20", 20f, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4bf97d69-54e4-4947-b138-6daea4f188a1"), new DateTime(2024, 12, 21, 12, 28, 14, 45, DateTimeKind.Utc).AddTicks(9215), "A brief description of the product, highlighting its key features and benefits.", "Product 37", 37f, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5015fdcf-078a-401f-8261-b4f4710d7d22"), new DateTime(2024, 12, 21, 12, 27, 40, 45, DateTimeKind.Utc).AddTicks(9060), "A brief description of the product, highlighting its key features and benefits.", "Product 3", 3f, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56e0226b-3c38-4ff3-b350-12365bd16da7"), new DateTime(2024, 12, 21, 12, 27, 42, 45, DateTimeKind.Utc).AddTicks(9064), "A brief description of the product, highlighting its key features and benefits.", "Product 5", 5f, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("630ffcba-1346-457c-8ffb-c1198f2f9a74"), new DateTime(2024, 12, 21, 12, 28, 20, 45, DateTimeKind.Utc).AddTicks(9227), "A brief description of the product, highlighting its key features and benefits.", "Product 43", 43f, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("722126c8-4c8d-4cc0-8435-2ac0548c855b"), new DateTime(2024, 12, 21, 12, 27, 44, 45, DateTimeKind.Utc).AddTicks(9080), "A brief description of the product, highlighting its key features and benefits.", "Product 7", 7f, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("741cdc91-7422-47f3-ae69-09983686ac9c"), new DateTime(2024, 12, 21, 12, 27, 41, 45, DateTimeKind.Utc).AddTicks(9062), "A brief description of the product, highlighting its key features and benefits.", "Product 4", 4f, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b0d3322-9ee0-4665-9f94-9531fd5651d1"), new DateTime(2024, 12, 21, 12, 28, 8, 45, DateTimeKind.Utc).AddTicks(9139), "A brief description of the product, highlighting its key features and benefits.", "Product 31", 31f, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c4972d0-203c-4fd7-9caa-f40c4b0471c3"), new DateTime(2024, 12, 21, 12, 27, 48, 45, DateTimeKind.Utc).AddTicks(9091), "A brief description of the product, highlighting its key features and benefits.", "Product 11", 11f, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7d1bb5a3-cd16-4d2d-90b1-c9d29b2c6501"), new DateTime(2024, 12, 21, 12, 28, 27, 45, DateTimeKind.Utc).AddTicks(9240), "A brief description of the product, highlighting its key features and benefits.", "Product 50", 50f, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e98e120-2abf-4eaa-b3ef-bdf40afc29bc"), new DateTime(2024, 12, 21, 12, 27, 56, 45, DateTimeKind.Utc).AddTicks(9110), "A brief description of the product, highlighting its key features and benefits.", "Product 19", 19f, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("82068b35-1f97-430f-9bb3-bcc218c97a0a"), new DateTime(2024, 12, 21, 12, 27, 51, 45, DateTimeKind.Utc).AddTicks(9097), "A brief description of the product, highlighting its key features and benefits.", "Product 14", 14f, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("82643079-3647-42a5-8fe8-c013d88602b8"), new DateTime(2024, 12, 21, 12, 27, 59, 45, DateTimeKind.Utc).AddTicks(9116), "A brief description of the product, highlighting its key features and benefits.", "Product 22", 22f, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86beb608-871a-4105-848d-318f8847cfe4"), new DateTime(2024, 12, 21, 12, 27, 47, 45, DateTimeKind.Utc).AddTicks(9088), "A brief description of the product, highlighting its key features and benefits.", "Product 10", 10f, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("87006eca-dbfd-489f-b015-50564934fae4"), new DateTime(2024, 12, 21, 12, 28, 15, 45, DateTimeKind.Utc).AddTicks(9217), "A brief description of the product, highlighting its key features and benefits.", "Product 38", 38f, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("916dca98-1c3b-47c2-9fac-51c7fe91a464"), new DateTime(2024, 12, 21, 12, 28, 9, 45, DateTimeKind.Utc).AddTicks(9207), "A brief description of the product, highlighting its key features and benefits.", "Product 32", 32f, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98c43b7d-a4de-4961-9c91-30bad7fb4456"), new DateTime(2024, 12, 21, 12, 28, 12, 45, DateTimeKind.Utc).AddTicks(9212), "A brief description of the product, highlighting its key features and benefits.", "Product 35", 35f, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a91778b7-f074-45d6-afe9-f97249a7ecc2"), new DateTime(2024, 12, 21, 12, 28, 2, 45, DateTimeKind.Utc).AddTicks(9125), "A brief description of the product, highlighting its key features and benefits.", "Product 25", 25f, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac9bb4b9-9f25-4847-874f-126c4f1f5e49"), new DateTime(2024, 12, 21, 12, 28, 11, 45, DateTimeKind.Utc).AddTicks(9210), "A brief description of the product, highlighting its key features and benefits.", "Product 34", 34f, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b03bf9a7-c9e9-4357-b686-dee3360c7a3c"), new DateTime(2024, 12, 21, 12, 27, 49, 45, DateTimeKind.Utc).AddTicks(9093), "A brief description of the product, highlighting its key features and benefits.", "Product 12", 12f, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0a59ffa-1560-462b-9f32-12d0c888fbea"), new DateTime(2024, 12, 21, 12, 28, 4, 45, DateTimeKind.Utc).AddTicks(9129), "A brief description of the product, highlighting its key features and benefits.", "Product 27", 27f, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b570f014-132b-48de-a065-d35700eee1fb"), new DateTime(2024, 12, 21, 12, 28, 21, 45, DateTimeKind.Utc).AddTicks(9229), "A brief description of the product, highlighting its key features and benefits.", "Product 44", 44f, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ba7802f6-a7a5-4945-8f44-1866ad8768cc"), new DateTime(2024, 12, 21, 12, 28, 24, 45, DateTimeKind.Utc).AddTicks(9235), "A brief description of the product, highlighting its key features and benefits.", "Product 47", 47f, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c12a18fe-9f8f-43ca-8f21-0387907f1c8d"), new DateTime(2024, 12, 21, 12, 28, 19, 45, DateTimeKind.Utc).AddTicks(9225), "A brief description of the product, highlighting its key features and benefits.", "Product 42", 42f, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c26c5f3a-a852-42aa-887d-819b1dbc2f8d"), new DateTime(2024, 12, 21, 12, 28, 7, 45, DateTimeKind.Utc).AddTicks(9135), "A brief description of the product, highlighting its key features and benefits.", "Product 30", 30f, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4502854-a40b-4fcb-8387-71baf888cdaa"), new DateTime(2024, 12, 21, 12, 27, 53, 45, DateTimeKind.Utc).AddTicks(9104), "A brief description of the product, highlighting its key features and benefits.", "Product 16", 16f, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca12bca4-027f-40b6-b134-bbdb246afbb2"), new DateTime(2024, 12, 21, 12, 28, 25, 45, DateTimeKind.Utc).AddTicks(9237), "A brief description of the product, highlighting its key features and benefits.", "Product 48", 48f, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb398ecc-e88a-4fee-b218-18ce30947c8a"), new DateTime(2024, 12, 21, 12, 28, 13, 45, DateTimeKind.Utc).AddTicks(9214), "A brief description of the product, highlighting its key features and benefits.", "Product 36", 36f, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cf7608a4-fde3-46f2-9514-76a975e5bc5f"), new DateTime(2024, 12, 21, 12, 27, 43, 45, DateTimeKind.Utc).AddTicks(9065), "A brief description of the product, highlighting its key features and benefits.", "Product 6", 6f, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9bb563a-c4c4-4a9b-9339-231a0d292cfd"), new DateTime(2024, 12, 21, 12, 27, 50, 45, DateTimeKind.Utc).AddTicks(9095), "A brief description of the product, highlighting its key features and benefits.", "Product 13", 13f, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da2f1808-0ca8-44ee-90ef-a9cbdd90d1ca"), new DateTime(2024, 12, 21, 12, 28, 10, 45, DateTimeKind.Utc).AddTicks(9209), "A brief description of the product, highlighting its key features and benefits.", "Product 33", 33f, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd497706-e704-4113-a68f-63217fd8fd82"), new DateTime(2024, 12, 21, 12, 28, 3, 45, DateTimeKind.Utc).AddTicks(9127), "A brief description of the product, highlighting its key features and benefits.", "Product 26", 26f, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2133344-417f-4633-9aea-04c5d1da5dba"), new DateTime(2024, 12, 21, 12, 27, 45, 45, DateTimeKind.Utc).AddTicks(9082), "A brief description of the product, highlighting its key features and benefits.", "Product 8", 8f, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f150917b-3e0c-4d04-a168-27f16f3f7d24"), new DateTime(2024, 12, 21, 12, 28, 16, 45, DateTimeKind.Utc).AddTicks(9220), "A brief description of the product, highlighting its key features and benefits.", "Product 39", 39f, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f27e0768-f401-4c6c-82fb-f323ad81db4b"), new DateTime(2024, 12, 21, 12, 28, 17, 45, DateTimeKind.Utc).AddTicks(9222), "A brief description of the product, highlighting its key features and benefits.", "Product 40", 40f, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5b39d61-79cd-4fad-97e4-ed013ed83185"), new DateTime(2024, 12, 21, 12, 28, 28, 45, DateTimeKind.Utc).AddTicks(9242), "A brief description of the product, highlighting its key features and benefits.", "Product 51", 51f, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8982a65-8828-4715-b17b-496da729ef9a"), new DateTime(2024, 12, 21, 12, 27, 38, 45, DateTimeKind.Utc).AddTicks(9051), "A brief description of the product, highlighting its key features and benefits.", "Product 1", 1f, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fbde78a1-e189-42d7-b751-ffd334f1620e"), new DateTime(2024, 12, 21, 12, 27, 58, 45, DateTimeKind.Utc).AddTicks(9114), "A brief description of the product, highlighting its key features and benefits.", "Product 21", 21f, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fcdcac25-d005-408b-87c2-823d82a18d43"), new DateTime(2024, 12, 21, 12, 28, 5, 45, DateTimeKind.Utc).AddTicks(9131), "A brief description of the product, highlighting its key features and benefits.", "Product 28", 28f, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleEndpoint_RolesId",
                table: "AppRoleEndpoint",
                column: "RolesId");

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
                name: "IX_Endpoints_MenuId",
                table: "Endpoints",
                column: "MenuId");

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
                name: "AppRoleEndpoint");

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
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
