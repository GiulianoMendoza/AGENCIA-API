using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buys",
                columns: table => new
                {
                    OrderbuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateStar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buys", x => x.OrderbuyId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    dealerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cuit = table.Column<int>(type: "int", nullable: false),
                    ReasonSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameProv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.dealerID);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "Techns",
                columns: table => new
                {
                    TecnicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techns", x => x.TecnicoId);
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    MotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotoName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockMin = table.Column<int>(type: "int", nullable: false),
                    StockMax = table.Column<int>(type: "int", nullable: false),
                    StockCurrent = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineNum = table.Column<int>(type: "int", nullable: false),
                    ChasisNum = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cylinder = table.Column<int>(type: "int", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moto", x => x.MotoId);
                    table.ForeignKey(
                        name: "FK_Moto_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleMoto",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    Mot = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyOrderbuyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleMoto", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_SaleMoto_Moto_Mot",
                        column: x => x.Mot,
                        principalTable: "Moto",
                        principalColumn: "MotoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleMoto_Sale_Sale",
                        column: x => x.Sale,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleMoto_buys_BuyOrderbuyId",
                        column: x => x.BuyOrderbuyId,
                        principalTable: "buys",
                        principalColumn: "OrderbuyId");
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    TurnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Motoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeService = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.TurnId);
                    table.ForeignKey(
                        name: "FK_Turns_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turns_Moto_Motoid",
                        column: x => x.Motoid,
                        principalTable: "Moto",
                        principalColumn: "MotoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turns_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turns_Techns_TechnId",
                        column: x => x.TechnId,
                        principalTable: "Techns",
                        principalColumn: "TecnicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "CUBS" },
                    { 2, "SCOOTERS" },
                    { 3, "CALLE" },
                    { 4, "ENDURO" },
                    { 5, "TOURING" },
                    { 6, "NAKED" },
                    { 7, "RETRO" },
                    { 8, "DEPORTIVAS" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Addres", "Dni", "Email", "Locality", "Name", "Phone", "Province", "Surname" },
                values: new object[] { new Guid("9815e175-2967-4200-93e1-6088ba9387d9"), "MZA30", 41539440, "Giuliano@gmail.com", "CLAYPOLE", "Giuliano", 1141462757, "BS AS", "Mendoza" });

            migrationBuilder.InsertData(
                table: "Moto",
                columns: new[] { "MotoId", "Age", "CategoryId", "ChasisNum", "Cylinder", "Description", "Discount", "EngineNum", "Mark", "Model", "MotoName", "Price", "StockCurrent", "StockMax", "StockMin", "imageUrl" },
                values: new object[,]
                {
                    { new Guid("02e07563-86f1-4d59-aa22-0e804e5359e5"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1235), 8, 87654321, 1000, "La YAMAHA-R1 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 1000cc, 4 tiempos.", 0, 12345678, "YAMAHA", "R1", "YAMAHA-R1", 24000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723496_e9fd31c1ce_w.jpg" },
                    { new Guid("0d5aa725-4416-437c-a1e2-977aa6598200"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1233), 8, 87654321, 110, "La KAWASAKI-NINJA650 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 650cc, 4 tiempos.", 0, 12345678, "KAWASAKI", "NINJA650", "KAWASAKI-NINJA650", 21000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052966093_2668c66a23_z.jpg" },
                    { new Guid("0f578ae9-87f8-4e67-82dc-0ab6e31fa1ec"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1209), 7, 87654321, 400, "La BENELLI-IMPERIALE400 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 400cc, 4 tiempos.", 0, 12345678, "BENELLI", "IMPERIALE400", "BENELLI-IMPERIALE400", 7420000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051852632_abbe287943.jpg" },
                    { new Guid("181f6247-a775-46af-bc87-b3d2a3f79c6e"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1216), 7, 87654321, 150, "La ZANELLA-CCECATOR150 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 150cc, 4 tiempos.", 0, 12345678, "ZANELLA", "CCECATOR150", "ZANELLA-CCECATOR150 ", 2000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053170900_ac988f9146.jpg" },
                    { new Guid("1fd2aef3-9c02-46f5-8f66-e84c4b906f65"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1185), 6, 87654321, 125, "La HONDA-CB125FTWISTER cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 125cc, 4 tiempos.", 0, 12345678, "HONDA", "CB125FTWISTER", "HONDA-CB125FTWISTER", 3200000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051852407_4ce9eaf366_b.jpg" },
                    { new Guid("20658076-8f40-4243-a58d-c957a9dc4215"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1117), 2, 87654321, 125, "La YAMAHA-RAYZR125 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 125cc, 4 tiempos.", 0, 12345678, "YAMAHA", "RAYZR125", "YAMAHA-RAYZR125", 4000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051853037_ed7616af9b_b.jpg" },
                    { new Guid("22c89d1e-f8da-472b-8254-f55f8831063b"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1224), 8, 87654321, 650, "La HONDA-CBR650R cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 650cc, 4 tiempos.", 0, 12345678, "HONDA", "CBR650R", "HONDA-CBR650R", 12820000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051851657_5db0101ba3_b.jpg" },
                    { new Guid("255b079a-7221-4416-a8ec-b525e278d901"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1203), 6, 87654321, 1000, "La YAMAHA-MT10 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 1000cc, 4 tiempos.", 0, 12345678, "YAMAHA", "MT10", "YAMAHA-MT10", 27000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053049024_a643ceec91_b.jpg" },
                    { new Guid("28dffafe-6b57-4593-9822-cf6abe58e827"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1226), 8, 87654321, 1000, "La HONDA-CBR1000RR cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 1000cc, 4 tiempos.", 0, 12345678, "HONDA", "CBR1000RR", "HONDA-CBR1000RR", 48000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053169895_f58b5a1c8c_b.jpg" },
                    { new Guid("2b0f13d9-8201-466b-9005-9de6d932a714"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1230), 8, 87654321, 1000, "La HONDA-CBR1000SP cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 1000cc, 4 tiempos.", 20, 12345678, "HONDA", "CBR1000SP", "HONDA-CBR1000SP", 48000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052966098_41a8786f3c_b.jpg" },
                    { new Guid("2d6a3a58-0cac-4fe1-9888-57f18e50380d"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1097), 1, 87654321, 110, "La GILERA-SMASHX125 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 5, 12345678, "GILERA", "SMASHX125", "GILERA-SMASHX125", 2300000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052965798_d10760455e_c.jpg" },
                    { new Guid("2e79f178-c74e-4fef-92fc-209425a64386"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1115), 2, 87654321, 155, "La YAMAHA-NMAXCONNECTED155 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 155cc, 4 tiempos.", 0, 12345678, "YAMAHA", "NMAXCONNECTED155", "YAMAHA-NMAXCONNECTED155", 7600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052967493_6727664557_b.jpg" },
                    { new Guid("2e960f49-574f-49c2-ae82-2392322f00c9"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1162), 5, 87654321, 500, "La HONDA-CB500X cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 500cc, 4 tiempos.", 5, 12345678, "HONDA", "CB500X", "HONDA-CB500X", 19000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052725166_7675f4cf13_b.jpg" },
                    { new Guid("2f67e34a-b3c3-4ab5-a365-bbb4bad67054"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1171), 5, 87654321, 750, "La HONDA-NC750X cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 750cc, 4 tiempos.", 0, 12345678, "HONDA", "NC750X", "HONDA-NC750X", 21600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052967743_1cf44bbee9_b.jpg" },
                    { new Guid("3a9b02d0-a8ec-4bc3-a35a-a860c3d3ee12"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1049), 1, 87654321, 110, "La CORVEN-ENERGYTUNNING110 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 0, 12345678, "CORVEN", "ENERGYTUNNING110", "CORVEN-ENERGYTUNNING110", 1900000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052965873_54860b1c3b_z.jpg" },
                    { new Guid("3aeb31d0-f52e-4e77-a043-1e9f332d8939"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1126), 3, 87654321, 110, "La ROUSER-NS160TD cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 110cc, 4 tiempos.", 0, 12345678, "ROUSER", "NS160TD", "ROUSER-NS160TD", 3600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723066_b3a6736e08_b.jpg" },
                    { new Guid("3cf08928-9c42-4671-846b-a87261a093b0"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1200), 6, 87654321, 850, "La YAMAHA-MT09 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 850cc, 4 tiempos.", 0, 12345678, "YAMAHA", "MT09", "YAMAHA-MT09", 16500000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053049049_df5a0149ed_b.jpg" },
                    { new Guid("4bf0b04c-0e7e-4ef2-bba0-3e1c19d3dc51"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1140), 4, 87654321, 450, "La HONDA-450R cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 450cc, 4 tiempos.", 0, 12345678, "HONDA", "450R", "HONDA-450R", 24000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053170115_0be57ee08d_c.jpg" },
                    { new Guid("4eb1e975-ca93-4789-9b8e-b3198b0a0ea7"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1166), 5, 87654321, 1100, "La HONDA-CRF1100 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 1100cc, 4 tiempos.", 0, 12345678, "HONDA", "CRF1100", "HONDA-CRF1100", 55200000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052725126_ef4c4f2276_b.jpg" },
                    { new Guid("52a84943-29d7-49c6-b832-a1bf4e581505"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1131), 3, 87654321, 250, "La YAMAHA-FZ25ABS cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 250cc, 4 tiempos.", 0, 12345678, "YAMAHA", "FZ25ABS", "YAMAHA-FZ25ABS", 6800000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051851202_4cf9d0daa1_b.jpg" },
                    { new Guid("572c8c2b-c5e2-429c-8882-bade8f511e2a"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1151), 4, 87654321, 450, "La YAMAHA-NEWWR450F cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 450cc, 4 tiempos.", 0, 12345678, "YAMAHA", "NEWWR450F", "YAMAHA-NEWWR450F", 11400100m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723811_cab777ec70_w.jpg" },
                    { new Guid("59a63083-1363-47d5-80ad-bdd555cfe891"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1147), 4, 87654321, 250, "La HONDA-CRF250RX cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 250cc, 4 tiempos.", 0, 12345678, "HONDA", "CRF250RX", "HONDA-CRF250RX", 22000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723786_8e28337d58_b.jpg" },
                    { new Guid("5edf0e4a-a3bc-4024-aae6-4c28200cf28a"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1144), 4, 87654321, 250, "La HONDA-CRF250R cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 250cc, 4 tiempos.", 0, 12345678, "HONDA", "CRF250R", "HONDA-CRF250R", 19000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051851832_ba8597d650_c.jpg" },
                    { new Guid("63779011-db36-4f0d-a29b-d85a043281e3"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1168), 5, 87654321, 1100, "La HONDA-CRF1100ADVENTURE cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 1100cc, 4 tiempos.", 0, 12345678, "HONDA", "CRF1100ADVENTURE", "HONDA-CRF1100ADVENTURE", 55200000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051853212_235e0bfe5d_b.jpg" },
                    { new Guid("67db922d-251d-4b83-be24-29af3ced9583"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1221), 7, 87654321, 150, "La ZANELLA-SAPUCAI150 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 150cc, 4 tiempos.", 0, 12345678, "ZANELLA", "SAPUCAI150", "ZANELLA-SAPUCAI150", 1849000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053049244_b9b7ebea2e.jpg" },
                    { new Guid("6e80b2ff-282f-4750-9d19-df6731cd446a"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1102), 2, 87654321, 125, "La HONDA-NEWELITE cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 125cc, 4 tiempos.", 0, 12345678, "HONDA", "NEWELITE", "HONDA-NEWELITE", 6600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052967503_31e3785e44_b.jpg" },
                    { new Guid("75f421ce-c806-4e83-922d-c4e823d7aa7e"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1191), 6, 87654321, 500, "La HONDA-CB500F cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 500cc, 4 tiempos.", 0, 12345678, "HONDA", "CB500F", "HONDA-CB500F", 18000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052966883_7069860413_z.jpg" },
                    { new Guid("7df8bedc-9215-48c7-8f58-3fe9f1c50c62"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1052), 1, 87654321, 110, "La COVERN-ENERGYBASE110 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 0, 12345678, "CORVEN", "ENERGYBASE110", "COVERN-ENERGYBASE110", 1450000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723341_e5952e81c9_z.jpg" },
                    { new Guid("7e3ad06b-515b-4751-95c0-38eb906fc078"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1240), 8, 87654321, 700, "La YAMAHA-R7 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 700cc, 4 tiempos.", 0, 12345678, "YAMAHA", "R7", "YAMAHA-R7", 9866000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723516_51ed4df75c_w.jpg" },
                    { new Guid("808e40d2-70f4-4b1a-9cc8-c9ea2a285602"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1175), 5, 87654321, 650, "La KAWASAKI-VERSYS650 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 650cc, 4 tiempos.", 0, 12345678, "KAWASAKI", "VERSYS650", "KAWASAKI-VERSYS650", 26400000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052967683_dbe595e46d_c.jpg" },
                    { new Guid("8605a13a-0baa-4ab6-8d49-a05c6943994f"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1188), 6, 87654321, 300, "La HONDA-CB300FTWISTER cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 300cc, 4 tiempos.", 10, 12345678, "HONDA", "CB300FTWISTER", "HONDA-CB300FTWISTER", 7890000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053170650_05f98b2d9a_b.jpg" },
                    { new Guid("873d9514-0c41-4e40-ba54-127f1a0a9db7"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1159), 4, 87654321, 450, "La YAMAHA-YZ450FX cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 450cc, 4 tiempos.", 0, 12345678, "YAMAHA", "YZ450FX", "YAMAHA-YZ450FX", 10000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051851792_51fc2a1f08_w.jpg" },
                    { new Guid("8df1bbca-2641-49f0-ad66-60451a12c124"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1219), 7, 87654321, 250, "La ZANELLA-CECCATOX250 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 250cc, 4 tiempos.", 0, 12345678, "ZANELLA", "CECCATOX250", "ZANELLA-CECCATOX250", 4600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052967153_21968c0114.jpg" },
                    { new Guid("95390e07-8f60-41be-8a59-49f9586e9858"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1055), 1, 87654321, 110, "La COVERN-MIRAGEFULL110 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 0, 12345678, "CORVEN", "MIRAGEFULL110", "COVERN-MIRAGEFULL110", 1090000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723361_bee58fba5d_b.jpg" },
                    { new Guid("999e7caa-6220-44be-a806-d6ef739d5aee"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1034), 1, 87654321, 110, "La CORVEN-ENERGYFULL110 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 0, 12345678, "CORVEN", "ENERGYFULL110", "CORVEN-ENERGYFULL110", 1599900m, 10, 20, 5, "https://live.staticflickr.com/65535/54053169650_a289468e65_c.jpg" },
                    { new Guid("9af5ddd9-9180-45dd-b6ee-d6b762fc80de"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1198), 6, 87654321, 700, "La YAMAHA-MT07 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 700cc, 4 tiempos.", 0, 12345678, "YAMAHA", "MT07", "YAMAHA-MT07", 12000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053170675_e11b6950ca_b.jpg" },
                    { new Guid("9b6509e7-4ebd-4afb-a90b-252ac605a3fb"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1135), 3, 87654321, 150, "La YAMAHA-FZX cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 150cc, 4 tiempos.", 20, 12345678, "YAMAHA", "FZX", "YAMAHA-FZX", 5500000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052965558_26387c535b_b.jpg" },
                    { new Guid("a0f209f2-1d32-4eb9-8214-de8563cf04da"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1128), 3, 87654321, 200, "La ROUSER-NS200 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 200cc, 4 tiempos.", 0, 12345678, "ROUSER", "NS200", "ROUSER-NS200", 5400000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053169335_e52d3e9687_z.jpg" },
                    { new Guid("a2c791d9-44d1-40e6-95af-8da73df3770f"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1193), 6, 87654321, 750, "La HONDA-CB750HORNET cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 750cc, 4 tiempos.", 0, 12345678, "HONDA", "CB750HORNET", "HONDA-CB750HORNET", 19200000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052724331_545ff1889d_b.jpg" },
                    { new Guid("a2dab439-3850-4a18-963d-f3e8e9f26258"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1138), 3, 87654321, 125, "La YAMAHA-YBR125 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 125cc, 4 tiempos.", 0, 12345678, "YAMAHA", "YBR125", "YAMAHA-YBR125", 2800000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723056_b6d8b79cb6_b.jpg" },
                    { new Guid("a48ba5e4-eb5e-4839-8795-f199868f2f10"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1173), 5, 87654321, 300, "La KAWASAKI-VERSYS300 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 300cc, 4 tiempos.", 0, 12345678, "KAWASAKI", "VERSYS300", "KAWASAKI-VERSYS300", 15600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052967693_3df6137024_c.jpg" },
                    { new Guid("a4914630-66fa-4dd0-84fd-24b741dcd52b"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1205), 7, 87654321, 500, "La BENELLI-502CRUISER cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 500cc, 4 tiempos.", 0, 12345678, "BENELLI", "502CRUISER", "BENELLI-502CRUISER", 13825000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051852647_8492c767fb.jpg" },
                    { new Guid("a63fde75-e4ad-4465-b4f5-1258b17940db"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1133), 3, 87654321, 150, "YAMAHA-FZSFIV3 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 150cc, 4 tiempos.", 0, 12345678, "YAMAHA", "FZSFIV3", "YAMAHA-FZSFIV3", 5500000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052965548_283a4068e1_b.jpg" },
                    { new Guid("ac36db5a-53f9-4ca0-8e79-3943cedec4ce"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1178), 5, 87654321, 700, "La YAMAHA-NEWTENERE700 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 700cc, 4 tiempos.", 0, 12345678, "YAMAHA", "NEWTENERE700", "YAMAHA-NEWTENERE700", 13500000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051853202_a9d886ae64_b.jpg" },
                    { new Guid("b03a3901-1440-42e0-8b10-4ac345aebc70"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1095), 1, 87654321, 110, "La GILERA-SMASHFULL110 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 0, 12345678, "GILERA", "SMASHFULL110", "GILERA-SMASHFULL110", 1700000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723251_e0e1709bfc_c.jpg" },
                    { new Guid("b6f1d7ab-562d-4611-919c-3376fa404211"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1060), 1, 87654321, 110, "La GILERA-SMASHBASE110 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 0, 12345678, "GILERA", "SMASHBASE110", "GILERA-SMASHBASE110", 1400000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052965823_4aa76e5ffe_z.jpg" },
                    { new Guid("beea9436-dadd-47e7-9d19-567577f0d931"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1212), 7, 87654321, 250, "La BENELLI-LEONCINO250 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 250cc, 4 tiempos.", 0, 12345678, "BENELLI", "LEONCINO250", "BENELLI-LEONCINO250", 6450000m, 10, 20, 5, "https://live.staticflickr.com/65535/54051852642_87d6c905e7.jpg" },
                    { new Guid("c1547712-57cf-4c92-b137-e2099775d9a7"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1242), 8, 87654321, 155, "La YAMAHA-R15 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 155cc, 4 tiempos.", 0, 12345678, "YAMAHA", "R15", "YAMAHA-R15", 4000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053169865_11db74cf7e_w.jpg" },
                    { new Guid("c2ea9c88-ff8d-48ba-aecd-cbf9430528cb"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1107), 2, 87654321, 160, "La HONDA-PCX160 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 160cc, 4 tiempos.", 0, 12345678, "HONDA", "PCX160", "HONDA-PCX160", 7990000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053171235_4a4271923d_b.jpg" },
                    { new Guid("cd40a09b-7756-4add-9719-5da35389fa0f"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1120), 3, 87654321, 250, "La ROUSER-N250 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 250cc, 4 tiempos.", 0, 12345678, "ROUSER", "N250", "ROUSER-N250", 6000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053047864_2d248790ed_z.jpg" },
                    { new Guid("d311679b-b5c7-4a3d-973b-72f3eac71e5d"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1105), 2, 87654321, 150, "La HONDA-PCX150 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 150cc, 4 tiempos.", 0, 12345678, "HONDA", "PCX150", "HONDA-PCX150", 7990000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053049594_235673c725_b.jpg" },
                    { new Guid("d918460e-c76f-46d2-95a9-19eb5ab52696"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1154), 4, 87654321, 125, "La YAMAHA-YZ125X cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 125cc, 4 tiempos.", 0, 12345678, "YAMAHA", "YZ125X", "YAMAHA-YZ125X", 7000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052966293_9b427b3c13_w.jpg" },
                    { new Guid("dfe165d7-abb7-47ed-a076-fcdbc6f41fdb"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1237), 8, 87654321, 350, "La YAMAHA-R3A cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 350cc, 4 tiempos.", 10, 12345678, "YAMAHA", "R3A", "YAMAHA-R3A", 5820000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052966078_e4bd6a7781_w.jpg" },
                    { new Guid("e45e529d-53cd-4f3b-8fa0-f20ed56d875e"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1214), 7, 87654321, 150, "La ZANELLA-CCECATO60 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 150cc, 4 tiempos.", 0, 12345678, "ZANELLA", "CCECATO60", "ZANELLA-CCECATO60", 2890000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052967163_65d5be1736.jpg" },
                    { new Guid("e4a2d445-13f3-49a7-90ab-e140ccc64906"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1112), 2, 87654321, 125, "La YAMAHA-MADRID125 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 125cc, 4 tiempos.", 10, 12345678, "YAMAHA", "MADRID125", "YAMAHA-MADRID125", 6600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053049564_8a9b9bf027_b.jpg" },
                    { new Guid("e7e47878-c1c6-4e72-a5cd-c9e6ebe95013"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1196), 6, 87654321, 650, "La YAMAHA-MT03 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 650cc, 4 tiempos.", 15, 12345678, "YAMAHA", "MT03", "YAMAHA-MT03", 9600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053049019_b3ba8377a3_b.jpg" },
                    { new Guid("e942e059-2a2c-4e27-a04e-c4cf89d7b3f7"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1157), 4, 87654321, 250, "La YAMAHA-YZ250X cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 250cc, 4 tiempos.", 10, 12345678, "YAMAHA", "YZ250X", "YAMAHA-YZ250X", 7400000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052966318_1324fe79e7_w.jpg" },
                    { new Guid("e9ed2282-69c1-46d8-939f-295b339559c9"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1180), 5, 87654321, 1200, "La YAMAHA-XT1200 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 1200cc, 4 tiempos.", 0, 12345678, "YAMAHA", "XT1200", "YAMAHA-XT1200", 55000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053171435_6b3ecd17eb_b.jpg" },
                    { new Guid("f1d00837-88d2-4c4e-b52e-db567ccb22a8"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1057), 1, 87654321, 110, "La GILERA-SMASHAUTOMATICA110 es una motocicleta que combina un diseño deportivo y elegante, ideal para la ciudad y recorridos de media distancia. Equipado con un motor de 110cc, 4 tiempo.", 10, 12345678, "GILERA", "SMASHAUTOMATICA110", "GILERA-SMASHAUTOMATICA110", 1500000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052723316_28593e4b8e_c.jpg" },
                    { new Guid("f3a7dc48-ff3f-45e5-a28b-827a75771026"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1124), 3, 87654321, 160, "La ROUSER-NS125 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 160cc, 4 tiempos.", 0, 12345678, "ROUSER", "NS125", "ROUSER-NS125", 2600000m, 10, 20, 5, "https://live.staticflickr.com/65535/54052965583_75665ecab6_b.jpg" },
                    { new Guid("f74ad2db-50a6-4741-b04f-99186ccc48b3"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1149), 4, 87654321, 450, "La HONDA-CRF450RX cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 450cc, 4 tiempos.", 0, 12345678, "HONDA", "CRF450RX", "HONDA-CRF450RX", 24000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053170100_ed677c45db_z.jpg" },
                    { new Guid("fcd88600-16a3-4d9e-8d37-d388c3a3c6a9"), new DateTime(2024, 10, 22, 13, 10, 34, 418, DateTimeKind.Local).AddTicks(1110), 2, 87654321, 125, "La YAMAHA-FASCINO125 cuenta con un diseño deportivo, ideal para la ciudad y los recorridos de media distancia. Motor de 125cc, 4 tiempos.", 0, 12345678, "YAMAHA", "FASCINO125", "YAMAHA-FASCINO125", 4000000m, 10, 20, 5, "https://live.staticflickr.com/65535/54053171220_d996053cef_b.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moto_CategoryId",
                table: "Moto",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleMoto_BuyOrderbuyId",
                table: "SaleMoto",
                column: "BuyOrderbuyId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleMoto_Mot",
                table: "SaleMoto",
                column: "Mot");

            migrationBuilder.CreateIndex(
                name: "IX_SaleMoto_Sale",
                table: "SaleMoto",
                column: "Sale");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_ClientId",
                table: "Turns",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_Motoid",
                table: "Turns",
                column: "Motoid");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_SaleId",
                table: "Turns",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_TechnId",
                table: "Turns",
                column: "TechnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "SaleMoto");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "buys");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Moto");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Techns");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
