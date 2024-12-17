using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepairPK.Migrations
{
    /// <inheritdoc />
    public partial class InitStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hardwares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerialNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hardwares_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HardwareId = table.Column<int>(type: "int", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: true),
                    CountPart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Hardwares_HardwareId",
                        column: x => x.HardwareId,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John Doe", "1234567890" },
                    { 2, "Jane Smith", "0987654321" },
                    { 3, "Michael Johnson", "1122334455" },
                    { 4, "Emily Davis", "5566778899" },
                    { 5, "William Brown", "6677889900" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Name", "Price", "QuantityAvailable" },
                values: new object[,]
                {
                    { 1, "SSD 512GB", 120.50m, 10 },
                    { 2, "Power Supply 600W", 75.00m, 5 },
                    { 3, "RAM 16GB DDR4", 89.99m, 20 },
                    { 4, "CPU Intel i5-12400F", 199.99m, 7 },
                    { 5, "GPU Nvidia RTX 3060", 399.99m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "Content", "CustomerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Консультация по ремонту материнской платы", 1 },
                    { 2, new DateTime(2024, 6, 16, 11, 30, 0, 0, DateTimeKind.Unspecified), "Диагностика видеокарты", 2 },
                    { 3, new DateTime(2024, 6, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Замена блока питания", 3 },
                    { 4, new DateTime(2024, 6, 18, 9, 30, 0, 0, DateTimeKind.Unspecified), "Чистка системы охлаждения", 4 },
                    { 5, new DateTime(2024, 6, 19, 15, 0, 0, 0, DateTimeKind.Unspecified), "Установка SSD диска", 5 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Comment", "CustomerId", "Date", "Rating" },
                values: new object[,]
                {
                    { 1, "Отличная работа! Быстро и качественно.", 1, new DateTime(2024, 12, 17, 7, 58, 24, 585, DateTimeKind.Utc).AddTicks(3408), (short)5 },
                    { 2, "Хорошая диагностика, но могли бы сделать скидку.", 2, new DateTime(2024, 12, 17, 7, 58, 24, 585, DateTimeKind.Utc).AddTicks(3410), (short)4 },
                    { 3, "Понравилось обслуживание, рекомендую!", 3, new DateTime(2024, 12, 17, 7, 58, 24, 585, DateTimeKind.Utc).AddTicks(3411), (short)5 },
                    { 4, "Работу сделали, но сроки немного затянули.", 4, new DateTime(2024, 12, 17, 7, 58, 24, 585, DateTimeKind.Utc).AddTicks(3412), (short)3 },
                    { 5, "Супер! Всё работает как надо.", 5, new DateTime(2024, 12, 17, 7, 58, 24, 585, DateTimeKind.Utc).AddTicks(3413), (short)5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompletionDate", "CustomerId", "PaymentStatus", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 250.00m },
                    { 2, new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 180.00m },
                    { 3, new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 300.00m },
                    { 4, new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 90.00m },
                    { 5, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, 400.00m }
                });

            migrationBuilder.InsertData(
                table: "Hardwares",
                columns: new[] { "Id", "Manufacturer", "Model", "OrderId", "SerialNumber", "Type" },
                values: new object[,]
                {
                    { 1, "ASUS", "PRIME B550M", 1, "SN123456789", "Motherboard" },
                    { 2, "NVIDIA", "RTX 3080", 2, "SN987654321", "Graphics Card" },
                    { 3, "Corsair", "RM750x", 3, "SN112233445", "Power Supply" },
                    { 4, "Intel", "i7-11700K", 4, "SN998877665", "CPU" },
                    { 5, "Samsung", "970 EVO Plus 1TB", 5, "SN554433221", "SSD" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "Cost", "CountPart", "Description", "HardwareId", "PartId", "RepairDate" },
                values: new object[,]
                {
                    { 1, 120.00m, 4, "Замена конденсаторов на материнской плате", 1, 1, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 200.00m, 1, "Пайка чипа видеокарты", 2, 2, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 150.00m, 1, "Замена блока питания на новый", 3, 3, new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 90.00m, 2, "Установка системы охлаждения для процессора", 4, 4, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 80.00m, 1, "Установка SSD и перенос данных", 5, 5, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hardwares_OrderId",
                table: "Hardwares",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_HardwareId",
                table: "Repairs",
                column: "HardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_PartId",
                table: "Repairs",
                column: "PartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Hardwares");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
