using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineCompany.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    id_passenger = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fullname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passport = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    registration = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ticket_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seat_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    baggage_weight = table.Column<double>(type: "double", nullable: false),
                    id_flight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.id_passenger);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "planes",
                columns: table => new
                {
                    id_plane = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    model = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    load_capacity = table.Column<double>(type: "double", nullable: false),
                    efficiency = table.Column<double>(type: "double", nullable: false),
                    passenger_max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planes", x => x.id_plane);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "airflights",
                columns: table => new
                {
                    id_flight = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    departure_point = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    arrival_point = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    departure = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    arrive = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    flying_time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    id_plane = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airflights", x => x.id_flight);
                    table.ForeignKey(
                        name: "FK_airflights_planes_id_plane",
                        column: x => x.id_plane,
                        principalTable: "planes",
                        principalColumn: "id_plane",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "passengers",
                columns: new[] { "id_passenger", "baggage_weight", "fullname", "id_flight", "passport", "registration", "seat_number", "ticket_number" },
                values: new object[,]
                {
                    { 1, 0.0, "Belyackova Veronicka Sergeevna", 4, "3678678903", true, "A18", "35999" },
                    { 2, 8.5999999999999996, "Nenashev Ivan Nickolayevich", 0, "5678359284", true, "E6", "78112" },
                    { 3, 2.7000000000000002, "Zamotohina Maria Andreevna", 4, "2875909090", true, "E7", "97966" },
                    { 4, 7.5, "Chumackov Michail Vladimirovich", 0, "837968585", true, "D15", "80318" },
                    { 5, 8.8000000000000007, "Zhuckov Semyon Viktorovich", 5, "7492748492", true, "E8", "46692" },
                    { 6, 9.5, "Chumackov Michail Vladimirovich", 3, "837968585", true, "F5", "12681" },
                    { 7, 7.0, "Zamotohina Maria Andreevna", 0, "2875909090", true, "A13", "18614" },
                    { 8, 6.5999999999999996, "Belyackova Veronicka Sergeevna", 6, "3678678903", true, "E11", "52424" },
                    { 9, 0.0, "Nenashev Ivan Nickolayevich", 4, "5678359284", true, "D13", "71384" },
                    { 10, 4.0, "Nenashev Ivan Nickolayevich", 6, "5678359284", true, "E16", "57713" },
                    { 11, 2.2999999999999998, "Belyackova Veronicka Sergeevna", 8, "3678678903", true, "A8", "76112" },
                    { 12, 7.2000000000000002, "Nenashev Ivan Nickolayevich", 5, "5678359284", true, "C16", "31952" },
                    { 13, 8.4000000000000004, "Zemlyanov Vladimir Borisovich", 6, "1234567890", true, "A13", "30020" },
                    { 14, 1.3, "Belyackova Veronicka Sergeevna", 2, "3678678903", true, "E17", "15824" },
                    { 15, 2.2000000000000002, "Zemlyanov Vladimir Borisovich", 7, "1234567890", true, "C17", "96981" },
                    { 16, 8.0999999999999996, "Zemlyanov Vladimir Borisovich", 1, "1234567890", true, "D8", "36824" },
                    { 17, 7.2999999999999998, "Zemlyanov Vladimir Borisovich", 8, "1234567890", true, "C6", "45619" },
                    { 18, 5.7999999999999998, "Nenashev Ivan Nickolayevich", 2, "5678359284", true, "A14", "44659" },
                    { 19, 7.0, "Zemlyanov Vladimir Borisovich", 2, "1234567890", true, "C17", "58068" },
                    { 20, 3.1000000000000001, "Zamotohina Maria Andreevna", 8, "2875909090", true, "C12", "67255" }
                });

            migrationBuilder.InsertData(
                table: "planes",
                columns: new[] { "id_plane", "efficiency", "load_capacity", "model", "passenger_max" },
                values: new object[,]
                {
                    { 1, 334.0, 4.0, "NG Model 15001", 210 },
                    { 2, 367.0, 4.5, "NG Model 20103", 210 },
                    { 3, 334.0, 3.5, "Panda 202015", 165 },
                    { 4, 949.0, 12.0, "Panda 202208", 210 },
                    { 5, 949.0, 2.7000000000000002, "NG Model 22009", 170 },
                    { 6, 329.0, 2.7000000000000002, "Herpa 515726", 165 }
                });

            migrationBuilder.InsertData(
                table: "airflights",
                columns: new[] { "id_flight", "arrival_point", "arrive", "code_number", "departure", "departure_point", "flying_time", "id_plane" },
                values: new object[,]
                {
                    { 1, "Dublin", new DateTime(2024, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "1000", new DateTime(2024, 3, 23, 16, 39, 0, 0, DateTimeKind.Unspecified), "Tokio", new TimeOnly(4, 21, 0), 1 },
                    { 2, "Amsterdam", new DateTime(2024, 9, 2, 1, 39, 0, 0, DateTimeKind.Unspecified), "2000", new DateTime(2024, 9, 1, 16, 35, 0, 0, DateTimeKind.Unspecified), "Rome", new TimeOnly(9, 4, 0), 4 },
                    { 3, "Vienna", new DateTime(2024, 11, 24, 12, 1, 0, 0, DateTimeKind.Unspecified), "3000", new DateTime(2024, 11, 23, 23, 50, 0, 0, DateTimeKind.Unspecified), "Rome", new TimeOnly(12, 11, 0), 4 },
                    { 4, "St. Petersburg", new DateTime(2024, 6, 26, 22, 39, 0, 0, DateTimeKind.Unspecified), "4000", new DateTime(2024, 6, 26, 17, 17, 0, 0, DateTimeKind.Unspecified), "London", new TimeOnly(5, 22, 0), 5 },
                    { 5, "Amsterdam", new DateTime(2024, 9, 26, 2, 21, 0, 0, DateTimeKind.Unspecified), "5000", new DateTime(2024, 9, 25, 23, 1, 0, 0, DateTimeKind.Unspecified), "Moscow", new TimeOnly(3, 20, 0), 3 },
                    { 6, "Dublin", new DateTime(2024, 12, 19, 14, 30, 0, 0, DateTimeKind.Unspecified), "6000", new DateTime(2024, 12, 19, 4, 20, 0, 0, DateTimeKind.Unspecified), "Samara", new TimeOnly(10, 10, 0), 4 },
                    { 7, "Dublin", new DateTime(2024, 1, 29, 3, 46, 0, 0, DateTimeKind.Unspecified), "7000", new DateTime(2024, 1, 28, 19, 20, 0, 0, DateTimeKind.Unspecified), "Rome", new TimeOnly(8, 26, 0), 1 },
                    { 8, "Washington", new DateTime(2024, 6, 3, 19, 11, 0, 0, DateTimeKind.Unspecified), "8000", new DateTime(2024, 6, 3, 15, 43, 0, 0, DateTimeKind.Unspecified), "Tokio", new TimeOnly(3, 28, 0), 4 },
                    { 9, "Vienna", new DateTime(2024, 7, 14, 0, 20, 0, 0, DateTimeKind.Unspecified), "9000", new DateTime(2024, 7, 13, 12, 23, 0, 0, DateTimeKind.Unspecified), "Moscow", new TimeOnly(11, 57, 0), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_airflights_id_plane",
                table: "airflights",
                column: "id_plane");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airflights");

            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "planes");
        }
    }
}
