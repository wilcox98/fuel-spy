using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projects.Migrations
{
    /// <inheritdoc />
    public partial class AddFuelPricesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelPrices",
                columns: table => new
                {
                    FuelPriceId = table.Column<string>(type: "TEXT", nullable: false),
                    StationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Diesel = table.Column<double>(type: "REAL", nullable: true),
                    Kerosene = table.Column<double>(type: "REAL", nullable: true),
                    Petrol = table.Column<double>(type: "REAL", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelPrices", x => x.FuelPriceId);
                });

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "FuelPriceId", "CreatedAt", "Diesel", "Kerosene", "Petrol", "StationId" },
                values: new object[] { "d0f6065b-e62b-4533-b81d-71fb15dd36f7", new DateTime(2023, 11, 16, 5, 1, 20, 175, DateTimeKind.Utc).AddTicks(3068), 200.0, 200.0, 200.0, 30092081 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelPrices");
        }
    }
}
