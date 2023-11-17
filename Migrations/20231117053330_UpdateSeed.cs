using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projects.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 17, 5, 33, 30, 465, DateTimeKind.Utc).AddTicks(5685));

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Amenity", "Brand", "City", "Name", "Operator", "Street" },
                values: new object[] { 30092222, "fuel", null, "Nairobi", "OLA Energy", null, "Popo Rd/Mombasa Rd" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "Lat", "LocationType", "Lon", "TagId" },
                values: new object[] { 30092222, -1.3195401, "node", 36.8371639, 30092222 });

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "Id", "CreatedAt", "Diesel", "FuelPriceId", "Kerosene", "Petrol", "StationId" },
                values: new object[] { 2, new DateTime(2023, 11, 17, 5, 33, 30, 465, DateTimeKind.Utc).AddTicks(5690), 2020.0, 30092222, 2200.0, 2020.0, 30092222 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 30092222);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 30092222);

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 17, 0, 31, 30, 422, DateTimeKind.Utc).AddTicks(7640));
        }
    }
}
