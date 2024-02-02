using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "Id", "CreatedOn", "Hours", "Make", "Mileage", "Model", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 2, 21, 18, 36, 413, DateTimeKind.Utc).AddTicks(8932), null, "Ford", 61000, "F-150", 2018 },
                    { 2, new DateTime(2024, 2, 2, 21, 18, 36, 413, DateTimeKind.Utc).AddTicks(8934), 20, "Honda", null, "CRF250R", 2023 }
                });

            migrationBuilder.InsertData(
                table: "log_items",
                columns: new[] { "Id", "Closed", "ClosedOn", "CreatedOn", "Discrepency", "VehicleId" },
                values: new object[] { 1, false, null, new DateTime(2024, 2, 2, 21, 18, 36, 413, DateTimeKind.Utc).AddTicks(9046), "Rear right hand tire has slow leak.", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
