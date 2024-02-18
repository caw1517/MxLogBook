using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class LogItemSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93d93984-a20f-4925-9a02-702d8c005793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca2b9f76-9845-4f84-a627-b4950481ddd6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "398bf48e-7d76-4f42-bdc4-338706d1ff00", null, "User", "USER" },
                    { "5b4b0c3e-4221-4465-a70a-bf74133459a1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2024, 2, 15, 18, 50, 50, 995, DateTimeKind.Utc).AddTicks(4803), "66b55995-d23f-4b07-ab16-6425b63c603d" });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 18, 50, 50, 995, DateTimeKind.Utc).AddTicks(4718));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398bf48e-7d76-4f42-bdc4-338706d1ff00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b4b0c3e-4221-4465-a70a-bf74133459a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93d93984-a20f-4925-9a02-702d8c005793", null, "User", "USER" },
                    { "ca2b9f76-9845-4f84-a627-b4950481ddd6", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2024, 2, 15, 18, 50, 17, 966, DateTimeKind.Utc).AddTicks(4545), null });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 18, 50, 17, 966, DateTimeKind.Utc).AddTicks(4460));
        }
    }
}
