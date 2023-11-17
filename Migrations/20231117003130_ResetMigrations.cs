using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projects.Migrations
{
    /// <inheritdoc />
    public partial class ResetMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Amenity = table.Column<string>(type: "TEXT", nullable: true),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Operator = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationType = table.Column<string>(type: "TEXT", nullable: true),
                    Lat = table.Column<double>(type: "REAL", nullable: false),
                    Lon = table.Column<double>(type: "REAL", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_Stations_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuelPriceId = table.Column<int>(type: "INTEGER", nullable: false),
                    StationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Diesel = table.Column<double>(type: "REAL", nullable: true),
                    Kerosene = table.Column<double>(type: "REAL", nullable: true),
                    Petrol = table.Column<double>(type: "REAL", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelPrices_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId");
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Amenity", "Brand", "City", "Name", "Operator", "Street" },
                values: new object[] { 30092081, "fuel", "Total", "Nairobi", "Total", "Total", "Ngong Road" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "Lat", "LocationType", "Lon", "TagId" },
                values: new object[] { 30092081, -1.2990005, "node", 36.759717299999998, 30092081 });

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "Id", "CreatedAt", "Diesel", "FuelPriceId", "Kerosene", "Petrol", "StationId" },
                values: new object[] { 1, new DateTime(2023, 11, 17, 0, 31, 30, 422, DateTimeKind.Utc).AddTicks(7640), 200.0, 30092081, 200.0, 200.0, 30092081 });

            migrationBuilder.CreateIndex(
                name: "IX_FuelPrices_StationId",
                table: "FuelPrices",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_TagId",
                table: "Stations",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelPrices");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
